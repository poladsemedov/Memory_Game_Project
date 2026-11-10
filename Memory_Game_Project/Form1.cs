using System;
using System.Drawing;
using System.Windows.Forms;

namespace Memory_Game_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int num;
        int score = 0;
        int matchedPairs = 0;
        PictureBox firstClicked = null;
        PictureBox secondClicked = null;
        bool isChecking = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            num = r.Next(1, 9);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Oyundan çıxış edilsinmi?", "Sual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void CardClick(PictureBox pb, int cardPairId)
        {
            if (isChecking) return;
            if (pb.ImageLocation != @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png") return;

            if (cardPairId == 1)
            {
                pb.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\Blue-Card.png";
            }
            else if (cardPairId == 2)
            {
                pb.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\Green-card.png";
            }
            else if (cardPairId == 3)
            {
                pb.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\Red-card.png";
            }
            else if (cardPairId == 4)
            {
                pb.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\Yellow-Card.png";
            }

            if (firstClicked == null)
            {
                firstClicked = pb;
                return;
            }

            secondClicked = pb;
            isChecking = true;

            System.Windows.Forms.Timer checkTimer = new System.Windows.Forms.Timer();
            checkTimer.Interval = 700;
            checkTimer.Tick += (s, args) =>
            {
                checkTimer.Stop();
                checkTimer.Dispose();

                if (firstClicked.ImageLocation == secondClicked.ImageLocation)
                {
                    score += 10;
                    matchedPairs++;
                    label1.Text = "XAL : " + score;

                    firstClicked.Enabled = false;
                    secondClicked.Enabled = false;

                    if (matchedPairs == 4)
                    {
                        MessageBox.Show("Təbriklər! Bütün kartları tapdınız!", "Oyun Bitdi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    firstClicked.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
                    secondClicked.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
                }

                firstClicked = null;
                secondClicked = null;
                isChecking = false;
            };
            checkTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            score = 0;
            matchedPairs = 0;
            label1.Text = "XAL : 0";
            firstClicked = null;
            secondClicked = null;
            isChecking = false;

            Random r = new Random();
            num = r.Next(1, 9);

            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
            pictureBox8.Enabled = true;

            pictureBox1.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
            pictureBox2.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
            pictureBox3.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
            pictureBox4.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
            pictureBox5.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
            pictureBox6.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
            pictureBox7.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
            pictureBox8.ImageLocation = @"C:\Users\LENOVO\source\repos\Memory_Game_Project\Memory_Game_Project\question-sign.png";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int pairId;
            if (num == 1) pairId = 1;
            else pairId = 3;
            CardClick(pictureBox1, pairId);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int pairId;
            if (num == 1) pairId = 1;
            else pairId = 4;
            CardClick(pictureBox2, pairId);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int pairId;
            if (num == 2) pairId = 2;
            else pairId = 3;
            CardClick(pictureBox3, pairId);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int pairId;
            if (num == 2) pairId = 2;
            else pairId = 4;
            CardClick(pictureBox4, pairId);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int pairId;
            if (num == 3) pairId = 3;
            else pairId = 1;
            CardClick(pictureBox5, pairId);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            int pairId;
            if (num == 3) pairId = 3;
            else pairId = 2;
            CardClick(pictureBox6, pairId);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            int pairId;
            if (num == 4) pairId = 4;
            else pairId = 1;
            CardClick(pictureBox7, pairId);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            int pairId;
            if (num == 4) pairId = 4;
            else pairId = 2;
            CardClick(pictureBox8, pairId);
        }
    }
}