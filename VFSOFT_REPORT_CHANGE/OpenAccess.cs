/***
 * Autor:PwnInt
 * Time:2021/8/6 15:47:19
 * Name:OpenAccess
 * Ver:1.0
 * Can I Just Say Thank you for being in my Life
 ****/
using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
//打开Access数据库
namespace VFSOFT_REPORT_CHANGE
{
    class OpenAccess
    {
        readonly MainForm M_F = MainForm.M_Frm;
        string AccessConnectStr;
        public static OleDbConnection OLEDB;
        DataTable DTABLE;
        public OpenAccess()//初始化操作
        {
            M_F.OpenAccessFile.Filter = "Access数据库(*.mdb)|*.mdb";
            M_F.OpenAccessFile.Title = "请选择数据库文件";
            M_F.OpenAccessFile.InitialDirectory = new ApplicationInitClass().GetDataBasePath();
            M_F.OpenAccessFile.CheckFileExists = true;
            M_F.OpenAccessFile.CheckPathExists = true;
            M_F.OpenAccessFile.Multiselect = false;
            M_F.OpenAccessFile.RestoreDirectory = false;
            M_F.OpenAccessFile.FileName = "";
            M_F.DataBaseFileLoad.Click += (s, e) => 
            {
                if (OLEDB?.State == ConnectionState.Open)
                {
                    OLEDB.Close();//侦测数据库连接状态，打开则关闭
                }
                ConnectAccess();//按钮事件绑定
                
            };
        }
        private DialogResult OpenDialog()
        {
            return M_F.OpenAccessFile.ShowDialog();
        }
        private string GetAccessFullName()
        {
            switch (OpenDialog())
            {
                case DialogResult.OK:
                    M_F.Text = $"当前选择文件为:{M_F.OpenAccessFile.FileName}";
                    AccessConnectStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={M_F.OpenAccessFile.FileName}";
                    return M_F.OpenAccessFile.FileName;
                case DialogResult.Cancel:
                    AccessConnectStr = string.Empty;
                    return string.Empty;
            }
            return string.Empty;
        }
        private void ConnectAccess()//连接数据库，并展示文件中报表数据
        {
            try
            {
                if (GetAccessFullName() != string.Empty)
                {
                    string Query_Report = "select reportid,reportname from report_ess";
                    OLEDB = new OleDbConnection(AccessConnectStr);
                    OLEDB.Open();
                    OleDbDataAdapter OA = new OleDbDataAdapter(Query_Report,OLEDB);
                    DTABLE = new DataTable();
                    OA.Fill(DTABLE);
                    DTABLE.Columns[0].ColumnName = "报表ID";
                    DTABLE.Columns[1].ColumnName = "报表名称";
                    if (DTABLE.Rows.Count != 0)
                    {
                        M_F.Report_DataView.DataSource = DTABLE;
                    }
                    else
                    {
                        DTABLE.Rows.Clear();
                        M_F.Report_DataView.DataSource = DTABLE;
                        M_F.Text = $"没有选择文件";
                        MessageBox.Show("没有找到报表数据,请重新选择数据库文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        OLEDB.Close();
                        OLEDB = null;//为null防止产生BUG
                    }
                }            
            }
            catch(Exception e)
            {

                if (e.Message.Contains("未在本地计算机"))
                {
                    string Arch_Type = Environment.Is64BitOperatingSystem == true ? "X64" : "X86";
                    MessageBox.Show($"没有安装AccessEngine控件，请安装软件目录下{Arch_Type}文件夹中的控件再尝试加载数据库", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                M_F.Text = "114514";
                OLEDB = null;

            }
            
        }
    }
}
