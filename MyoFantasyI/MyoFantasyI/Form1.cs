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

namespace MyoFantasyI
{
    public partial class Form1 : Form
    {
        private readonly IChannel _channel;
        private readonly IHub _hub;

        Random rnd = new Random();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private Boolean isGameStarted = false;
        private Boolean isPlayerMove;
        private Boolean isEnemyMove;
        private Boolean isTimeSet = false;
        private int enemyHealth;
        private int enemyCurrHealth;
        private int enemyAttack;
        private int enemyMagic;
        private int enemyRage;
        private int playerHealth;
        private int playerCurrHealth;
        private int playerAttack;
        private int playerMagic;
        private int playerRage;

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
            updateRageAbilityMove();
            e.Myo.Vibrate(VibrationType.Medium);
        }

        private void Myo_PoseChanged(object sender, PoseEventArgs e)
        {
            string status = "Waiting for pose.";

            if (e.Myo.Pose == Pose.Fist)
            {
                if(isGameStarted == false)
                {
                    startGame();
                    setTimeLeft();
                    isGameStarted = true;
                }                  
            }

            if (e.Myo.Pose == Pose.WaveIn)
            {
                if (isPlayerMove == true && isGameStarted == true)
                {
                    updateAttackMove();
                }
            }

            if (e.Myo.Pose == Pose.WaveOut)
            {
                if (isPlayerMove == true && isGameStarted == true && playerRage >= 2)
                {
                    updateHealMove();
                }
                else
                {
                    statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You do not have enough rage to heal yourself."; }));
                }
            }

            if (isConnectedLbl.InvokeRequired)
            {
                isConnectedLbl.Invoke(new MethodInvoker(delegate { isConnectedLbl.Text = status; }));
            }
        }

        private void startGame()
        {
            setPlayer();
            changeDisplay();
            isPlayerMove = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timeLeft -= 5;
            if (timeLeft < 10 && timeLeft > 0)
            {
                timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Text = "You only have 10 seconds left!"; }));               
            }
            else if (timeLeft <= 0)
            {
                timerlbl.Invoke(new MethodInvoker(delegate { timerlbl.Text = ""; })); 
                isTimeSet = false;
                if (isPlayerMove == true)
                {
                    setTimeLeft();
                    isPlayerMove = false;
                    isEnemyMove = true;
                }
                else if (isEnemyMove == true)
                {
                    setTimeLeft();
                    if (timeLeft == 20)
                    {
                        enemiesMove();
                    }
                    isEnemyMove = false;
                    isPlayerMove = true;                 
                }
            }

            if (isGameStarted == true)
            {
                if (isPlayerMove == true)
                {
                    setTimeLeft();
                    //statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "It's your move!"; }));
                }
                else if (isEnemyMove == true)
                {
                    setTimeLeft();
                    //statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "It's enemies move!"; }));

                    if (timeLeft <= 20)
                    {
                        enemiesMove();
                    }
                }
            }
        }

        private void setTimeLeft()
        {
            if(isTimeSet == false)
            {
                timeLeft = 30;
                isTimeSet = true;
            }
        }

        private void setPlayer()
        {
            playerHealth = 1000;
            playerCurrHealth = playerHealth;
            playerAttack = 125;
            playerMagic = 150;
            playerRage = 0;
        }

        private void updateAttackMove()
        {
            int attackStrength = rnd.Next((playerAttack/2), playerAttack);
            enemyCurrHealth -= attackStrength;

            if (enemyRage == 10)
            {
                enemyRage = 10;
            }
            else
            {
                enemyRage += 1;
            }

            enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
            enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You dealt " + attackStrength.ToString() + " damage to the enemy! \n Enemies move!"; }));
            isPlayerMove = false;
            isEnemyMove = true;
            timeLeft = 30;
        }

        private void updateHealMove()
        {
            int healAmount = rnd.Next((playerMagic / 2), playerMagic);
            playerCurrHealth += healAmount;
            //2 rage is taken when healed
            playerRage -= 2;

            if (playerCurrHealth > playerHealth)
            {
                playerCurrHealth = playerHealth;
            }
                
            playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You healed yourself by " + healAmount.ToString() + " hit points!"; }));
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
            playerRage -= 5;

            if (playerCurrHealth > playerHealth)
                playerCurrHealth = playerHealth;

            if (enemyRage == 10)
            {
                enemyRage = 10;
            }
            else if(enemyRage <= 8)
            {
                enemyRage += 2;
            }
            else
            {
                enemyRage += 1;
            }

            enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text = "Health: " + enemyCurrHealth.ToString(); }));
            playerHP.Invoke(new MethodInvoker(delegate { playerHP.Text = "Health: " + playerCurrHealth.ToString(); }));
            playerRagelbl.Invoke(new MethodInvoker(delegate { playerRagelbl.Text = "Rage: " + playerRage.ToString() + " / 10."; }));
            enemyRagelbl.Invoke(new MethodInvoker(delegate { enemyRagelbl.Text = "Rage: " + enemyRage.ToString() + " / 10."; }));
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "You dealt " + attackStrength.ToString() + " damage to enemy, \n and healed yourself by " + healAmount.ToString() + " hit points!"; }));
            isPlayerMove = false;
            isEnemyMove = true;
            timeLeft = 30;
        }

        private void enemiesMove()
        {
            int enemiesMove;
            //Change this later
            if(enemyRage < 5)
            {
                //If rage is less than 5, can't use rage ability, only option is to heal or attack.
                enemiesMove = rnd.Next(1, 2);
            }
            else if(enemyRage < 3)
            {
                //If rage is less than 3 (enemy took atleast 3 hits, known by enemyRage), only option is to attack.
                enemiesMove = 1;
            }
            else if(enemyRage == 10)
            {
                //if enemy has max Rage use Rage ability.
                enemiesMove = 3;
            }
            else
            {
                //There is atleast 5 rage, can use any ability.
                enemiesMove = rnd.Next(1, 3);
            }


            switch (enemiesMove)
            {
                case 1:
                    enemyAttackMove();
                    break;
                case 2:
                    enemyHealMove();
                    break;
                default:
                    enemyRageAbility();
                    break;
            }
        }

        private void enemyAttackMove()
        {        
            int attackStrength = rnd.Next((enemyAttack / 3), enemyAttack);
            playerCurrHealth -= attackStrength;

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
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy dealt " + attackStrength.ToString() + " damage to you!"; }));
            isPlayerMove = true;
            isEnemyMove = false;
            timeLeft = 30;
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
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy healed himself by " + healAmount.ToString() + " hit points!"; }));
            isPlayerMove = true;
            isEnemyMove = false;
            timeLeft = 30;
        }

        private void enemyRageAbility()
        {
            int attackStrength = rnd.Next((enemyAttack+10), (enemyAttack * 2));
            int healAmount = rnd.Next(enemyMagic, (enemyMagic+50));
            playerCurrHealth -= attackStrength;
            enemyCurrHealth += healAmount;          
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
            statusLbl.Invoke(new MethodInvoker(delegate { statusLbl.Text = "Enemy dealt " + attackStrength.ToString() + " damage to you, and healed himself by " + healAmount.ToString() + " hit points!"; }));
            isPlayerMove = true;
            isEnemyMove = false;
            timeLeft = 30;
        }

        private void changeDisplay()
        {
            generateRandomEnemy();
            enemyPic.Invoke(new MethodInvoker(delegate { enemyPic.Visible = true; }));
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
        }

        private void generateRandomEnemy()
        {
            //Random rnd = new Random();
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
            //enemyHP.Invoke(new MethodInvoker(delegate { enemyHP.Text += enemyCurrHealth; }));
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
