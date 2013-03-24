using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EP_StupidConverter
{
    public class Rule
    {
        public List<string> conditions;
        public string result;

        public Rule(string result, List<string> conditions)
        {
            this.result = result;
            this.conditions = conditions;
        }

        public Rule(string raw_string)
        {
            result = "";
            conditions = new List<string>();
            string[] temp_lines = raw_string.Split('(', ')');
            foreach (string temp_line in temp_lines)
            {
                string[] supported_line = temp_line.Split(';');
                if (supported_line.Length > 1)
                {
                    string value = supported_line[1].Remove(0, 1);
                    value = value.Replace("\"", "\\\"");
                    conditions.Add(value);
                }
            }
            result = conditions[conditions.Count - 1];
            conditions.RemoveAt(conditions.Count - 1); // Последнее условие - и есть результат
        }

        public override string ToString()
        {
            // Строим правило вида:
            // choose(X1, X2, ..., Xn, Y).
            string result = "";

            result += "choose(";
            for (int i = 0; i < conditions.Count; i++)
            {
                result += "\"";
                result += conditions[i];
                result += "\", ";
            }
            result += "\"";
            result += this.result;
            result += "\"";
            result += ").";

            return result;
        }
    }
}
