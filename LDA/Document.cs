using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LDA
{
	public class Document
	{
		public int[] Words;
		public int Length;

		public void Init(string str, WordDictionary WD)
		{
			try
			{
				string sp = @"\s+";
				string[] doc = Regex.Split(str, sp);
				Words = new int[doc.Length];
				Length = doc.Length;
				for (int i = 0; i < Length; i++)
				{
					Words[i] = WD.GetWords(doc[i]);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
