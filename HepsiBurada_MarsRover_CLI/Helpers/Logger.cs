using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace HepsiBurada_MarsRover_CLI.Helpers
{
    public class Logger
    {
        private static List<string> errorLogs { get; set; } = new List<string>();

        public static void AddErrorLog(string e)
        {
            if (errorLogs.Count > int.MaxValue)
            {
                errorLogs.Clear();
            }
            else
            {
                ConsoleColor originalColor = Console.ForegroundColor;
                StackTrace trace = new StackTrace();
                string errorStr = String.Format("{0} Warn => {1}", trace.GetFrame(trace.FrameCount-1).GetMethod().Name, e);
                errorLogs.Add(errorStr);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(errorStr);
                Console.ForegroundColor = originalColor;
                GC.Collect();
            }
        }


    }
}
