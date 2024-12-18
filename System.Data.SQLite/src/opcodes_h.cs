namespace System.Data.SQLite
{
    public partial class Sqlite3
    {
        /* Automatically generated.  Do not edit */
        /* See the mkopcodeh.awk script for details */
        /* Automatically generated.  Do not edit */
        /* See the mkopcodeh.awk script for details */
        //#define OP_Goto                                 1
        //#define OP_Gosub                                2
        //#define OP_Return                               3
        //#define OP_Yield                                4
        //#define OP_HaltIfNull                           5
        //#define OP_Halt                                 6
        //#define OP_Integer                              7
        //#define OP_Int64                                8
        //#define OP_Real                               130   /* same as TK_FLOAT    */
        //#define OP_String8                             94   /* same as TK_STRING   */
        //#define OP_String                               9
        //#define OP_Null                                10
        //#define OP_Blob                                11
        //#define OP_Variable                            12
        //#define OP_Move                                13
        //#define OP_Copy                                14
        //#define OP_SCopy                               15
        //#define OP_ResultRow                           16
        //#define OP_Concat                              91   /* same as TK_CONCAT   */
        //#define OP_Add                                 86   /* same as TK_PLUS     */
        //#define OP_Subtract                            87   /* same as TK_MINUS    */
        //#define OP_Multiply                            88   /* same as TK_STAR     */
        //#define OP_Divide                              89   /* same as TK_SLASH    */
        //#define OP_Remainder                           90   /* same as TK_REM      */
        //#define OP_CollSeq                             17
        //#define OP_Function                            18
        //#define OP_BitAnd                              82   /* same as TK_BITAND   */
        //#define OP_BitOr                               83   /* same as TK_BITOR    */
        //#define OP_ShiftLeft                           84   /* same as TK_LSHIFT   */
        //#define OP_ShiftRight                          85   /* same as TK_RSHIFT   */
        //#define OP_AddImm                              20
        //#define OP_MustBeInt                           21
        //#define OP_RealAffinity                        22
        //#define OP_ToText                             141   /* same as TK_TO_TEXT  */
        //#define OP_ToBlob                             142   /* same as TK_TO_BLOB  */
        //#define OP_ToNumeric                          143   /* same as TK_TO_NUMERIC*/
        //#define OP_ToInt                              144   /* same as TK_TO_INT   */
        //#define OP_ToReal                             145   /* same as TK_TO_REAL  */
        //#define OP_Eq                                  76   /* same as TK_EQ       */
        //#define OP_Ne                                  75   /* same as TK_NE       */
        //#define OP_Lt                                  79   /* same as TK_LT       */
        //#define OP_Le                                  78   /* same as TK_LE       */
        //#define OP_Gt                                  77   /* same as TK_GT       */
        //#define OP_Ge                                  80   /* same as TK_GE       */
        //#define OP_Permutation                         23
        //#define OP_Compare                             24
        //#define OP_Jump                                25
        //#define OP_And                                 69   /* same as TK_AND      */
        //#define OP_Or                                  68   /* same as TK_OR       */
        //#define OP_Not                                 19   /* same as TK_NOT      */
        //#define OP_BitNot                              93   /* same as TK_BITNOT   */
        //#define OP_If                                  26
        //#define OP_IfNot                               27
        //#define OP_IsNull                              73   /* same as TK_ISNULL   */
        //#define OP_NotNull                             74   /* same as TK_NOTNULL  */
        //#define OP_Column                              28
        //#define OP_Affinity                            29
        //#define OP_MakeRecord                          30
        //#define OP_Count                               31
        //#define OP_Savepoint                           32
        //#define OP_AutoCommit                          33
        //#define OP_Transaction                         34
        //#define OP_ReadCookie                          35
        //#define OP_SetCookie                           36
        //#define OP_VerifyCookie                        37
        //#define OP_OpenRead                            38
        //#define OP_OpenWrite                           39
        //#define OP_OpenAutoindex                       40
        //#define OP_OpenEphemeral                       41
        //#define OP_OpenPseudo                          42
        //#define OP_Close                               43
        //#define OP_SeekLt                              44
        //#define OP_SeekLe                              45
        //#define OP_SeekGe                              46
        //#define OP_SeekGt                              47
        //#define OP_Seek                                48
        //#define OP_NotFound                            49
        //#define OP_Found                               50
        //#define OP_IsUnique                            51
        //#define OP_NotExists                           52
        //#define OP_Sequence                            53
        //#define OP_NewRowid                            54
        //#define OP_Insert                              55
        //#define OP_InsertInt                           56
        //#define OP_Delete                              57
        //#define OP_ResetCount                          58
        //#define OP_RowKey                              59
        //#define OP_RowData                             60
        //#define OP_Rowid                               61
        //#define OP_NullRow                             62
        //#define OP_Last                                63
        //#define OP_Sort                                64
        //#define OP_Rewind                              65
        //#define OP_Prev                                66
        //#define OP_Next                                67
        //#define OP_IdxInsert                           70
        //#define OP_IdxDelete                           71
        //#define OP_IdxRowid                            72
        //#define OP_IdxLT                               81
        //#define OP_IdxGE                               92
        //#define OP_Destroy                             95
        //#define OP_Clear                               96
        //#define OP_CreateIndex                         97
        //#define OP_CreateTable                         98
        //#define OP_ParseSchema                         99
        //#define OP_LoadAnalysis                       100
        //#define OP_DropTable                          101
        //#define OP_DropIndex                          102
        //#define OP_DropTrigger                        103
        //#define OP_IntegrityCk                        104
        //#define OP_RowSetAdd                          105
        //#define OP_RowSetRead                         106
        //#define OP_RowSetTest                         107
        //#define OP_Program                            108
        //#define OP_Param                              109
        //#define OP_FkCounter                          110
        //#define OP_FkIfZero                           111
        //#define OP_MemMax                             112
        //#define OP_IfPos                              113
        //#define OP_IfNeg                              114
        //#define OP_IfZero                             115
        //#define OP_AggStep                            116
        //#define OP_AggFinal                           117
        //#define OP_Checkpoint                         118
        //#define OP_JournalMode                        119
        //#define OP_Vacuum                             120
        //#define OP_IncrVacuum                         121
        //#define OP_Expire                             122
        //#define OP_TableLock                          123
        //#define OP_VBegin                             124
        //#define OP_VCreate                            125
        //#define OP_VDestroy                           126
        //#define OP_VOpen                              127
        //#define OP_VFilter                            128
        //#define OP_VColumn                            129
        //#define OP_VNext                              131
        //#define OP_VRename                            132
        //#define OP_VUpdate                            133
        //#define OP_Pagecount                          134
        //#define OP_MaxPgcnt                           135
        //#define OP_Trace                              136
        //#define OP_Noop                               137
        //#define OP_Explain                            138

        public const int OP_Goto = 1;
        public const int OP_Gosub = 2;
        public const int OP_Return = 3;
        public const int OP_Yield = 4;
        public const int OP_HaltIfNull = 5;
        public const int OP_Halt = 6;
        public const int OP_Integer = 7;
        public const int OP_Int64 = 8;
        public const int OP_Real = 130   /* same as TK_FLOAT    */;
        public const int OP_String8 = 94   /* same as TK_STRING   */;
        public const int OP_String = 9;
        public const int OP_Null = 10;
        public const int OP_Blob = 11;
        public const int OP_Variable = 12;
        public const int OP_Move = 13;
        public const int OP_Copy = 14;
        public const int OP_SCopy = 15;
        public const int OP_ResultRow = 16;
        public const int OP_Concat = 91   /* same as TK_CONCAT   */;
        public const int OP_Add = 86   /* same as TK_PLUS     */;
        public const int OP_Subtract = 87   /* same as TK_MINUS    */;
        public const int OP_Multiply = 88   /* same as TK_STAR     */;
        public const int OP_Divide = 89   /* same as TK_SLASH    */;
        public const int OP_Remainder = 90   /* same as TK_REM      */;
        public const int OP_CollSeq = 17;
        public const int OP_Function = 18;
        public const int OP_BitAnd = 82   /* same as TK_BITAND   */;
        public const int OP_BitOr = 83   /* same as TK_BITOR    */;
        public const int OP_ShiftLeft = 84   /* same as TK_LSHIFT   */;
        public const int OP_ShiftRight = 85   /* same as TK_RSHIFT   */;
        public const int OP_AddImm = 20;
        public const int OP_MustBeInt = 21;
        public const int OP_RealAffinity = 22;
        public const int OP_ToText = 141   /* same as TK_TO_TEXT  */;
        public const int OP_ToBlob = 142   /* same as TK_TO_BLOB  */;
        public const int OP_ToNumeric = 143   /* same as TK_TO_NUMERIC*/;
        public const int OP_ToInt = 144   /* same as TK_TO_INT   */;
        public const int OP_ToReal = 145   /* same as TK_TO_REAL  */;
        public const int OP_Eq = 76   /* same as TK_EQ       */;
        public const int OP_Ne = 75   /* same as TK_NE       */;
        public const int OP_Lt = 79   /* same as TK_LT       */;
        public const int OP_Le = 78   /* same as TK_LE       */;
        public const int OP_Gt = 77   /* same as TK_GT       */;
        public const int OP_Ge = 80   /* same as TK_GE       */;
        public const int OP_Permutation = 23;
        public const int OP_Compare = 24;
        public const int OP_Jump = 25;
        public const int OP_And = 69   /* same as TK_AND      */;
        public const int OP_Or = 68   /* same as TK_OR       */;
        public const int OP_Not = 19   /* same as TK_NOT      */;
        public const int OP_BitNot = 93   /* same as TK_BITNOT   */;
        public const int OP_If = 26;
        public const int OP_IfNot = 27;
        public const int OP_IsNull = 73   /* same as TK_ISNULL   */;
        public const int OP_NotNull = 74   /* same as TK_NOTNULL  */;
        public const int OP_Column = 28;
        public const int OP_Affinity = 29;
        public const int OP_MakeRecord = 30;
        public const int OP_Count = 31;
        public const int OP_Savepoint = 32;
        public const int OP_AutoCommit = 33;
        public const int OP_Transaction = 34;
        public const int OP_ReadCookie = 35;
        public const int OP_SetCookie = 36;
        public const int OP_VerifyCookie = 37;
        public const int OP_OpenRead = 38;
        public const int OP_OpenWrite = 39;
        public const int OP_OpenAutoindex = 40;
        public const int OP_OpenEphemeral = 41;
        public const int OP_OpenPseudo = 42;
        public const int OP_Close = 43;
        public const int OP_SeekLt = 44;
        public const int OP_SeekLe = 45;
        public const int OP_SeekGe = 46;
        public const int OP_SeekGt = 47;
        public const int OP_Seek = 48;
        public const int OP_NotFound = 49;
        public const int OP_Found = 50;
        public const int OP_IsUnique = 51;
        public const int OP_NotExists = 52;
        public const int OP_Sequence = 53;
        public const int OP_NewRowid = 54;
        public const int OP_Insert = 55;
        public const int OP_InsertInt = 56;
        public const int OP_Delete = 57;
        public const int OP_ResetCount = 58;
        public const int OP_RowKey = 59;
        public const int OP_RowData = 60;
        public const int OP_Rowid = 61;
        public const int OP_NullRow = 62;
        public const int OP_Last = 63;
        public const int OP_Sort = 64;
        public const int OP_Rewind = 65;
        public const int OP_Prev = 66;
        public const int OP_Next = 67;
        public const int OP_IdxInsert = 70;
        public const int OP_IdxDelete = 71;
        public const int OP_IdxRowid = 72;
        public const int OP_IdxLT = 81;
        public const int OP_IdxGE = 92;
        public const int OP_Destroy = 95;
        public const int OP_Clear = 96;
        public const int OP_CreateIndex = 97;
        public const int OP_CreateTable = 98;
        public const int OP_ParseSchema = 99;
        public const int OP_LoadAnalysis = 100;
        public const int OP_DropTable = 101;
        public const int OP_DropIndex = 102;
        public const int OP_DropTrigger = 103;
        public const int OP_IntegrityCk = 104;
        public const int OP_RowSetAdd = 105;
        public const int OP_RowSetRead = 106;
        public const int OP_RowSetTest = 107;
        public const int OP_Program = 108;
        public const int OP_Param = 109;
        public const int OP_FkCounter = 110;
        public const int OP_FkIfZero = 111;
        public const int OP_MemMax = 112;
        public const int OP_IfPos = 113;
        public const int OP_IfNeg = 114;
        public const int OP_IfZero = 115;
        public const int OP_AggStep = 116;
        public const int OP_AggFinal = 117;
        public const int OP_Checkpoint = 118;
        public const int OP_JournalMode = 119;
        public const int OP_Vacuum = 120;
        public const int OP_IncrVacuum = 121;
        public const int OP_Expire = 122;
        public const int OP_TableLock = 123;
        public const int OP_VBegin = 124;
        public const int OP_VCreate = 125;
        public const int OP_VDestroy = 126;
        public const int OP_VOpen = 127;
        public const int OP_VFilter = 128;
        public const int OP_VColumn = 129;
        public const int OP_VNext = 131;
        public const int OP_VRename = 132;
        public const int OP_VUpdate = 133;
        public const int OP_Pagecount = 134;
        public const int OP_MaxPgcnt = 135;
        public const int OP_Trace = 136;
        public const int OP_Noop = 137;
        public const int OP_Explain = 138;

        /* The following opcode values are never used */
        //#define OP_NotUsed_139                        139
        //#define OP_NotUsed_140                        140

        /* The following opcode values are never used */
        public const int OP_NotUsed_138 = 138;
        public const int OP_NotUsed_139 = 139;
        public const int OP_NotUsed_140 = 140;


        /* Properties such as "out2" or "jump" that are specified in
		** comments following the "case" for each opcode in the vdbe.c
		** are encoded into bitvectors as follows:
		*/
        //#define OPFLG_JUMP            0x0001  /* jump:  P2 holds jmp target */
        //#define OPFLG_OUT2_PRERELEASE 0x0002  /* out2-prerelease: */
        //#define OPFLG_IN1             0x0004  /* in1:   P1 is an input */
        //#define OPFLG_IN2             0x0008  /* in2:   P2 is an input */
        //#define OPFLG_IN3             0x0010  /* in3:   P3 is an input */
        //#define OPFLG_OUT2            0x0020  /* out2:  P2 is an output */
        //#define OPFLG_OUT3            0x0040  /* out3:  P3 is an output */

        public const int OPFLG_JUMP = 0x0001;            /* jump:  P2 holds jmp target */
        public const int OPFLG_OUT2_PRERELEASE = 0x0002; /* out2-prerelease: */
        public const int OPFLG_IN1 = 0x0004;             /* in1:   P1 is an input */
        public const int OPFLG_IN2 = 0x0008;             /* in2:   P2 is an input */
        public const int OPFLG_IN3 = 0x0010;             /* in3:   P3 is an input */
        public const int OPFLG_OUT2 = 0x0020;            /* out2:  P2 is an output */
        public const int OPFLG_OUT3 = 0x0040;            /* out3:  P3 is an output */
        public static int[] OPFLG_INITIALIZER = new int[]{
/*   0 */ 0x00, 0x01, 0x05, 0x04, 0x04, 0x10, 0x00, 0x02,
/*   8 */ 0x02, 0x02, 0x02, 0x02, 0x02, 0x00, 0x24, 0x24,
/*  16 */ 0x00, 0x00, 0x00, 0x24, 0x04, 0x05, 0x04, 0x00,
/*  24 */ 0x00, 0x01, 0x05, 0x05, 0x00, 0x00, 0x00, 0x02,
/*  32 */ 0x00, 0x00, 0x00, 0x02, 0x10, 0x00, 0x00, 0x00,
/*  40 */ 0x00, 0x00, 0x00, 0x00, 0x11, 0x11, 0x11, 0x11,
/*  48 */ 0x08, 0x11, 0x11, 0x11, 0x11, 0x02, 0x02, 0x00,
/*  56 */ 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x01,
/*  64 */ 0x01, 0x01, 0x01, 0x01, 0x4c, 0x4c, 0x08, 0x00,
/*  72 */ 0x02, 0x05, 0x05, 0x15, 0x15, 0x15, 0x15, 0x15,
/*  80 */ 0x15, 0x01, 0x4c, 0x4c, 0x4c, 0x4c, 0x4c, 0x4c,
/*  88 */ 0x4c, 0x4c, 0x4c, 0x4c, 0x01, 0x24, 0x02, 0x02,
/*  96 */ 0x00, 0x02, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00,
/* 104 */ 0x00, 0x0c, 0x45, 0x15, 0x01, 0x02, 0x00, 0x01,
/* 112 */ 0x08, 0x05, 0x05, 0x05, 0x00, 0x00, 0x00, 0x02,
/* 120 */ 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
/* 128 */ 0x01, 0x00, 0x02, 0x01, 0x00, 0x00, 0x02, 0x02,
/* 136 */ 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x04, 0x04,
/* 144 */ 0x04, 0x04
};
    }
}
