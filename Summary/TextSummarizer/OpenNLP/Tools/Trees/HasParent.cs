namespace OpenNLP.Tools.Trees
{
    /// <summary>
    /// Only to be implemented by Tree subclasses that actualy keep their
    /// parent pointers.  For example, the base Tree class should
    /// <b>not</b> implement this, but TreeGraphNode should.
    /// 
    /// @author John Bauer
    /// 
    /// Code retrieved on the Stanford parser and ported to C# (see http://nlp.stanford.edu/software/lex-parser.shtml)
    /// </summary>
    public interface IHasParent
    {
        Tree Parent();
    }
}