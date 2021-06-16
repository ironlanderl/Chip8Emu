
namespace Chip8Emu
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPixel = new System.Windows.Forms.Button();
            this.pcbSchermo = new System.Windows.Forms.PictureBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TestopCode = new System.Windows.Forms.Button();
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.tmrAudio = new System.Windows.Forms.Timer(this.components);
            this.lblDebug = new System.Windows.Forms.Label();
            this.tmrDebug = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcbSchermo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPixel
            // 
            this.btnPixel.Location = new System.Drawing.Point(13, 415);
            this.btnPixel.Name = "btnPixel";
            this.btnPixel.Size = new System.Drawing.Size(96, 23);
            this.btnPixel.TabIndex = 0;
            this.btnPixel.Text = "Random Pixel";
            this.btnPixel.UseVisualStyleBackColor = true;
            this.btnPixel.Click += new System.EventHandler(this.btnPixel_Click);
            // 
            // pcbSchermo
            // 
            this.pcbSchermo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbSchermo.Location = new System.Drawing.Point(13, 12);
            this.pcbSchermo.Name = "pcbSchermo";
            this.pcbSchermo.Size = new System.Drawing.Size(100, 100);
            this.pcbSchermo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbSchermo.TabIndex = 1;
            this.pcbSchermo.TabStop = false;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(629, 266);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(159, 172);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(115, 415);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Pulisci";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(523, 394);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // TestopCode
            // 
            this.TestopCode.Location = new System.Drawing.Point(523, 415);
            this.TestopCode.Name = "TestopCode";
            this.TestopCode.Size = new System.Drawing.Size(75, 23);
            this.TestopCode.TabIndex = 5;
            this.TestopCode.Text = "button1";
            this.TestopCode.UseVisualStyleBackColor = true;
            this.TestopCode.Click += new System.EventHandler(this.TestopCode_Click);
            // 
            // tmrDelay
            // 
            this.tmrDelay.Interval = 16;
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(626, 12);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(35, 13);
            this.lblDebug.TabIndex = 6;
            this.lblDebug.Text = "label1";
            // 
            // tmrDebug
            // 
            this.tmrDebug.Enabled = true;
            this.tmrDebug.Tick += new System.EventHandler(this.tmrDebug_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.TestopCode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.pcbSchermo);
            this.Controls.Add(this.btnPixel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pcbSchermo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPixel;
        private System.Windows.Forms.PictureBox pcbSchermo;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button TestopCode;
        private System.Windows.Forms.Timer tmrDelay;
        private System.Windows.Forms.Timer tmrAudio;
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.Timer tmrDebug;
    }
}

