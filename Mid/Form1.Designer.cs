namespace Mid
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.txtScore = new System.Windows.Forms.Label();
            this.txtAccuracy = new System.Windows.Forms.Label();
            this.pbLane3 = new System.Windows.Forms.PictureBox();
            this.pbLane4 = new System.Windows.Forms.PictureBox();
            this.pbLane1 = new System.Windows.Forms.PictureBox();
            this.pbLane2 = new System.Windows.Forms.PictureBox();
            this.pbHitline = new System.Windows.Forms.PictureBox();
            this.txtCombo = new System.Windows.Forms.Label();
            this.plFix = new System.Windows.Forms.Panel();
            this.plGame = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbLane3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLane4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLane1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLane2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHitline)).BeginInit();
            this.plFix.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 200;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Location = new System.Drawing.Point(692, 9);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(43, 16);
            this.txtScore.TabIndex = 0;
            this.txtScore.Text = "Score";
            // 
            // txtAccuracy
            // 
            this.txtAccuracy.AutoSize = true;
            this.txtAccuracy.Location = new System.Drawing.Point(692, 25);
            this.txtAccuracy.Name = "txtAccuracy";
            this.txtAccuracy.Size = new System.Drawing.Size(63, 16);
            this.txtAccuracy.TabIndex = 1;
            this.txtAccuracy.Text = "Accuracy";
            // 
            // pbLane3
            // 
            this.pbLane3.BackgroundImage = global::Mid.Properties.Resources.arrowDown_Tap;
            this.pbLane3.Location = new System.Drawing.Point(200, 16);
            this.pbLane3.Name = "pbLane3";
            this.pbLane3.Size = new System.Drawing.Size(100, 100);
            this.pbLane3.TabIndex = 5;
            this.pbLane3.TabStop = false;
            // 
            // pbLane4
            // 
            this.pbLane4.BackgroundImage = global::Mid.Properties.Resources.arrowRight_Tap;
            this.pbLane4.Location = new System.Drawing.Point(300, 16);
            this.pbLane4.Name = "pbLane4";
            this.pbLane4.Size = new System.Drawing.Size(100, 100);
            this.pbLane4.TabIndex = 4;
            this.pbLane4.TabStop = false;
            // 
            // pbLane1
            // 
            this.pbLane1.BackgroundImage = global::Mid.Properties.Resources.arrowLeft_Tap1;
            this.pbLane1.ErrorImage = global::Mid.Properties.Resources.arrowLeft_Tap1;
            this.pbLane1.Location = new System.Drawing.Point(100, 16);
            this.pbLane1.Name = "pbLane1";
            this.pbLane1.Size = new System.Drawing.Size(100, 100);
            this.pbLane1.TabIndex = 3;
            this.pbLane1.TabStop = false;
            // 
            // pbLane2
            // 
            this.pbLane2.BackgroundImage = global::Mid.Properties.Resources.arrowUp_Tap;
            this.pbLane2.Location = new System.Drawing.Point(0, 16);
            this.pbLane2.Name = "pbLane2";
            this.pbLane2.Size = new System.Drawing.Size(100, 100);
            this.pbLane2.TabIndex = 2;
            this.pbLane2.TabStop = false;
            // 
            // pbHitline
            // 
            this.pbHitline.BackColor = System.Drawing.Color.Yellow;
            this.pbHitline.Location = new System.Drawing.Point(-3, 0);
            this.pbHitline.Name = "pbHitline";
            this.pbHitline.Size = new System.Drawing.Size(400, 10);
            this.pbHitline.TabIndex = 6;
            this.pbHitline.TabStop = false;
            // 
            // txtCombo
            // 
            this.txtCombo.AutoSize = true;
            this.txtCombo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtCombo.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCombo.Location = new System.Drawing.Point(12, 13);
            this.txtCombo.Name = "txtCombo";
            this.txtCombo.Size = new System.Drawing.Size(125, 46);
            this.txtCombo.TabIndex = 7;
            this.txtCombo.Text = "Combo";
            // 
            // plFix
            // 
            this.plFix.BackColor = System.Drawing.Color.IndianRed;
            this.plFix.Controls.Add(this.pbLane4);
            this.plFix.Controls.Add(this.pbLane2);
            this.plFix.Controls.Add(this.pbLane1);
            this.plFix.Controls.Add(this.pbHitline);
            this.plFix.Controls.Add(this.pbLane3);
            this.plFix.Location = new System.Drawing.Point(200, 600);
            this.plFix.Name = "plFix";
            this.plFix.Size = new System.Drawing.Size(400, 120);
            this.plFix.TabIndex = 8;
            // 
            // plGame
            // 
            this.plGame.BackColor = System.Drawing.Color.Black;
            this.plGame.Location = new System.Drawing.Point(200, 0);
            this.plGame.Name = "plGame";
            this.plGame.Size = new System.Drawing.Size(400, 600);
            this.plGame.TabIndex = 9;
            this.plGame.Paint += new System.Windows.Forms.PaintEventHandler(this.plGame_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.txtCombo);
            this.Controls.Add(this.txtAccuracy);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.plFix);
            this.Controls.Add(this.plGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbLane3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLane4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLane1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLane2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHitline)).EndInit();
            this.plFix.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtAccuracy;
        private System.Windows.Forms.PictureBox pbLane2;
        private System.Windows.Forms.PictureBox pbLane1;
        private System.Windows.Forms.PictureBox pbLane4;
        private System.Windows.Forms.PictureBox pbLane3;
        private System.Windows.Forms.PictureBox pbHitline;
        private System.Windows.Forms.Label txtCombo;
        private System.Windows.Forms.Panel plFix;
        private System.Windows.Forms.Panel plGame;
    }
}

