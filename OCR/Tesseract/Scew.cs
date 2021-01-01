namespace Tesseract
{
    public struct Scew
    {
        public Scew(float angle, float confidence)
        {
            Angle = angle;
            Confidence = confidence;
        }

        public float Angle { get; }


        public float Confidence { get; }

        #region ToString

        public override string ToString()
        {
            return string.Format("Scew: {0} [conf: {1}]", Angle, Confidence);
        }

        #endregion

        #region Equals and GetHashCode implementation

        public override bool Equals(object obj)
        {
            return obj is Scew && Equals((Scew) obj);
        }

        public bool Equals(Scew other)
        {
            return Confidence == other.Confidence && Angle == other.Angle;
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            unchecked
            {
                hashCode += 1000000007 * Angle.GetHashCode();
                hashCode += 1000000009 * Confidence.GetHashCode();
            }

            return hashCode;
        }

        public static bool operator ==(Scew lhs, Scew rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Scew lhs, Scew rhs)
        {
            return !(lhs == rhs);
        }

        #endregion
    }
}