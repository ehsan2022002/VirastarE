using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LanguageDetection
{
    public class LanguageLearner
    {
        public Dictionary<string, int> Learn(string languageCode, string sourcePath, string targetPath = null)
        {
            var text = Helper.GetFileContents(sourcePath);

            var ngramBuilder = new NgramBuilder();

            var ngrams = ngramBuilder.Get(text);

            if (targetPath == null)
            {
                return ngrams;
            }

            Save(languageCode, ngrams, targetPath);

            return ngrams;
        }

        private void Save(string languageCode, Dictionary<string, int> ngrams, string path)
        {
            List<string> lines;

            var existingIndex = -1;

            if (File.Exists(path))
            {
                var contents = Helper.GetFileContents(path);

                lines = contents.Split(new[] { '\r', '\n' }).ToList();

                for (var i = 0; i < lines.Count; i++)
                {
                    var model = lines[i].Split(':');

                    if (model[0] == languageCode)
                    {
                        existingIndex = i;

                        break;
                    }
                }
            }
            else
            {
                File.Create(path).Dispose();

                lines = new List<string>();
            }

            var newLine = languageCode + ":" + string.Join("_", ngrams.Keys.ToArray());

            if (existingIndex > -1)
            {
                lines[existingIndex] = newLine;
            }
            else
            {
                lines.Add(newLine);
            }

            File.WriteAllLines(path, lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray(), Encoding.Unicode);
        }

        public Dictionary<string, Dictionary<string, int>> Remember(string path)
        {
            var result = new Dictionary<string, Dictionary<string, int>>();

            string line;

            using (var reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var model = line.Split(':');

                    var ngramBuilder = new NgramBuilder();

                    result.Add(model[0], ngramBuilder.Load(model[1].Split('_')));
                }
            }

            return result;
        }
    }
}

