using System;
using System.IO;

namespace ServerTKM.Classes {
    public class Logger {

        private static object processSync = new object();
        private static string logFolderName = "logs";
        private static string logFileName = string.Format("{0}.log", DateTime.Now.ToString("dd-MM-yyyy---HH-mm-ss"));

        /// <summary>
        /// Log dizininin olup olmadığını kontrol eder. Yoksa oluşturur.
        /// </summary>
        public static void CheckLogDirectory() {
            if (!Directory.Exists(logFolderName))
                Directory.CreateDirectory(logFolderName);
        }

        /// <summary>
        /// Console ekranına Sarı renkte uyarı mesajı yazdırır.
        /// </summary>
        /// <param name="Message">Yazılacak olan mesajdır.</param>
        public static void LogWarning(string Message) {
            WriteLog(Message, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Console ekranına Turkuaz renkte uyarı mesajı yazdırır.
        /// </summary>
        /// <param name="Message">Yazılacak olan mesajdır.</param>
        public static void LogInfo(string Message) {
            WriteLog(Message, ConsoleColor.Cyan);
        }

        /// <summary>
        /// Console ekranına Magenta renkte uyarı mesajı yazdırır.
        /// </summary>
        /// <param name="Message">Yazılacak olan mesajdır.</param>
        public static void LogFightInfo(string Message) {
            WriteLog(Message, ConsoleColor.Magenta);
        }

        /// <summary>
        /// Console ekranına Kırmızı renkte uyarı mesajı yazdırır.
        /// </summary>
        /// <param name="Message">Yazılacak olan mesajdır.</param>
        public static void LogError(string Message) {
            WriteLog(Message, ConsoleColor.Red);
        }

        /// <summary>
        /// Her türden mesajı yazdırır.
        /// </summary>
        /// <param name="Message">Yazılacak olan mesajdır.</param>
        /// <param name="Color">Mesajın rengidir.</param>
        private static void WriteLog(string Message, ConsoleColor Color) {
            lock (processSync) {
                Console.ForegroundColor = Color;
                Message = string.Format("[{0}] {1}", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), Message);
                Console.WriteLine(Message);
                Console.ForegroundColor = ConsoleColor.White;
                SaveLog(Message);
            }
        }

        /// <summary>
        /// İstenen mesajı log dosyasına yazar.
        /// </summary>
        /// <param name="Message">Yazılacak olan mesajdır.</param>
        private static void SaveLog(string Message) {
            try {
                string FilePath = string.Format("{0}/{1}", logFolderName, logFileName);
                using (StreamWriter streamWriter = new StreamWriter(FilePath, true)) {
                    if (streamWriter != null)
                        streamWriter.WriteLine(Message);
                    streamWriter.Close();
                }
            } catch (Exception appException) {
                Console.WriteLine(appException.Message);
                return;
            }
        }
    }
}