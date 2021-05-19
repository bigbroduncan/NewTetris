namespace NewTetris {
  partial class FrmMain {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label2 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpNextBlock = new System.Windows.Forms.GroupBox();
            this.tmrCurrentPieceFall = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPlayingField = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(48, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Level:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblLevel.Location = new System.Drawing.Point(145, 165);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(25, 25);
            this.lblLevel.TabIndex = 10;
            this.lblLevel.Text = "1";
            this.lblLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(48, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Next Block:";
            // 
            // grpNextBlock
            // 
            this.grpNextBlock.BackColor = System.Drawing.Color.DimGray;
            this.grpNextBlock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpNextBlock.Location = new System.Drawing.Point(186, 231);
            this.grpNextBlock.Name = "grpNextBlock";
            this.grpNextBlock.Size = new System.Drawing.Size(120, 120);
            this.grpNextBlock.TabIndex = 13;
            this.grpNextBlock.TabStop = false;
            // 
            // tmrCurrentPieceFall
            // 
            this.tmrCurrentPieceFall.Enabled = true;
            this.tmrCurrentPieceFall.Interval = 500;
            this.tmrCurrentPieceFall.Tick += new System.EventHandler(this.tmrCurrentPieceFall_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(48, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Score:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(145, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "0";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Terminator Two", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(515, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "Almost Tetris";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblPlayingField
            // 
            this.lblPlayingField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPlayingField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPlayingField.Image = ((System.Drawing.Image)(resources.GetObject("lblPlayingField.Image")));
            this.lblPlayingField.Location = new System.Drawing.Point(397, 89);
            this.lblPlayingField.Name = "lblPlayingField";
            this.lblPlayingField.Size = new System.Drawing.Size(450, 660);
            this.lblPlayingField.TabIndex = 7;
            this.lblPlayingField.Click += new System.EventHandler(this.lblPlayingField_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1183, 803);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpNextBlock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPlayingField);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblPlayingField;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblLevel;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox grpNextBlock;
    private System.Windows.Forms.Timer tmrCurrentPieceFall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

