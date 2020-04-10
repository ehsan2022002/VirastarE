namespace Stemming.Persian
{
    public class Rule
    {

        public Rule(string sBody, string sSubstitution, char sPoS, byte iMinLength, bool bState)
        {
            this.setBody(sBody);
            this.setSubstitution(sSubstitution);
            this.setPoS(sPoS);
            this.setMinLength(iMinLength);
            this.setState(bState);
        }

        private string body;
        public string getBody()
        {
            return body;
        }
        public void setBody(string value)
        {
            body = value;
        }

        private string substitution;
        public string getSubstitution()
        {
            return substitution;
        }
        public void setSubstitution(string value)
        {
            substitution = value;
        }

        private char poS;
        public char getPoS()
        {
            return poS;
        }
        public void setPoS(char value)
        {
            poS = value;
        }

        private byte minLength;
        public byte getMinLength()
        {
            return minLength;
        }
        public void setMinLength(byte value)
        {
            minLength = value;
        }

        private bool state;
        public bool getState()
        {
            return state;
        }
        public void setState(bool value)
        {
            state = value;
        }
    }
}