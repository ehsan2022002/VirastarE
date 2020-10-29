namespace PersianStemmer.Stemming.Persian
{
    public class Rule
    {
        private string _body;

        private byte _minLength;

        private char _poS;

        private bool _state;

        private string _substitution;

        public Rule(string sBody, string sSubstitution, char sPoS, byte iMinLength, bool bState)
        {
            SetBody(sBody);
            SetSubstitution(sSubstitution);
            SetPoS(sPoS);
            SetMinLength(iMinLength);
            SetState(bState);
        }

        public string GetBody()
        {
            return _body;
        }

        public void SetBody(string value)
        {
            _body = value;
        }

        public string GetSubstitution()
        {
            return _substitution;
        }

        public void SetSubstitution(string value)
        {
            _substitution = value;
        }

        public char GetPoS()
        {
            return _poS;
        }

        public void SetPoS(char value)
        {
            _poS = value;
        }

        public byte GetMinLength()
        {
            return _minLength;
        }

        public void SetMinLength(byte value)
        {
            _minLength = value;
        }

        public bool GetState()
        {
            return _state;
        }

        public void SetState(bool value)
        {
            _state = value;
        }
    }
}