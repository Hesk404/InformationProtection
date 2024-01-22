namespace ClientForm
{
    partial class Client
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
            label1 = new Label();
            textBox_p = new TextBox();
            textBox_q = new TextBox();
            label2 = new Label();
            textBox_n = new TextBox();
            label3 = new Label();
            textBox_fi = new TextBox();
            label4 = new Label();
            textBox_e = new TextBox();
            label5 = new Label();
            textBox_d = new TextBox();
            label6 = new Label();
            textBox_publicKey = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBox_secretKey = new TextBox();
            button_generateKeys = new Button();
            button_loadKeys = new Button();
            openFileDialog1 = new OpenFileDialog();
            button_sigFile = new Button();
            button_checkSig = new Button();
            textBox_hash = new TextBox();
            label9 = new Label();
            label10 = new Label();
            textBox_sig = new TextBox();
            saveFileDialog1 = new SaveFileDialog();
            label11 = new Label();
            textBox_sigDecipher = new TextBox();
            button_saveKeys = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 0;
            label1.Text = "p";
            // 
            // textBox_p
            // 
            textBox_p.Location = new Point(12, 27);
            textBox_p.Multiline = true;
            textBox_p.Name = "textBox_p";
            textBox_p.ReadOnly = true;
            textBox_p.ScrollBars = ScrollBars.Vertical;
            textBox_p.Size = new Size(249, 83);
            textBox_p.TabIndex = 1;
            // 
            // textBox_q
            // 
            textBox_q.Location = new Point(12, 134);
            textBox_q.Multiline = true;
            textBox_q.Name = "textBox_q";
            textBox_q.ReadOnly = true;
            textBox_q.ScrollBars = ScrollBars.Vertical;
            textBox_q.Size = new Size(249, 83);
            textBox_q.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 116);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 2;
            label2.Text = "q";
            // 
            // textBox_n
            // 
            textBox_n.Location = new Point(12, 238);
            textBox_n.Multiline = true;
            textBox_n.Name = "textBox_n";
            textBox_n.ReadOnly = true;
            textBox_n.ScrollBars = ScrollBars.Vertical;
            textBox_n.Size = new Size(249, 83);
            textBox_n.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 220);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 4;
            label3.Text = "n";
            // 
            // textBox_fi
            // 
            textBox_fi.Location = new Point(12, 345);
            textBox_fi.Multiline = true;
            textBox_fi.Name = "textBox_fi";
            textBox_fi.ReadOnly = true;
            textBox_fi.ScrollBars = ScrollBars.Vertical;
            textBox_fi.Size = new Size(249, 83);
            textBox_fi.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 327);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 6;
            label4.Text = "fi(n)";
            // 
            // textBox_e
            // 
            textBox_e.Location = new Point(12, 450);
            textBox_e.Multiline = true;
            textBox_e.Name = "textBox_e";
            textBox_e.ReadOnly = true;
            textBox_e.Size = new Size(249, 26);
            textBox_e.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 432);
            label5.Name = "label5";
            label5.Size = new Size(13, 15);
            label5.TabIndex = 8;
            label5.Text = "e";
            // 
            // textBox_d
            // 
            textBox_d.Location = new Point(12, 500);
            textBox_d.Multiline = true;
            textBox_d.Name = "textBox_d";
            textBox_d.ReadOnly = true;
            textBox_d.ScrollBars = ScrollBars.Vertical;
            textBox_d.Size = new Size(249, 83);
            textBox_d.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 482);
            label6.Name = "label6";
            label6.Size = new Size(14, 15);
            label6.TabIndex = 10;
            label6.Text = "d";
            // 
            // textBox_publicKey
            // 
            textBox_publicKey.Location = new Point(287, 27);
            textBox_publicKey.Multiline = true;
            textBox_publicKey.Name = "textBox_publicKey";
            textBox_publicKey.ReadOnly = true;
            textBox_publicKey.ScrollBars = ScrollBars.Vertical;
            textBox_publicKey.Size = new Size(181, 259);
            textBox_publicKey.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(287, 9);
            label7.Name = "label7";
            label7.Size = new Size(106, 15);
            label7.TabIndex = 12;
            label7.Text = "Публичный ключ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(518, 9);
            label8.Name = "label8";
            label8.Size = new Size(96, 15);
            label8.TabIndex = 14;
            label8.Text = "Закрытый ключ";
            // 
            // textBox_secretKey
            // 
            textBox_secretKey.Location = new Point(518, 27);
            textBox_secretKey.Multiline = true;
            textBox_secretKey.Name = "textBox_secretKey";
            textBox_secretKey.ReadOnly = true;
            textBox_secretKey.ScrollBars = ScrollBars.Vertical;
            textBox_secretKey.Size = new Size(181, 259);
            textBox_secretKey.TabIndex = 15;
            // 
            // button_generateKeys
            // 
            button_generateKeys.Location = new Point(287, 298);
            button_generateKeys.Name = "button_generateKeys";
            button_generateKeys.Size = new Size(181, 23);
            button_generateKeys.TabIndex = 16;
            button_generateKeys.Text = "Сгенерировать ключи";
            button_generateKeys.UseVisualStyleBackColor = true;
            button_generateKeys.Click += button_generateKeys_Click;
            // 
            // button_loadKeys
            // 
            button_loadKeys.Location = new Point(518, 298);
            button_loadKeys.Name = "button_loadKeys";
            button_loadKeys.Size = new Size(181, 23);
            button_loadKeys.TabIndex = 17;
            button_loadKeys.Text = "Загрузить ключи";
            button_loadKeys.UseVisualStyleBackColor = true;
            button_loadKeys.Click += button_loadKeys_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_sigFile
            // 
            button_sigFile.Location = new Point(287, 356);
            button_sigFile.Name = "button_sigFile";
            button_sigFile.Size = new Size(181, 23);
            button_sigFile.TabIndex = 18;
            button_sigFile.Text = "Подписать файл";
            button_sigFile.UseVisualStyleBackColor = true;
            button_sigFile.Click += button_sigFile_Click;
            // 
            // button_checkSig
            // 
            button_checkSig.Location = new Point(517, 356);
            button_checkSig.Name = "button_checkSig";
            button_checkSig.Size = new Size(181, 23);
            button_checkSig.TabIndex = 19;
            button_checkSig.Text = "Проверить подпись";
            button_checkSig.UseVisualStyleBackColor = true;
            button_checkSig.Click += button_checkSig_Click;
            // 
            // textBox_hash
            // 
            textBox_hash.Location = new Point(288, 413);
            textBox_hash.Multiline = true;
            textBox_hash.Name = "textBox_hash";
            textBox_hash.ReadOnly = true;
            textBox_hash.ScrollBars = ScrollBars.Vertical;
            textBox_hash.Size = new Size(411, 63);
            textBox_hash.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(288, 395);
            label9.Name = "label9";
            label9.Size = new Size(69, 15);
            label9.TabIndex = 21;
            label9.Text = "Хэш файла";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(287, 502);
            label10.Name = "label10";
            label10.Size = new Size(93, 15);
            label10.TabIndex = 23;
            label10.Text = "Подпись файла";
            // 
            // textBox_sig
            // 
            textBox_sig.Location = new Point(287, 520);
            textBox_sig.Multiline = true;
            textBox_sig.Name = "textBox_sig";
            textBox_sig.ReadOnly = true;
            textBox_sig.ScrollBars = ScrollBars.Vertical;
            textBox_sig.Size = new Size(411, 63);
            textBox_sig.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(287, 594);
            label11.Name = "label11";
            label11.Size = new Size(192, 15);
            label11.TabIndex = 25;
            label11.Text = "Расшифрованная подпись файла";
            // 
            // textBox_sigDecipher
            // 
            textBox_sigDecipher.Location = new Point(287, 612);
            textBox_sigDecipher.Multiline = true;
            textBox_sigDecipher.Name = "textBox_sigDecipher";
            textBox_sigDecipher.ReadOnly = true;
            textBox_sigDecipher.ScrollBars = ScrollBars.Vertical;
            textBox_sigDecipher.Size = new Size(411, 63);
            textBox_sigDecipher.TabIndex = 24;
            // 
            // button_saveKeys
            // 
            button_saveKeys.Location = new Point(401, 327);
            button_saveKeys.Name = "button_saveKeys";
            button_saveKeys.Size = new Size(180, 23);
            button_saveKeys.TabIndex = 26;
            button_saveKeys.Text = "Сохранить ключи";
            button_saveKeys.UseVisualStyleBackColor = true;
            button_saveKeys.Click += button_saveKeys_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 687);
            Controls.Add(button_saveKeys);
            Controls.Add(label11);
            Controls.Add(textBox_sigDecipher);
            Controls.Add(label10);
            Controls.Add(textBox_sig);
            Controls.Add(label9);
            Controls.Add(textBox_hash);
            Controls.Add(button_checkSig);
            Controls.Add(button_sigFile);
            Controls.Add(button_loadKeys);
            Controls.Add(button_generateKeys);
            Controls.Add(textBox_secretKey);
            Controls.Add(label8);
            Controls.Add(textBox_publicKey);
            Controls.Add(label7);
            Controls.Add(textBox_d);
            Controls.Add(label6);
            Controls.Add(textBox_e);
            Controls.Add(label5);
            Controls.Add(textBox_fi);
            Controls.Add(label4);
            Controls.Add(textBox_n);
            Controls.Add(label3);
            Controls.Add(textBox_q);
            Controls.Add(label2);
            Controls.Add(textBox_p);
            Controls.Add(label1);
            Name = "Form1";
            Text = "ЭЦП (SHA256 + RSA)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_p;
        private TextBox textBox_q;
        private Label label2;
        private TextBox textBox_n;
        private Label label3;
        private TextBox textBox_fi;
        private Label label4;
        private TextBox textBox_e;
        private Label label5;
        private TextBox textBox_d;
        private Label label6;
        private TextBox textBox_publicKey;
        private Label label7;
        private Label label8;
        private TextBox textBox_secretKey;
        private Button button_generateKeys;
        private Button button_loadKeys;
        private OpenFileDialog openFileDialog1;
        private Button button_sigFile;
        private Button button_checkSig;
        private TextBox textBox_hash;
        private Label label9;
        private Label label10;
        private TextBox textBox_sig;
        private SaveFileDialog saveFileDialog1;
        private Label label11;
        private TextBox textBox_sigDecipher;
        private Button button_saveKeys;
    }
}