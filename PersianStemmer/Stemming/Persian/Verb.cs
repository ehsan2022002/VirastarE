namespace Stemming.Persian
{
    public class Verb
    {

        public Verb(string sPast, string sPresent)
        {
            this.setPresent(sPresent);
            this.setPast(sPast);

        }
        private string present;
        public string getPresent()
        {
            return present;
        }
        public void setPresent(string value)
        {
            present = value;
        }

        private string past;
        public string getPast()
        {
            return past;
        }
        public void setPast(string value)
        {
            past = value;
        }
    }
}