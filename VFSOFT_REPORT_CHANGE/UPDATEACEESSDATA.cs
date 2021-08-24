using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VFSOFT_REPORT_CHANGE
{
    class UPDATEACEESSDATA
    {
        private bool CheckConnection()
        {
            if (OpenAccess.OLEDB == null)
            {
                return false;//连接关闭或者没打开
            }
            else
            {
                return true;//连接被打开
            }
        }
        public void StartChange()
        {
            if (CheckConnection())
            {
                int ReportID = Int32.Parse(MainForm.M_Frm.Report_DataView.SelectedRows[0].Cells[0].Value.ToString());//当前选择的报表ID
                string ItemKind = MainForm.M_Frm.ItemReverseBox.SelectedItem.ToString();
                int ItemKindId = MainForm.M_Frm.ItemReverseBox.SelectedIndex;
                int PeopleKind_Select_Id = MainForm.M_Frm.FillPepoleKindBox.SelectedIndex;
                string SQLSEACHSTR = $"select content from report_detail where content like '%Raid=%' and reportid={ReportID}";//寻找报表格式
                OleDbDataAdapter OLDA = new OleDbDataAdapter(SQLSEACHSTR, OpenAccess.OLEDB);
                DataSet DataCache = new DataSet();
                OLDA.Fill(DataCache, "TempSqlStr");
                DialogResult BoxResult = MessageBox.Show("确认要修改报表内容吗,此操作将无法恢复", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (BoxResult)
                {
                    case DialogResult.Yes:
                        MainForm.M_Frm.ProcessBar.Visible = true;
                        if (  ItemKindId > 0 & PeopleKind_Select_Id == 0)//只修改计算项，不修改测评主体
                        {
                            Task<int> Only_ChangeKind_Result = Task.Factory.StartNew<int>(() => OnlyChangeKind(DataCache, ItemKind, ReportID));
                            if (Only_ChangeKind_Result.Result == 0)
                            {
                                MessageBox.Show("修改完毕，请打开考评系统进行查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainForm.M_Frm.ProcessBar.Value = 0;
                            }
                            else
                            {
                                MessageBox.Show("报表中没有找到任何数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        else if (ItemKindId == 0 && PeopleKind_Select_Id > 0)//不修改计算项，只修改测评主体
                        {
                            Task<int> Only_ChangeRaid_Result = Task.Factory.StartNew<int>(() => OnlyChangeRaid(DataCache, PeopleKind_Select_Id, ReportID));
                            if (Only_ChangeRaid_Result.Result == 0)
                            {
                                MessageBox.Show("修改完毕，请打开考评系统进行查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainForm.M_Frm.ProcessBar.Value = 0;
                            }
                            else
                            {
                                MessageBox.Show("报表中没有找到任何数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (ItemKindId == 0 & PeopleKind_Select_Id == 0)
                        {
                            MessageBox.Show("你TM故意找茬是不是！？", "。。。", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else//测评主体和计算项都更改
                        {
                            Task<int> Only_ChangeKind_Result = Task.Factory.StartNew<int>(() => OnlyChangeKind(DataCache, ItemKind, ReportID));
                            Task<int> ChangeKindRaid_Result = Task.Factory.StartNew<int>(() => ChangeKindAndRaid(DataCache, PeopleKind_Select_Id, ReportID));
                            if (Only_ChangeKind_Result.Result == 0 & ChangeKindRaid_Result.Result == 0)
                            {
                                MessageBox.Show("修改完毕，请打开考评系统进行查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainForm.M_Frm.ProcessBar.Value = 0;
                            }
                            else
                            {
                                MessageBox.Show("报表中没有找到任何数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }


            }
            else
            {
                MessageBox.Show("请先加载数据库", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private int OnlyChangeKind(DataSet DataCache, string ItemKind, int ReportID)// 不修改评测主体 / 没有评测主体的情况
        {
            // 不修改评测主体 / 没有评测主体的情况
                string RegexStr = @"Kind\D.+?(?=&vftab)";//匹配Kind
                Regex REgexClass_Kind = new Regex(RegexStr);
                ArrayList RaidArray = new ArrayList();
                if (DataCache.Tables["TempSqlStr"]?.Rows != null)
                {
                    MainForm.M_Frm.ProcessBar.Maximum = DataCache.Tables["TempSqlStr"].Rows.Count;
                foreach (DataRow _DataRow in DataCache.Tables["TempSqlStr"].Rows)
                    {
                        MatchCollection MC_Raid = REgexClass_Kind.Matches(_DataRow[0].ToString());
                        RaidArray.Add(MC_Raid[0].ToString());
                    }
                    foreach (string MatchRaidStr in RaidArray)
                    {
                        string NewUpdateStr_Kind = $"update report_detail set content=Replace(content,'{MatchRaidStr}','Kind={ItemKind}') where reportid={ReportID}";
                        OleDbCommand OC_Raid = new OleDbCommand(NewUpdateStr_Kind, OpenAccess.OLEDB);
                        OC_Raid.ExecuteNonQuery();
                        MainForm.M_Frm.ProcessBar.PerformStep();
                     }
                    return 0;
                }
                else
                {
                    return 1;
                }
        }

        private int ChangeKindAndRaid(DataSet DataCache, int PeopleKind_Select_Id, int ReportID)//修改评测主体
        {
            string RegexStr_Raid = @"Raid=.+(?=vftab;ReserveDec)";
            Regex REgexClass_Raid = new Regex(RegexStr_Raid);
            ArrayList RaidArray = new ArrayList();
            if (DataCache.Tables["TempSqlStr"]?.Rows != null)
            {
                MainForm.M_Frm.ProcessBar.Maximum = DataCache.Tables["TempSqlStr"].Rows.Count;
                foreach (DataRow _DataRow in DataCache.Tables["TempSqlStr"].Rows)
                {
                    MatchCollection MC_Raid = REgexClass_Raid.Matches(_DataRow[0].ToString());
                    RaidArray.Add(MC_Raid[0].ToString());
                }
                foreach (string MatchRaidStr in RaidArray)
                {
                    string NewUpdateStr_Raid = $"update report_detail set content=Replace(content,'{MatchRaidStr}','Raid={MainForm.M_Frm.FillPepoleKindBox.Items[PeopleKind_Select_Id]}&') where reportid={ReportID}";
                    OleDbCommand OC_Raid = new OleDbCommand(NewUpdateStr_Raid, OpenAccess.OLEDB);
                    OC_Raid.ExecuteNonQuery();
                    MainForm.M_Frm.ProcessBar.PerformStep();
                }
                return 0;
            }
            else
            {
                return 1;
            }

        }
        private int OnlyChangeRaid(DataSet DataCache, int PeopleKind_Select_Id, int ReportID)//不修改计算项
        {
            string Raid_Regex = @"Raid=.+(?=vftab;ReserveDec)";
            Regex REgexClass_Raid = new Regex(Raid_Regex);
            ArrayList RaidArray = new ArrayList();
            if (DataCache.Tables["TempSqlStr"]?.Rows != null)
            {
                MainForm.M_Frm.ProcessBar.Maximum = DataCache.Tables["TempSqlStr"].Rows.Count;
                foreach (DataRow _DataRow in DataCache.Tables["TempSqlStr"].Rows)
                {
                    MatchCollection MC_Raid = REgexClass_Raid.Matches(_DataRow[0].ToString());
                    RaidArray.Add(MC_Raid[0].ToString());
                }
                foreach (string MatchRaidStr in RaidArray)
                {
                    string NewUpdateStr_Raid = $"update report_detail set content=Replace(content,'{MatchRaidStr}','Raid={MainForm.M_Frm.FillPepoleKindBox.Items[PeopleKind_Select_Id]}&') where reportid={ReportID}";
                    OleDbCommand OC_Raid = new OleDbCommand(NewUpdateStr_Raid, OpenAccess.OLEDB);
                    OC_Raid.ExecuteNonQuery();
                    MainForm.M_Frm.ProcessBar.PerformStep();
                }
                return 0;
            }
            else
            {
                return 1;
            }
        }//最终版本
    }
}
