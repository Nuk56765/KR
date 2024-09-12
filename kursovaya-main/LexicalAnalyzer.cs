using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp6
{
    public class LexicalAnalyzer
    {
        
        List<Token> tokens = new List<Token>();

        public enum TYPE
        {
            NUMBER,
            SPECIAL,
            IDENTIFIER,
            START,
            ERROR
        }
       

        public List<Token> Analyze(string input_text)//анализ входного текста
        {
            input_text = input_text.Replace("\n", " ").Trim();
            string buffer = "";
            TYPE state = TYPE.START;

            for (int i = 0; i < input_text.Length; i++)
            {
                if (input_text[i] != ' ')
                {
                    TYPE new_state = Check(input_text[i].ToString(), state);
                    string current_value = input_text[i].ToString();//сохранение значения текущего символа в переменную

                    if (new_state == TYPE.SPECIAL)// Если символ является специальным символом, то создается отдельный токен и состояние меняется
                    {
                        if (buffer.Length > 0) { FillItem(state, buffer); }
                        buffer = current_value;
                        state = new_state;
                    }
                    else if (state == TYPE.START || state == new_state)//Если текущий символ совпадает с состоянием, то символ добавляется в буфер.
                    {
                        buffer += current_value;
                        state = new_state;
                    }
                    else //Если текущий символ не соответствует состоянию, то предыдущий токен создается и символ добавляется в буфер.
                    {
                        FillItem(state, buffer);
                        buffer = current_value;
                        state = new_state;
                    }
                }
                else if(input_text[i] == ' ')//Если символ пробел, то создается токен из буфера
                {
                    if (buffer.Length > 0) { FillItem(state, buffer); }
                    state = TYPE.START;
                    buffer = "";
                }
                else
                {
                    Console.WriteLine("-"+input_text[i]);
                }
            }
            if (buffer.Length > 0) { FillItem(state, buffer); }

            return tokens;//возвращает список токенов
        }

        
        public void FillItem(TYPE type, string value)//заполнение списка токенов(на основе типа и значения)
        {
            if (type == TYPE.NUMBER)//Создается токен с типом `TokenType.LITERAL` и значением `value`.
            {
                tokens.Add(new Token(TokenType.LITERAL, value));
            }
            if (type == TYPE.SPECIAL)
            {
                tokens.Add(new Token(SpecialSymbols.Symbols[value[0]], null));
            }
            if (type == TYPE.IDENTIFIER)
            {

                if (SpecialWords.Words.ContainsKey(value))
                {
                    tokens.Add(new Token(SpecialWords.Words[value], null));
                }
                else
                {
                    if (value.Length <= 8)
                    {
                        tokens.Add(new Token(TokenType.IDENTIFIER, value));
                    }
                    else
                    {
                        throw new Exception($"Идентификатор больше 8 символов: {value}");
                    }
                }
            }
            if (type == TYPE.ERROR)
            {
                throw new Exception($"Неизвестный символ: {value}");
            }
        }

        public TYPE Check(string value, TYPE currentType)// проверка типа символа
        {
            if (Regex.IsMatch(value, @"[0-9]"))// является ли символ цифрой
            {
                if (currentType == TYPE.START)
                {
                    return TYPE.NUMBER;//символ - начало числа
                }
                if (currentType == TYPE.IDENTIFIER)//добавление к имени идентификатора
                {
                    return TYPE.IDENTIFIER;
                }
                return TYPE.NUMBER;
            }

            if (SpecialSymbols.Symbols.ContainsKey(value[0]))//является ли спец символом
            {
                return TYPE.SPECIAL;
            }

            if (Regex.IsMatch(value, @"[a-zA-Z]"))// проверка символа на букву
            {
                if (currentType == TYPE.NUMBER)
                {
                    throw new Exception("Переменная не может начинтся с числа.");
                }
                return TYPE.IDENTIFIER;//символ является началом идентификатора
            }
            return TYPE.ERROR;//символ не соответствует ни одному из условий
        }
    }
}
