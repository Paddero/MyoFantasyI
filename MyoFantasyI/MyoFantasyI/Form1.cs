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
        private readonly IChannel _channel;
        private readonly IHub _hub;

        Random rnd = new Random();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        SoundPlayer swordSlash = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\sword2.wav");
        SoundPlayer playerHeal = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\healing2.wav");
        SoundPlayer playerRageAbility = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\playerRage2.wav");
        SoundPlayer enemyAttackSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\enemyAttack.wav");
        SoundPlayer enemyHealingSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\enemyHealing.wav");
        SoundPlayer enemyRageSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\enemyRage.wav");
        SoundPlayer enemyWonSound = new SoundPlayer(@"C:\Users\Paddy\Desktop\MyoApp\MyoFantasyI\MyoFantasyI\Sounds\enemyWonSound.wav");

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

        // 1 for Enemy, 2 for Player.
        private int whoWon = 0;

        private int timeLeft = 30;

        public Form1()
        {
            InitializeComponent();

            // get set up to listen for Myo events
            _channel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create()));

            _hub = Hub.Create(_channel);
            _hub.MyoConnected += _hub_MyoConnected;
            _hub.MyoDisconnected += _hub_MyoDisconnected;
            
            timer.Interval = 5000; // specify interval time as you want
            timer.Tick += timer_Tick;
            timer.Start();          
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WindowState = FormWindowState.Maximized;
            
            // start listening for Myo data
            _channel.StartListening();          
        }

        protected override void OnClosed(EventArgs e)
        {
            _channel.Dispose();
            _hub.Dispose();

            base.OnClosed(e);
        }

        private void _hub_MyoDisconnected(object sender, MyoEventArgs e)
        {
            string status = "Myo is Connected";
         
            if (isConnectedLbl.InvokeRequired)
            {
                isConnectedLbl.Invoke(new MethodInvoker(delegate { isConnectedLbl.Text = status; }));
            }
        }

        private void _hub_MyoConnected(object sender, MyoEventArgs e)
        {
            string status = "Myo is Connected";
            
            e.Myo.Unlock(UnlockType.Hold);

            var sequence = PoseSequence.Create(
                        e.Myo,
                        Pose.Fist,
                        Pose.DoubleTap,
                        Pose.FingersSpread);
            sequence.PoseSequenceCompleted += sequence_PoseSequenceCompleted;

            if (isConnectedLbl.InvokeRequired)
            {
                isConnectedLbl.Invoke(new MethodInvoker(delegate { isConnectedLbl.Text = status; }));
            }

            e.Myo.PoseChanged += Myo_PoseChanged;
        }

        private void sequence_PoseSequenceCompleted(object sender, PoseSequenceEventArgs e)
        {
            if (isGameStarted == true && isPlayerMove == true && playerRage >= 5)
            {
                updateRageAbilityMove();
                e.Myo.Vibrate(VibrationType.Medium);
            }
            else if (isGameStarted == true && isPlayerMove == true && playerRage < 5)
            {
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You do not have enough rage to use Rage Ability!"; }));
            }          
        }

        private void Myo_PoseChanged(object sender, PoseEventArgs e)
        {
            if (e.Myo.Pose == Pose.Fist)
            {
                if(isGameStarted == false)
                {
                    startGame();
                    timeLeft = 30;
                    isGameStarted = true;
                }                  
            }

            if (e.Myo.Pose == Pose.WaveIn)
            {
                if (isPlayerMove == true && isGameStarted == true && isGameOver == false)
                {
                    swordSlash.Play();
                    updateAttackMove();
                }
            }

            if (e.Myo.Pose == Pose.WaveOut)
            {
                if (isPlayerMove == true && isGameStarted == true && playerRage >= 2 && isGameOver == false)
                {
                    playerHeal.Play();
                    updateHealMove();
                }
                else if(isPlayerMove == true && isGameStarted == true)
                {
                    statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You do not have enough rage to heal yourself."; }));
                }
            }
        }

        private void startGame()
        {
            setPlayer();
            changeDisplay();            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timeLeft -= 5;
            timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Text = ""; }));
            if (timeLeft < 10 && timeLeft > 0)
            {
                timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Text = "You only have 10 seconds left!"; }));               
            }
            else if (timeLeft <= 0)
            {
                timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Text = ""; })); 
                if (isPlayerMove == true)
                {
                    timeLeft = 30;
                    isPlayerMove = false;
                    isEnemyMove = true;
                }
            }

            if (isGameStarted == true)
            {
                if (timeLeft <= 25 && isEnemyMove == false)
                {
                    isPlayerMove = true;
                    //statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "It's your move!"; }));
                }
                else if (isEnemyMove == true)
                {
                    //setTimeLeft();
                    //statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "It's enemies move!"; }));

                    if (timeLeft <= 20)
                    {
                        enemiesMove();
                    }
                }
            }
        }

        private void setPlayer()
        {
            playerHealth = 1000;
            playerCurrHealth = playerHealth;
            playerAttack = 125;
            playerMagic = 150;
            playerRage = 0;
            playerRageStatus = "Medium";
            isPlayerMove = true;
        }

        private void updateAttackMove()
        {
            int attackStrength = rnd.Next((playerAttack/2), playerAttack);
            enemyCurrHealth -= attackStrength;

            if (enemyCurrHealth <= 0)
            {
                whoWon = 2;
                gameOver();
            }
            else
            {
                if (enemyRage == 10)
                {
                    enemyRage = 10;
                }
                else
                {
                    enemyRage += 2;
                }

                enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
                enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You dealt " + attackStrength.ToString() + " damage to the enemy!\n\n\tEnemies move!"; }));
                isPlayerMove = false;
                isEnemyMove = true;
                timeLeft = 30;
            }           
        }

        private void updateHealMove()
        {
            int healAmount = rnd.Next((playerMagic / 2), playerMagic);
            playerCurrHealth += healAmount;
            //2 rage is taken when healed
            playerRage -= 2;

            if (playerCurrHealth > playerHealth)
                playerCurrHealth = playerHealth;
                
            playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You healed yourself by " + healAmount.ToString() + " hit points!\n\n\tEnemies move!"; }));
            checkIfPlayerCanUseRageAbility();
            isPlayerMove = false;
            isEnemyMove = true;           
            timeLeft = 30;
        }

        private void updateRageAbilityMove()
        {
            int attackStrength = rnd.Next((playerAttack + 50), (playerAttack * 2));
            int healAmount = rnd.Next(playerMagic, (playerMagic * 2));
            enemyCurrHealth -= attackStrength;
            playerCurrHealth += healAmount;
           

            if (enemyCurrHealth <= 0)
            {
                whoWon = 2;
                gameOver();
            }
            else
            {
                 playerRage -= 5;
                
                if (playerCurrHealth > playerHealth)
                    playerCurrHealth = playerHealth;

                if (enemyRage == 10)
                {
                    enemyRage = 10;
                }
                else if (enemyRage <= 8)
                {
                    enemyRage += 2;
                }

                enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
                playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
                playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
                enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You dealt " + attackStrength.ToString() + " damage to enemy, \n and healed yourself by " + healAmount.ToString() + " hit points!\n\n\tEnemies move!"; }));
                checkIfPlayerCanUseRageAbility();
                isPlayerMove = false;
                isEnemyMove = true;
                timeLeft = 30;
            }     
        }

        private void gameOver()
        {
            isPlayerMove = false;
            isEnemyMove = false;
            isGameOver = true;

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
            playerAtklbl.Invoke(new MethodInvoker(delegate { playerAtklbl.Visible = false; }));
            playerMagiclbl.Invoke(new MethodInvoker(delegate { playerMagiclbl.Visible = false; }));
            playerRageStatuslbl.Invoke(new MethodInvoker(delegate { playerRageStatuslbl.Visible = false; }));
            enemyAtklbl.Invoke(new MethodInvoker(delegate { enemyAtklbl.Visible = false; }));
            enemyMagiclbl.Invoke(new MethodInvoker(delegate { enemyMagiclbl.Visible = false; }));
            enemyRageStatuslbl.Invoke(new MethodInvoker(delegate { enemyRageStatuslbl.Visible = false; }));

            if (whoWon == 1)
            {

            }
            else if (whoWon == 2)
            {

            }
        }

        private void enemiesMove()
        {
            int enemiesMove;
            //Change this later
            if(enemyRage >= 5)
            {
                //If rage is greater or equal to 5, can use any ability. Generate 3/4 as well to give better chance for rage ability
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
            int attackStrength = rnd.Next((enemyAttack / 3), enemyAttack);
            playerCurrHealth -= attackStrength;

            if (playerCurrHealth <= 0)
            {
                whoWon = 1;
                gameOver();
            }
            else
            {
                if (playerRage == 10)
                {
                    playerRage = 10;
                }
                else
                {
                    playerRage += 1;
                }

                playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
                playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy dealt " + attackStrength.ToString() + " damage to you!\n\n\tIt's your move!"; }));
                checkIfPlayerCanUseRageAbility();
                isEnemyMove = false;
                timeLeft = 30;
            }            
        }

        private void enemyHealMove()
        {
            int healAmount = rnd.Next((enemyMagic / 3), enemyMagic);
            enemyCurrHealth += healAmount;
            //3 rage is taken when healed
            enemyRage -= 3;

            if (enemyCurrHealth > enemyHealth)
                enemyCurrHealth = enemyHealth;

            enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
            enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy healed himself by " + healAmount.ToString() + " hit points!\n\n\tIt's your move!"; }));
            //isPlayerMove = true;
            isEnemyMove = false;
            timeLeft = 30;
        }

        private void enemyRageAbility()
        {
            int attackStrength = rnd.Next((enemyAttack+10), (enemyAttack * 2));
            int healAmount = rnd.Next(enemyMagic, (enemyMagic+50));
            playerCurrHealth -= attackStrength;
            enemyCurrHealth += healAmount;          
            
            if(playerCurrHealth <= 0)
            {
                whoWon = 1;
                gameOver();
            }
            else
            {
                enemyRage = 0;

                if (enemyCurrHealth > enemyHealth)
                    enemyCurrHealth = enemyHealth;

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

                enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
                playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
                playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
                enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
                statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy dealt " + attackStrength.ToString() + " damage to you,\nand healed himself by " + healAmount.ToString() + " hit points!\n\n\tIt's your move!"; }));
                //isPlayerMove = true;
                checkIfPlayerCanUseRageAbility();
                isEnemyMove = false;
                timeLeft = 30;
            }                      
        }

        private void changeDisplay()
        {
            generateRandomEnemy();
            enemyPic.Invoke(new MethodInvoker(delegate { enemyPic.Visible = true; }));
            characterPic.Invoke(new MethodInvoker(delegate { characterPic.Visible = true; }));
            playerHP.Invoke(new MethodInvoker(delegate { playerHP.Visible = true; }));
            playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
            enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Visible = true; }));
            enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Visible = true; }));
            enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Visible = true; }));
            enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Visible = true; }));
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
            timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Visible = true; }));
            attacklbl.Invoke(new MethodInvoker(delegate { attacklbl.Visible = true; }));
            heallbl.Invoke(new MethodInvoker(delegate { heallbl.Visible = true; }));
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
        }

        private void checkIfPlayerCanUseRageAbility()
        {
            if (playerRage >= 5)
            {
                rageAbilitylbl.Invoke(new MethodInvoker(delegate { rageAbilitylbl.Visible = true; }));
            }
            else
            {
                rageAbilitylbl.Invoke(new MethodInvoker(delegate { rageAbilitylbl.Visible = false; }));
            }
        }

        private void generateRandomEnemy()
        {
            int enemy = 1;

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
            enemyAttack = 200;
            enemyHealth = 750;
        }
        private void enemy3()
        {
            enemyAttack = 100;
            enemyHealth = 1000;
        }
    }
}
