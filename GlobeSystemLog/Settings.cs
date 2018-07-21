using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace GlobeSystemLog
{
    class Settings
    {
        PathSettings oPath = new PathSettings();
		public string[] FileExtensionList = { "*.frm", "*.cls", "*.bas" };

		public Settings()
        {
        }

        public void WriteJsonFile()
        {
            using (StreamWriter file = File.CreateText(oPath.SettingFilename))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(file, oPath);
            }
        }

        public string ReadJsonFile()
        {
            string sFileContent = "";

            if (File.Exists(oPath.SettingFilename))
            {
                using (StreamReader file = new StreamReader(oPath.SettingFilename))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        sFileContent = line + '\n';
                    }
                }
            }
            return sFileContent;
        }

        public PathSettings GetSettingsFromFile()
        {
            string json = ReadJsonFile();
            PathSettings filePath = JsonConvert.DeserializeObject<PathSettings>(json);

            try
            {
                // Check if saved path exists
                if (filePath != null)
                {
                    if (Directory.Exists(filePath.TargetFolder))
                    {
                        oPath.TargetFolder = filePath.TargetFolder;
                        oPath.LogFilename = filePath.LogFilename;
                        return oPath;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error {0}", ex.Message);
            }

            return oPath;
        }

        public void WriteVBLoggerFile()
        {
            string basFilename = Path.Combine(Directory.GetCurrentDirectory(), "GLBSysLog.bas");
            string newFileDateFormat = "dd-MMM-yyyy";
            string editFilename = string.Format(@"log_path = ""{0}"" + Format(Now, ""{1}"") + "".log"" ", oPath.LogFilename, newFileDateFormat);

            string logFileCommented = "";
            string dbgViewCommented = "";

            if (oPath.EnableOutputDebugView == false)
            {
                dbgViewCommented = string.Format("\'");
            }

            if (oPath.EnableOutputLog == false)
            {
                logFileCommented = string.Format("\'");
            }

            //
            // Output to GLBSysLog.bas file : Lines commented out for unselected output option
            //
            string[] lines = {
                "Option Explicit",
                dbgViewCommented + "Private Declare Sub OutputDebugString Lib \"kernel32\" Alias \"OutputDebugStringA\"(ByVal lpOutputString As String) \n",
                "Public Function ESysLogger(targetName As String, fileName As String, status As String, funcName As String)",
                dbgViewCommented + "\t" + "OutputDebugString(targetName + \" \" + fileName + \" \" + status + \" \" + funcName)\n",
                logFileCommented + "\tDim log_path As String, content As String",
                logFileCommented + "\tDim lngFileHandle As Long: lngFileHandle = FreeFile\n",
                logFileCommented + "\t" + editFilename + "\n",
                logFileCommented + "\tcontent = content + Format(Now, \"dd-MMM-yyyy HH:nn:ss\") &\".\" & Right(Format(Timer, \"#0.00\"), 2)",
                logFileCommented + "\tcontent = content + \" \" + targetName + \" \" + fileName + \" \" + status + \" \" + funcName\n",
                logFileCommented + "\tlngFileHandle = FreeFile",
                logFileCommented + "\tOpen log_path For Append As lngFileHandle",
                logFileCommented + "\tPrint #lngFileHandle, content",
                logFileCommented + "\tClose lngFileHandle",
                "End Function",
            };
            File.WriteAllLines(basFilename, lines);
        }
    }

    class PathSettings
    {
        public string TargetFolder { get; set; }
        public string LogFilename { get; set; }
        public string SettingFilename { get; set; }
        public bool EnableOutputLog { get; set; }
        public bool EnableOutputDebugView { get; set; }

        public PathSettings()
        {
            TargetFolder = "C:\\";
            LogFilename = "GLBSysLog";
            SettingFilename = Path.Combine(Directory.GetCurrentDirectory(), "settings.json");

            EnableOutputDebugView = false;
            EnableOutputLog = false;
        }
    }
}

