using System;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace VFSOFT_REPORT_CHANGE
{
    public partial class MainForm : Form
    {
        public static MainForm M_Frm;
        public MainForm()
        {
            InitializeComponent();
            M_Frm = this;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new OpenAccess();
            //Assembly ExeAsb = Assembly.GetExecutingAssembly();
            //IWavePlayer WavDevice = new WaveOut();
            //StreamMediaFoundationReader StreamMediaReader = new StreamMediaFoundationReader(ExeAsb.GetManifestResourceStream("VFSOFT_REPORT_CHANGE.MP3.HQ.mp3"));
            //WavDevice.Init(StreamMediaReader);
            //WavDevice.Play();//播放音乐
            //注释的代码演示了如何播放使用Naudio来播放MP3以及C#如何使用嵌入资源文件
        }

        private void StartChangeSql_Click(object sender, EventArgs e)
        {
            M_Frm.ProcessBar.Value = 0;
            new UPDATEACEESSDATA().StartChange();//执行修改
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OpenAccess.OLEDB != null)
            {
                OpenAccess.OLEDB.Close();
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
