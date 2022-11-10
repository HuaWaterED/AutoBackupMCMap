using System;
using System.IO.Compression;
using System.Timers;

namespace AutoBackupMCMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainActivity mainActivity = new();
            mainActivity.Activity();
            Console.ReadKey();
        }
    }
    internal class MainActivity
    {
        string backupdic;
        string zipPath;
        uint backupTime;
        public void Activity()
        {
            Console.Write("输入需要备份的文件夹：");
            backupdic = Console.ReadLine();
            Console.Write("输入存放备份文件的路径：");
            zipPath = Console.ReadLine();
            Console.Write("请输入每隔多少时间备份一次(单位：毫秒)：");
            backupTime = uint.Parse(Console.ReadLine());

            Timer timer = new(backupTime);

            timer.Elapsed += Timer_Elapsed;

            timer.Start();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Console.WriteLine(@$"{DateTime.Now}执行一次");
            ZipFile.CreateFromDirectory(backupdic + "/", zipPath + @$"/mcpe_AutoBackupMap_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}_{DateTime.Now.Millisecond}.zip", CompressionLevel.SmallestSize, false);
        }
    }
}