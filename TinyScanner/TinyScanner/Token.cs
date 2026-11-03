using System;
using System.Collections.Generic;
using System.Text;

namespace TinyScanner
{
    public enum TokenType
    {
        SEMICOLON,IF,THEN,END,REPEAT,UNTIL,READ,WRITE,IDENTIFIER,ASSIGN,LESSTHAN,EQUAL,
        PLUS,MINUS,MULT,DIV,OPENBRACKET,CLOSEDBRACKET,NUMBER,ENDOFFILE,ERROR
    }

    public class Token
    {
        public string Value { get; set; }
        public TokenType Type { get; set; }

        public Token(string value, TokenType type)
        {
            Value = value;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Value}, {Type}";
        }
    }
}
