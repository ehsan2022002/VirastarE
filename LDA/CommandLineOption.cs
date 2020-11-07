namespace LDA
{
    public class CommandLineOption
    {
        public int Topics { get; set; }

        public int Savestep { get; set; }

        public double Alpha { get; set; }

        public double Beta { get; set; }

        public int Niters { get; set; }

        public string Input { get; set; }

        public string Outputfile { get; set; }

        public int Twords { get; set; }
    }
}