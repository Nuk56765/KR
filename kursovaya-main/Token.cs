using System;

namespace WindowsFormsApp6
{
    public class Token//отдельный класс, хранящий его тип и значение
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Type} {Value}";
        }
    }

    public enum TokenType// формирование типа лексемы
    {
        
        IDENTIFIER,
        LITERAL,
        PLUS,
        MINUS,
        DIVISION,
        MULTIPLY,
        EQUAL,
        EXCLAM,
        MORE,
        LESS,
        LPAR,
        RPAR,
        VOID,
        MAIN,
        BEGIN,
        END,
        COMMA,
        SEMICOLON,
        INT,
        FLOAT,
        DOUBLE,
        BOOL,
        FOR,
        COLON,
        NETERMINAL,
        EOF,
        EXPR,
        Programma,
        SpisokOperatorov,
        OdinochniyOperator,
        Obyavlenie,
        Prisvaivanie,
        OperatorCikla,
        Expression,
        Tip,
        SpisokPeremennih,
        Prisvaivanie1,
        Operand,
        Uslovie,
        Znak2,
        Increment
    }
}
