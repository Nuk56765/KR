using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WindowsFormsApp6;
using System.Windows.Forms;

public class Expression
{
    private List<Token> tokens;
    private Stack<Token> operators = new Stack<Token>();
    private Stack<Token> output = new Stack<Token>();
    private List<string> rpn = new List<string>();
    private List<string> matrix = new List<string>();

    public Expression(List<Token> tokens)
    {
        this.tokens = tokens;
    }

    public void ParseExpression(ref Token currentToken, ref int counter)
    {
        rpn.Clear();
        operators.Clear();
        output.Clear();

        bool expectOperand = true;
        while (currentToken.Type != TokenType.SEMICOLON)
        {
            if (currentToken.Type == TokenType.IDENTIFIER || currentToken.Type == TokenType.LITERAL)
            {
                if (!expectOperand)
                {
                    throw new Exception("Неожиданный операнд. Ошибка в разборе сложного выражения.");
                }
                output.Push(currentToken);
                rpn.Add(currentToken.Value);
                expectOperand = false;
            }
            else if (currentToken.Type == TokenType.PLUS || currentToken.Type == TokenType.MINUS ||
                     currentToken.Type == TokenType.MULTIPLY || currentToken.Type == TokenType.DIVISION ||
                     currentToken.Type == TokenType.MORE || currentToken.Type == TokenType.LESS ||
                     currentToken.Type == TokenType.EQUAL || currentToken.Type == TokenType.EXCLAM)
            {
                if (expectOperand)
                {
                    throw new Exception("Неожиданный оператор. Ошибка в разборе сложного выражения.");
                }
                PopOperators(currentToken);
                operators.Push(currentToken);
                expectOperand = true;
            }
            else if (currentToken.Type == TokenType.LPAR)
            {
                operators.Push(currentToken);
                expectOperand = true;
            }
            else if (currentToken.Type == TokenType.RPAR)
            {
                if (expectOperand)
                {
                    throw new Exception("Неожиданная закрывающая скобка. Ошибка в разборе сложного выражения.");
                }
                while (operators.Count > 0 && operators.Peek().Type != TokenType.LPAR)
                {
                    Token op = operators.Pop();
                    output.Push(op);
                    rpn.Add(op.Value);
                }
                if (operators.Count == 0 || operators.Peek().Type != TokenType.LPAR)
                {
                    throw new Exception("Несоответствие скобок. Ошибка в разборе сложного выражения.");
                }
                operators.Pop();
                expectOperand = false;
            }
            else
            {
                throw new Exception($"Неожиданный токен '{currentToken.Type}' в выражении.  Ошибка в разборе сложного выражения.");
            }
            counter++;
            if (counter < tokens.Count)
            {
                currentToken = tokens[counter];
            }
            else
            {
                throw new Exception("Неожиданный конец ввода. Ошибка в разборе сложного выражения.");
            }
        }
        while (operators.Count > 0)
        {
            if (operators.Peek().Type == TokenType.LPAR)
            {
                throw new Exception("Несоответствие скобок.  Ошибка в разборе сложного выражения.");
            }
            Token op = operators.Pop();
            output.Push(op);
            rpn.Add(op.Value);
        }
        counter++;
        if (counter < tokens.Count)
        {
            currentToken = tokens[counter];
        }

        GenerateMatrix();
    }

    private void PopOperators(Token token)
    {
        while (operators.Count > 0)
        {
            Token top = operators.Peek();
            if ((IsLeftAssociative(token) && GetPrecedence(token) <= GetPrecedence(top)) ||
                (!IsLeftAssociative(token) && GetPrecedence(token) < GetPrecedence(top)))
            {
                Token op = operators.Pop();
                output.Push(op);
                rpn.Add(op.Value);
            }
            else
            {
                break;
            }
        }
    }

    private int GetPrecedence(Token token)
    {
        switch (token.Type)
        {
            case TokenType.PLUS:
            case TokenType.MINUS:
                return 1;
            case TokenType.MULTIPLY:
            case TokenType.DIVISION:
                return 2;
            case TokenType.MORE:
            case TokenType.LESS:
            case TokenType.EQUAL:
            case TokenType.EXCLAM:
                return 0;
            default:
                return -1;
        }
    }

    private bool IsLeftAssociative(Token token)
    {
        switch (token.Type)
        {
            case TokenType.PLUS:
            case TokenType.MINUS:
            case TokenType.MULTIPLY:
            case TokenType.DIVISION:
                return true;
            default:
                return false;
        }
    }

    public string GetRPN()
    {
        string out_str = "";
 
        if(output.Count > 1)
        {
            foreach (Token value in output.Reverse())
            {

                if (value.Type == TokenType.IDENTIFIER || value.Type == TokenType.LITERAL)
                {
                    out_str += value.Value;
                }
                else
                {
                    out_str += SpecialSymbols.Symbols.FirstOrDefault(x => x.Value == value.Type).Key;
                }
                out_str += " ";
            }
            
        }

        return out_str;
    }

    public string GetMatrix()
    {
        return string.Join("\n", matrix);
    }

    private void GenerateMatrix()
    {
        int tempCounter = 1;
        Stack<string> matrixStack = new Stack<string>();

        foreach (Token token in output.Reverse())
        {
            if (token.Type == TokenType.PLUS || token.Type == TokenType.MINUS || token.Type == TokenType.DIVISION || token.Type == TokenType.MULTIPLY)
            {
                string operand2 = matrixStack.Pop();
                string operand1 = matrixStack.Pop();
                string tempVar = $"M{tempCounter++}";
                matrixStack.Push(tempVar);
                matrix.Add($"{tempVar}: {SpecialSymbols.Symbols.FirstOrDefault(x => x.Value == token.Type).Key} {operand1} {operand2}");
            }
            else
            {
                matrixStack.Push(token.Value);
            }
        }
    }
}

