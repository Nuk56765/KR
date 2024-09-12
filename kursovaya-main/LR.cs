using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    internal class LR

    {
        public List<Token> tokens;
        public Stack<Token> tokenStack;
        public Stack<int> stateStack;
        public int nextLex = 0;
        private bool isEnd = false;
        public int state = 0;
        int count = 0;
        public LR(List<Token> tokens)
        {
            this.tokens = tokens;
            tokenStack = new Stack<Token>();
            stateStack = new Stack<int>();
            GoToState(0);
        }

        public void Run()
        {
            Console.WriteLine("Run");
            while (isEnd != true)
            {
                switch (state)
                {
                    case 0: State0(); break;
                    case 1: State1(); break;
                    case 2: State2(); break;
                    case 3: State3(); break;
                    case 4: State4(); break;
                    case 5: State5(); break;
                    case 6: State6(); break;
                    case 7: State7(); break;
                    case 8: State8(); break;
                    case 9: State9(); break;
                    case 10: State10(); break;
                    case 13: State13(); break;
                    case 14: State14(); break;
                    case 15: State15(); break;
                    case 16: State16(); break;
                    case 17: State17(); break;
                    case 19: State19(); break;
                    case 20: State20(); break;
                    case 21: State21(); break;
                    case 23: State23(); break;
                    case 26: State26(); break;
                    case 27: State27(); break;
                    case 28: State28(); break;
                    case 29: State29(); break;
                    case 30: State30(); break;
                    case 31: State31(); break;
                    case 32: State32(); break;
                    case 33: State33(); break;
                    case 34: State34(); break;
                    case 35: State35(); break;
                    case 36: State36(); break;
                    case 37: State37(); break;
                    case 38: State38(); break;
                    case 40: State40(); break;
                    case 41: State41(); break;
                    case 42: State42(); break;
                    case 43: State43(); break;
                    case 44: State44(); break;
                    case 45: State45(); break;
                    case 46: State46(); break;
                    case 47: State47(); break;
                    case 48: State48(); break;
                    case 50: State50(); break;
                    case 51: State51(); break;
                    case 52: State52(); break;
                    case 53: State53(); break;
                    case 55: State55(); break;
                    case 56: State56(); break;
                    case 58: State58(); break;
                    case 59: State59(); break;
                    case 60: State60(); break;
                    case 62: State62(); break;
                    case 63: State63(); break;
                    case 64: State64(); break;
                    case 65: State65(); break;
                    case 66: State66(); break;
                    case 67: State67(); break;
                }
            }
        }

        void Reduce(int n, int count, TokenType type)
        {

            while (n > 0)
            {
                tokenStack.Pop();
                stateStack.Pop();
                n--;
            }
            while(count > 0)
            {
                tokenStack.Pop();
                count--;
            }
            Token token = new Token(type, "");
            tokenStack.Push(token);
            GoToState(stateStack.Pop());
        }

        void Shift()
        {
            tokenStack.Push(tokens[nextLex++]);
        }
        void GoToState(int state)
        {
            stateStack.Push(state);
            this.state = state;
        }
        void State0()
        {
            if (tokenStack.Count == 0)
            {
                Shift();
            }
            switch (tokenStack.Peek().Type)
            {
                case TokenType.Programma:
                    isEnd = true;
                    break;
                case TokenType.VOID:
                    GoToState(1);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State1()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.VOID:
                    Shift();
                    break;
                case TokenType.MAIN:
                    GoToState(2);
                    break;
                default: throw new Exception("Был встречен неверный токен");
            }
        }
        void State2()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.MAIN:
                    Shift();
                    break;
                case TokenType.LPAR:
                    GoToState(3);
                    break;
                default: 
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State3()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.LPAR:
                    Shift();
                    break;
                case TokenType.RPAR:
                    GoToState(4);
                    break;
                default: 
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State4()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.RPAR:
                    Shift();
                    break;
                case TokenType.BEGIN:
                    GoToState(5);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State5()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.BEGIN:
                    Shift();
                    break;
                case TokenType.SpisokOperatorov:
                    GoToState(6);
                    break;
                case TokenType.OdinochniyOperator:
                    GoToState(7);
                    break;
                case TokenType.Obyavlenie:
                    GoToState(8);
                    break;
                case TokenType.Prisvaivanie:
                    GoToState(9);
                    break;
                case TokenType.OperatorCikla:
                    GoToState(10);
                    break;
                case TokenType.Expression:
                    GoToState(13);
                    break;
                case TokenType.Tip:
                    GoToState(14);
                    break;
                case TokenType.INT:
                    GoToState(15);
                    break;
                case TokenType.FLOAT:
                    GoToState(16);
                    break;
                case TokenType.DOUBLE:
                    GoToState(17);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(20);
                    break;
                case TokenType.FOR:
                    GoToState(21);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State6()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.SpisokOperatorov:
                    Shift();
                    break;
                case TokenType.OdinochniyOperator:
                    GoToState(67);
                    break;
                case TokenType.END:
                    GoToState(23);
                    break;
                case TokenType.Obyavlenie:
                    GoToState(8);
                    break;
                case TokenType.Prisvaivanie:
                    GoToState(9);
                    break;
                case TokenType.OperatorCikla:
                    GoToState(10);
                    break;
                case TokenType.Expression:
                    GoToState(13);
                    break;
                case TokenType.Tip:
                    GoToState(14);
                    break;
                case TokenType.INT:
                    GoToState(15);
                    break;
                case TokenType.FLOAT:
                    GoToState(16);
                    break;
                case TokenType.DOUBLE:
                    GoToState(17);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(20);
                    break;
                case TokenType.FOR:
                    GoToState(21);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State7()
        {
            if(tokenStack.Peek().Type == TokenType.OdinochniyOperator)
            {
                Reduce(1, 0, TokenType.SpisokOperatorov);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State8()
        {
            if(tokenStack.Peek().Type == TokenType.Obyavlenie)
            {
                Reduce(1, 0, TokenType.OdinochniyOperator);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State9()
        {
            if(tokenStack.Peek().Type == TokenType.Prisvaivanie)
            {
                Reduce(1, 0, TokenType.OdinochniyOperator);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State10()
        {
            if(tokenStack.Peek().Type == TokenType.OperatorCikla)
            {
                Reduce(1, 0, TokenType.OdinochniyOperator);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State13()
        {
            if(tokenStack.Peek().Type == TokenType.Expression)
            {
                Reduce(1, 0, TokenType.OdinochniyOperator);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State14()
        {
            switch(tokenStack.Peek().Type)
            {
                case TokenType.Tip:
                    Shift();
                    break;
                case TokenType.SpisokPeremennih:
                    GoToState(32);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(63);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State15()
        {
            if(tokenStack.Peek().Type == TokenType.INT)
            {
                Reduce(1, 0, TokenType.Tip);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State16()
        {
            if (tokenStack.Peek().Type == TokenType.FLOAT)
            {
                Reduce(1, 0, TokenType.Tip);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State17()
        {
            if (tokenStack.Peek().Type == TokenType.DOUBLE)
            {
                Reduce(1, 0, TokenType.Tip);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State19()
        {
            if (tokenStack.Peek().Type == TokenType.SEMICOLON)
            {
                Reduce(3, 0, TokenType.Obyavlenie);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State20()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.IDENTIFIER:
                    Shift();
                    break;
                case TokenType.EQUAL:
                    GoToState(26);
                    break;
                default: 
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State21()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.FOR:
                    Shift();
                    break;
                case TokenType.LPAR:
                    GoToState(33);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State23()
        {
            if(tokenStack.Peek().Type == TokenType.END)
            {
                Reduce(7, 0, TokenType.Programma);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State26()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.EQUAL:
                    Shift();
                    break;
                case TokenType.IDENTIFIER://вместо EXPR
                    GoToState(27);
                    break;
                case TokenType.LITERAL://вместо EXPR
                    GoToState(27);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State27()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.IDENTIFIER:
                    count = 0;
                    while (tokenStack.Peek().Type != TokenType.SEMICOLON)
                    {
                        count++;
                        Shift();
                    }
                    break;
                case TokenType.LITERAL:
                    count = 0;
                    while (tokenStack.Peek().Type != TokenType.SEMICOLON)
                    {
                        count++;
                        Shift();
                    }
                    break;
                case TokenType.SEMICOLON:
                    GoToState(28);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State28()
        {
            if(tokenStack.Peek().Type == TokenType.SEMICOLON)
            {
                Reduce(4, count - 1, TokenType.Prisvaivanie);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State29()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.IDENTIFIER:
                    if (tokens[nextLex].Type == TokenType.COMMA)
                    {
                        Shift();
                    }
                    else
                    {
                        Reduce(1, 0, TokenType.SpisokPeremennih);
                    }
                    break;
                case TokenType.COMMA:
                    GoToState(30);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State30()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.COMMA:
                    Shift();
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(29);
                    break;
                case TokenType.SpisokPeremennih:
                    GoToState(31);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State31()
        {
            if(tokenStack.Peek().Type == TokenType.SpisokPeremennih)
            {
                Reduce(3, 0, TokenType.SpisokPeremennih);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State32()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.SpisokPeremennih:
                    Shift();
                    break;
                case TokenType.SEMICOLON:
                    GoToState(19);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State33()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.LPAR:
                    Shift();
                    break;
                case TokenType.Prisvaivanie1:
                    GoToState(34);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(35);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State34()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.Prisvaivanie1:
                    Shift();
                    break;
                case TokenType.SEMICOLON:
                    GoToState(41);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State35()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.IDENTIFIER:
                    Shift();
                    break;
                case TokenType.EQUAL:
                    GoToState(36);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State36()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.EQUAL:
                    Shift();
                    break;
                case TokenType.Operand:
                    GoToState(40);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(37);
                    break;
                case TokenType.LITERAL:
                    GoToState(38);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State37()
        {
            if(tokenStack.Peek().Type == TokenType.IDENTIFIER)
            {
                Reduce(1, 0, TokenType.Operand);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State38()
        {
            if (tokenStack.Peek().Type == TokenType.LITERAL)
            {
                Reduce(1, 0, TokenType.Operand);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State40()
        {
            if (tokenStack.Peek().Type == TokenType.Operand)
            {
                Reduce(3, 0, TokenType.Prisvaivanie1);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State41()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.SEMICOLON:
                    Shift();
                    break;
                case TokenType.Uslovie:
                    GoToState(42);
                    break;
                case TokenType.Operand:
                    GoToState(43);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(37);
                    break;
                case TokenType.LITERAL:
                    GoToState(38);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State42()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.Uslovie:
                    Shift();
                    break;
                case TokenType.SEMICOLON:
                    GoToState(51);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State43()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.Operand:
                    Shift();
                    break;
                case TokenType.Znak2:
                    GoToState(44);
                    break;
                case TokenType.MORE:
                    GoToState(45);
                    break;
                case TokenType.LESS:
                    GoToState(46);
                    break;
                case TokenType.EQUAL:
                    GoToState(47);
                    break;
                case TokenType.EXCLAM:
                    GoToState(48);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State44()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.Znak2:
                    Shift();
                    break;
                case TokenType.Operand:
                    GoToState(50);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(37);
                    break;
                case TokenType.LITERAL:
                    GoToState(38);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State45()
        {
            if(tokenStack.Peek().Type == TokenType.MORE)
            {
                Reduce(1, 0, TokenType.Znak2);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State46()
        {
            if (tokenStack.Peek().Type == TokenType.LESS)
            {
                Reduce(1, 0, TokenType.Znak2);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State47()
        {
            if (tokenStack.Peek().Type == TokenType.EQUAL)
            {
                if (tokens[nextLex].Type == TokenType.EQUAL)
                {
                    Shift();
                    GoToState(47);
                }
                else
                {
                    Reduce(2, 0, TokenType.Znak2);
                }
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State48()
        {
            if (tokenStack.Peek().Type == TokenType.EXCLAM)
            {
                if (tokens[nextLex].Type == TokenType.EQUAL)
                {
                    Shift();
                    GoToState(48);
                }
                else
                {
                    Reduce(2, 0, TokenType.Znak2);
                }
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State50()
        {
            if (tokenStack.Peek().Type == TokenType.Operand)
            {
                Reduce(3, 0, TokenType.Uslovie);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State51()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.SEMICOLON:
                    Shift();
                    break;
                case TokenType.Increment:
                    GoToState(52);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(53);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State52()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.Increment:
                    Shift();
                    break;
                case TokenType.RPAR:
                    GoToState(58);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State53()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.IDENTIFIER:
                    Shift();
                    break;
                case TokenType.PLUS:
                    GoToState(55);
                    break;
                case TokenType.MINUS:
                    GoToState(56);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State55()
        {
            if (tokenStack.Peek().Type == TokenType.PLUS)
            {
                if (tokens[nextLex].Type == TokenType.PLUS)
                {
                    Shift();
                    GoToState(55);
                }
                else
                {
                    Reduce(3, 0, TokenType.Increment);
                }
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State56()
        {
            if (tokenStack.Peek().Type == TokenType.MINUS)
            {
                if (tokens[nextLex].Type == TokenType.MINUS)
                {
                    Shift();
                    GoToState(56);
                }
                else
                {
                    Reduce(3, 0, TokenType.Increment);
                }
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State58()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.RPAR:
                    Shift();
                    break;
                case TokenType.BEGIN:
                    GoToState(59);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State59()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.BEGIN:
                    Shift();
                    break;
                case TokenType.SpisokOperatorov:
                    GoToState(60);
                    break;
                case TokenType.OdinochniyOperator:
                    GoToState(7);
                    break;
                case TokenType.Obyavlenie:
                    GoToState(8);
                    break;
                case TokenType.Prisvaivanie:
                    GoToState(9);
                    break;
                case TokenType.OperatorCikla:
                    GoToState(10);
                    break;
                case TokenType.Expression:
                    GoToState(13);
                    break;
                case TokenType.Tip:
                    GoToState(14);
                    break;
                case TokenType.INT:
                    GoToState(15);
                    break;
                case TokenType.FLOAT:
                    GoToState(16);
                    break;
                case TokenType.DOUBLE:
                    GoToState(17);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(20);
                    break;
                case TokenType.FOR:
                    GoToState(21);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State60()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.SpisokOperatorov:
                    Shift();
                    break;
                case TokenType.OdinochniyOperator:
                    GoToState(67);
                    break;
                case TokenType.END:
                    GoToState(62);
                    break;
                case TokenType.Obyavlenie:
                    GoToState(8);
                    break;
                case TokenType.Prisvaivanie:
                    GoToState(9);
                    break;
                case TokenType.OperatorCikla:
                    GoToState(10);
                    break;
                case TokenType.Expression:
                    GoToState(13);
                    break;
                case TokenType.Tip:
                    GoToState(14);
                    break;
                case TokenType.INT:
                    GoToState(15);
                    break;
                case TokenType.FLOAT:
                    GoToState(16);
                    break;
                case TokenType.DOUBLE:
                    GoToState(17);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(20);
                    break;
                case TokenType.FOR:
                    GoToState(21);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State62()
        {
            if(tokenStack.Peek().Type == TokenType.END)
            {
                Reduce(11, 0, TokenType.OperatorCikla);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State63()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.IDENTIFIER:
                    if (tokens[nextLex].Type == TokenType.EQUAL || tokens[nextLex].Type == TokenType.COMMA)
                    {
                        Shift();
                    }
                    else
                    {
                        Reduce(1, 0, TokenType.SpisokPeremennih);
                    }
                    break;
                case TokenType.EQUAL:
                    GoToState(64);
                    break;
                case TokenType.COMMA:
                    GoToState(30);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State64()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.EQUAL:
                    Shift();
                    break;
                case TokenType.LITERAL:
                    GoToState(65);
                    break;
                case TokenType.IDENTIFIER:
                    GoToState(65);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State65()
        {
            switch (tokenStack.Peek().Type)
            {
                case TokenType.LITERAL:
                    count = 0;
                    while (tokenStack.Peek().Type != TokenType.SEMICOLON)
                    {
                        count++;
                        Shift();
                    }
                    break;
                case TokenType.IDENTIFIER:
                    count = 0;
                    while (tokenStack.Peek().Type != TokenType.SEMICOLON)
                    {
                        count++;
                        Shift();
                    }
                    break;
                case TokenType.SEMICOLON:
                    GoToState(66);
                    break;
                default:
                    throw new Exception("Был встречен неверный токен");
            }
        }
        void State66()
        {
            if(tokenStack.Peek().Type == TokenType.SEMICOLON)
            {
                Reduce(5, count - 1, TokenType.Expression);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
        void State67()
        {
            if (tokenStack.Peek().Type == TokenType.OdinochniyOperator)
            {
                Reduce(2, 0, TokenType.SpisokOperatorov);
            }
            else
            {
                throw new Exception("Был встречен неверный токен");
            }
        }
    }
}
