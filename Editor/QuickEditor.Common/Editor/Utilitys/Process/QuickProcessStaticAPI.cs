#if UNITY_EDITOR

namespace QuickEditor.Common
{
    using System.Diagnostics;

    public class QuickProcessStaticAPI
    {
        [Conditional("UNITY_EDITOR_WIN")]
        public static void ExecuteNotepadCommand(string args)
        {
            QuickProcessStaticAPI.ProcessCommand("notepad.exe", args);
        }

        [Conditional("UNITY_EDITOR_WIN")]
        public static void ExecuteTortoiseSVNCommand(string args)
        {
            QuickProcessStaticAPI.ProcessCommand("TortoiseProc.exe", args, true, null, true);
        }

        public static void ProcessCommand(string processName, string args, bool withWindow = true, string workingDir = "", bool useShellExecute = false)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = processName;   //确定程序名
            process.StartInfo.Arguments = args;    //确定程式命令行
            if (!workingDir.IsNullOrEmpty())
            {
                process.StartInfo.WorkingDirectory = workingDir; //工作目录
            }
            process.StartInfo.UseShellExecute = useShellExecute;        //Shell的使用
            process.StartInfo.CreateNoWindow = withWindow;
            process.StartInfo.ErrorDialog = true;
            if (process.StartInfo.UseShellExecute)
            {
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.RedirectStandardInput = false;
            }
            else
            {
                process.StartInfo.RedirectStandardInput = true;   //重定向输入
                process.StartInfo.RedirectStandardOutput = true; //重定向输出
                process.StartInfo.RedirectStandardError = true;   //重定向输出错误

                process.StartInfo.StandardOutputEncoding = System.Text.UTF8Encoding.UTF8;
                process.StartInfo.StandardErrorEncoding = System.Text.UTF8Encoding.UTF8;
            }

            process.Start();
            if (!process.StartInfo.UseShellExecute)
            {
                process.StandardOutput.ReadToEnd();//输出出流取得命令行结果果
                string error = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(error))
                {
                    UnityEngine.Debug.LogErrorFormat("ProcessCommand {0} Error: -> {1}", processName, error);
                }
            }
            process.WaitForExit();
            process.Close();
        }
    }
}

#endif