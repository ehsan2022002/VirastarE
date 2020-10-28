using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BorzoyaSpell
{
    public class UserDicOpration
    {
        //string _fileLocationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) 
        //                        + @"\db\" + Environment.UserName + "_txt";

        private readonly string _dirlocationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                         @"\VirastarE\";

        private readonly string _fileLocationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                               @"\VirastarE\" + Environment.UserName + "_txt";

        public void Add(string word)
        {
            var fileInfo = new FileInfo(_fileLocationPath);

            if (Directory.Exists(_dirlocationPath) == false) Directory.CreateDirectory(_dirlocationPath);

            if (fileInfo.Exists)
                File.AppendAllText(_fileLocationPath, word + Environment.NewLine);
            else
                using (var streamWriter = fileInfo.CreateText())
                {
                    streamWriter.WriteLine(word + Environment.NewLine);
                }
        }

        public void Remove(string word)
        {
            try
            {
                var tempFile = Path.GetTempFileName();
                var linesToKeep = File.ReadLines(_fileLocationPath).Where(l => l != word);

                File.WriteAllLines(tempFile, linesToKeep);

                File.Delete(_fileLocationPath);
                File.Move(tempFile, _fileLocationPath);
            }
            catch (Exception)
            {
            }
        }

        public List<string> LoadAll()
        {
            var list = new List<string>();

            if (File.Exists(_fileLocationPath)) list = File.ReadLines(_fileLocationPath).ToList();
            return list;
        }
    }
}