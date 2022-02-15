using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TimHelper
{
    public class CmdHelper
    {
        public static void ExecuteBat(string path)
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo(path);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            process.Close();
        }
        public static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }
    }

    public class ProcessHelper
    {
        //public static Process process;
        //public ProcessHelper(string exe)
        //{
        //    process = new Process();
        //    process.StartInfo.FileName = exe;
        //    process.StartInfo.Verb = "runas";
        //    process.Start();
        //}

        //public void Send(string command)
        //{
        //    if (process != null)
        //    {
        //        IntPtr h = process.MainWindowHandle;
        //        SendKeys.SendWait(command);
        //        SendKeys.SendWait("{ENTER}");
        //    }
        //}

        //public void WaitForExist()
        //{
        //    process.WaitForExit();
        //}
    }
}
