using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogger {
    public class Logger {

        public string LogPath = "./error.log";
        /// <summary>
        /// Log string to LogPath. Default path is "./error.log".
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public void Log(string text) {
            if (!File.Exists(LogPath)) {
                File.Create(LogPath).Dispose();
            }
            StreamWriter log = File.AppendText(LogPath);
            log.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} - {text}");

            log.Close();
        }
    }
}
