namespace Arduino
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnConectar = new Button();
            btnPotenciometro = new Button();
            cmbPortas = new ComboBox();
            txtReceber = new TextBox();
            tmrPortas = new System.Windows.Forms.Timer(components);
            grpLeds = new GroupBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            grpLeds.SuspendLayout();
            SuspendLayout();
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(14, 16);
            btnConectar.Margin = new Padding(3, 4, 3, 4);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(112, 31);
            btnConectar.TabIndex = 0;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // btnPotenciometro
            // 
            btnPotenciometro.Enabled = false;
            btnPotenciometro.Location = new Point(14, 53);
            btnPotenciometro.Margin = new Padding(3, 4, 3, 4);
            btnPotenciometro.Name = "btnPotenciometro";
            btnPotenciometro.Size = new Size(257, 31);
            btnPotenciometro.TabIndex = 1;
            btnPotenciometro.Text = "Ativar Potenciômetro";
            btnPotenciometro.UseVisualStyleBackColor = true;
            btnPotenciometro.Click += btnPotenciometro_Click;
            // 
            // cmbPortas
            // 
            cmbPortas.FormattingEnabled = true;
            cmbPortas.Location = new Point(133, 16);
            cmbPortas.Margin = new Padding(3, 4, 3, 4);
            cmbPortas.Name = "cmbPortas";
            cmbPortas.Size = new Size(248, 28);
            cmbPortas.TabIndex = 2;
            // 
            // txtReceber
            // 
            txtReceber.Enabled = false;
            txtReceber.Location = new Point(14, 92);
            txtReceber.Margin = new Padding(3, 4, 3, 4);
            txtReceber.Multiline = true;
            txtReceber.Name = "txtReceber";
            txtReceber.ReadOnly = true;
            txtReceber.ScrollBars = ScrollBars.Vertical;
            txtReceber.Size = new Size(257, 395);
            txtReceber.TabIndex = 4;
            // 
            // tmrPortas
            // 
            tmrPortas.Interval = 1000;
            // 
            // grpLeds
            // 
            grpLeds.Controls.Add(checkBox3);
            grpLeds.Controls.Add(checkBox2);
            grpLeds.Controls.Add(checkBox1);
            grpLeds.Enabled = false;
            grpLeds.Location = new Point(277, 53);
            grpLeds.Name = "grpLeds";
            grpLeds.Size = new Size(104, 105);
            grpLeds.TabIndex = 5;
            grpLeds.TabStop = false;
            grpLeds.Text = "LEDS";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(6, 68);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(65, 24);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "LED3";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(6, 48);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(65, 24);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "LED2";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 27);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(65, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "LED1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 505);
            Controls.Add(grpLeds);
            Controls.Add(txtReceber);
            Controls.Add(cmbPortas);
            Controls.Add(btnPotenciometro);
            Controls.Add(btnConectar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grpLeds.ResumeLayout(false);
            grpLeds.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConectar;
        private Button btnPotenciometro;
        private ComboBox cmbPortas;
        private TextBox txtReceber;
        private System.Windows.Forms.Timer tmrPortas;
        private GroupBox grpLeds;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
    }
}
