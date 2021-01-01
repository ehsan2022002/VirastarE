using OpenNLP.Tools.Util;
using System;

namespace OpenNLP.Tools.Ling
{
    public interface IAbstractCoreLabel : ILabel, IHasWord, IHasIndex, IHasTag, IHasLemma, IHasOffset, ITypesafeMap
    {
        string Ner();

        void SetNer(string ner);

        string OriginalText();

        void SetOriginalText(string originalText);

        string GetString(Type key);
    }
}