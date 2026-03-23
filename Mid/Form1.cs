using Mid.Managerment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Mid
{
    public partial class Form1 : Form
    {
        GameManager game = new GameManager();
        InputManager input = new InputManager();
        WindowsMediaPlayer p = new WindowsMediaPlayer();

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
            laneX[0] = plGame.Width/4*0+20;
            laneX[1] = plGame.Width / 4 * 1 + 20;
            laneX[2] = plGame.Width / 4 * 2 + 20;
            laneX[3] = plGame.Width / 4 * 3 + 20;

            game.LoadFile(@"Resources/NoteLoad/AnDoMixi.txt");
            game.startTime = Environment.TickCount;

            gameTimer.Interval = 16;
            gameTimer.Start();

            p.URL = @"Resources/Songs/AnDoMixi.mp3";
            p.controls.play();

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.SpawnNote(laneX);
            game.MoveNotes();
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

            // ===== lane =====
            for (int i = 1; i < 4; i++)
            {
                int x = i * plGame.Width / 4;
                g.DrawLine(Pens.Gray, x, 0, x, plGame.Height);
            }

            // ===== note =====
            foreach (Note n in game.notes)
            {
                g.FillRectangle(Brushes.DeepSkyBlue, n.x, n.y, 40, 40);
            }

            // ===== hit text =====
            if (hitText != "")
            {
                Font f = new Font("Arial", 24, FontStyle.Bold);

                g.DrawString(
                    hitText,
                    f,
                    Brushes.White,
                    plGame.Width / 2 - 60,
                    pbHitline.Top - 80
                );
            }
        }
    }
}
