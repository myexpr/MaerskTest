using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BussinessRule
{
    public class Logger
    {
        static string fdicectory = Environment.CurrentDirectory;
        static string file = Path.Combine(fdicectory, "Logs.txt");

        public static void Log(string text)
        {
            if (!Directory.Exists(fdicectory))
            {
                Directory.CreateDirectory(file);

            }
            if (!File.Exists(file))
            {
                File.Create(file).Dispose();
            }
            using (StreamWriter sw = File.AppendText(file))
            {
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
