using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDA
{

	public delegate void EventHandler();
	public delegate void ProgressEventHandler(object source, LdaProcessEventArgs e);

	public class LdaProcessEventArgs : EventArgs
	{
		private string EventInfo;
		public LdaProcessEventArgs(string text)
		{
			EventInfo = text;
		}
		public string GetInfo()
		{
			return EventInfo;
		}
	}



	public class LdaGibbsSampling : LDA
	{

		public event ProgressEventHandler OnIterate;


		protected int[][] Nw;
		protected int[][] Nd;
		protected int[] Nwsum;
		protected int[] Ndsum;
		protected double[] P;

		protected int Savestep;
		protected int Niters;

		protected string Outputfile;
		protected int Twords;

		Corpora _cor;




		public LdaGibbsSampling()
		{
			M = 0;
			V = 0;
			K = 10;
			Alpha = 0.1;
			Beta = 0.1;
		}

		public void InitOption(CommandLineOption opt)
		{
			try
			{
				K = opt.topics;
				Alpha = opt.alpha;
				Beta = opt.beta;
				Savestep = opt.savestep;
				Niters = opt.niters;
				Outputfile = opt.outputfile;
				Twords = opt.twords;
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		private void InitModel(Corpora cor)
		{
			this._cor = cor;

			M = cor.totalDocuments;
			V = cor.MaxWordID();

			P = new double[K];
			Random rnd = new Random();

			Nw = new int[V][];
			Nd = new int[M][];
			for (int w = 0; w < V; w++)
			{
				Nw[w] = new int[K];
			}
			for (int m = 0; m < M; m++)
			{
				Nd[m] = new int[K];
			}

			Nwsum = new int[K];
			Ndsum = new int[M];

			Words = new int[cor.totalWords];
			Doc = new int[cor.totalWords];
			Z = new int[cor.totalWords];
			Wn = 0;
			for (int i = 0; i < M; i++)
			{
				int l = cor.Docs[i].Length;
				for (int j = 0; j < l; j++)
				{
					Words[Wn] = cor.Docs[i].Words[j];
					Doc[Wn] = i;
					Wn++;
				}
				Ndsum[i] = l;
			}
			for (int i = 0; i < Wn; i++)
			{

				int topic = rnd.Next(K);
				Nw[Words[i]][topic] += 1;
				Nd[Doc[i]][topic] += 1;
				Nwsum[topic] += 1;
				Z[i] = topic;
			}

			Theta = new double[M][];
			for (int m = 0; m < M; m++)
			{
				Theta[m] = new double[K];
			}
			Phi = new double[K][];
			for (int k = 0; k < K; k++)
			{
				Phi[k] = new double[V];
			}

		}

		public void TrainNewModel(Corpora cor, CommandLineOption opt)
		{
			InitOption(opt);
			InitModel(cor);
			PrintModelInfo();
			GibbsSampling(Niters);
		}

		public void PrintModelInfo()
		{
			Console.WriteLine(@"Aplha: " + Alpha.ToString());
			Console.WriteLine(@"Beta: " + Beta.ToString());
			Console.WriteLine(@"M: " + M);
			Console.WriteLine(@"K: " + K);
			Console.WriteLine(@"V: " + V);
			Console.WriteLine(@"Total iterations:" + Niters);
			Console.WriteLine(@"Save at: " + Savestep);
			Console.WriteLine();
		}

		private void GibbsSampling(int totalIter)
		{
			for (int iter = 1; iter <= totalIter; iter++)
			{
				Console.Write(@"Iteration " + iter + @":");
				if (OnIterate != null)
					OnIterate(this, new LdaProcessEventArgs(iter.ToString()));


				var stopWatch = new Stopwatch();
				stopWatch.Start();
				for (int i = 0; i < Wn; i++)
				{
					int topic = DoSampling(i);
					Z[i] = topic;
				}

				stopWatch.Stop();
				Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0 + @" seconds");
				if (iter % Savestep == 0)
				{
					SaveModel(Outputfile + "." + iter.ToString() + ".json");
					SaveTopWords(Outputfile + "." + iter.ToString() + ".topwords");
					Console.WriteLine(@"LogLikelihood= " + LogLikelihood);
				}
			}
		}

		private int DoSampling(int i)
		{
			int oldZ = Z[i];
			int w = Words[i];
			int m = Doc[i];

			Nw[w][oldZ] -= 1;
			Nd[m][oldZ] -= 1;
			Nwsum[oldZ] -= 1;
			Ndsum[m] -= 1;

			double vbeta = V * Beta;
			double kalpha = K * Alpha;
			for (int k = 0; k < K; k++)
			{
				P[k] = (Nw[w][k] + Beta) / (Nwsum[k] + vbeta) * (Nd[m][k] + Alpha) / (Ndsum[m] + kalpha);
			}
			for (int k = 1; k < K; k++)
			{
				P[k] += P[k - 1];
			}
			Random rnd = new Random();
			double cp = rnd.NextDouble() * P[K - 1];

			int newZ;
			for (newZ = 0; newZ < K; newZ++)
			{
				if (P[newZ] > cp)
				{
					break;
				}
			}
			if (newZ == K) newZ--;
			Nw[w][newZ] += 1;
			Nd[m][newZ] += 1;
			Nwsum[newZ] += 1;
			Ndsum[m] += 1;
			return newZ;
		}


		public void SaveModel(string modelpath)
		{
			CalcParameter();
			string jstr = GetJsonString();
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
			int tw = Twords > V ? V : Twords;

			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(modelpath))
			{
				for (int k = 0; k < K; k++)
				{
					var wordsProbsList = new Dictionary<int, double>();

					for (int w = 0; w < V; w++)
					{
						wordsProbsList.Add(w, Phi[k][w]);
					}

					double ans = 0;
					for (int w = 0; w < V; w++)
					{
						ans += Phi[k][w];
					}
					if (Math.Abs(ans - 1.00) > 0.1)
					{
						throw (new Exception("Phi Calculation Error"));
					}

					sw.Write("Topic " + k + "th:\n");
					List<KeyValuePair<int, double>> wordsProbsListOrdered;
                    wordsProbsListOrdered = wordsProbsList.OrderBy(e => -e.Value).ToList();

                    for (int i = 0; i < tw; i++)
					{
						string word = _cor.GetStringByID(wordsProbsListOrdered[i].Key);
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
					Theta[m][k] = (Nd[m][k] + Alpha) / (Ndsum[m] + K * Alpha);
				}
			}

			for (int k = 0; k < K; k++)
			{
				for (int w = 0; w < V; w++)
				{
					Phi[k][w] = (Nw[w][k] + Beta) / (Nwsum[k] + V * Beta);
				}
			}
		}
	}
}
