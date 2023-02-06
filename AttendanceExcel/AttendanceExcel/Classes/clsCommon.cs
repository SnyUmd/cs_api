using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiCtrl;

namespace AttendanceExcel.Classes
{
    internal class clsCommon
    {
        public const string CONFIG_FILE_NAME = "AttendanceExcel.Config";


        public static string ExlName_Header = $"isub_作業報告書_";
        public static string ExlName_UserName = "梅田慎也";

        public static string ExlName
        {
            get
            {
                return ExlName_Header + ExlName_UserName + ".xlsx";
            }
        }

        public static SystemInfomation SystemInfo = new();

        public clsCommon()
        {

        }

        public static bool AttendanceExcelInit()
        {
            SystemInfo.CurrentDir = FileCtrl.GetCurrentDir();
            SystemInfo.Version = SystemCtrl.GetVersion();

            if (!FileCtrl.FindFile(ExlName))
            {

            }
            return FileCtrl.FindFile(ExlName);
        }

    }

    class SystemInfomation
    {
        public string CurrentDir;
        public Version Version;
    }
}
