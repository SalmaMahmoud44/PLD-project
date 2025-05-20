
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using com.calitha.goldparser;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF         =  0, // (EOF)
        SYMBOL_ERROR       =  1, // (Error)
        SYMBOL_WHITESPACE  =  2, // Whitespace
        SYMBOL_MINUS       =  3, // '-'
        SYMBOL_EXCLAMEQ    =  4, // '!='
        SYMBOL_LPAREN      =  5, // '('
        SYMBOL_RPAREN      =  6, // ')'
        SYMBOL_TIMES       =  7, // '*'
        SYMBOL_COMMA       =  8, // ','
        SYMBOL_DIV         =  9, // '/'
        SYMBOL_PLUS        = 10, // '+'
        SYMBOL_LT          = 11, // '<'
        SYMBOL_EQ          = 12, // '='
        SYMBOL_EQEQ        = 13, // '=='
        SYMBOL_GT          = 14, // '>'
        SYMBOL_3LA         = 15, // '3la'
        SYMBOL_3RF         = 16, // '3rf'
        SYMBOL_7OT         = 17, // '7ot'
        SYMBOL_A3ML        = 18, // 'a3ml'
        SYMBOL_BOOL        = 19, // bool
        SYMBOL_BRDO        = 20, // brdo
        SYMBOL_DIGIT       = 21, // digit
        SYMBOL_E3ML        = 22, // 'e3ml'
        SYMBOL_END         = 23, // end
        SYMBOL_ID          = 24, // id
        SYMBOL_KALAM       = 25, // kalam
        SYMBOL_KASR        = 26, // kasr
        SYMBOL_KOL_SHWAYA  = 27, // 'kol_shwaya'
        SYMBOL_LAW         = 28, // law
        SYMBOL_LW          = 29, // lw
        SYMBOL_NADY        = 30, // nady
        SYMBOL_RAKAM       = 31, // rakam
        SYMBOL_START       = 32, // start
        SYMBOL_ASSIGN_STMT = 33, // <assign_stmt>
        SYMBOL_COND_STMT   = 34, // <cond_stmt>
        SYMBOL_DECL_STMT   = 35, // <decl_stmt>
        SYMBOL_DIGIT2      = 36, // <digit>
        SYMBOL_ELKALAM     = 37, // <elkalam>
        SYMBOL_ELSHART     = 38, // <elshart>
        SYMBOL_EXPR        = 39, // <expr>
        SYMBOL_FACTOR      = 40, // <factor>
        SYMBOL_ID2         = 41, // <id>
        SYMBOL_LOOP_STMT   = 42, // <loop_stmt>
        SYMBOL_M3AYA       = 43, // <m3aya>
        SYMBOL_METHOD_CALL = 44, // <method_call>
        SYMBOL_METHOD_DECL = 45, // <method_decl>
        SYMBOL_OP          = 46, // <op>
        SYMBOL_PROGRAM     = 47, // <program>
        SYMBOL_STMT_LIST   = 48, // <stmt_list>
        SYMBOL_TERM        = 49, // <term>
        SYMBOL_TYPE        = 50, // <type>
        SYMBOL_WDI         = 51  // <wdi>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                                   =  0, // <program> ::= start <stmt_list> end
        RULE_STMT_LIST                                                           =  1, // <stmt_list> ::= <elkalam>
        RULE_STMT_LIST2                                                          =  2, // <stmt_list> ::= <elkalam> <stmt_list>
        RULE_ELKALAM                                                             =  3, // <elkalam> ::= <decl_stmt>
        RULE_ELKALAM2                                                            =  4, // <elkalam> ::= <assign_stmt>
        RULE_ELKALAM3                                                            =  5, // <elkalam> ::= <cond_stmt>
        RULE_ELKALAM4                                                            =  6, // <elkalam> ::= <loop_stmt>
        RULE_ELKALAM5                                                            =  7, // <elkalam> ::= <method_decl>
        RULE_ELKALAM6                                                            =  8, // <elkalam> ::= <method_call>
        RULE_ID_ID                                                               =  9, // <id> ::= id
        RULE_DIGIT_DIGIT                                                         = 10, // <digit> ::= digit
        RULE_DECL_STMT_3RF                                                       = 11, // <decl_stmt> ::= '3rf' <id> <type>
        RULE_TYPE_RAKAM                                                          = 12, // <type> ::= rakam
        RULE_TYPE_KASR                                                           = 13, // <type> ::= kasr
        RULE_TYPE_KALAM                                                          = 14, // <type> ::= kalam
        RULE_TYPE_BOOL                                                           = 15, // <type> ::= bool
        RULE_ASSIGN_STMT_7OT_LPAREN_EQ_LPAREN_RPAREN                             = 16, // <assign_stmt> ::= '7ot' '(' <id> '=' '(' <expr> ')'
        RULE_EXPR_PLUS                                                           = 17, // <expr> ::= <term> '+' <expr>
        RULE_EXPR_MINUS                                                          = 18, // <expr> ::= <term> '-' <expr>
        RULE_EXPR                                                                = 19, // <expr> ::= <term>
        RULE_TERM_TIMES                                                          = 20, // <term> ::= <factor> '*' <term>
        RULE_TERM_DIV                                                            = 21, // <term> ::= <factor> '/' <term>
        RULE_TERM                                                                = 22, // <term> ::= <factor>
        RULE_FACTOR                                                              = 23, // <factor> ::= <id>
        RULE_FACTOR2                                                             = 24, // <factor> ::= <digit>
        RULE_COND_STMT_LW_LPAREN_RPAREN_A3ML_LPAREN_RPAREN                       = 25, // <cond_stmt> ::= lw '(' <elshart> ')' 'a3ml' '(' <stmt_list> ')'
        RULE_COND_STMT_LW_LPAREN_RPAREN_A3ML_LPAREN_RPAREN_LW_BRDO_LPAREN_RPAREN = 26, // <cond_stmt> ::= lw '(' <elshart> ')' 'a3ml' '(' <stmt_list> ')' lw brdo '(' <stmt_list> ')'
        RULE_ELSHART                                                             = 27, // <elshart> ::= <expr> <op> <expr>
        RULE_OP_LT                                                               = 28, // <op> ::= '<'
        RULE_OP_GT                                                               = 29, // <op> ::= '>'
        RULE_OP_EQEQ                                                             = 30, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                                         = 31, // <op> ::= '!='
        RULE_LOOP_STMT_KOL_SHWAYA_LAW_A3ML_LPAREN_RPAREN                         = 32, // <loop_stmt> ::= 'kol_shwaya' <id> law <elshart> 'a3ml' '(' <stmt_list> ')'
        RULE_METHOD_DECL_E3ML_LPAREN_RPAREN_LPAREN_RPAREN                        = 33, // <method_decl> ::= 'e3ml' <id> '(' <m3aya> ')' '(' <stmt_list> ')'
        RULE_M3AYA                                                               = 34, // <m3aya> ::= <id>
        RULE_M3AYA_COMMA                                                         = 35, // <m3aya> ::= <id> ',' <m3aya>
        RULE_METHOD_CALL_NADY_3LA_LPAREN_RPAREN                                  = 36, // <method_call> ::= nady '3la' <id> '(' <wdi> ')'
        RULE_WDI                                                                 = 37, // <wdi> ::= <expr>
        RULE_WDI_COMMA                                                           = 38  // <wdi> ::= <expr> ',' <wdi>
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox list;
        ListBox list2;

        public MyParser(string filename, ListBox list, ListBox list2)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.list = list;
            this.list2 = list2;

            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_3LA :
                //'3la'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_3RF :
                //'3rf'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_7OT :
                //'7ot'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_A3ML :
                //'a3ml'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BRDO :
                //brdo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_E3ML :
                //'e3ml'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KALAM :
                //kalam
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KASR :
                //kasr
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KOL_SHWAYA :
                //'kol_shwaya'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LAW :
                //law
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LW :
                //lw
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NADY :
                //nady
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RAKAM :
                //rakam
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN_STMT :
                //<assign_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND_STMT :
                //<cond_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECL_STMT :
                //<decl_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELKALAM :
                //<elkalam>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSHART :
                //<elshart>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP_STMT :
                //<loop_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_M3AYA :
                //<m3aya>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD_CALL :
                //<method_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD_DECL :
                //<method_decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WDI :
                //<wdi>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= start <stmt_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <elkalam>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <elkalam> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELKALAM :
                //<elkalam> ::= <decl_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELKALAM2 :
                //<elkalam> ::= <assign_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELKALAM3 :
                //<elkalam> ::= <cond_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELKALAM4 :
                //<elkalam> ::= <loop_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELKALAM5 :
                //<elkalam> ::= <method_decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELKALAM6 :
                //<elkalam> ::= <method_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECL_STMT_3RF :
                //<decl_stmt> ::= '3rf' <id> <type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_RAKAM :
                //<type> ::= rakam
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_KASR :
                //<type> ::= kasr
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_KALAM :
                //<type> ::= kalam
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_BOOL :
                //<type> ::= bool
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_STMT_7OT_LPAREN_EQ_LPAREN_RPAREN :
                //<assign_stmt> ::= '7ot' '(' <id> '=' '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <term> '+' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <term> '-' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <factor> '*' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <factor> '/' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR2 :
                //<factor> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_STMT_LW_LPAREN_RPAREN_A3ML_LPAREN_RPAREN :
                //<cond_stmt> ::= lw '(' <elshart> ')' 'a3ml' '(' <stmt_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_STMT_LW_LPAREN_RPAREN_A3ML_LPAREN_RPAREN_LW_BRDO_LPAREN_RPAREN :
                //<cond_stmt> ::= lw '(' <elshart> ')' 'a3ml' '(' <stmt_list> ')' lw brdo '(' <stmt_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSHART :
                //<elshart> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOP_STMT_KOL_SHWAYA_LAW_A3ML_LPAREN_RPAREN :
                //<loop_stmt> ::= 'kol_shwaya' <id> law <elshart> 'a3ml' '(' <stmt_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_DECL_E3ML_LPAREN_RPAREN_LPAREN_RPAREN :
                //<method_decl> ::= 'e3ml' <id> '(' <m3aya> ')' '(' <stmt_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_M3AYA :
                //<m3aya> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_M3AYA_COMMA :
                //<m3aya> ::= <id> ',' <m3aya>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_CALL_NADY_3LA_LPAREN_RPAREN :
                //<method_call> ::= nady '3la' <id> '(' <wdi> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WDI :
                //<wdi> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WDI_COMMA :
                //<wdi> ::= <expr> ',' <wdi>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"in line: "+args.UnexpectedToken.Location.LineNr;
            list.Items.Add(message);
            string m2 = "Expected token: " + args.ExpectedTokens.ToString();
            list.Items.Add(m2);
            //todo: Report message to UI?
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "   \t  \t" + (SymbolConstants)args.Token.Symbol.Id;
            list2.Items.Add(info);
        }

    }
}
