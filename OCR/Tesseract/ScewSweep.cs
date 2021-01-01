namespace Tesseract
{
    /// <summary>
    ///     Represents the parameters for a sweep search used by scew algorithms.
    /// </summary>
    public struct ScewSweep
    {
        public static ScewSweep Default = new ScewSweep(DefaultReduction);

        #region Constants and Fields

        public const int DefaultReduction = 4; // Sweep part; 4 is good
        public const float DefaultRange = 7.0F;
        public const float DefaultDelta = 1.0F;

        #endregion

        #region Factory Methods + Constructor

        public ScewSweep(int reduction = DefaultReduction, float range = DefaultRange, float delta = DefaultDelta)
        {
            Reduction = reduction;
            Range = range;
            Delta = delta;
        }

        #endregion

        #region Properties

        public int Reduction { get; }

        public float Range { get; }

        public float Delta { get; }

        #endregion
    }
}