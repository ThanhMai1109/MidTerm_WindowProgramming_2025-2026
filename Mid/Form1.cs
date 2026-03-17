using Mid.Managerment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid
{
    public partial class Form1 : Form
    {
        GameManager game = new GameManager();
        InputManager input = new InputManager();

        string hitText = "";
        int hitTextTimer = 0;

        int[] laneX = new int[4];

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            laneX[0] = pbLane1.Left;
            laneX[1] = pbLane2.Left;
            laneX[2] = pbLane3.Left;
            laneX[3] = pbLane4.Left;

            gameTimer.Interval = 32;
            gameTimer.Start();

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.MoveNotes();
            game.SpawnNote(plGame.Width);
            game.RemoveMiss(pbHitline.Top);

            hitText = input.hitText;

            if (hitText != "")
            {
                hitTextTimer = 20;
                input.hitText = "";
            }

            if (hitTextTimer > 0)
            {
                hitTextTimer--;
            }
            else
            {
                hitText = "";
            }

            UpdateUI();

            plGame.Invalidate();
        }
        void UpdateUI()
        {
            txtScore.Text = game.score.ToString();
            txtCombo.Text = "Combo: "+game.combo.ToString()+"x";

            float accuracy = 0;

            if (game.totalHit > 0)
                accuracy = game.GetAccuracy()*100;

            txtAccuracy.Text = accuracy.ToString("0.00") + "%";
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
                input.HitLane(game, 0, pbHitline.Top);

            if (e.KeyCode == Keys.F)
                input.HitLane(game, 1, pbHitline.Top);

            if (e.KeyCode == Keys.J)
                input.HitLane(game, 2, pbHitline.Top);

            if (e.KeyCode == Keys.K)
                input.HitLane(game, 3, pbHitline.Top);
        }

        private void plGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Vẽ lane
            for (int i = 1; i < 4; i++)
            {
                int x = i * plGame.Width / 4;
                g.DrawLine(Pens.Gray, x, 0, x, plGame.Height);
            }

            // Vẽ note
            foreach (Note n in game.notes)
            {
                g.FillRectangle(Brushes.White, n.x, n.y, 40, 40);
            }

            // Vẽ hit text
            if (hitText != "")
            {
                Font f = new Font("Arial", 26, FontStyle.Bold);

                g.DrawString(hitText,f, Brushes.White,plGame.Width / 2 - 60,pbHitline.Top - 80);
            }
        }
    }
}
