namespace OpenNLP.Tools.Ling
{
    /// <summary>
    /// @author grenager
    /// 
    /// Code retrieved on the Stanford parser and ported to C# (see http://nlp.stanford.edu/software/lex-parser.shtml)
    /// </summary>
    public interface IHasIndex
    {
        string DocId();

        void SetDocId(string docId);

        int SentIndex();

        void SetSentIndex(int sentIndex);

        int Index();

        void SetIndex(int index);
    }
}