using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{ 
    internal class Bauer
    {
        List<Token> tokens;
        int i = 0;//индекс итерации списка токенов
        Stack<Token> tmp = new Stack<Token>();//стек временного хранения токенов
        Stack<Token> E = new Stack<Token>();//Стек для хранения токенов из выражения. Результат преобразования (постфиксной записи)
        Stack<Token> T = new Stack<Token>();//операторы
        string str = "";//результат преобразований
        bool flag = true;//
        public Bauer(List<Token> tokens)
        {
            this.tokens = tokens;//параметр
            while (i < tokens.Count - 1)
            {
                i++;
                if (tokens[i].Type == TokenType.EQUAL)  //текущий токен оператор equal?
                {
                    if (tokens[i + 1].Type != TokenType.EQUAL)
                    {
                        i++;//итерация для перехода к следующему токену
                        Expr();
                        flag = true;
                        str += Matr() + "\r\n";
                    }
                    else
                    {
                        i++;//если текущий и следующий токен - оператор equal, то итерация
                    }
                }
            }
        }
        void K()
        {
            if (E.Count <= 1)//содержит ли стек E не менее одного элемента
            {
                throw new Exception("Отсутствуют операнды");
            }
            tmp.Push(E.Pop());//удаление верхнего элемента из стека, помещение в стек temp
            tmp.Push(E.Pop());
            while (tmp.Count > 0)
            {
                E.Push(tmp.Pop());//помещение в стек.
            }
        }
        void Expr() 
        {
            while (flag)
            {
                switch (tokens[i].Type)
                {
                    case TokenType.IDENTIFIER:
                        E.Push(tokens[i++]);
                        break;
                    case TokenType.LITERAL:
                        E.Push(tokens[i++]);
                        break;
                    case TokenType.SEMICOLON:
                        if(T.Count == 0)
                        {
                            flag = false;
                        }
                        else if (T.Peek().Type == TokenType.PLUS || T.Peek().Type == TokenType.MINUS
                            || T.Peek().Type == TokenType.MULTIPLY || T.Peek().Type == TokenType.DIVISION)
                        {
                            tmp.Push(T.Pop());
                            K();
                        }
                        else if(T.Peek().Type == TokenType.LPAR)
                        {
                            throw new Exception("Ошибка в арифметичсеком операторе");
                        }
                        else
                        {
                            throw new Exception("Ошибка в арифметичсеком операторе");
                        }
                        break;
                    case TokenType.LPAR:
                        T.Push(tokens[i++]);
                        break;
                    case TokenType.RPAR:
                        if(T.Count == 0)
                        {
                            throw new Exception("Ошибка в арифметичсеком операторе");
                        }
                        else if(T.Peek().Type == TokenType.LPAR)
                        {
                            T.Pop();
                            i++;
                        }
                        else if(T.Peek().Type == TokenType.PLUS || T.Peek().Type == TokenType.MINUS
                            || T.Peek().Type == TokenType.MULTIPLY || T.Peek().Type == TokenType.DIVISION)
                        {
                            tmp.Push(T.Pop());
                            K();
                        }
                        else
                        {
                            throw new Exception("Ошибка в арифметичсеком операторе");
                        }
                        break;
                    default:
                        if (tokens[i].Type == TokenType.PLUS || tokens[i].Type == TokenType.MINUS)
                        {
                            if (T.Count == 0 || T.Peek().Type == TokenType.LPAR)
                            {
                                T.Push(tokens[i++]);
                            }
                            else if (T.Peek().Type == TokenType.PLUS || T.Peek().Type == TokenType.MINUS)
                            {
                                tmp.Push(T.Pop());
                                K();
                                T.Push(tokens[i++]);
                            }
                            else if (T.Peek().Type == TokenType.MULTIPLY || T.Peek().Type == TokenType.DIVISION)
                            {
                                tmp.Push(T.Pop());
                                K();
                            }
                            else
                            {
                                throw new Exception("Ошибка в арифметичсеком операторе");
                            }
                        }
                        else if (tokens[i].Type == TokenType.MULTIPLY || tokens[i].Type == TokenType.DIVISION)
                        {
                            if (T.Count == 0 || T.Peek().Type == TokenType.LPAR || T.Peek().Type == TokenType.MINUS
                                || T.Peek().Type == TokenType.PLUS)
                            {
                                T.Push(tokens[i++]);
                            }
                            else if (T.Peek().Type == TokenType.MULTIPLY || T.Peek().Type == TokenType.DIVISION)
                            {
                                tmp.Push(T.Pop());
                                K();
                                T.Push(tokens[i++]);
                            }
                            else
                            {
                                throw new Exception("Ошибка в арифметичсеком операторе");
                            }
                        }
                        else
                        {
                            throw new Exception("Ошибка в арифметичсеком операторе");
                        }
                        break;
                }
            }
        }
        string Matr()
        {
            while (E.Count > 0)
            {
                tmp.Push(E.Pop());
            }
            string str = "", v = "";
            string[] s = new string[tmp.Count];
            Token t;
            int i = 1, j = 0;

            while (tmp.Count > 0)
            {
                t = tmp.Pop();
                if (t.Type == TokenType.PLUS || t.Type == TokenType.MINUS 
                    || t.Type == TokenType.MULTIPLY || t.Type == TokenType.DIVISION)
                {
                    if (j == 1)
                    {
                        throw new Exception("Отсутствует операнд");
                    }
                    if (t.Type == TokenType.PLUS)
                    {
                        v = "M" + i.ToString() + ": " + "+" + s[j - 2] + s[j - 1];
                    }
                    else if (t.Type == TokenType.MINUS)
                    {
                        v = "M" + i.ToString() + ": " + "-" + s[j - 2] + s[j - 1];
                    }
                    else if(t.Type == TokenType.MULTIPLY)
                    {
                        v = "M" + i.ToString() + ": " + "*" + s[j - 2] +
                       s[j - 1];
                    }
                    else if (t.Type == TokenType.DIVISION)
                    {
                        v = "M" + i.ToString() + ": " + "/" + s[j - 2] +
                       s[j - 1];
                    }
                    s[j - 2] = "M" + i++.ToString();
                    s[j - 1] = null;
                    j--;
                    str += v + "\r\n";
                }
                else
                { s[j++] = t.Value; }
            }
            return str;

        }
        public string Info()
        {
            return str;
        }
    }
}
