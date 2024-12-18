﻿namespace OpenNLP.Tools.Trees.TRegex.Tsurgeon
{
    /// <summary>
    /// Token literal values and constants.
    /// Generated by org.javacc.parser.OtherFilesGen#start()
    /// </summary>
    public abstract class TsurgeonParserConstants
    {
        /// <summary>End of File</summary>
        public const int Eof = 0;
        /// <summary>RegularExpression Id</summary>
        public const int OpenBracket = 5;
        /// <summary>RegularExpression Id</summary>
        public const int If = 6;
        /// <summary>RegularExpression Id</summary>
        public const int Not = 7;
        /// <summary>RegularExpression Id</summary>
        public const int Exists = 8;
        /// <summary>RegularExpression Id</summary>
        public const int Delete = 9;
        /// <summary>RegularExpression Id</summary>
        public const int Prune = 10;
        /// <summary>RegularExpression Id</summary>
        public const int Relabel = 11;
        /// <summary>RegularExpression Id</summary>
        public const int Excise = 12;
        /// <summary>RegularExpression Id</summary>
        public const int Insert = 13;
        /// <summary>RegularExpression Id</summary>
        public const int Move = 14;
        /// <summary>RegularExpression Id</summary>
        public const int Replace = 15;
        /// <summary>RegularExpression Id</summary>
        public const int CreateSubtree = 16;
        /// <summary>RegularExpression Id</summary>
        public const int Adjoin = 17;
        /// <summary>RegularExpression Id</summary>
        public const int AdjoinToHead = 18;
        /// <summary>RegularExpression Id</summary>
        public const int AdjoinToFoot = 19;
        /// <summary>RegularExpression Id</summary>
        public const int Coindex = 20;
        /// <summary>RegularExpression Id</summary>
        public const int Name = 21;
        /// <summary>RegularExpression Id</summary>
        public const int CloseBracket = 22;
        /// <summary>RegularExpression Id</summary>
        public const int Selection = 23;
        /// <summary>RegularExpression Id</summary>
        public const int GeneralRelabel = 24;
        /// <summary>RegularExpression Id</summary>
        public const int Identifier = 25;
        /// <summary>RegularExpression Id</summary>
        public const int LocationRelation = 26;
        /// <summary>RegularExpression Id</summary>
        public const int Regex = 27;
        /// <summary>RegularExpression Id</summary>
        public const int Quotex = 28;
        /// <summary>RegularExpression Id</summary>
        public const int HashInteger = 29;
        /// <summary>RegularExpression Id</summary>
        public const int TreeNodeTerminalLabel = 30;
        /// <summary>RegularExpression Id</summary>
        public const int TreeNodeNonterminalLabel = 31;
        /// <summary>RegularExpression Id</summary>
        public const int CloseParen = 32;

        /// <summary>Lexical state</summary>
        public const int Operation = 0;
        /// <summary>Lexical state</summary>
        public const int Conditional = 1;
        /// <summary>Lexical state</summary>
        public const int Default = 2;

        /// <summary>Literal token values</summary>
        public string[] TokenImages =
        {
            "<EOF>",
            "\" \"",
            "\"\\r\"",
            "\"\\t\"",
            "\"\\n\"",
            "\"[\"",
            "\"if\"",
            "\"not\"",
            "\"exists\"",
            "\"delete\"",
            "\"prune\"",
            "\"relabel\"",
            "\"excise\"",
            "\"insert\"",
            "\"move\"",
            "\"replace\"",
            "\"createSubtree\"",
            "\"adjoin\"",
            "\"adjoinH\"",
            "\"adjoinF\"",
            "\"coindex\"",
            "<NAME>",
            "\"]\"",
            "<SELECTION>",
            "<GENERAL_RELABEL>",
            "<IDENTIFIER>",
            "<LOCATION_RELATION>",
            "<REGEX>",
            "<QUOTEX>",
            "<HASH_INTEGER>",
            "<TREE_NODE_TERMINAL_LABEL>",
            "<TREE_NODE_NONTERMINAL_LABEL>",
            "\")\"",
        };
    }
}