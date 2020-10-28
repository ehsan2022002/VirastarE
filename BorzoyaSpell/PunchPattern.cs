namespace BorzoyaSpell
{
    public class PunchPattern
    {
        public PunchPattern(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public PunchPattern(string regax, string erroMessage, string errorCorrection, int errorCode)
        {
            Regax = regax;
            ErroMessage = erroMessage;
            ErrorCorrection = errorCorrection;
            ErrorCode = errorCode;
        }

        public string Regax { get; set; }
        public string ErroMessage { get; set; }
        public string ErrorCorrection { get; set; }
        public int ErrorCode { get; set; }
        public int IndexStart { get; set; }
        public int IndexLenght { get; set; }
        public int IndexEnd => IndexStart + IndexLenght;
    }
}