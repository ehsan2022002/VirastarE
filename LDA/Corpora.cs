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
		public int TotalWords;
		public int TotalDocuments;
		public Document[] Docs;
		public WordDictionary WD;

		public Corpora()
		{
			WD = new WordDictionary();
			TotalDocuments = 0;
			TotalWords = 0;
		}

		public int MaxWordId()
		{
			return WD.Count;
		}

		public void LoadDataFile(string file)
		{

            var encoding = Encoding.UTF8;

			try
			{
                string[] f = File.ReadAllLines(file, encoding);
				TotalDocuments = f.Length;
				Docs = new Document[TotalDocuments];
				for (int i = 0; i < TotalDocuments; i++)
				{
					Docs[i] = new Document();
					Docs[i].Init(f[i], WD);
					TotalWords += Docs[i].Length;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string GetStringById(int id)
		{
			return WD.GetString(id);
		}
	}
}
