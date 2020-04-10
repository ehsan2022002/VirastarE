using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorzoyaSpell
{

    public class PunchPattern
    {
        public PunchPattern(int ErrorCode)
        {
            this.ErrorCode = ErrorCode;
        }
        public PunchPattern(string regax, string erroMessage, string errorCorrection, int errorCode)
        {
            this.Regax = regax;
            this.ErroMessage = erroMessage;
            this.ErrorCorrection = errorCorrection;
            this.ErrorCode = errorCode;
        }
        public string Regax { get; set; }
        public string ErroMessage { get; set; }
        public string ErrorCorrection { get; set; }
        public int ErrorCode { get; set; }
        public int IndexStart { get; set; }
        public int IndexLenght { get; set; }
        public int IndexEnd { get { return this.IndexStart + this.IndexLenght; } }
        

    }
}
