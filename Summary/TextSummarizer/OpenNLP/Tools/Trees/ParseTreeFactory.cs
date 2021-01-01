using OpenNLP.Tools.Ling;

namespace OpenNLP.Tools.Trees
{
    public class ParseTreeFactory : LabeledScoredTreeFactory
    {
        public ParseTreeFactory(ILabelFactory lf) : base(lf)
        {
        }
    }
}