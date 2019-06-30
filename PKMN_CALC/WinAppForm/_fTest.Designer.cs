namespace PKMN_CALC.WinAppForm
{
    partial class _fTest
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.button12 = new System.Windows.Forms.Button();
            this.cboMaster = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "RELOAD";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "てすとList";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "てすとLinq";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "てすとjson";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "てすとjsonsave";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 190);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "てすとxmlsave";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 12;
            this.lbLog.Items.AddRange(new object[] {
            "---Log---"});
            this.lbLog.Location = new System.Drawing.Point(116, 12);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(383, 64);
            this.lbLog.TabIndex = 7;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 219);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "てすとLinq2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(13, 258);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Calcタイプ相性";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(12, 288);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(89, 33);
            this.button9.TabIndex = 10;
            this.button9.Text = "わざマスタバインド";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(12, 327);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(89, 37);
            this.button10.TabIndex = 11;
            this.button10.Text = "わざマスタ編集終了";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(13, 370);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(88, 23);
            this.button11.TabIndex = 12;
            this.button11.Text = "Calcステータス";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(142, 92);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 21;
            this.dgv1.Size = new System.Drawing.Size(1430, 881);
            this.dgv1.TabIndex = 13;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(12, 418);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(101, 35);
            this.button12.TabIndex = 14;
            this.button12.Text = "test12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // cboMaster
            // 
            this.cboMaster.FormattingEnabled = true;
            this.cboMaster.Location = new System.Drawing.Point(519, 53);
            this.cboMaster.Name = "cboMaster";
            this.cboMaster.Size = new System.Drawing.Size(121, 20);
            this.cboMaster.TabIndex = 15;
            this.cboMaster.SelectedIndexChanged += new System.EventHandler(this.cboMaster_SelectedIndexChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(665, 17);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(142, 23);
            this.btn_save.TabIndex = 16;
            this.btn_save.Text = "jsonSAVE";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(665, 50);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(142, 23);
            this.btn_Load.TabIndex = 17;
            this.btn_Load.Text = "jsonLOAD";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // _fTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 985);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cboMaster);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "_fTest";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ComboBox cboMaster;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_Load;
    }
}

