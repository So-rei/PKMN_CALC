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
            this.lbLog = new System.Windows.Forms.ListBox();
            this.button11 = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.cboMaster = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnGoro = new System.Windows.Forms.Button();
            this.txtgoro = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGoroCnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "RELOAD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
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
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(13, 142);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(88, 23);
            this.button11.TabIndex = 12;
            this.button11.Text = "Calcステータス";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // dgv1
            // 
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(246, 92);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 21;
            this.dgv1.Size = new System.Drawing.Size(1445, 881);
            this.dgv1.TabIndex = 13;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 314);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnGoro
            // 
            this.btnGoro.Location = new System.Drawing.Point(54, 77);
            this.btnGoro.Name = "btnGoro";
            this.btnGoro.Size = new System.Drawing.Size(75, 23);
            this.btnGoro.TabIndex = 20;
            this.btnGoro.Text = "calc!";
            this.btnGoro.UseVisualStyleBackColor = true;
            this.btnGoro.Click += new System.EventHandler(this.btnGoro_Click);
            // 
            // txtgoro
            // 
            this.txtgoro.Location = new System.Drawing.Point(6, 18);
            this.txtgoro.Name = "txtgoro";
            this.txtgoro.Size = new System.Drawing.Size(171, 19);
            this.txtgoro.TabIndex = 21;
            this.txtgoro.Text = "ノーザン";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGoroCnt);
            this.groupBox1.Controls.Add(this.btnGoro);
            this.groupBox1.Controls.Add(this.txtgoro);
            this.groupBox1.Location = new System.Drawing.Point(13, 487);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 106);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "語呂";
            // 
            // txtGoroCnt
            // 
            this.txtGoroCnt.Location = new System.Drawing.Point(24, 49);
            this.txtGoroCnt.Name = "txtGoroCnt";
            this.txtGoroCnt.Size = new System.Drawing.Size(45, 19);
            this.txtGoroCnt.TabIndex = 23;
            this.txtGoroCnt.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "匹で語呂合わせ";
            // 
            // _fTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1703, 985);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cboMaster);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.button1);
            this.Name = "_fTest";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.ComboBox cboMaster;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnGoro;
        private System.Windows.Forms.TextBox txtgoro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGoroCnt;
        private System.Windows.Forms.Label label1;
    }
}

