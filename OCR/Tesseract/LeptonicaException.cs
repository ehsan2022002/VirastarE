using System;
using System.Runtime.Serialization;

namespace Tesseract
{
    [Serializable]
    public class LeptonicaException : Exception
    {
        public LeptonicaException()
        {
        }

        public LeptonicaException(string message) : base(message)
        {
        }

        public LeptonicaException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LeptonicaException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}