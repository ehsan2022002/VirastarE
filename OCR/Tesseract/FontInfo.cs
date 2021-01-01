namespace Tesseract
{
    // The .NET equivalent of the ccstruct/fontinfo.h
    // FontInfo struct. It's missing spacing info
    // since we don't have any way of getting it (and
    // it's probably not all that useful anyway)
    public class FontInfo
    {
        internal FontInfo(
            string name, int id,
            bool isItalic, bool isBold, bool isFixedPitch,
            bool isSerif, bool isFraktur = false
        )
        {
            Name = name;
            Id = id;

            IsItalic = isItalic;
            IsBold = isBold;
            IsFixedPitch = isFixedPitch;
            IsSerif = isSerif;
            IsFraktur = isFraktur;
        }

        public string Name { get; }

        public int Id { get; }
        public bool IsItalic { get; }
        public bool IsBold { get; }
        public bool IsFixedPitch { get; }
        public bool IsSerif { get; }
        public bool IsFraktur { get; }
    }
}