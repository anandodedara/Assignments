
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;


namespace assignment2
{
    public static class StringHelper
    {
        //to convert in upper case
        public static string ToUpperCustom(this string input)
        {
            char[] c = input.ToCharArray();
            int length = input.Length;
            for(int i=0; i<length; i++)
            {
                c[i] = char.ToUpper(c[i]);
            }
            return new string(c);
        }

        //to convert in lower case
        public static string ToLowerCase(this string input)
        {
            char[] c = input.ToCharArray();
            int length = input.Length;
            for (int i = 0; i < length; i++)
            {
                c[i] = char.ToLower(c[i]);
            }
            return new string(c);
        }

        //to title case

        //public static string ToTitleCase(this string input)
        // {
        //     TextInfo text = new CultureInfo("en-US", false).TextInfo;

        //     input = text.ToTitleCase(input);
        //     return input;
        // }

        public static String ToTitleCase(this string input)
        {
            if (input == null) return input;

            String[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;
                Char firstChar = Char.ToUpper(words[i][0]);
                String test = "";
                if (words[i].Length > 1)
                {
                    test = words[i].Substring(1).ToLower();
                }
                words[i] = firstChar + test;
            }
            return String.Join(" ", words);
        }

        //to check if string is in lower case
        public static bool CheckLowerCase(this string input)
        {
            Regex re = new Regex("[a-z]+");
            if (re.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        //to check if string is in upper case
        public static bool CheckUpperCase(this string input)
        {
            Regex re = new Regex("[A-Z]+");
            if (re.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        //to capitalize the string
        public static string Capitalize(this string input)
        {
            input= input.First().ToString().ToUpper() + input.Substring(1);
            return input;
        }

        //to check string can be converted to a valid numeric value 
        public static bool IsNumericValue(this string input)
        {
            input = input.Trim();
            Regex re = new Regex("^[0-9]+$");
            if (re.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        // to remove last character of the string
        public static string ToRemoveLastCharachter(this string input)
        {
            input = input.Remove(input.Length - 1);
            return input;
        }

        //to get word count of the string
        public static int GetWordCount(this string input)
        {
            int wordcount=0,i=0;            
            int status=0;
            while (i < input.Length)
            {
               if(input[i] == ' ' || input[i] == '\n' || input[i] == '\t')
               {
                    status = 0;
               }
               else if (status == 0)
               {
                    status = 1;
                    ++wordcount;
               }
                ++i;
            }
            return wordcount;
        }

        //to convert string into int
        public static int ConvertStringToInt(this string input)
        {
            int number;
            if (int.TryParse(input, out number))
            {
                number = int.Parse(input);                
            }
            return number;
        }
    }
}