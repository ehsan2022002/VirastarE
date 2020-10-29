using System;
using Newtonsoft.Json;


namespace LDA
{
    [Serializable]
    public class LDA
    {
        public double Alpha; // Dirichlet Prior Parameter for Document->Topic
        public double Beta; // Dirichlet Prior Parameter for Topic->Word
        protected int[] Doc;
        public int K; //#Topics
        public int M; //#Documents
        public double[][] Phi; // Topic->Word Distributions

        public double[][] Theta; //Document -> Topic Distributions
        public int V; //#Words
        protected int Wn;

        protected int[] Words;
        protected int[] Z;


        public double LogLikelihood
        {
            get
            {
                double ans = 0;
                for (var i = 0; i < Wn; i++)
                {
                    var w = Words[i];
                    var m = Doc[i];
                    double tmp = 0;
                    for (var k = 0; k < K; k++) tmp += Phi[k][w] * Theta[m][k];
                    ans += Math.Log(tmp);
                }

                return ans;
            }
        }


        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}