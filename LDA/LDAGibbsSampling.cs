using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDA
{

	public delegate void EventHandler();
	public delegate void ProgressEventHandler(object source, LDAProcessEventArgs e);

	public class LDAProcessEventArgs : EventArgs
	{
		private string EventInfo;
		public LDAProcessEventArgs(string Text)
		{
			EventInfo = Text;
		}
		public string GetInfo()
		{
			return EventInfo;
		}
	}



	public class LDAGibbsSampling : LDA
	{

		public event ProgressEventHandler OnIterate;


		protected int[][] nw;
		protected int[][] nd;
		protected int[] nwsum;
		protected int[] ndsum;
		protected double[] p;

		protected int savestep;
		protected int niters;

		protected string outputfile;
		protected int twords;

		Corpora cor;




		public LDAGibbsSampling()
		{
			M = 0;
			V = 0;
			K = 10;
			alpha = 0.1;
			beta = 0.1;
		}

		public void InitOption(CommandLineOption opt)
		{
			try
			{
				K = opt.Topics;
				alpha = opt.Alpha;
				beta = opt.Beta;
				savestep = opt.Savestep;
				niters = opt.Niters;
				outputfile = opt.Outputfile;
				twords = opt.Twords;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void InitModel(Corpora cor)
		{
			this.cor = cor;

			M = cor.TotalDocuments;
			V = cor.MaxWordId();

			p = new double[K];
			Random rnd = new Random();

			nw = new int[V][];
			nd = new int[M][];
			for (int w = 0; w < V; w++)
			{
				nw[w] = new int[K];
			}
			for (int m = 0; m < M; m++)
			{
				nd[m] = new int[K];
			}

			nwsum = new int[K];
			ndsum = new int[M];

			words = new int[cor.TotalWords];
			doc = new int[cor.TotalWords];
			z = new int[cor.TotalWords];
			wn = 0;
			for (int i = 0; i < M; i++)
			{
				int l = cor.Docs[i].Length;
				for (int j = 0; j < l; j++)
				{
					words[wn] = cor.Docs[i].Words[j];
					doc[wn] = i;
					wn++;
				}
				ndsum[i] = l;
			}
			for (int i = 0; i < wn; i++)
			{

				int topic = rnd.Next(K);
				nw[words[i]][topic] += 1;
				nd[doc[i]][topic] += 1;
				nwsum[topic] += 1;
				z[i] = topic;
			}

			theta = new double[M][];
			for (int m = 0; m < M; m++)
			{
				theta[m] = new double[K];
			}
			phi = new double[K][];
			for (int k = 0; k < K; k++)
			{
				phi[k] = new double[V];
			}

		}

		public void TrainNewModel(Corpora cor, CommandLineOption opt)
		{
			InitOption(opt);
			InitModel(cor);
			PrintModelInfo();
			GibbsSampling(niters);
		}

		public void PrintModelInfo()
		{
			Console.WriteLine("Aplha: " + alpha.ToString());
			Console.WriteLine("Beta: " + beta.ToString());
			Console.WriteLine("M: " + M);
			Console.WriteLine("K: " + K);
			Console.WriteLine("V: " + V);
			Console.WriteLine("Total iterations:" + niters);
			Console.WriteLine("Save at: " + savestep);
			Console.WriteLine();
		}

		private void GibbsSampling(int totalIter)
		{
			for (int iter = 1; iter <= totalIter; iter++)
			{
				Console.Write("Iteration " + iter + ":");
				if (OnIterate != null)
					OnIterate(this, new LDAProcessEventArgs(iter.ToString()));


				var stopWatch = new Stopwatch();
				stopWatch.Start();
				for (int i = 0; i < wn; i++)
				{
					int topic = DoSampling(i);
					z[i] = topic;
				}

				stopWatch.Stop();
				Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0 + " seconds");
				if (iter % savestep == 0)
				{
					SaveModel(outputfile + "." + iter.ToString() + ".json");
					SaveTopWords(outputfile + "." + iter.ToString() + ".topwords");
					Console.WriteLine("LogLikelihood= " + LogLikelihood);
				}
			}
		}

		private int DoSampling(int i)
		{
			int oldZ = z[i];
			int w = words[i];
			int m = doc[i];

			nw[w][oldZ] -= 1;
			nd[m][oldZ] -= 1;
			nwsum[oldZ] -= 1;
			ndsum[m] -= 1;

			double Vbeta = V * beta;
			double Kalpha = K * alpha;
			for (int k = 0; k < K; k++)
			{
				p[k] = (nw[w][k] + beta) / (nwsum[k] + Vbeta) * (nd[m][k] + alpha) / (ndsum[m] + Kalpha);
			}
			for (int k = 1; k < K; k++)
			{
				p[k] += p[k - 1];
			}
			Random rnd = new Random();
			double cp = rnd.NextDouble() * p[K - 1];

			int newZ;
			for (newZ = 0; newZ < K; newZ++)
			{
				if (p[newZ] > cp)
				{
					break;
				}
			}
			if (newZ == K) newZ--;
			nw[w][newZ] += 1;
			nd[m][newZ] += 1;
			nwsum[newZ] += 1;
			ndsum[m] += 1;
			return newZ;
		}


		public void SaveModel(string modelpath)
		{
			CalcParameter();
			string jstr = GetJSONString();
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(modelpath))
			{
				sw.WriteLine(jstr);
			}

		}

		public void LoadModel(string modelpath)
		{

		}

		public void SaveTopWords(string modelpath)
		{
			int tw = twords > V ? V : twords;

			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(modelpath))
			{
				for (int k = 0; k < K; k++)
				{
					var wordsProbsList = new Dictionary<int, double>();

					for (int w = 0; w < V; w++)
					{
						wordsProbsList.Add(w, phi[k][w]);
					}

					double ans = 0;
					for (int w = 0; w < V; w++)
					{
						ans += phi[k][w];
					}
					if (Math.Abs(ans - 1.00) > 0.1)
					{
						throw (new Exception("Phi Calculation Error"));
					}

					sw.Write("Topic " + k + "th:\n");
					var wordsProbsListOrdered = wordsProbsList.OrderBy(e => -e.Value).ToList();

					for (int i = 0; i < tw; i++)
					{
						string word = cor.GetStringById(wordsProbsListOrdered[i].Key);
						sw.WriteLine("\t" + word + " " + wordsProbsListOrdered[i].Value);
					}
				}

			}
		}

		protected void CalcParameter()
		{
			for (int m = 0; m < M; m++)
			{
				for (int k = 0; k < K; k++)
				{
					theta[m][k] = (nd[m][k] + alpha) / (ndsum[m] + K * alpha);
				}
			}

			for (int k = 0; k < K; k++)
			{
				for (int w = 0; w < V; w++)
				{
					phi[k][w] = (nw[w][k] + beta) / (nwsum[k] + V * beta);
				}
			}
		}
	}
}
