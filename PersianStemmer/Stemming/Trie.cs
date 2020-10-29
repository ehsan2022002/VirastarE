using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stemming
{
    public class Trie<TValue> : IEnumerable, IEnumerable<Trie<TValue>.TrieNodeBase>
    {
        public static int c_sparse_nodes;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int CNodes;

        public IEnumerable<TValue> Values => Root.SubsumedValues();

        /// 
        /// Trie proper begins here
        ///
        public TrieNodeBase Root { get; private set; } = new TrieNode();

        // in combination with Add(...), enables C# 3.0 initialization syntax, even though it never seems to call it
        public IEnumerator GetEnumerator()
        {
            return Root.SubsumedNodes().GetEnumerator();
        }

        IEnumerator<TrieNodeBase> IEnumerable<TrieNodeBase>.GetEnumerator()
        {
            return Root.SubsumedNodes().GetEnumerator();
        }

        public void OptimizeSparseNodes()
        {
            if (Root.ShouldOptimize)
            {
                Root = new SparseTrieNode(Root.CharNodePairs());
                c_sparse_nodes++;
            }
            Root.OptimizeChildNodes();
        }

        public TrieNodeBase Add(string s, TValue v)
        {
            var node = Root;
            foreach (var c in s)
                node = node.AddChild(c, ref CNodes);

            node.Value = v;
            node.Key = s;
            return node;
        }

        public bool Contains(string s)
        {
            var node = Root;
            foreach (var c in s)
            {
                node = node[c];
                if (node == null)
                    return false;
            }
            return node.HasValue;
        }

        /// <summary>
        /// Debug only; this is hideously inefficient
        /// </summary>
        public string GetKey(TrieNodeBase seek)
        {
            var sofar = string.Empty;

            GetKeyHelper fn = null;
            fn = cur =>
            {
                sofar += " ";   // placeholder
                foreach (var kvp in cur.CharNodePairs())
                {
                    //Util.SetStringChar(ref sofar, sofar.Length - 1, kvp.Key);
                    if (kvp.Value == seek)
                        return true;
                    if (kvp.Value.Nodes != null && fn(kvp.Value))
                        return true;
                }
                sofar = sofar.Substring(0, sofar.Length - 1);
                return false;
            };

            if (fn(Root))
                return sofar;
            return null;
        }

        public string GetKey(TValue seek)
        {
            var sofar = string.Empty;

            GetKeyHelper fn = null;
            fn = cur =>
            {
                sofar += " ";   // placeholder
                foreach (var kvp in cur.CharNodePairs())
                {
                    //Util.SetStringChar(ref sofar, sofar.Length - 1, kvp.Key);
                    if (kvp.Value.Value != null && kvp.Value.Value.Equals(seek))
                        return true;
                    if (kvp.Value.Nodes != null && fn(kvp.Value))
                        return true;
                }
                sofar = sofar.Substring(0, sofar.Length - 1);
                return false;
            };

            if (fn(Root))
                return sofar;
            return null;
        }

        public TrieNodeBase FindNode(string s_in)
        {
            var node = Root;
            foreach (var c in s_in)
                if ((node = node[c]) == null)
                    return null;
            return node;
        }

        public TValue ContainsKey(string s_in)
        {
            var node = FindNode(s_in);
            if (node == null || !node.HasValue)
                return default;
            return node.Value;
        }

        public bool IsEmpty()
        {
            return Root.ChildCount == 0;
        }

        /// <summary>
        /// If continuation from the terminal node is possible with a different input string, then that node is not
        /// returned as a 'last' node for the given input. In other words, 'last' nodes must be leaf nodes, where
        /// continuation possibility is truly unknown. The presense of a nodes array that we couldn't match to 
        /// means the search fails; it is not the design of the 'OrLast' feature to provide 'closest' or 'best'
        /// matching but rather to enable truncated tails still in the context of exact prefix matching.
        /// </summary>
        public TrieNodeBase FindNodeOrLast(string sIn, out bool fExact)
        {
            var node = Root;
            foreach (var c in sIn)
            {
                if (node.IsLeaf)
                {
                    fExact = false;
                    return node;
                }
                if ((node = node[c]) == null)
                {
                    fExact = false;
                    return null;
                }
            }
            fExact = true;
            return node;
        }

        // even though I found some articles that attest that using a foreach enumerator with arrays (and Lists)
        // returns a value type, thus avoiding spurious garbage, I had already changed the code to not use enumerator.
        /*public unsafe TValue Find(String s_in)
		{
			TrieNodeBase node = _root;
			fixed (Char* pin_s = s_in)
			{
				Char* p = pin_s;
				Char* p_end = p + s_in.Length;
				while (p < p_end)
				{
					if ((node = node[*p]) == null)
						return default(TValue);
					p++;
				}
				return node.Value;
			}
		}

		public unsafe TValue Find(Char* p_tag, int cb_ctag)
		{
			TrieNodeBase node = _root;
			Char* p_end = p_tag + cb_ctag;
			while (p_tag < p_end)
			{
				if ((node = node[*p_tag]) == null)
					return default(TValue);
				p_tag++;
			}
			return node.Value;
		}
        */
        public IEnumerable<TValue> FindAll(string s_in)
        {
            var node = Root;
            foreach (var c in s_in)
            {
                if ((node = node[c]) == null)
                    break;
                if (node.Value != null)
                    yield return node.Value;
            }
        }

        public IEnumerable<TValue> SubsumedValues(string s)
        {
            var node = FindNode(s);
            return node == null ? Enumerable.Empty<TValue>() : node.SubsumedValues();
        }

        public IEnumerable<TrieNodeBase> SubsumedNodes(string s)
        {
            var node = FindNode(s);
            return node == null ? Enumerable.Empty<TrieNodeBase>() : node.SubsumedNodes();
        }

        public IEnumerable<TValue> GetAllValues(IEnumerable<string> words)
        {
            return words.Select(FindNode).Where(node => node != null).Select(node => node.Value);
        }

        public IEnumerable<TValue> GetAllValuesWithDef(IEnumerable<string> words, Func<string, TValue> def)
        {
            return words.Select(z => FindNode(z) == null || FindNode(z).Value == null ? def(z) : FindNode(z).Value);
        }

        public IEnumerable<TValue> AllSubstringValues(string s)
        {
            var iCur = 0;
            while (iCur < s.Length)
            {
                var node = Root;
                var i = iCur;
                while (i < s.Length)
                {
                    node = node[s[i]];
                    if (node == null)
                        break;
                    if (node.Value != null)
                        yield return node.Value;
                    i++;
                }
                iCur++;
            }
        }

        /// <summary>
        /// note: only returns nodes with non-null values
        /// </summary>
        public void DepthFirstTraverse(Action<string, TrieNodeBase> callback)
        {
            var rgch = new char[100];
            var depth = 0;

            Action<TrieNodeBase> fn = null;
            fn = cur =>
            {
                if (depth >= rgch.Length)
                {
                    var tmp = new char[rgch.Length * 2];
                    Buffer.BlockCopy(rgch, 0, tmp, 0, rgch.Length * sizeof(char));
                    rgch = tmp;
                }
                foreach (var kvp in cur.CharNodePairs())
                {
                    rgch[depth] = kvp.Key;
                    var n = kvp.Value;
                    if (n.Nodes != null)
                    {
                        depth++;
                        fn(n);
                        depth--;
                    }
                    else if (n.Value == null)       // leaf nodes should always have a value
                    {
                        throw new Exception();
                    }

                    if (n.Value != null)
                        callback(new string(rgch, 0, depth + 1), n);
                }
            };

            fn(Root);
        }


        /// <summary>
        /// note: only returns nodes with non-null values
        /// </summary>
        public void EnumerateLeafPaths(Action<string, IEnumerable<TrieNodeBase>> callback)
        {
            var stk = new Stack<TrieNodeBase>();
            var rgch = new char[100];

            Action<TrieNodeBase> fn = null;
            fn = cur =>
            {
                if (stk.Count >= rgch.Length)
                {
                    var tmp = new char[rgch.Length * 2];
                    Buffer.BlockCopy(rgch, 0, tmp, 0, rgch.Length * sizeof(char));
                    rgch = tmp;
                }
                foreach (var kvp in cur.CharNodePairs())
                {
                    rgch[stk.Count] = kvp.Key;
                    var n = kvp.Value;
                    stk.Push(n);
                    if (n.Nodes != null)
                    {
                        fn(n);
                    }
                    else
                    {
                        if (n.Value == null)        // leaf nodes should always have a value
                            throw new Exception();
                        callback(new string(rgch, 0, stk.Count), stk);
                    }
                    stk.Pop();
                }
            };

            fn(Root);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        /// Convert a trie with one value type to another
        ///
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Trie<TNew> ToTrie<TNew>(Func<TValue, TNew> valueConverter)
        {
            var t = new Trie<TNew>();
            DepthFirstTraverse((s, n) =>
            {
                t.Add(s, valueConverter(n.Value));
            });
            return t;
        }

        public abstract class TrieNodeBase
        {
            protected string MKey = "";
            protected TValue MValue;

            public TValue Value
            {
                get => MValue;
                set => MValue = value;
            }

            public string Key
            {
                get => MKey;
                set => MKey = value;
            }

            public bool HasValue => !Equals(MValue, default(TValue));
            public abstract bool IsLeaf { get; }

            public abstract TrieNodeBase this[char c] { get; }

            public abstract TrieNodeBase[] Nodes { get; }

            public abstract int ChildCount { get; }

            public abstract bool ShouldOptimize { get; }

            public abstract void SetLeaf();

            public abstract KeyValuePair<char, TrieNodeBase>[] CharNodePairs();

            public abstract TrieNodeBase AddChild(char c, ref int node_count);

            /// <summary>
            /// Includes current node value
            /// </summary>
            /// <returns></returns>
            public IEnumerable<TValue> SubsumedValues()
            {
                if (Value != null)
                    yield return Value;
                if (Nodes != null)
                    foreach (var child in Nodes)
                        if (child != null)
                            foreach (var t in child.SubsumedValues())
                                yield return t;
            }

            /// <summary>
            /// Includes current node
            /// </summary>
            /// <returns></returns>
            public IEnumerable<TrieNodeBase> SubsumedNodes()
            {
                yield return this;
                if (Nodes != null)
                    foreach (var child in Nodes)
                        if (child != null)
                            foreach (var n in child.SubsumedNodes())
                                yield return n;
            }

            /// <summary>
            /// Doesn't include current node
            /// </summary>
            /// <returns></returns>
            public IEnumerable<TrieNodeBase> SubsumedNodesExceptThis()
            {
                if (Nodes != null)
                    foreach (var child in Nodes)
                        if (child != null)
                            foreach (var n in child.SubsumedNodes())
                                yield return n;
            }

            /// <summary>
            /// Note: doesn't de-optimize optimized nodes if re-run later
            /// </summary>
            public void OptimizeChildNodes()
            {
                if (Nodes != null)
                    foreach (var q in CharNodePairs())
                    {
                        var nOld = q.Value;
                        if (nOld.ShouldOptimize)
                        {
                            TrieNodeBase nNew = new SparseTrieNode(nOld.CharNodePairs());
                            nNew.MValue = nOld.MValue;
                            c_sparse_nodes++;
                            ReplaceChild(q.Key, nNew);
                        }
                        nOld.OptimizeChildNodes();
                    }
            }

            public abstract void ReplaceChild(char c, TrieNodeBase n);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        /// Sparse Trie Node
        ///
        /// currently, this one's "nodes" value is never null, because we leave leaf nodes as the non-sparse type,
        /// (with nodes==null) and they currently never get converted back. Consequently, IsLeaf should always be 'false'.
        /// However, we're gonna do the check anyway.
        /// 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class SparseTrieNode : TrieNodeBase
        {
            private Dictionary<char, TrieNodeBase> d;

            public SparseTrieNode(IEnumerable<KeyValuePair<char, TrieNodeBase>> ie)
            {
                d = new Dictionary<char, TrieNodeBase>();
                foreach (var kvp in ie)
                    d.Add(kvp.Key, kvp.Value);
            }

            public override TrieNodeBase this[char c]
            {
                get
                {
                    TrieNodeBase node;
                    return d.TryGetValue(c, out node) ? node : null;
                }
            }

            public override TrieNodeBase[] Nodes => d.Values.ToArray();

            public override int ChildCount => d.Count;

            public override bool ShouldOptimize => false;
            public override bool IsLeaf => d == null;

            /// <summary>
            /// do not use in current form. This means, run OptimizeSparseNodes *after* any pruning
            /// </summary>
            public override void SetLeaf() { d = null; }

            public override KeyValuePair<char, TrieNodeBase>[] CharNodePairs()
            {
                return d.ToArray();
            }

            public override TrieNodeBase AddChild(char c, ref int nodeCount)
            {
                TrieNodeBase node;
                if (!d.TryGetValue(c, out node))
                {
                    node = new TrieNode();
                    nodeCount++;
                    d.Add(c, node);
                }
                return node;
            }

            public override void ReplaceChild(char c, TrieNodeBase n)
            {
                d[c] = n;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        /// Non-sparse Trie Node
        ///
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class TrieNode : TrieNodeBase
        {
            private char m_base;
            private TrieNodeBase[] nodes;

            public override int ChildCount { get { return nodes != null ? nodes.Count(e => e != null) : 0; } }
            public int AllocatedChildCount => nodes != null ? nodes.Length : 0;

            public override TrieNodeBase[] Nodes => nodes;

            public override TrieNodeBase this[char c]
            {
                get
                {
                    if (nodes != null && m_base <= c && c < m_base + nodes.Length)
                        return nodes[c - m_base];
                    return null;
                }
            }

            public override bool ShouldOptimize
            {
                get
                {
                    if (nodes == null)
                        return false;
                    return ChildCount * 9 < nodes.Length;     // empirically determined optimal value (space & time)
                }
            }

            public override bool IsLeaf => nodes == null;

            public override void SetLeaf() { nodes = null; }

            public override KeyValuePair<char, TrieNodeBase>[] CharNodePairs()
            {
                var rg = new KeyValuePair<char, TrieNodeBase>[ChildCount];
                var ch = m_base;
                var i = 0;
                foreach (var child in nodes)
                {
                    if (child != null)
                        rg[i++] = new KeyValuePair<char, TrieNodeBase>(ch, child);
                    ch++;
                }
                return rg;
            }

            public override TrieNodeBase AddChild(char c, ref int node_count)
            {
                if (nodes == null)
                {
                    m_base = c;
                    nodes = new TrieNodeBase[1];
                }
                else if (c >= m_base + nodes.Length)
                {
                    Array.Resize(ref nodes, c - m_base + 1);
                }
                else if (c < m_base)
                {
                    var cNew = (char)(m_base - c);
                    var tmp = new TrieNodeBase[nodes.Length + cNew];
                    nodes.CopyTo(tmp, cNew);
                    m_base = c;
                    nodes = tmp;
                }

                var node = nodes[c - m_base];
                if (node == null)
                {
                    node = new TrieNode();
                    node_count++;
                    nodes[c - m_base] = node;
                }
                return node;
            }

            public override void ReplaceChild(char c, TrieNodeBase n)
            {
                if (nodes == null || c >= m_base + nodes.Length || c < m_base)
                    throw new Exception();
                nodes[c - m_base] = n;
            }
        }


        /// <summary>
        /// Debug only; this is hideously inefficient
        /// </summary>
        private delegate bool GetKeyHelper(TrieNodeBase cur);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///
    ///
    ///
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class TrieExtension
    {
        public static Trie<TValue> ToTrie<TValue>(this IEnumerable<string> src, Func<string, int, TValue> selector)
        {
            var t = new Trie<TValue>();
            var idx = 0;
            foreach (var s in src)
                t.Add(s, selector(s, idx++));
            return t;
        }

        public static Trie<TValue> ToTrie<TValue>(this Dictionary<string, TValue> src)
        {
            var t = new Trie<TValue>();
            foreach (var kvp in src)
                t.Add(kvp.Key, kvp.Value);
            return t;
        }

        public static IEnumerable<TValue> AllSubstringValues<TValue>(this string s, Trie<TValue> trie)
        {
            return trie.AllSubstringValues(s);
        }

        public static void AddToValueHashset<TKey, TValue>(this Dictionary<TKey, HashSet<TValue>> d, TKey k, TValue v)
        {
            HashSet<TValue> hs;
            if (d.TryGetValue(k, out hs))
                hs.Add(v);
            else
                d.Add(k, new HashSet<TValue> { v });
        }
    }
}
