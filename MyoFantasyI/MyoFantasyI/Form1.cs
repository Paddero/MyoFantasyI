using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyoSharp.Communication;
using MyoSharp.Device;
using MyoSharp.Exceptions;
using MyoSharp.Poses;
using System.Media;

namespace MyoFantasyI
{
    public partial class Form1 : Form
    {
        #region Variables
        //channel and hub for the myo
        private readonly IChannel _channel;
        private readonly IHub _hub;

        //Creating rnd and timer 
        Random rnd = new Random();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        //Saving sound wav files so I can use them later when needed.
        SoundPlayer swordSlash = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\sword2.wav");
        SoundPlayer playerHeal = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\healing2.wav");
        SoundPlayer playerRageAbility = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\swordRage.wav");
        SoundPlayer enemyAttackSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\enemyAttack.wav");
        SoundPlayer enemyHealingSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\enemyHealing.wav");
        SoundPlayer enemyRageSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\enemyRage.wav");
        SoundPlayer enemyWonSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\enemyWonSound.wav");
        SoundPlayer playerWonSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\youWin.wav");
        SoundPlayer playerBuffSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\buff.wav");

        //Game variables
        private Boolean isGameStarted = false;
        private Boolean isPlayerMove;
        private Boolean isEnemyMove;      
        private Boolean isGameOver = false;
        private int enemyHealth;
        private int enemyCurrHealth;
        private int enemyAttack;
        private int enemyMagic;
        private int enemyRage;
        private string enemyRageStatus;
        private int playerHealth;
        private int playerCurrHealth;
        private int playerAttack;
        private int playerMagic;
        private int playerRage;
        private string playerRageStatus;

        // Variable to check who won, 1 for the enemy, 2 for the user.
        private int whoWon = 0;

        //Time left variable, refreshing it every time someone makes a move.
        private int timeLeft = 30;
        #endregion

        public Form1()
        {
            InitializeComponent();

            // get set up to listen for Myo events
            _channel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create()));

            _hub = Hub.Create(_channel);
            _hub.MyoConnected += _hub_MyoConnected;
            _hub.MyoDisconnected += _hub_MyoDisconnected;
            
            //Starting the timer when the game starts
            //and setting the time internal to 2 sec ticks.
            timer.Interval = 2000; 
            timer.Tick += timer_Tick;
            timer.Start();          
        }

        protected override void OnLoad(EventArgs e)
        {           
            base.OnLoad(e);
            //Maximizing the window when the game starts
            WindowState = FormWindowState.Maximized; 
          
            // start listening for Myo data
            _channel.StartListening();          
        }

        protected override void OnClosed(EventArgs e)
        {
            //Disposing channel and hub when closing the game
            _channel.Dispose();
            _hub.Dispose();

            base.OnClosed(e);
        }

        #region MyoArmbandEvents 
        private void _hub_MyoDisconnected(object sender, MyoEventArgs e)
        {
            string status = "Myo has diconnected";
         
            if (isConnectedLbl.InvokeRequired)
            {
                isConnectedLbl.Invoke(new MethodInvoker(delegate { isConnectedLbl.Text = status; }));
            }
        }

        private void _hub_MyoConnected(object sender, MyoEventArgs e)
        {
            //When myo connects, unlock myo so the user can interact with it at all times.
            string status = "Myo is Connected";
            
            e.Myo.Unlock(UnlockType.Hold);

            //Create sequence for the rage ability (Fist -> Fingerspread).
            var sequence = PoseSequence.Create(
                        e.Myo,
                        Pose.Fist,
                        Pose.FingersSpread);
            sequence.PoseSequenceCompleted += sequence_PoseSequenceCompleted;

            //Whenever pose is changed, go to poseChanged event.
            e.Myo.PoseChanged += Myo_PoseChanged;

            //Whenever orientation is changed, go to this event.
            e.Myo.OrientationDataAcquired += Myo_OrientationDataAcquired;

            if (isConnectedLbl.InvokeRequired)
            {
                isConnectedLbl.Invoke(new MethodInvoker(delegate { isConnectedLbl.Text = status; }));
            }           
        }

        private void Myo_OrientationDataAcquired(object sender, OrientationDataEventArgs e)
        {
            const float PI = (float)System.Math.PI;

            // convert the values to a 0-9 scale (for easier digestion/understanding)
            var roll = (int)((e.Roll + PI) / (PI * 2.0f) * 10);
            var pitch = (int)((e.Pitch + PI) / (PI * 2.0f) * 10);
            var yaw = (int)((e.Yaw + PI) / (PI * 2.0f) * 10);

            //Check if the user has his arm down, as well as checking if the game has started and if its player move. 
            if(roll <= 3 && pitch <= 3 && isPlayerMove == true && isGameStarted == true)
            {
                //Making sure player has enough rage to buff his ability
                if (playerRage >= 1)
                {
                    bufflbl.Invoke(new MethodInvoker(delegate { bufflbl.ForeColor = System.Drawing.Color.DeepSkyBlue; }));
                    playerBuffSound.Play();
                    updateBuffMove();
                    System.Threading.Thread.Sleep(500);
                    bufflbl.Invoke(new MethodInvoker(delegate { bufflbl.ForeColor = System.Drawing.Color.OrangeRed; }));
                }
                else
                {
                    statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You do not have enough rage to Buff!"; }));
                }
            }
        }

        private void sequence_PoseSequenceCompleted(object sender, PoseSequenceEventArgs e)
        {
            //Making sure that the game has started, it's player's move and has atleast 5 rage.
            //IF so, call rage ability, play sound and vibrate.
            if (isGameStarted == true && isPlayerMove == true && playerRage >= 5)
            {
                rageAbilitylbl.Invoke(new MethodInvoker(delegate { rageAbilitylbl.ForeColor = System.Drawing.Color.DeepSkyBlue; }));
                updateRageAbilityMove();
                playerRageAbility.Play();
                e.Myo.Vibrate(VibrationType.Medium);
                System.Threading.Thread.Sleep(500);
                attacklbl.Invoke(new MethodInvoker(delegate { attacklbl.ForeColor = System.Drawing.Color.OrangeRed; }));

            }
            else if (isGameStarted == true && isPlayerMove == true && playerRage < 5)
            {
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You do not have enough rage to use Rage Ability!"; }));
            }          
        }

        private void Myo_PoseChanged(object sender, PoseEventArgs e)
        {
            //This event checks all the poses

            //If user makes fist, check to see if game has started, if not start the game and vibrate
            if (e.Myo.Pose == Pose.Fist)
            {
                if(isGameStarted == false)
                {
                    startGame();
                    e.Myo.Vibrate(VibrationType.Medium);
                    timeLeft = 30;
                    isGameStarted = true;
                    isGameOver = false;
                }                  
            }

            //If user makes waveIn gesture, it is players move, game has started and game isn't over, call attack method and play sound
            if (e.Myo.Pose == Pose.WaveIn)
            {
                if (isPlayerMove == true && isGameStarted == true && isGameOver == false)
                {
                    attacklbl.Invoke(new MethodInvoker(delegate { attacklbl.ForeColor = System.Drawing.Color.DeepSkyBlue; }));
                    swordSlash.Play();
                    updateAttackMove();
                    System.Threading.Thread.Sleep(500);
                    attacklbl.Invoke(new MethodInvoker(delegate { attacklbl.ForeColor = System.Drawing.Color.OrangeRed; }));
                }
            }

            //If user makes waveOut gesture, it is players move, game has started and game isn't over, call heal method and play sound
            if (e.Myo.Pose == Pose.WaveOut)
            {
                if (isPlayerMove == true && isGameStarted == true && playerRage >= 1 && isGameOver == false)
                {
                    heallbl.Invoke(new MethodInvoker(delegate { heallbl.ForeColor = System.Drawing.Color.DeepSkyBlue; }));
                    playerHeal.Play();
                    updateHealMove();
                    System.Threading.Thread.Sleep(500);
                    heallbl.Invoke(new MethodInvoker(delegate { heallbl.ForeColor = System.Drawing.Color.OrangeRed; }));
                }
                else if(isPlayerMove == true && isGameStarted == true)
                {
                    statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You do not have enough rage to heal yourself."; }));
                }
            }
        }
        #endregion

        #region timerTicksEvents
        void timer_Tick(object sender, EventArgs e)
        {
            //First check if game is over, if so, end the game.
            if(isGameOver == true)
            {
                gameOver();           
            }
            //Otherwise do this
            else
            {
                //-2 timeleft as it ticks every 2 seconds.
                timeLeft -= 2;
                timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Text = ""; }));

                //If timeleft is 10 or below but greater than 0, show message that user has only 10 seconds left.
                if (timeLeft <= 10 && timeLeft > 0)
                {
                    timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Text = "You only have " + timeLeft.ToString() + " seconds left!"; }));
                }
                //If time is 0 or less, end player move.
                else if (timeLeft <= 0)
                {
                    timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Text = ""; }));
                    if (isPlayerMove == true)
                    {
                        timeLeft = 30;
                        statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You missed your move!\n\tEnemies move!"; }));
                        isPlayerMove = false;
                        isEnemyMove = true;
                        changeLights();
                    }
                }

                //If game has started
                if (isGameStarted == true)
                {
                    //Once timer ticked once (30 - 2 = 28) and it is not enemies move, enable player to make any move by setting isPlayerMove to true
                    if (timeLeft <= 28 && isEnemyMove == false)
                    {
                        isPlayerMove = true;
                        changeLights();
                    }
                    else if (isEnemyMove == true)
                    {
                        //Once timer ticks 3 times (30 - (3x2) = 24), make enemies move. I made it this was so the game doesn't go too fast.
                        if (timeLeft <= 24)
                        {
                            enemiesMove();
                        }
                    }
                }
            }            
        }
        #endregion

        #region PlayersAbilities 
        private void updateAttackMove()
        {
            //Generate random number between half of the user attack power to the max of the user attack power
            int attackStrength = rnd.Next((playerAttack/2), playerAttack);
            //Take away enemies health
            enemyCurrHealth -= attackStrength;

            //If enemy is at below or at 0 health it means the user has won.
            if (enemyCurrHealth <= 0)
            {
                //Updating variables needed to end the game and updating status before gameOver is called. (It is called after next timerTick).
                whoWon = 2;
                isGameOver = true;
                enemyCurrHealth = 0;
                enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You dealt " + attackStrength.ToString() + " damage to the enemy!\n\tEnemy defeated!"; }));
            }
            else
            {
                //If game isn't over, add enemies rage
                if (enemyRage == 10)
                {
                    enemyRage = 10;
                }
                else if (enemyRage <= 8)
                {
                    enemyRage += 2;
                }
                else
                {
                    enemyRage += 1;
                }

                //Updating the user interface and set time and who's move it is.
                enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
                enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You dealt " + attackStrength.ToString() + " damage to the enemy!\n\tEnemies move!"; }));
                isPlayerMove = false;
                isEnemyMove = true;
                changeLights();
                timeLeft = 30;
            }           
        }

        private void updateHealMove()
        {
            //Generate random number between half of the user healing power to the max of the user healing power
            int healAmount = rnd.Next((playerMagic / 2), playerMagic);
            //Add that to the user health
            playerCurrHealth += healAmount;
            //1 rage is taken when healed
            playerRage -= 1;

            //If current health is higher than max health, set it back to max health.
            if (playerCurrHealth > playerHealth)
                playerCurrHealth = playerHealth;

            //Updating the user interface and set time and who's move it is.
            playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You healed yourself by " + healAmount.ToString() + " hit points!\n\tEnemies move!"; }));
            checkIfPlayerCanUseRageAbility();
            isPlayerMove = false;
            isEnemyMove = true;
            changeLights();
            timeLeft = 30;
        }

        private void updateRageAbilityMove()
        {
            //Generate random number between user attack power+50 to the users attack power *2 as this is a rage (special) ability.
            //Generate random number between user healing power to the users healing power *2 as this is a rage (special) ability.
            int attackStrength = rnd.Next((playerAttack + 50), (playerAttack * 2));
            int healAmount = rnd.Next(playerMagic, (playerMagic * 2));

            //Hitting the enemy and adding health to the user
            enemyCurrHealth -= attackStrength;
            playerCurrHealth += healAmount;

            //If enemy is at below or at 0 health it means the user has won.
            if (enemyCurrHealth <= 0)
            {
                //Updating variables needed to end the game and updating status before gameOver is called. (It is called after next timerTick).
                whoWon = 2;
                isGameOver = true;
                enemyCurrHealth = 0;
                enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You dealt " + attackStrength.ToString() + " damage to the enemy!\n\tEnemy defeated!"; }));
            }
            else
            {
                //5 rage is taken when rage ability is used.
                playerRage -= 5;

                //If current health is higher than max health, set it back to max health.
                if (playerCurrHealth > playerHealth)
                    playerCurrHealth = playerHealth;

                //If game isn't over, add enemies rage
                if (enemyRage == 10)
                {
                    enemyRage = 10;
                }
                else if (enemyRage <= 8)
                {
                    enemyRage += 2;
                }
                else
                {
                    enemyRage += 1;
                }

                //Updating the user interface and set time and who's move it is. Also checking if player can still use rage ability. (Might have been used at 10 rage)
                enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
                playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
                playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
                enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You dealt " + attackStrength.ToString() + " damage to enemy, \nand healed yourself by " + healAmount.ToString() + " hit points!\n\tEnemies move!"; }));
                checkIfPlayerCanUseRageAbility();
                isPlayerMove = false;
                isEnemyMove = true;
                changeLights();
                timeLeft = 30;
            }     
        }

        private void updateBuffMove()
        {
            //Adding 15 to players attack power, removing 1 rage, updating user interface and setting time and who's move it is.
            playerAttack += 15;
            playerRage -= 1;
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
            playerAtklbl.Invoke(new MethodInvoker(delegate { playerAtklbl.Text = "Max. Attack : " + playerAttack.ToString(); }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You buffed your attack by 15 damage!\n\tEnemies move!"; }));
            isPlayerMove = false;
            isEnemyMove = true;
            changeLights();
            timeLeft = 30;
        }
#endregion

        #region EnemyAIandAbilities
        private void enemiesMove()
        {
            //Variable to check what move is generated
            int enemiesMove;

            if(enemyRage >= 5)
            {
                //If rage is greater or equal to 5, can use any ability. Having max number to 3, I found it to generate max number very rarely so I generate from 1 to 4.
                enemiesMove = rnd.Next(1, 4);
            }
            else if(enemyRage < 5 && enemyRage > 3)
            {
                //If rage is greater than 3 but less than 5, can use heal or attack.
                enemiesMove = rnd.Next(1,2);
            }
            else if(enemyRage == 10)
            {
                //If enemy has max Rage use Rage ability.
                enemiesMove = 3;
            }
            else
            {
                //Only ability to use is attack
                enemiesMove = 1;
            }

            //Based on what move is generated, call it and play sound for each event.
            switch (enemiesMove)
            {
                case 1:
                    enemyAttackSound.Play();
                    enemyAttackMove();              
                    break;
                case 2:
                    enemyHealingSound.Play();
                    enemyHealMove();
                    break;
                default:
                    enemyRageSound.Play();
                    enemyRageAbility();
                    break;
            }
        }

        private void enemyAttackMove()
        {
            //Generate random number between 1/3 of the enemy attack power to the max of the enemy attack power
            int attackStrength = rnd.Next((enemyAttack / 3), enemyAttack);
            //Take that away from user health
            playerCurrHealth -= attackStrength;

            //Check if users health is at or below 0 health
            if (playerCurrHealth <= 0)
            {
                //Updating variables needed to end the game and updating status before gameOver is called. (It is called after next timerTick).
                whoWon = 1;
                playerCurrHealth = 0;
                isGameOver = true;
                playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy dealt " + attackStrength.ToString() + " damage to you!\n\tYou died!"; }));
            }
            else
            {
                //Else update players rage
                if (playerRage == 10)
                {
                    playerRage = 10;
                }
                else
                {
                    playerRage += 1;
                }

                //Updating the user interface, set time and who's move it is. Also checking if user can use rage ability
                playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
                playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy dealt " + attackStrength.ToString() + " damage to you!\n\tIt's your move!"; }));
                checkIfPlayerCanUseRageAbility();
                isEnemyMove = false;
                changeLights();
                timeLeft = 30;
            }            
        }

        private void enemyHealMove()
        {
            //Generate random number between 1/3 of the enemy healing power to the max of the enemy healing power
            int healAmount = rnd.Next((enemyMagic / 3), enemyMagic);
            //Add that to the enemy health
            enemyCurrHealth += healAmount;
            //3 rage is taken when healed
            enemyRage -= 3;

            //If enemy current health is greater than max health, set it back to max.
            if (enemyCurrHealth > enemyHealth)
                enemyCurrHealth = enemyHealth;

            //Updating the user interface, set time and who's move it is.
            enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
            enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy healed himself by " + healAmount.ToString() + " hit points!\n\tIt's your move!"; }));
            isEnemyMove = false;
            changeLights();
            timeLeft = 30;
        }

        private void enemyRageAbility()
        {
            //Generate random number between enemy attack power +10 to the enemy attack power *2
            //Generate random number the enemy healing power to the enemy healing power +50
            int attackStrength = rnd.Next((enemyAttack+10), (enemyAttack * 2));
            int healAmount = rnd.Next(enemyMagic, (enemyMagic+50));

            //Add that to enemy health and take away from user health
            playerCurrHealth -= attackStrength;
            enemyCurrHealth += healAmount;

            //Check if users health is at or below 0 health
            if(playerCurrHealth <= 0)
            {
                //Updating variables needed to end the game and updating status before gameOver is called. (It is called after next timerTick).
                whoWon = 1;
                playerCurrHealth = 0;
                isGameOver = true;
                playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy dealt " + attackStrength.ToString() + " damage to you!\n\tYou died!"; }));
            }
            else
            {
                //Using rage ability resets it's rage back to 0.
                enemyRage = 0;

                //If enemy current health is greater than max health, set it back to max.
                if (enemyCurrHealth > enemyHealth)
                    enemyCurrHealth = enemyHealth;

                //Add players rage
                if (playerRage == 10)
                {
                    playerRage = 10;
                }
                else if (playerRage <= 8)
                {
                    playerRage += 2;
                }
                else
                {
                    playerRage += 1;
                }

                //Updating the user interface, set time and who's move it is. Also checking if user can use rage ability
                enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
                playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
                playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
                enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy dealt " + attackStrength.ToString() + " damage to you,\nand healed himself by " + healAmount.ToString() + " hit points!\n\tIt's your move!"; }));
                checkIfPlayerCanUseRageAbility();
                isEnemyMove = false;
                changeLights();
                timeLeft = 30;
            }                      
        }

        private void generateRandomEnemy()
        {
            //Generate random enemy between 1 and 3. Setting max to 3 I found it very rarely to generate max number so I set it so 4.
            int enemy = rnd.Next(1, 4);

            //Call method based on what enemy has been chosen.
            switch (enemy)
            {
                case 1:
                    enemy1();
                    break;
                case 2:
                    enemy2();
                    break;
                default:
                    enemy3();
                    break;
            }
        }

        private void enemy1()
        {
            //Setting enemy 1
            enemyAttack = 100;
            enemyHealth = 1500;
            enemyCurrHealth = enemyHealth;
            enemyMagic = 100;
            enemyRage = 0;
            enemyRageStatus = "Low";
            enemyPic.Invoke(new MethodInvoker(delegate
            {
                enemyPic.Image = Image.FromFile("C:/Users/Paddy/Desktop/MyoApp/MyoFantasyI/MyoFantasyI/Images/enemy1.png");
            }));
        }

        private void enemy2()
        {
            //Setting enemy 2
            enemyAttack = 200;
            enemyHealth = 750;
            enemyCurrHealth = enemyHealth;
            enemyMagic = 50;
            enemyRage = 0;
            enemyRageStatus = "High";
            enemyPic.Invoke(new MethodInvoker(delegate
            {
                enemyPic.Image = Image.FromFile("C:/Users/Paddy/Desktop/MyoApp/MyoFantasyI/MyoFantasyI/Images/enemy2.jpg");
            }));
        }

        private void enemy3()
        {
            //Setting enemy 3
            enemyAttack = 175;
            enemyHealth = 2250;
            enemyCurrHealth = enemyHealth;
            enemyMagic = 25;
            enemyRage = 0;
            enemyRageStatus = "Medium";
            enemyPic.Invoke(new MethodInvoker(delegate
            {
                enemyPic.Image = Image.FromFile("C:/Users/Paddy/Desktop/MyoApp/MyoFantasyI/MyoFantasyI/Images/enemy3.jpg");
            }));
        }
        #endregion

        #region gameMethods
        private void startGame()
        {
            //Starting the game, setting player and changing the display of the screen.
            setPlayer();
            changeDisplay();            
        }

        private void setPlayer()
        {
            //Setting player variables
            playerHealth = 1000;
            playerCurrHealth = playerHealth;
            playerAttack = 125;
            playerMagic = 175;
            playerRage = 0;
            playerRageStatus = "Medium";
            isPlayerMove = true;
        }

        private void gameOver()
        {
            //Updating user interface and variables to make sure the game has ended.
            isPlayerMove = false;
            isEnemyMove = false;
            isGameOver = true;
            isGameStarted = false;
            changeLights();
            enemyPic.Invoke(new MethodInvoker(delegate { enemyPic.Visible = false; }));
            characterPic.Invoke(new MethodInvoker(delegate { characterPic.Visible = false; }));
            playerHP.Invoke(new MethodInvoker(delegate { playerHP.Visible = false; }));
            enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Visible = false; }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Visible = false; }));
            enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Visible = false; }));
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Visible = false; }));
            timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Visible = false; }));
            attacklbl.Invoke(new MethodInvoker(delegate { attacklbl.Visible = false; }));
            heallbl.Invoke(new MethodInvoker(delegate { heallbl.Visible = false; }));
            bufflbl.Invoke(new MethodInvoker(delegate { bufflbl.Visible = false; }));
            playerAtklbl.Invoke(new MethodInvoker(delegate { playerAtklbl.Visible = false; }));
            playerMagiclbl.Invoke(new MethodInvoker(delegate { playerMagiclbl.Visible = false; }));
            playerRageStatuslbl.Invoke(new MethodInvoker(delegate { playerRageStatuslbl.Visible = false; }));
            enemyAtklbl.Invoke(new MethodInvoker(delegate { enemyAtklbl.Visible = false; }));
            enemyMagiclbl.Invoke(new MethodInvoker(delegate { enemyMagiclbl.Visible = false; }));
            enemyRageStatuslbl.Invoke(new MethodInvoker(delegate { enemyRageStatuslbl.Visible = false; }));
            waveLeftPic.Invoke(new MethodInvoker(delegate { waveLeftPic.Visible = false; }));
            waveRightPic.Invoke(new MethodInvoker(delegate { waveRightPic.Visible = false; }));
            armDownPic.Invoke(new MethodInvoker(delegate { armDownPic.Visible = false; }));
            rageAbilityPic.Invoke(new MethodInvoker(delegate { rageAbilityPic.Visible = false; }));
            rageAbilitylbl.Invoke(new MethodInvoker(delegate { rageAbilitylbl.Visible = false; }));
            playerMovepic.Invoke(new MethodInvoker(delegate { playerMovepic.Visible = false; }));
            enemyMovepic.Invoke(new MethodInvoker(delegate { enemyMovepic.Visible = false; }));
            
            //If enemy won, display you lose and play sound. Set whoWon back to 0.
            if (whoWon == 1)
            {
                youLoselbl.Invoke(new MethodInvoker(delegate { youLoselbl.Visible = true; }));
                startAgainlbl.Invoke(new MethodInvoker(delegate { startAgainlbl.Visible = true; }));
                enemyWonSound.Play();
                whoWon = 0;
            }
            //If player won, display you win and play sound. Set whoWon back to 0.
            else if (whoWon == 2)
            {
                youWinlbl.Invoke(new MethodInvoker(delegate { youWinlbl.Visible = true; }));
                startAgainlbl.Invoke(new MethodInvoker(delegate { startAgainlbl.Visible = true; }));
                playerWonSound.Play();
                whoWon = 0;
            }
        }

        private void changeLights()
        {
            if(isPlayerMove == true && isEnemyMove == false)
            {
                playerMovepic.Invoke(new MethodInvoker(delegate
                {
                    playerMovepic.Image = Image.FromFile("C:/Users/Paddy/Desktop/MyoApp/MyoFantasyI/MyoFantasyI/Images/greenLight.png");
                }));
                enemyMovepic.Invoke(new MethodInvoker(delegate
                {
                    enemyMovepic.Image = Image.FromFile("C:/Users/Paddy/Desktop/MyoApp/MyoFantasyI/MyoFantasyI/Images/redLight.png");
                }));
            }
            else if (isEnemyMove == true && isPlayerMove == false)
            {
                playerMovepic.Invoke(new MethodInvoker(delegate
                {
                    playerMovepic.Image = Image.FromFile("C:/Users/Paddy/Desktop/MyoApp/MyoFantasyI/MyoFantasyI/Images/redLight.png");
                }));
                enemyMovepic.Invoke(new MethodInvoker(delegate
                {
                    enemyMovepic.Image = Image.FromFile("C:/Users/Paddy/Desktop/MyoApp/MyoFantasyI/MyoFantasyI/Images/greenLight.png");
                }));
            }
            else
            {
                playerMovepic.Invoke(new MethodInvoker(delegate
                {
                    playerMovepic.Image = Image.FromFile("C:/Users/Paddy/Desktop/MyoApp/MyoFantasyI/MyoFantasyI/Images/redLight.png");
                }));
                enemyMovepic.Invoke(new MethodInvoker(delegate
                {
                    enemyMovepic.Image = Image.FromFile("C:/Users/Paddy/Desktop/MyoApp/MyoFantasyI/MyoFantasyI/Images/redLight.png");
                }));
            }
        }

        private void changeDisplay()
        {
            //Changing display and generating random enemy.
            generateRandomEnemy();
            enemyPic.Invoke(new MethodInvoker(delegate { enemyPic.Visible = true; }));
            characterPic.Invoke(new MethodInvoker(delegate { characterPic.Visible = true; }));
            playerHP.Invoke(new MethodInvoker(delegate { playerHP.Visible = true; }));
            playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
            enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Visible = true; }));
            enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Visible = true; }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "It's your move! Use any gestures."; }));
            enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Visible = true; }));
            enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Visible = true; }));
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
            timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Visible = true; }));
            attacklbl.Invoke(new MethodInvoker(delegate { attacklbl.Visible = true; }));
            heallbl.Invoke(new MethodInvoker(delegate { heallbl.Visible = true; }));
            bufflbl.Invoke(new MethodInvoker(delegate { bufflbl.Visible = true; }));
            howToStartlbl.Invoke(new MethodInvoker(delegate { howToStartlbl.Visible = false; }));
            playerAtklbl.Invoke(new MethodInvoker(delegate { playerAtklbl.Text = "Max. Attack : " + playerAttack.ToString(); }));
            playerAtklbl.Invoke(new MethodInvoker(delegate { playerAtklbl.Visible = true; }));
            playerMagiclbl.Invoke(new MethodInvoker(delegate { playerMagiclbl.Text = "Max. Magic : " + playerMagic.ToString(); }));
            playerMagiclbl.Invoke(new MethodInvoker(delegate { playerMagiclbl.Visible = true; }));
            playerRageStatuslbl.Invoke(new MethodInvoker(delegate { playerRageStatuslbl.Text = "Rage Threat : " + playerRageStatus; }));
            playerRageStatuslbl.Invoke(new MethodInvoker(delegate { playerRageStatuslbl.Visible = true; }));
            enemyAtklbl.Invoke(new MethodInvoker(delegate { enemyAtklbl.Text = "Max. Attack : " + enemyAttack.ToString(); }));
            enemyAtklbl.Invoke(new MethodInvoker(delegate { enemyAtklbl.Visible = true; }));
            enemyMagiclbl.Invoke(new MethodInvoker(delegate { enemyMagiclbl.Text = "Max. Magic : " + enemyMagic.ToString(); }));
            enemyMagiclbl.Invoke(new MethodInvoker(delegate { enemyMagiclbl.Visible = true; }));
            enemyRageStatuslbl.Invoke(new MethodInvoker(delegate { enemyRageStatuslbl.Text = "Rage Threat : " + enemyRageStatus; }));
            enemyRageStatuslbl.Invoke(new MethodInvoker(delegate { enemyRageStatuslbl.Visible = true; }));
            waveLeftPic.Invoke(new MethodInvoker(delegate { waveLeftPic.Visible = true; }));
            waveRightPic.Invoke(new MethodInvoker(delegate { waveRightPic.Visible = true; }));
            armDownPic.Invoke(new MethodInvoker(delegate { armDownPic.Visible = true; }));
            youLoselbl.Invoke(new MethodInvoker(delegate { youLoselbl.Visible = false; }));
            youWinlbl.Invoke(new MethodInvoker(delegate { youWinlbl.Visible = false; }));
            startAgainlbl.Invoke(new MethodInvoker(delegate { startAgainlbl.Visible = false; }));
            playerMovepic.Invoke(new MethodInvoker(delegate { playerMovepic.Visible = true; }));
            enemyMovepic.Invoke(new MethodInvoker(delegate { enemyMovepic.Visible = true; }));
        }

        private void checkIfPlayerCanUseRageAbility()
        {
            //Checking to see if player can use rage ability, if he can update the user interface, otherwise hide the rage ability labels.
            if (playerRage >= 5)
            {
                rageAbilitylbl.Invoke(new MethodInvoker(delegate { rageAbilitylbl.Visible = true; }));
                rageAbilityPic.Invoke(new MethodInvoker(delegate { rageAbilityPic.Visible = true; }));
            }
            else
            {
                rageAbilitylbl.Invoke(new MethodInvoker(delegate { rageAbilitylbl.Visible = false; }));
                rageAbilityPic.Invoke(new MethodInvoker(delegate { rageAbilityPic.Visible = false; }));
            }
        }
        #endregion
    }
}
