
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LDA
{
	class Program
	{

		static private CommandLineOption GetDefaultOption()
		{
			CommandLineOption option = new CommandLineOption();
			option.alpha = 0.1;
			option.beta = 0.1;
			option.topics = 1;
			option.savestep = 100;
			option.niters = 100;
			option.twords = 30;
            option.input = @"C:\download\dictionary\LDA_CGS-master\LDA_CGS-master\LDA2\ConsoleApplication1\ConsoleApplication1\bin\Debug\docs.dat";
            option.outputfile = @"C:\download\dictionary\LDA_CGS-master\LDA_CGS-master\LDA2\ConsoleApplication1\ConsoleApplication1\bin\Debug\out.txt";

			return option;
		}

		static void Main(string[] args)
		{

			CommandLineOption opt = GetDefaultOption();
			//Parser parser = new Parser();
			var stopwatch = new Stopwatch();
			try
			{
				//parser.ParseArguments(args, opt);
				LDAGibbsSampling model = new LDAGibbsSampling();
				Corpora cor = new Corpora();
				cor.LoadDataFile(opt.input);
				model.TrainNewModel(cor, opt);
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.StackTrace);
				Console.WriteLine(ex.Message);

			}

		}
	}
}
