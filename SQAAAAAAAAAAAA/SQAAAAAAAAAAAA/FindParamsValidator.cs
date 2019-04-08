using System.Collections.Generic;

namespace SQAAAAAAAAAAAA
{
    internal class FindParamsValidator
    {
        internal List<string> Validate(string value)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(value))
            {
                result.Add("empty string");
                return result;
            }
            else
            {
                char[] valChar = value.ToCharArray();
                for (int i = 0; i < valChar.Length; i++)
                {
                    if (char.IsDigit(valChar[i]))
                    {
                        result.Add("string contains number");
                        return result;
                    }
                }
                bool findFirstComma = false;
                for (int i = 0; i < valChar.Length; i++)
                {
                    if ((valChar[i] == ',') && (findFirstComma == false))
                    {
                        findFirstComma = true;
                    }
                    else 
                    {
                        if ((valChar[i] == ',') && (findFirstComma == true))
                        {
                            result.Add("string contains more than one ',' ");
                            return result;
                        }
                    }
                }
                if (findFirstComma == true)
                {
                    for (int i = value.IndexOf(',')+1; i < valChar.Length; i++)
                    {
                        if (!char.IsLetter(valChar[i]))
                        {
                            result.Add("string contains comma and some symbol");
                            return result;
                        }
                    }
                }
                //
                bool findFirstSpace = false;
                for (int i = 0; i < valChar.Length; i++)
                {
                    if ((valChar[i] == ' ') && (findFirstSpace == false))
                    {
                        findFirstSpace = true;
                    }
                    else
                    {
                        if ((valChar[i] == ' ') && (findFirstSpace == true))
                        {
                            result.Add("string contains more than one white space ");
                            return result;
                        }
                    }
                }

                if (findFirstSpace == true)
                {
                    for (int i = value.IndexOf(' ') + 1; i < valChar.Length; i++)
                    {
                        if (!char.IsLetter(valChar[i]))
                        {
                            result.Add("string contains space and some symbol");
                            return result;
                        }
                    }
                }
            }
            if (value.Length < 3)
            {
                result.Add("too short string");
                return result;
            }
            if (value.Length > 30)
            {
                result.Add("too long string");
            }
            return result;
        }
    }
}