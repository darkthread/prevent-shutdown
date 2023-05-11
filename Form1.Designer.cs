namespace prevent_shutdown;

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
        btnPunchOut = new Button();
        lblTime = new Label();
        lblPunchOutTime = new Label();
        timer1 = new System.Windows.Forms.Timer(components);
        cbxAuto = new CheckBox();
        statusStrip = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // btnPunchOut
        // 
        btnPunchOut.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        btnPunchOut.Location = new Point(100, 6);
        btnPunchOut.Name = "btnPunchOut";
        btnPunchOut.Size = new Size(88, 34);
        btnPunchOut.TabIndex = 0;
        btnPunchOut.Text = "下班打卡";
        btnPunchOut.UseVisualStyleBackColor = true;
        btnPunchOut.Click += btnPunchOut_Click;
        // 
        // lblTime
        // 
        lblTime.AutoSize = true;
        lblTime.BackColor = Color.FromArgb(64, 64, 64);
        lblTime.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        lblTime.ForeColor = Color.Lime;
        lblTime.Location = new Point(12, 11);
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(84, 24);
        lblTime.TabIndex = 1;
        lblTime.Text = "00:00:00";
        lblTime.DoubleClick += lblTime_DoubleClick;
        // 
        // lblPunchOutTime
        // 
        lblPunchOutTime.AutoSize = true;
        lblPunchOutTime.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        lblPunchOutTime.Location = new Point(104, 37);
        lblPunchOutTime.Name = "lblPunchOutTime";
        lblPunchOutTime.Size = new Size(0, 19);
        lblPunchOutTime.TabIndex = 2;
        // 
        // timer1
        // 
        timer1.Enabled = true;
        timer1.Interval = 1000;
        timer1.Tick += timer1_Tick;
        // 
        // cbxAuto
        // 
        cbxAuto.AutoSize = true;
        cbxAuto.Location = new Point(194, 16);
        cbxAuto.Name = "cbxAuto";
        cbxAuto.Size = new Size(98, 19);
        cbxAuto.TabIndex = 3;
        cbxAuto.Text = "登出自動打卡";
        cbxAuto.UseVisualStyleBackColor = true;
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
        statusStrip.Location = new Point(0, 44);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(292, 24);
        statusStrip.TabIndex = 4;
        statusStrip.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        lblStatus.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(99, 19);
        lblStatus.Text = "尚未打下班卡";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(292, 68);
        Controls.Add(statusStrip);
        Controls.Add(cbxAuto);
        Controls.Add(lblPunchOutTime);
        Controls.Add(lblTime);
        Controls.Add(btnPunchOut);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Name = "Form1";
        Text = "模擬打卡程式";
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnPunchOut;
    private Label lblTime;
    private Label lblPunchOutTime;
    private System.Windows.Forms.Timer timer1;
    private CheckBox cbxAuto;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblStatus;
}
