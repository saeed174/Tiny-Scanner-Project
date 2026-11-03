using System;
using System.Collections.Generic;
using System.Text;

namespace TinyScanner
{
    internal class TinyScanner
    {
        private string sourceCode;
        private int pos;
        private int line;

        private static readonly Dictionary<string, TokenType> Keywords = new Dictionary<string, TokenType>(StringComparer.OrdinalIgnoreCase)
        {
            { "if",     TokenType.IF },
            { "then",   TokenType.THEN },
            { "end",    TokenType.END },
            { "repeat", TokenType.REPEAT },
            { "until",  TokenType.UNTIL },
            { "read",   TokenType.READ },
            { "write",  TokenType.WRITE }
        };

        public TinyScanner(string sourceCode)
        {
            this.sourceCode = sourceCode;
            this.pos = 0;
            this.line = 1;
        }

        public Token GetNextToken()
        {
            while (pos < sourceCode.Length && char.IsWhiteSpace(sourceCode[pos]))
            {
                if (sourceCode[pos] == '\n')
                {
                    line++;
                }
                pos++;
                continue;
            }
            if (pos >= sourceCode.Length)
            {
                return new Token("EOF", TokenType.ENDOFFILE);
            }


            char currentChar = sourceCode[pos];

            if (char.IsLetter(currentChar))
            {
                return ReadIdentifierOrKeyword();
            }

            if (char.IsDigit(currentChar))
            {
                return ReadNumber();
            }

            if (currentChar == ':')
            {
                if (pos + 1 < sourceCode.Length && sourceCode[pos + 1] == '=')
                {
                    pos += 2;
                    return new Token(":=", TokenType.ASSIGN);
                }
                else
                {
                    pos++;
                    return new Token(":", TokenType.ERROR);
                }
            }

            switch (currentChar)
            {
                case ';':
                    pos++;
                    return new Token(";", TokenType.SEMICOLON);
                case '+':
                    pos++;
                    return new Token("+", TokenType.PLUS);
                case '-':
                    pos++;
                    return new Token("-", TokenType.MINUS);
                case '*':
                    pos++;
                    return new Token("*", TokenType.MULT);
                case '/':
                    pos++;
                    return new Token("/", TokenType.DIV);
                case '<':
                    pos++;
                    return new Token("<", TokenType.LESSTHAN);
                case '=':
                    pos++;
                    return new Token("=", TokenType.EQUAL);
                case '(':
                    pos++;
                    return new Token("(", TokenType.OPENBRACKET);
                case ')':
                    pos++;
                    return new Token(")", TokenType.CLOSEDBRACKET);
                default:
                    pos++;
                    return new Token(currentChar.ToString(), TokenType.ERROR);
            }
            return new Token("EOF", TokenType.ENDOFFILE);
        }

        private Token ReadIdentifierOrKeyword()
        {
            StringBuilder sb = new StringBuilder();
            while (pos < sourceCode.Length && char.IsLetterOrDigit(sourceCode[pos]))
            {
                sb.Append(sourceCode[pos]);
                pos++;
            }
            string value = sb.ToString();
            if (Keywords.ContainsKey(value))
            {
                return new Token(value, Keywords[value]);
            }
            return new Token(value, TokenType.IDENTIFIER);
        }

        private Token ReadNumber() {
            StringBuilder sb = new StringBuilder();
            while (pos < sourceCode.Length && char.IsDigit(sourceCode[pos]))
            {
                sb.Append(sourceCode[pos]);
                pos++;
            }
            return new Token(sb.ToString(), TokenType.NUMBER);
        }

        public List<Token> Scan()
        {
            List<Token> tokens = new List<Token>();
            Token token;
            do
            {
                token = GetNextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.ENDOFFILE);
            return tokens;
        }
    }
}
