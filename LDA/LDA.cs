using Newtonsoft.Json;
using System;
namespace LDA
{
	[Serializable]
	public class LDA
	{
		public int M; //#Documents
		public int V; //#Words
		public int K; //#Topics
		public double alpha; // Dirichlet Prior Parameter for Document->Topic
		public double beta; // Dirichlet Prior Parameter for Topic->Word


		public double LogLikelihood
		{
			get
			{
				double ans = 0;
				for (int i = 0; i < wn; i++)
				{
					int w = words[i];
					int m = doc[i];
					double tmp = 0;
					for (int k = 0; k < K; k++)
					{
						tmp += phi[k][w] * theta[m][k];
					}
					ans += Math.Log(tmp);
				}
				return ans;
			}
		}

		public double[][] theta; //Document -> Topic Distributions
		public double[][] phi; // Topic->Word Distributions

		protected int[] words;
		protected int wn;
		protected int[] doc;
		protected int[] z;


		public string GetJSONString()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
}
