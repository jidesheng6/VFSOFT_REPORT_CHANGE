using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading.Tasks;

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
                int PeopleKind_Select_Id = MainForm.M_Frm.FillPepoleKindBox.SelectedIndex;
                string SQLSEACHSTR = $"select content from report_detail where content like '%Raid=%' and reportid={ReportID}";//寻找报表格式
                OleDbDataAdapter OLDA = new OleDbDataAdapter(SQLSEACHSTR, OpenAccess.OLEDB);
                DataSet DataCache = new DataSet();
                OLDA.Fill(DataCache, "TempSqlStr");
                DialogResult BoxResult = MessageBox.Show("确认要修改报表内容吗,此操作将无法恢复", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (BoxResult)
                {
                    case DialogResult.Yes:
                        if (PeopleKind_Select_Id == 0)
                        {
                            Task<int> Only_ChangeKind_Result = Task.Factory.StartNew<int>(()=>OnlyChangeKind(DataCache, ItemKind, ReportID));
                            if (Only_ChangeKind_Result.Result== 0)
                            {
                                MessageBox.Show("修改完毕，请打开考评系统进行查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("报表中没有找到任何数据，请重新加载报表", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                OpenAccess.OLEDB = null;
                            }


                        }
                        else
                        {
                            Task<int> Only_ChangeKind_Result = Task.Factory.StartNew<int>(() => OnlyChangeKind(DataCache, ItemKind, ReportID));
                            Task<int> ChangeKindRaid_Result = Task.Factory.StartNew<int>(() => ChangeKindAndRaid(DataCache, PeopleKind_Select_Id, ReportID));
                            if (Only_ChangeKind_Result.Result == 0 & ChangeKindRaid_Result.Result == 0)
                            {
                                MessageBox.Show("修改完毕，请打开考评系统进行查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("报表中没有找到任何数据，请重新加载报表", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                OpenAccess.OLEDB = null;
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
            string RegexStr = @"Kind=.+(?=&vftab;Raid)";//匹配Kind
            string Temp_ChangeSqlStr = DataCache?.Tables["TempSqlStr"]?.Rows[0][0]?.ToString();//取出第一条数据
            if (Temp_ChangeSqlStr != null)
            {
                Regex REgexClass = new Regex(RegexStr);
                MatchCollection MC = REgexClass.Matches(Temp_ChangeSqlStr);
                string NewUpdateStr = $"update report_detail set content=Replace(content,'{MC[0]}','Kind={ItemKind}') where reportid={ReportID}";
                OleDbCommand OC = new OleDbCommand(NewUpdateStr, OpenAccess.OLEDB);
                OC.ExecuteNonQuery();
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
                }
                return 0;
            }
            else
            {
                return 1;
            }

        }
    }
}
