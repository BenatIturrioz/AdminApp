namespace AdminApp
{
    partial class Form4
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxErosketaKant = new System.Windows.Forms.TextBox();
            this.textBoxKantitatea = new System.Windows.Forms.TextBox();
            this.textBoxKantMin = new System.Windows.Forms.TextBox();
            this.textBoxErosketaPrezioa = new System.Windows.Forms.TextBox();
            this.textBoxPrezioa = new System.Windows.Forms.TextBox();
            this.textBoxIzena = new System.Windows.Forms.TextBox();
            this.listBoxCarrito = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SASKIA = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(326, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1824, 770);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.button4.Location = new System.Drawing.Point(12, 1322);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(182, 72);
            this.button4.TabIndex = 10;
            this.button4.Text = "ATZERA";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxErosketaKant);
            this.groupBox1.Controls.Add(this.textBoxKantitatea);
            this.groupBox1.Controls.Add(this.textBoxKantMin);
            this.groupBox1.Controls.Add(this.textBoxErosketaPrezioa);
            this.groupBox1.Controls.Add(this.textBoxPrezioa);
            this.groupBox1.Controls.Add(this.textBoxIzena);
            this.groupBox1.Location = new System.Drawing.Point(326, 800);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1824, 273);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EROSTEKO PRODUKTUA";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.button1.Location = new System.Drawing.Point(1623, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 217);
            this.button1.TabIndex = 12;
            this.button1.Text = "EROSKETA SASKIAN SARTU";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1371, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Erosketa Kantitatea:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1113, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kantitatea:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(860, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kantitate Minimoa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(606, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Erosketa Prezioa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Prezioa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Izena:";
            // 
            // textBoxErosketaKant
            // 
            this.textBoxErosketaKant.Location = new System.Drawing.Point(1376, 95);
            this.textBoxErosketaKant.Name = "textBoxErosketaKant";
            this.textBoxErosketaKant.Size = new System.Drawing.Size(172, 31);
            this.textBoxErosketaKant.TabIndex = 5;
            // 
            // textBoxKantitatea
            // 
            this.textBoxKantitatea.Location = new System.Drawing.Point(1118, 95);
            this.textBoxKantitatea.Name = "textBoxKantitatea";
            this.textBoxKantitatea.ReadOnly = true;
            this.textBoxKantitatea.Size = new System.Drawing.Size(172, 31);
            this.textBoxKantitatea.TabIndex = 4;
            // 
            // textBoxKantMin
            // 
            this.textBoxKantMin.Location = new System.Drawing.Point(864, 95);
            this.textBoxKantMin.Name = "textBoxKantMin";
            this.textBoxKantMin.ReadOnly = true;
            this.textBoxKantMin.Size = new System.Drawing.Size(172, 31);
            this.textBoxKantMin.TabIndex = 3;
            // 
            // textBoxErosketaPrezioa
            // 
            this.textBoxErosketaPrezioa.Location = new System.Drawing.Point(610, 95);
            this.textBoxErosketaPrezioa.Name = "textBoxErosketaPrezioa";
            this.textBoxErosketaPrezioa.ReadOnly = true;
            this.textBoxErosketaPrezioa.Size = new System.Drawing.Size(172, 31);
            this.textBoxErosketaPrezioa.TabIndex = 2;
            // 
            // textBoxPrezioa
            // 
            this.textBoxPrezioa.Location = new System.Drawing.Point(358, 95);
            this.textBoxPrezioa.Name = "textBoxPrezioa";
            this.textBoxPrezioa.ReadOnly = true;
            this.textBoxPrezioa.Size = new System.Drawing.Size(172, 31);
            this.textBoxPrezioa.TabIndex = 1;
            // 
            // textBoxIzena
            // 
            this.textBoxIzena.Location = new System.Drawing.Point(99, 95);
            this.textBoxIzena.Name = "textBoxIzena";
            this.textBoxIzena.ReadOnly = true;
            this.textBoxIzena.Size = new System.Drawing.Size(172, 31);
            this.textBoxIzena.TabIndex = 0;
            // 
            // listBoxCarrito
            // 
            this.listBoxCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listBoxCarrito.FormattingEnabled = true;
            this.listBoxCarrito.ItemHeight = 25;
            this.listBoxCarrito.Location = new System.Drawing.Point(326, 1105);
            this.listBoxCarrito.Name = "listBoxCarrito";
            this.listBoxCarrito.Size = new System.Drawing.Size(1824, 279);
            this.listBoxCarrito.TabIndex = 12;
            this.listBoxCarrito.SelectedIndexChanged += new System.EventHandler(this.listBoxCarrito_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.button2.Location = new System.Drawing.Point(1948, 1128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 225);
            this.button2.TabIndex = 13;
            this.button2.Text = "EROSKETA EGITERA BIDALI";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SASKIA
            // 
            this.SASKIA.AutoSize = true;
            this.SASKIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.SASKIA.Location = new System.Drawing.Point(320, 1077);
            this.SASKIA.Name = "SASKIA";
            this.SASKIA.Size = new System.Drawing.Size(207, 25);
            this.SASKIA.TabIndex = 14;
            this.SASKIA.Text = "EROSKETA SASKIA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AdminApp.Properties.Resources.Logo_Charlies_Nagusia_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(306, 207);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(214)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(2433, 1406);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SASKIA);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBoxCarrito);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxErosketaKant;
        private System.Windows.Forms.TextBox textBoxKantitatea;
        private System.Windows.Forms.TextBox textBoxKantMin;
        private System.Windows.Forms.TextBox textBoxErosketaPrezioa;
        private System.Windows.Forms.TextBox textBoxPrezioa;
        private System.Windows.Forms.TextBox textBoxIzena;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxCarrito;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label SASKIA;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}