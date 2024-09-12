//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;


//namespace WindowsFormsApp6
//{
//    /// <summary>
//    /// Класс для синтаксического анализа входной программы.
//    /// </summary>
//    internal class SyntaxAnalyzer
//    {
//        public List<Token> tokens;
//        public Token currentToken;
//        private Expression expressionParser;
//        public int counter = 0;
//        private RichTextBox outputTextBox;


//        /// <summary>
//        /// Конструктор класса SyntaxAnalyzer.
//        /// </summary>
//        /// <param name="tokens">Список токенов для анализа.</param>
//        /// <param name="outputTextBox">Элемент управления для вывода результата.</param>
//        public SyntaxAnalyzer(List<Token> tokens, RichTextBox outputTextBox)
//        {
//            this.tokens = tokens;
//            currentToken = tokens[0];
//            this.outputTextBox = outputTextBox;

//            this.expressionParser = new Expression(tokens);
//        }

//        /// <summary>
//        /// Переход к следующему токену в списке.
//        /// </summary>
//        private void Next()
//        {
//            counter++;
//            if (counter < tokens.Count)
//            {
//                currentToken = tokens[counter];
//            }
//            else
//            {
//                throw new Exception($"Неожиданный конец входной цепочки. Текущий токен: {currentToken}. Метод: Next.");
//            }
//        }

//        /// <summary>
//        /// Анализирует основную структуру программы.
//        /// </summary>
//        public void Program()
//        {
//            if (currentToken.Type != TokenType.MAIN)
//            {
//                throw new Exception($"Ожидался токен 'main' в начале программы. Текущий токен: {currentToken}. Метод: Program.");
//            }
//            Next();
//            if (currentToken.Type != TokenType.LPAR)
//            {
//                throw new Exception($"Ожидался токен '(' после 'main'. Текущий токен: {currentToken}. Метод: Program.");
//            }
//            Next();
//            if (currentToken.Type != TokenType.RPAR)
//            {
//                throw new Exception($"Ожидался токен ')' после '('. Текущий токен: {currentToken}. Метод: Program.");
//            }
//            Next();
//            if (currentToken.Type != TokenType.BEGIN)
//            {
//                throw new Exception($"Ожидался токен '{{' после ')'. Текущий токен: {currentToken}. Метод: Program.");
//            }
//            Next();
//            StatementList();
//            if (currentToken.Type != TokenType.END)
//            {
//                throw new Exception($"Ожидался токен '}}' в конце программы. Текущий токен: {currentToken}. Метод: Program.");
//            }
//        }

//        /// <summary>
//        /// Анализирует список операторов.
//        /// </summary>
//        private void StatementList()
//        {
//            Statement();
//            U();
//        }

//        /// <summary>
//        /// Рекурсивный метод для анализа списка операторов.
//        /// </summary>
//        private void U()
//        {
//            if (currentToken.Type == TokenType.END)
//            {
//                // Epsilon-переход
//                return;
//            }
//            else
//            {
//                StatementList();
//            }
//        }

//        /// <summary>
//        /// Анализирует отдельный оператор.
//        /// </summary>
//        private void Statement()
//        {
//            if (IsDeclaration())
//            {
//               if(LookAhead(2).Type  == TokenType.EQUAL)
//                {
//                    Expr();
//                }
//                else
//                {
//                    Declaration();
//                }
                
//            }
//            else if (IsAssignment())
//            {
//                Assignment();
//            }
//            else if (currentToken.Type == TokenType.FOR)
//            {
//                ForLoop();
//            }
            
//            else
//            {
//                throw new Exception($"Ожидалось объявление, присваивание или цикл 'for'. Текущий токен: {currentToken}. Метод: Statement.");
//            }
//        }

//        /// <summary>
//        /// Проверяет, является ли текущий токен объявлением переменной.
//        /// </summary>
//        /// <returns>Возвращает true, если текущий токен - объявление переменной.</returns>
//        private bool IsDeclaration()
//        {
//            return currentToken.Type == TokenType.INT || currentToken.Type == TokenType.FLOAT || currentToken.Type == TokenType.DOUBLE;
//        }

//        /// <summary>
//        /// Анализирует объявление переменной.
//        /// </summary>
//        private void Declaration()
//        {
//            VariableType();
//            IdentifierList();
//            if (currentToken.Type != TokenType.SEMICOLON)
//            {
//                throw new Exception($"Ожидался токен ';' после объявления переменной. Текущий токен: {currentToken}. Метод: Declaration.");
//            }
//            Next();
//        }

//        /// <summary>
//        /// Анализирует тип переменной.
//        /// </summary>
//        private void VariableType()
//        {
//            if (currentToken.Type == TokenType.INT || currentToken.Type == TokenType.FLOAT || currentToken.Type == TokenType.DOUBLE)
//            {
//                Next();
//            }
//            else
//            {
//                throw new Exception($"Ожидался тип переменной (int, float, double). Текущий токен: {currentToken}. Метод: VariableType.");
//            }
//        }

//        /// <summary>
//        /// Анализирует список идентификаторов.
//        /// </summary>
//        private void IdentifierList()
//        {
//            if (currentToken.Type != TokenType.IDENTIFIER)
//            {
//                throw new Exception($"Ожидался идентификатор. Текущий токен: {currentToken}. Метод: IdentifierList.");
//            }
//            Next();
//            R();
//        }

//        /// <summary>
//        /// Рекурсивный метод для анализа списка идентификаторов.
//        /// </summary>
//        private void R()
//        {
//            if (currentToken.Type == TokenType.COMMA)
//            {
//                Next();
//                IdentifierList();
//            }
//            // Epsilon-переход
//        }

//        /// <summary>
//        /// Проверяет, является ли текущий токен присваиванием.
//        /// </summary>
//        /// <returns>Возвращает true, если текущий токен - присваивание.</returns>
//        private bool IsAssignment()
//        {
//            return currentToken.Type == TokenType.IDENTIFIER && LookAhead(1).Type == TokenType.EQUAL;
//        }

//        /// <summary>
//        /// Анализирует оператор присваивания.
//        /// </summary>
//        private void Assignment()
//        {
//            if (currentToken.Type == TokenType.IDENTIFIER)
//            {
//                Next();
//                if (currentToken.Type == TokenType.EQUAL)
//                {
//                    Next();
//                    Expression();
//                }
//                else
//                {
//                    throw new Exception($"Ожидался токен '=' в присваивании. Текущий токен: {currentToken}. Метод: Assignment.");
//                }
//            }
//            else
//            {
//                throw new Exception($"Ожидался идентификатор в присваивании. Текущий токен: {currentToken}. Метод: Assignment.");
//            }
//        }
//        private void Expr()
//        {
//            if (IsDeclaration())
//            {
//                Next();
//                if (currentToken.Type == TokenType.IDENTIFIER)
//                {
//                    Next();
//                    if (currentToken.Type == TokenType.EQUAL)
//                    {
//                        Next();
//                        Expression();
//                    }
//                    else
//                    {
//                        throw new Exception($"Ожидался токен '=' в присваивании. Текущий токен: {currentToken}. Метод: Expr.");
//                    }
//                }
//                else
//                {
//                    throw new Exception($"Ожидался идентификатор в присваивании. Текущий токен: {currentToken}. Метод: Expr.");
//                }
//            }
            
//        }
//        private void Expression()
//        {
//            expressionParser.ParseExpression(ref currentToken, ref counter);
//            string rpnOutput = expressionParser.GetRPN();
//            string matrixOutput = expressionParser.GetMatrix();
//            if(rpnOutput != "")
//            {
//                outputTextBox.AppendText($"ОПН: {rpnOutput}\nМАТРИЦА: \n{matrixOutput}\n\n");
//            }
            
           
//        }
        


//        /// <summary>
//        /// Анализирует операнд в выражении.
//        /// </summary>
//        private void Operand()
//        {
//            if (currentToken.Type == TokenType.IDENTIFIER || currentToken.Type == TokenType.LITERAL)
//            {
//                Next();
//            }
//            else
//            {
//                throw new Exception($"Ожидался операнд (идентификатор или литерал). Текущий токен: {currentToken}. Метод: Operand.");
//            }
//        }

//        /// <summary>
//        /// Анализирует цикл 'for'.
//        /// </summary>
//        private void ForLoop()
//        {
//            if (currentToken.Type == TokenType.FOR)
//            {
//                Next();
//                if (currentToken.Type != TokenType.LPAR)
//                {
//                    throw new Exception($"Ожидался токен '(' после 'for'. Текущий токен: {currentToken}. Метод: ForLoop.");
//                }
//                Next();
//                Prisvaevanie();
//                if (currentToken.Type != TokenType.SEMICOLON)
//                {
//                    throw new Exception($"Ожидался токен ';' после присваивания в 'for'. Текущий токен: {currentToken}. Метод: ForLoop.");
//                }
//                Next();
//                Condition();
//                if (currentToken.Type != TokenType.SEMICOLON)
//                {
//                    throw new Exception($"Ожидался токен ';' после условия в 'for'. Текущий токен: {currentToken}. Метод: ForLoop.");
//                }
//                Next();
//                Increment();
//                if (currentToken.Type != TokenType.RPAR)
//                {
//                    throw new Exception($"Ожидался токен ')' после инкремента/дикремента в 'for'. Текущий токен: {currentToken}. Метод: ForLoop.");
//                }
//                Next();
//                ForBody();
//            }
//            else
//            {
//                throw new Exception("Ожидался токен 'for'.");
//            }
//        }

//        private void Prisvaevanie()
//        {
//            if (currentToken.Type == TokenType.IDENTIFIER)
//            {
//                Next();
//                if (currentToken.Type != TokenType.EQUAL)
//                {
//                    throw new Exception("Ожидался токен '=' в присваивании.");
//                }
//                Next();
//                Operand();
//            }
//            else
//            {
//                throw new Exception("Ожидался идентификатор в присваивании.");
//            }
//        }
//        /// <summary>
//        /// Анализирует условие.
//        /// </summary>
//        private void Condition()
//        {
//            Operand();
//            Znak2();
//            Operand();
//        }

//        /// <summary>
//        /// Анализирует знак условия.
//        /// </summary>
//        private void Znak2()
//        {
//            if (currentToken.Type == TokenType.MORE || currentToken.Type == TokenType.LESS || currentToken.Type == TokenType.EQUAL || currentToken.Type == TokenType.EXCLAM)
//            {
//                Next();
//            }
//            else
//            {
//                throw new Exception($"Ожидался знак сравнения ('>', '<', '=', '!='). Текущий токен: {currentToken}. Метод: Znak2.");
//            }
//        }
//        /// <summary>
//        /// Анализирует тело цикла 'for'.
//        /// </summary>
//        private void ForBody()
//        {
//            if (currentToken.Type == TokenType.BEGIN)
//            {
//                Next();
//                StatementList();
//                if (currentToken.Type != TokenType.END)
//                {
//                    throw new Exception($"Ожидался токен '}}' в конце тела 'for'. Текущий токен: {currentToken}. Метод: ForBody.");
//                }
//                Next();
//            }
//            else
//            {
//                Statement();
//            }
//        }
//        /// <summary>
//        /// Анализирует инкремент или декремент в цикле 'for'.
//        /// </summary>
//        private void Increment()
//        {
//            if (currentToken.Type == TokenType.IDENTIFIER)
//            {
//                Next();
//                if (currentToken.Type == TokenType.PLUS)
//                {
//                    Next();
//                    if (currentToken.Type == TokenType.PLUS)
//                    {
//                        Next();
//                    }
//                    else
//                    {
//                        throw new Exception($"Ожидался оператор инкремента ('++'). Текущий токен: {currentToken}. Метод: Increment.");
//                    }
//                }
//                else if (currentToken.Type == TokenType.MINUS)
//                {
//                    Next();
//                    if (currentToken.Type == TokenType.MINUS)
//                    {
//                        Next();
//                    }
//                    else
//                    {
//                        throw new Exception($"Ожидался оператор декремента ('--'). Текущий токен: {currentToken}. Метод: Increment.");
//                    }
//                }
//                else
//                {
//                    throw new Exception($"Ожидался оператор инкремента или декремента ('++' или '--'). Текущий токен: {currentToken}. Метод: Increment.");
//                }
//            }
//            else
//            {
//                throw new Exception($"Ожидался идентификатор в инкременте. Текущий токен: {currentToken}. Метод: Increment.");
//            }
//        }

//        /// <summary>
//        /// Выполняет предварительный просмотр токенов.
//        /// </summary>
//        /// <param name="k">Количество токенов для предварительного просмотра.</param>
//        /// <returns>Предпросмотренный токен.</returns>
//        private Token LookAhead(int k)
//        {
//            if (counter + k < tokens.Count)
//            {
//                return tokens[counter + k];
//            }
//            else
//            {
//                return new Token(TokenType.EOF, ""); // EOF - конец файла
//            }
//        }
//    }
//}
