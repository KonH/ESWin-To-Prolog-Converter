using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EP_StupidConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btConvert_Click(object sender, EventArgs e)
        {
            string[] input = rtbESWin_Text.Lines;
            string output = "";

            List<Rule> rules = new List<Rule>();

            string current_line = "";
            string current_outline = "";

            bool in_rule = false;
            bool in_conditions = false;

            for (int i = 0; i < input.Length; i++)
            {
                current_line = input[i];
                if (current_line.Contains("Rule"))
                {
                    // Начало правила
                    in_rule = true;
                    in_conditions = true;
                }
                if (current_line.Contains("Do"))
                {
                    // Следующая строка - результат
                    in_conditions = false;
                }
                if (current_line.Contains("EndR"))
                {
                    // Конец правила
                    in_rule = false;
                    in_conditions = false;
                }

                if (in_rule)
                {
                    if (in_conditions)
                    {
                        if (!current_line.Contains("Rule"))
                        {
                            current_outline += current_line + "\n";
                        }
                    }
                    else
                    {
                        if (!current_line.Contains("Do"))
                        {
                            current_outline += current_line;
                        }
                    }
                }
                else
                {
                    if (current_outline != "")
                    {
                        // Сброс результата
                        rules.Add(new Rule(current_outline));
                        current_outline = "";
                    }
                }
            }

            // Построение результата
            // Заголовок
            output += "domains\n";
            output += "\ts = symbol\n";
            output += "predicates\n";
            for(int i = 0; i < rules[0].conditions.Count; i++)
            {
                output += "\tnondeterm rule" + i + "(s)\n";
            }
            output += "\tnondeterm result(s)\n";
            // Сигнатура правила по первому полученному правилу
            output += "\tnondeterm choose(";
            for (int i = 0; i < rules[0].conditions.Count; i++)
            {
                output += "s, ";
            }
            output += "s)";
            output += "\n";
            // Сами правила
            output += "clauses\n";
            // Правила
            List<List<string>> unique_conditions = new List<List<string>>();
            for (int i = 0; i < rules[0].conditions.Count; i++)
            {
                unique_conditions.Add(new List<string>());
                foreach (Rule rule in rules)
                {
                    if (!unique_conditions[i].Contains(rule.conditions[i]))
                        unique_conditions[i].Add(rule.conditions[i]);
                }
            }
            List<string> unique_results = new List<string>();
            foreach(Rule rule in rules)
            {
                if (!unique_results.Contains(rule.result))
                    unique_results.Add(rule.result);
            }
            for (int i = 0; i < rules[0].conditions.Count; i++)
            {
                foreach(string cond in unique_conditions[i])
                    output += "\trule" + i + "(\"" + cond + "\").\n";
                output += "\n";
            }
            foreach(string result in unique_results)
                output += "\tresult(\"" + result + "\").\n";
            output += "\n";
            // Содержимое выбора
            foreach (Rule rule in rules)
            {
                output += "\t" + rule.ToString() + "\n";
            }
            output += "goal\n";

            rtbPrologText.Text = output;
        }
    }
}
