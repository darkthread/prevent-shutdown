using System.Runtime.InteropServices;

namespace prevent_shutdown;
//https://www.meziantou.net/prevent-windows-shutdown-or-session-ending-in-dotnet.htm
public partial class Form1 : Form
{
    public const int WM_QUERYENDSESSION = 0x0011;
    public const int WM_ENDSESSION = 0x0016;
    public const uint SHUTDOWN_NORETRY = 0x00000001;

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool ShutdownBlockReasonDestroy(IntPtr hWnd);
    [DllImport("kernel32.dll")]
    static extern bool SetProcessShutdownParameters(uint dwLevel, uint dwFlags);
    public Form1()
    {
        InitializeComponent();
        // Define the priority of the application (0x3FF = The higher priority)
        SetProcessShutdownParameters(0x3FF, SHUTDOWN_NORETRY);
        timer1_Tick(null!, null!);
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION)
        {
            if (!ReadyForShutdown()) return;
        }
        base.WndProc(ref m);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
    }

    CancellationTokenSource _cts = null;
    private int _countDown = -1;
    private bool InCountDown => _countDown > -1;
    private bool _done = false;

    private bool ReadyForShutdown()
    {
        if (_done) return true;
        if (InCountDown) return false;
        // Prevent windows shutdown
        ShutdownBlockReasonCreate(this.Handle, "休蛋幾壘，不打下班卡逆？" +
                             (cbxAuto.Checked ? "自動打卡中..." : string.Empty));
        if (!cbxAuto.Checked) return false;
        StartCountDown();
        Task.Run(async () =>
        {
            while (_countDown-- > 0 && !_cts.Token.IsCancellationRequested)
            {
                this.BeginInvoke(UpdatePunchOutBtn);
                await Task.Delay(1000);
            }
            if (_cts.Token.IsCancellationRequested) return;
            this.BeginInvoke(() =>
            {
                PunchOut();
                ShutdownBlockReasonCreate(this.Handle, "自動打卡完成。");
                ShutdownBlockReasonDestroy(this.Handle);
                this.Close();
            });
        }, _cts.Token);
        return false;
    }

    void StartCountDown()
    {
        _cts = new CancellationTokenSource();
        lblStatus.Text = @"自動打卡中...";
        _countDown = 15;
        UpdatePunchOutBtn();
    }
    void StopCountDown()
    {
        _cts.Cancel();
        lblStatus.Text = @"自動打卡已取消";
        _countDown = -1;
        UpdatePunchOutBtn();
    }
    void UpdatePunchOutBtn()
    {
        btnPunchOut.Text = _countDown == -1 ? "打卡下班" : $"取消({_countDown})";
    }

    void PunchOut()
    {
        lblStatus.ForeColor = Color.Green;
        lblStatus.Text = $@"於{DateTime.Now:HH:mm:ss}打卡下班";
        _done = true;
    }

    private void btnPunchOut_Click(object sender, EventArgs e)
    {
        if (InCountDown) StopCountDown(); else PunchOut();
    }

    // 模疑觸發關機事件，方便測試
    private void lblTime_DoubleClick(object sender, EventArgs e)
        => ReadyForShutdown();
}
