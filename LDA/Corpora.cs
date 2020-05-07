using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDA
{
	public class Corpora
	{
		public int totalWords;
		public int totalDocuments;
		public Document[] Docs;
		public WordDictionary WD;

		public Corpora()
		{
			WD = new WordDictionary();
			totalDocuments = 0;
			totalWords = 0;
		}

		public int MaxWordID()
		{
			return WD.Count;
		}

		public void LoadDataFile(string file)
		{

            var encoding = Encoding.UTF8;

			try
			{
                string[] f = File.ReadAllLines(file, encoding);
				totalDocuments = f.Length;
				Docs = new Document[totalDocuments];
				for (int i = 0; i < totalDocuments; i++)
				{
					Docs[i] = new Document();
					Docs[i].Init(f[i], WD);
					totalWords += Docs[i].Length;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string GetStringByID(int id)
		{
			return WD.GetString(id);
		}
	}
}
