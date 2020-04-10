using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BorzoyaSpell
{
    public class UserDicOpration
    {
        //string locationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) 
        //                        + @"\db\" + Environment.UserName + "_txt";

        string Dirloc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\VirastarE\";
        string locationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                               @"\VirastarE\" + Environment.UserName + "_txt";

        public void Add(string word)
        {
            FileInfo fi = new FileInfo(locationPath);

            if (Directory.Exists(Dirloc) == false)
            {
                Directory.CreateDirectory(Dirloc);
            }

            if (fi.Exists)
            {
                File.AppendAllText(locationPath, word + Environment.NewLine);
            }
            else
            {
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine(word + Environment.NewLine);                    
                }
            }

            
        }

        public void Remove(string word)
        {
            try
            {
                var tempFile = Path.GetTempFileName();
                var linesToKeep = File.ReadLines(locationPath).Where(l => l != word);

                File.WriteAllLines(tempFile, linesToKeep);

                File.Delete(locationPath);
                File.Move(tempFile, locationPath);
            }
            catch { }

        }

        public List<string> LoadAll()
        {
            List<string> list = new List<string>();

            if (File.Exists(locationPath))
            {
                list = File.ReadLines(locationPath).ToList();
            }
            return list;
                     
        }
    }
}
