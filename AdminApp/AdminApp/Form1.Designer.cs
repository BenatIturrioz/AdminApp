namespace AdminApp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.erabiltzaileaTextbox = new System.Windows.Forms.TextBox();
            this.pasahitzaTextbox = new System.Windows.Forms.TextBox();
            this.saioaHasiButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // erabiltzaileaTextbox
            // 
            this.erabiltzaileaTextbox.Location = new System.Drawing.Point(994, 575);
            this.erabiltzaileaTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.erabiltzaileaTextbox.Name = "erabiltzaileaTextbox";
            this.erabiltzaileaTextbox.Size = new System.Drawing.Size(510, 31);
            this.erabiltzaileaTextbox.TabIndex = 0;
            // 
            // pasahitzaTextbox
            // 
            this.pasahitzaTextbox.Location = new System.Drawing.Point(994, 662);
            this.pasahitzaTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pasahitzaTextbox.Name = "pasahitzaTextbox";
            this.pasahitzaTextbox.Size = new System.Drawing.Size(510, 31);
            this.pasahitzaTextbox.TabIndex = 1;
            // 
            // saioaHasiButton
            // 
            this.saioaHasiButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.saioaHasiButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.saioaHasiButton.Location = new System.Drawing.Point(1084, 742);
            this.saioaHasiButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saioaHasiButton.Name = "saioaHasiButton";
            this.saioaHasiButton.Size = new System.Drawing.Size(346, 71);
            this.saioaHasiButton.TabIndex = 2;
            this.saioaHasiButton.Text = "SAIOA HASI";
            this.saioaHasiButton.UseVisualStyleBackColor = false;
            this.saioaHasiButton.Click += new System.EventHandler(this.saioaHasiButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label1.Location = new System.Drawing.Point(988, 548);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "ERABILTZAILEA:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label2.Location = new System.Drawing.Point(988, 633);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "PASAHITZA:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(600, 49);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1328, 493);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(214)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(2404, 1123);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saioaHasiButton);
            this.Controls.Add(this.pasahitzaTextbox);
            this.Controls.Add(this.erabiltzaileaTextbox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox erabiltzaileaTextbox;
        private System.Windows.Forms.TextBox pasahitzaTextbox;
        private System.Windows.Forms.Button saioaHasiButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

