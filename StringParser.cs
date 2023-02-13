using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    class StringParser
    {
        public static int pos = 0;
        private String source;
        private int choice_type = 0;
        // 0 - undefined
        // 1 - char
        // 2 - int
        // 3 - double

        // variable, its description
        public SortedDictionary<String, String> variables;
        public SortedDictionary<String, String> constants;

        public static bool IsDigit(char c)
        {
            return ('0' <= c && c <= '9');
        }

        public static bool IsLetter(char c)
        {
            return ('a' <= c && c <= 'z');
        }

        public StringParser(String source)
        {
            this.source = source.ToLower();
            if (string.IsNullOrEmpty(source))
            {
                throw new KeyNotFoundException("Строка не может быть пустой");
            }

            variables = new SortedDictionary<string, string>();
            constants = new SortedDictionary<string, string>();
            pos = 0;
        }
        public void ParseString()
        {
            SkipWS();
            if (source.Substring(pos).StartsWith("case "))
            {
                pos += 5;
            }
            else
            {
                throw new FormatException("Синтаксическая ошибка: не обнаружено ключевое слово case");
            }
            SkipWS();
            nextIdentifier("идентификатор выбора");
            if (pos < source.Length && source[pos] == ' ')
            {
                ++pos;
            }
            else
            {
                throw new FormatException("Синтаксическая ошибка: ожидался пробел");
            }
            SkipWS();
            if (source.Substring(pos).StartsWith("of "))
            {
                pos += 3;
            }
            else
            {
                throw new FormatException("Синтаксическая ошибка: не обнаружено ключевое слово of");
            }
            var state = State.A1;
            while (pos < source.Length)
            {
                switch (state)
                {
                    case State.A1:
                        SkipWS();
                        if (pos >= source.Length)
                        {
                            throw new FormatException("Синтаксическая ошибка: ожидалась константа выбора");
                        }
                        if (source[pos] == '\'')
                        {
                            if (choice_type > 1)
                            {
                                throw new FormatException("Семантическая ошибка: несоответствие типов констант выбора");
                            }
                            choice_type = 1;
                            ++pos;
                            if (pos < source.Length && (IsDigit(source[pos]) || IsLetter(source[pos])))
                            {
                                ++pos;
                            }
                            else
                            {
                                throw new FormatException("Синтаксическая ошибка: ожидался символ");
                            }
                            if (pos < source.Length && source[pos] == '\'')
                            {
                                ++pos;
                            }
                            else
                            {
                                throw new FormatException("Синтаксическая ошибка: ожидалась кавычка");
                            }
                            constants.Add("\'" + source[pos - 2] + "\'", "константа выбора");
                        }
                        else
                        {
                            bool its_type = nextConstant("константа выбора");
                            if (!its_type && choice_type == 1)
                            {
                                throw new FormatException("Семантическая ошибка: несоответствие типов констант выбора");
                            }
                            choice_type = Math.Max(choice_type, (its_type ? 2 : 3));
                        }
                        state = State.A2;
                        break;
                    case State.A2:
                        SkipWS();
                        if (pos < source.Length)
                        {
                            if (source[pos] == ',')
                            {
                                state = State.A1;
                            }
                            else
                            {
                                if (source[pos] == ':')
                                {
                                    state = State.B1;
                                }
                                else
                                {
                                    throw new FormatException("Синтаксическая ошибка: ожидалась запятая или двоеточие");
                                }
                            }
                            ++pos;
                        }
                        else
                        {
                            throw new FormatException("Синтаксическая ошибка: ожидалась запятая или двоеточие");
                        }
                        break;
                    case State.B1:
                        SkipWS();
                        if (pos < source.Length)
                        {
                            nextAssignmentOperator();
                            SkipWS();
                            if (pos < source.Length && source[pos] == ';')
                            {
                                ++pos;
                            }
                            else
                            {
                                throw new FormatException("Синтаксическая ошибка: ожидалась точка с запятой");
                            }
                        }
                        else
                        {
                            throw new FormatException("Синтаксическая ошибка: ожидался оператор присваивания");
                        }
                        state = State.B2;
                        break;
                    case State.B2:
                        SkipWS();
                        if (source.Substring(pos).StartsWith("end;"))
                        {
                            pos += 4;
                            if (pos != source.Length)
                            {
                                throw new FormatException("Синтаксическая ошибка: встречен код после END;");
                            }
                            state = State.F;
                            break;
                        }
                        if (pos >= source.Length)
                        {
                            throw new FormatException("Синтаксическая ошибка: ожидалась точка с запятой, список констант или ELSE");
                        }
                        if (source.Substring(pos).StartsWith("else "))
                        {
                            pos += 5;
                            SkipWS();
                            nextAssignmentOperator();
                            SkipWS();
                            if (pos < source.Length && source[pos] == ';')
                            {
                                ++pos;
                            }
                            else
                            {
                                throw new FormatException("Синтаксическая ошибка: ожидалась точка с запятой");
                            }
                            SkipWS();
                            if (source.Substring(pos).StartsWith("end;"))
                            {
                                pos += 4;
                                state = State.F;
                            }
                            else
                            {
                                throw new FormatException("Синтаксическая ошибка: ожидался end;");
                            }
                            if (pos != source.Length)
                            {
                                throw new FormatException("Синтаксическая ошибка: встречен код после END;");
                            }
                        }
                        else
                        {
                            if (source[pos] == '\'')
                            {
                                if (choice_type > 1)
                                {
                                    throw new FormatException("Семантическая ошибка: несоответствие типов констант выбора");
                                }
                                choice_type = 1;
                                ++pos;
                                if (pos < source.Length && (IsDigit(source[pos]) || IsLetter(source[pos])))
                                {
                                    ++pos;
                                }
                                else
                                {
                                    throw new FormatException("Синтаксическая ошибка: ожидался символ");
                                }
                                if (pos < source.Length && source[pos] == '\'')
                                {
                                    ++pos;
                                }
                                else
                                {
                                    throw new FormatException("Синтаксическая ошибка: ожидалась кавычка");
                                }
                            }
                            else
                            {
                                bool its_type = nextConstant("константа выбора");
                                if (!its_type && choice_type == 1)
                                {
                                    throw new FormatException("Семантическая ошибка: несоответствие типов констант выбора");
                                }
                                choice_type = Math.Max(choice_type, (its_type ? 2 : 3));
                            }
                            state = State.B3;
                        }
                        break;
                    case State.B3:
                        SkipWS();
                        if (pos >= source.Length)
                        {
                            throw new FormatException("Синтаксическая ошибка: ожидась точка с запятой, двоеточие или список констант");
                        }
                        if (source[pos] == '\'')
                        {
                            ++pos;
                            if (pos < source.Length && (IsDigit(source[pos]) || IsLetter(source[pos])))
                            {
                                ++pos;
                            }
                            else
                            {
                                throw new FormatException("Синтаксическая ошибка: ожидался символ");
                            }
                            if (pos < source.Length && source[pos] == '\'')
                            {
                                ++pos;
                            }
                            else
                            {
                                throw new FormatException("Синтаксическая ошибка: ожидалась кавычка");
                            }
                            state = State.B3;
                        }
                        else
                        {
                            if (source[pos] == ':')
                            {
                                ++pos;
                                state = State.B1;
                            }
                            else
                            {
                                bool its_type = nextConstant("константа выбора");
                                if (!its_type && choice_type == 1)
                                {
                                    throw new FormatException("Семантическая ошибка: несоответствие типов констант выбора");
                                }
                                choice_type = Math.Max(choice_type, (its_type ? 2 : 3));
                                state = State.B3;
                            }
                        }
                        break;
                    default:
                        throw new Exception("Something went wrong...");
                }
            }
        }
        public String nextIdentifier(String base_type)
        {
            String id_name = "";
            if (pos < source.Length && (IsLetter(source[pos]) || source[pos] == '_'))
            {
                id_name += source[pos++];
            }
            else
            {
                throw new FormatException("Синтаксическая ошибка: ожидался идентификатор");
            }
            while (pos < source.Length && (IsLetter(source[pos]) || IsDigit(source[pos]) || source[pos] == '_'))
            {
                id_name += source[pos++];
            }

            if (id_name.Length > 8)
            {
                pos -= id_name.Length;
                throw new FormatException("Синтаксическая ошибка: длина имени идентификатора превышает 8 символов");
            }
            List<String> reserved_names = new List<String>() { "case", "of", "else", "end", "div", "mod" };
            if (reserved_names.Contains(id_name))
            {
                pos -= id_name.Length;
                throw new FormatException("Синтаксическая ошибка: имя идентификатора совпадает с зарезервированным словом " + id_name);
            }

            if (!variables.ContainsKey(id_name))
            {
                variables.Add(id_name, base_type);
            }
            return id_name;
        }

        public void nextIntegralConstant(String base_type)
        {
            String res = "";
            if (pos >= source.Length)
            {
                throw new FormatException("Синтаксическая ошибка: ожидалась целая константа");
            }
            if (source[pos] == '+' || source[pos] == '-')
            {
                res += source[pos++];
            }
            if (IsDigit(source[pos]))
            {
                if (source[pos] == '0')
                {
                    if (pos + 1 < source.Length || IsDigit(source[pos + 1]))
                    {
                        throw new FormatException("Синтаксическая ошибка: ведущие нули в константе");
                    }
                    res += "0";
                    ++pos;
                }
                else
                {
                    while (pos < source.Length && IsDigit(source[pos]))
                    {
                        res += source[pos++];
                    }
                }
            }
            else
            {
                throw new FormatException("Синтаксическая ошибка: ожидалась целая константа");
            }

            int val1;
            if (int.TryParse(res, out val1))
            {
                if (val1 < -32768 || 32767 < val1)
                {
                    throw new FormatException("Значение константы не является допустимым");
                }
            }
            if (!constants.ContainsKey(res))
                constants.Add(res, (base_type == "константа" ? "целая константа" : base_type));
        }

        public bool nextConstant(string base_type) // if constant is integer
        {
            String res = "";
            if (pos >= source.Length)
            {
                throw new FormatException("Синтаксическая ошибка: ожидалась константа");
            }
            if (source[pos] == '+' || source[pos] == '-')
            {
                res += source[pos++];
            }
            if (IsDigit(source[pos]))
            {
                if (source[pos] == '0')
                {
                    ++pos;
                    if (pos < source.Length && IsDigit(source[pos]) && source[pos] != '.')
                    {
                        throw new FormatException("Синтаксическая ошибка: ведущие нули в константе");
                    }
                    res += '0';
                }
                else
                {
                    while (pos < source.Length && IsDigit(source[pos]))
                    {
                        res += source[pos++];
                    }
                }
                if (pos < source.Length && source[pos] == '.')
                {
                    res += '.';
                    ++pos;
                    while (pos < source.Length && IsDigit(source[pos]))
                    {
                        res += source[pos++];
                    }
                    if (pos < source.Length && source[pos] == 'e')
                    {
                        res += 'e';
                        ++pos;
                        SkipWS();
                        if (pos >= source.Length || !IsDigit(source[pos]) && source[pos] != '+' && source[pos] != '-')
                        {
                            throw new FormatException("Синтаксическая ошибка: ожидалась экспонента");
                        }
                        if (source[pos] == '+' || source[pos] == '-')
                        {
                            res += source[pos++];
                        }
                        SkipWS();
                        while (pos < source.Length && IsDigit(source[pos]))
                        {
                            res += source[pos++];
                        }
                        if (!constants.ContainsKey(res))
                            constants.Add(res, (base_type == "константа" ? "вещ. константа с плав. точкой" : base_type));
                    }
                    else
                    {
                        if (!constants.ContainsKey(res))
                            constants.Add(res, (base_type == "константа" ? "вещ. константа с фикс. точкой" : base_type));
                    }
                    return false;
                }
                else
                {
                    int val1;
                    if (int.TryParse(res, out val1))
                    {
                        if (val1 < -32768 || 32767 < val1)
                        {
                            throw new FormatException("Значение константы не является допустимым");
                        }
                    }
                    if (!constants.ContainsKey(res))
                        constants.Add(res, (base_type == "константа" ? "целая константа" : base_type));
                    return true;
                }
            }
            else
            {
                throw new FormatException("Синтаксическая ошибка: ожидалась целая константа");
            }
        }

        public void nextOperand()
        {
            if (pos >= source.Length)
            {
                throw new FormatException("Синтаксическая ошибка: ожидался операнд");
            }
            if (IsDigit(source[pos]) || source[pos] == '+' || source[pos] == '-')
            {
                nextConstant("константа");
            }
            else
            {
                String id_name = nextIdentifier("идентификатор");
                SkipWS();
                if (pos < source.Length && source[pos] == '[')
                {
                    if (variables[id_name] != "массив" && variables[id_name] != "идентификатор")
                    {
                        throw new FormatException("Семантическая ошибка: обращение к переменной как к массиву");
                    }    
                    variables[id_name] = "массив";
                    ++pos;
                    SkipWS();
                    if (pos >= source.Length)
                    {
                        throw new FormatException("Синтаксическая ошибка: ожидался идентификатор или целая константа");
                    }
                    if (IsDigit(source[pos]) || source[pos] == '+' || source[pos] == '-')
                    {
                        nextIntegralConstant("индекс");
                    }
                    else
                    {
                        String index_id = nextIdentifier("индекс");
                        if (variables[index_id] != "индекс" && variables[index_id] != "переменная")
                        {
                            pos -= index_id.Length;
                            throw new FormatException("Семантическая ошибка: некорректное повторное использование идентификатора");
                        }
                        variables[index_id] = "индекс";
                    }
                    if (pos >= source.Length || source[pos++] != ']')
                    {
                        throw new FormatException("Синтаксическая ошибка: ожидалась закрывающая квадратная скобка");
                    }
                }
                else
                {
                    if (variables[id_name] != "переменная" && variables[id_name] != "идентификатор" && variables[id_name] != "индекс")
                    {
                        throw new FormatException("Семантическая ошибка: некорректное повторное использование идентификатора");
                    }
                    variables[id_name] = "переменная";
                }
            }
        }

        public void nextAssignmentOperator()
        {
            String id_name = nextIdentifier("идентификатор");
            SkipWS();
            if (pos >= source.Length)
            {
                throw new FormatException("Синтаксическая ошибка: ожидалось присваивание");
            }
            if (source[pos] == '[')
            {
                if (variables[id_name] != "массив" && variables[id_name] != "идентификатор")
                {
                    throw new FormatException("Семантическая ошибка: обращение к переменной как к массиву");
                }
                variables[id_name] = "массив";
                pos += 1;
                SkipWS();
                if (pos >= source.Length)
                {
                    throw new FormatException("Синтаксическая ошибка: ожидался идентификатор или целая константа");
                }
                if (IsDigit(source[pos]) || source[pos] == '+' || source[pos] == '-')
                {
                    nextIntegralConstant("индекс");
                }
                else
                {
                    String index_id = nextIdentifier("индекс");
                    if (variables[index_id] != "индекс" && variables[index_id] != "переменная")
                    {
                        throw new FormatException("Семантическая ошибка: некорректное повторное использование идентификатора");
                    }    
                    variables[index_id] = "индекс";
                }
                if (pos >= source.Length || source[pos++] != ']')
                {
                    throw new FormatException("Синтаксическая ошибка: ожидалась закрывающая квадратная скобка");
                }
            }
            else
            {
                if (variables[id_name] != "переменная" && variables[id_name] != "идентификатор" && variables[id_name] != "индекс")
                {
                    throw new FormatException("Семантическая ошибка: некорректное повторное использование идентификатора");
                }
                variables[id_name] = "переменная";
            }
            SkipWS();
            if (pos + 1 < source.Length && source[pos] == ':' && source[pos + 1] == '=')
            {
                pos += 2;
            }
            else
            {
                throw new FormatException("Синтаксическая ошибка: ожидалось присваивание");
            }
            SkipWS();
            nextOperand();
            SkipWS();
            foreach (String oper in new List<string>{ "+", "-", "*", "/", "div", "mod"})
            {
                if (source.Substring(pos).StartsWith(oper))
                {
                    pos += oper.Length;
                    SkipWS();
                    nextOperand();
                    break;
                }
            }
        }

        public void SkipWS()
        {
            while (pos < source.Length && source[pos] == ' ')
            {
                ++pos;
            }
        }
    }
}
