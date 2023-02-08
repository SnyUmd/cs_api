using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using MauiCtrl;

namespace MauiPost.Classes
{
    class ClsCommon
    {
        public const string FileNameBody = "Body.json"; 
        public static string CurrentDir = SystemCtrl.GetCurrentDir();
        public static bool BlJson = false;

        public static JsonNode JnBodysValue;

        public static void Init()
        {
            BlJson = FileCtrl.FindFile(CurrentDir, FileNameBody);
            if (!BlJson)
            {
                BlJson = FileCtrl.CreateFile(CurrentDir, FileNameBody);
                if(BlJson) Console.WriteLine(FileCtrl.WriteFile(CurrentDir, FileNameBody, "{\r\n\t\"value\":\"{}\"\r\n}", false));
            }
            Console.WriteLine(FileCtrl.ReadFile(CurrentDir, FileNameBody));
        }
    }
}
