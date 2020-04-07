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

            
            DirectoryInfo info = new DirectoryInfo(Path.Combine(_path, "files"));
            FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
            foreach (FileInfo file in files)
            {
                var _messageRead = string.Empty; 
                Thread fileThread = new Thread( ()=>
                    {
                        _messageRead = readFiles(file.FullName);
                        _content = _messageRead;
                        _numFiles++;
                    }
                );

                fileThread.Start();
                
                var flag = true;
                while (flag)
                {
                    if (_numFiles == 10)
                    {
                        fileThread.Join();
                        flag = false;
                        showFiles(_content);
                    }
                }

               // return;
            }

        }

        private static string readFiles(string path)
        {
            
            return File.ReadAllText(path);
        }

        private static void showFiles(string message)
        { 
        
        }


    }
}
