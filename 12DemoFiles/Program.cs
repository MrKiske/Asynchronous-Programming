namespace _12DemoFiles
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var _path = Directory.GetCurrentDirectory();
            var _numFiles = 0;
            var _content = string.Empty;
            var _flag = false;
            
            DirectoryInfo info = new DirectoryInfo(Path.Combine(_path, "files"));
            FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
            foreach (FileInfo file in files)
            {
                var _messageRead = string.Empty; 
                Thread fileThread = new Thread( ()=>
                    {
                        _messageRead = readFiles(file.FullName);
                        _content = _content + _messageRead;
                        _numFiles++;
                    }
                );

                fileThread.Start();

                if (_numFiles == 10)
                {
                    fileThread.Join();
                    showFiles(_content);
                    _flag = true;
                }
                else
                {
                    Thread.Sleep(1000);
                }

                if (_flag)
                    return;
            }

            if (_numFiles < 10)
                showFiles(_content);
        }

        private static string readFiles(string path)
        {
            
            return File.ReadAllText(path);
        }

        private static void showFiles(string message)
        {
            Console.WriteLine(message);
        }


    }
}
