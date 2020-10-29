namespace Stemming.Persian
{
    public class Verb
    {

        public Verb(string sPast, string sPresent)
        {
            this.SetPresent(sPresent);
            this.SetPast(sPast);

        }
        private string _present;
        public string GetPresent()
        {
            return _present;
        }
        public void SetPresent(string value)
        {
            _present = value;
        }

        private string _past;
        public string GetPast()
        {
            return _past;
        }
        public void SetPast(string value)
        {
            _past = value;
        }
    }
}