/***
 * Autor:PwnInt
 * Time:2021/8/6 15:12:37
 * Name:ApplicationInitClass
 * Ver:1.0
 * Can I Just Say Thank you for being in my Life
 ****/
//程序初始化类
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;

namespace VFSOFT_REPORT_CHANGE
{
    interface IFApplicationInitMethod
    {
        string GetAppPath();//获取程序运行目录
        string GetDataBasePath();//获取桌面
    }
    class ApplicationInitClass: IFApplicationInitMethod
    {
        private string AppCurrentPath { get; set; }
        private string NormalPath { get; set; }
        private string VFSOFTRegPath { get; set; }
        public ApplicationInitClass()
        {
            AppCurrentPath = AppDomain.CurrentDomain.BaseDirectory;
            MainForm.M_Frm.Report_DataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            MainForm.M_Frm.Report_DataView.AllowUserToAddRows = false;
            MainForm.M_Frm.Report_DataView.RowHeadersVisible = false;
            MainForm.M_Frm.Report_DataView.MultiSelect = false;
            MainForm.M_Frm.Report_DataView.ReadOnly = true;
            MainForm.M_Frm.Report_DataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            MainForm.M_Frm.ItemReverseBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            MainForm.M_Frm.FillPepoleKindBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            MainForm.M_Frm.ItemReverseBox.SelectedIndex=0;
            MainForm.M_Frm.FillPepoleKindBox.SelectedIndex = 0;
        }
        public string GetAppPath()
        {
            return AppCurrentPath;
        }
        public string GetDataBasePath()
        {
            RegistryKey REK = Registry.LocalMachine?.OpenSubKey(@"SOFTWARE\Wow6432Node\VFSoft\维世迅干部考评系统3");
            VFSOFTRegPath = REK?.GetValue("Path")?.ToString();
            NormalPath = VFSOFTRegPath == null ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop):VFSOFTRegPath + @"仕云欣干部考核推荐系统\Data";
            return NormalPath;
        }
        

    }
}