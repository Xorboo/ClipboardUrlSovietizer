using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;


namespace ClipboardUrlSovietizer
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        static extern int ShowWindow(IntPtr hWnd, uint Msg);
        const uint SW_RESTORE = 0x09;


        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


        IntPtr NextClipboardViewer;
        Regex UrlRegEx = new Regex(@"http://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?", RegexOptions.IgnoreCase);


        #region Form Callbacks
        public frmMain(bool startMinimized)
        {
            InitializeComponent();

            NextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);

            if (startMinimized)
                this.WindowState = FormWindowState.Minimized;

            UpdateToolstip();
            CheckAutorun();

            Console.WriteLine(WebUtility.UrlDecode("http://google.com/%2fwtf%2f%D0%B0%D0%B0%2f"));
        }
        
        void frmMain_Resize(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Minimized:
                    notifyIconMain.Visible = true;
                    this.Hide();
                    break;

                case FormWindowState.Normal:
                    notifyIconMain.Visible = false;
                    this.Show();
                    break;
            }
        }

        void toolStripOpen_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        void toolStripClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        void btnRemoveAutorun_Click(object sender, EventArgs e)
        {
            UpdateStartup(false);
        }

        void btnAddToAutorun_Click(object sender, EventArgs e)
        {
            UpdateStartup(true);
        }

        void chbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToolstip();
        }

        void toolStripEnabled_Click(object sender, EventArgs e)
        {
            chbEnabled.Checked = !chbEnabled.Checked;
        }
        #endregion


        void ShowForm()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowWindow(this.Handle, SW_RESTORE);
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        void UpdateToolstip()
        {
            toolStripEnabled.Checked = chbEnabled.Checked;
        }

        #region Registry/Autorun
        const string AppName = "Clipboard URL Sovietizer";
        const string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";


        void CheckAutorun()
        {
            bool hasAutorun = IsLaunchingOnStartup;
            UpdateStartupButtons(hasAutorun);
            
            if (!hasAutorun)
            {
                var autorunResult = MessageBox.Show("Add Sovietizer to Autorun?", "Autorun", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                switch (autorunResult)
                {
                    case DialogResult.Yes:
                        UpdateStartup(true);
                        break;
                    case DialogResult.No:
                        //UpdateStartup(false);
                        break;

                    default:
                        Console.WriteLine("WTF? " + autorunResult);
                        break;
                }
            }
        }

        bool IsLaunchingOnStartup
        {
            get
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(RegistryPath, true);
                return rk.GetValue(AppName) != null;
            }
        }

        void UpdateStartup(bool addToStartup)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(RegistryPath, true);

            if (addToStartup)
                rk.SetValue(AppName, Application.ExecutablePath + Program.MinimizedTag);
            else
                rk.DeleteValue(AppName, false);

            UpdateStartupButtons(addToStartup);
        }

        void UpdateStartupButtons(bool startupEnabled)
        {
            btnAddToAutorun.Visible = !startupEnabled;
            btnRemoveAutorun.Visible = startupEnabled;
        }
        #endregion


        #region Clipboard
        protected override void WndProc(ref Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    CheckClipboardData();
                    SendMessage(NextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == NextClipboardViewer)
                        NextClipboardViewer = m.LParam;
                    else
                        SendMessage(NextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        void CheckClipboardData()
        {
            try
            {
                if (!chbEnabled.Checked)
                    return;

                IDataObject iData = new DataObject();
                iData = Clipboard.GetDataObject();

                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string clipboardText = iData.GetData(DataFormats.Text) as string;
                    if (IsUrlString(clipboardText))
                    {
                        string fixedUrl = FixTextUrls(clipboardText);
                        if (fixedUrl != clipboardText)
                        {
                            Clipboard.SetDataObject(fixedUrl);
                            AddLog(DateTime.Now + " -> " + fixedUrl);
                        }
                        else
                            AddLog(DateTime.Now + " -> Same URL");
                    }
                    else
                        AddLog(DateTime.Now + " -> Not URL");
                }
                else
                    AddLog(DateTime.Now + " -> Not Text");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AddLog(string text)
        {
            if (chbLogClipboard.Checked)
                rtbData.Text = text;
        }

        bool IsUrlString(string text)
        {
            return Uri.TryCreate(text, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        string FixTextUrls(string text)
        {
            return FixUrl(text);

            // Can fix multiple URLS if needed
            /*
            MatchCollection mactches = UrlRegEx.Matches(text);
            foreach (Match match in mactches)
            {
                string urlString = match.Value;
                text = text.Replace(urlString, FixUrl(urlString));
            }
            return text;
            */
        }

        string FixUrl(string url)
        {
            return WebUtility.UrlDecode(url);
        }
        #endregion
    }
}
