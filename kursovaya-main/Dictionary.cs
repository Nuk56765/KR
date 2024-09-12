using System.Collections.Generic;

namespace WindowsFormsApp6
{
    public static class SpecialWords
    {
        public static readonly Dictionary<string, TokenType> Words = new Dictionary<string, TokenType>() {
            {"void", TokenType.VOID},
            { "main", TokenType.MAIN},
            { "int", TokenType.INT },
            { "float", TokenType.FLOAT },
            { "double", TokenType.DOUBLE },
            { "bool", TokenType.BOOL },
            { "for", TokenType.FOR },
        };
    }

    public static class SpecialSymbols
    {
        public static readonly Dictionary<char, TokenType> Symbols = new Dictionary<char, TokenType>() {
            { ';', TokenType.SEMICOLON },
            { ':', TokenType.COLON },
            { '(', TokenType.LPAR },
            { ')', TokenType.RPAR },
            { '+', TokenType.PLUS },
            { '-', TokenType.MINUS },
            { '=', TokenType.EQUAL },
            { '!', TokenType.EXCLAM },
            { '*', TokenType.MULTIPLY },
            { '/', TokenType.DIVISION },
            { '>', TokenType.MORE },
            { '<', TokenType.LESS },
            { ',', TokenType.COMMA },
            { '{', TokenType.BEGIN },
            { '}', TokenType.END }
        };
    }
}
