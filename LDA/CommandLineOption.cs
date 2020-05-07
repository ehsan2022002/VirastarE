using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LDA
{
	public class CommandLineOption
	{
		public int topics { get; set; }

		public int savestep { get; set; }

		public double alpha { get; set; }

		public double beta { get; set; }

		public int niters { get; set; }

		public string input { get; set; }

		public string outputfile { get; set; }

		public int twords { get; set; }
	}
}
