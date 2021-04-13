using System;
using System.Collections.Generic;
using System.Text;

namespace u_t6_data_1
{
    class Interpreter
    {
        public List<Fact> Facts;
        public List<Rule> Rules;

        public delegate bool CheckFactDelegate(string line);
        public CheckFactDelegate CheckFact;

        public delegate void CheckRuleDelegate(Rule rule);
        public CheckRuleDelegate CheckRule;

        public Interpreter()
        {
            Facts = new List<Fact>();
            Rules = new List<Rule>();
        }

        public void AddBeginFacts(params string[] facts)
        {
            Fact factObj = null;

            foreach (var fact in facts)
            {
                factObj = new Fact(fact);
                factObj.IsTrue = false;
                Facts.Add(factObj);

                Console.WriteLine($"{Facts.Count}. (факт): '{fact}' = ложь");
            }

            Console.WriteLine($"Добавлено фактов: {facts.Length}\n");
        }

        public void AddFact(string line)
        {
            var fact = new Fact(line);
            fact.IsTrue = CheckFact(line);

            Facts.Add(fact);

            CalcRules();
        }

        public void SetFact(string line, bool value)
        {
            var factObj = Facts.Find(x => x.Line == line);

            if (factObj != null)
            {
                factObj.IsTrue = value;

                var str = value ? "истина" : "ложь";
                Console.WriteLine($"Установлен факт: '{factObj.Line}' = {str}");
            }

            CalcRules();
        }

        public void AddRule(uint deps, params string[] facts)
        {
            var rule = new Rule();

            // Add Dependencies
            for (uint i = 0; i < deps; i++)
                rule.Dependency.Add(facts[i]);

            // Add Affection
            for (uint i = deps; i < facts.Length; i++)
                rule.Affects.Add(facts[i]);

            Rules.Add(rule);

            // Print
            Console.WriteLine($"{Rules.Count}. (правило) {rule}");

            CalcRules();
        }

        void CalcRules()
        {
            for (int i = 0; i < Rules.Count; i++)
            {
                if (Rules[i].Calculate(Facts))
                    i = -1;
            }
        }

        public void ShowRuleCount()
        {
            Console.WriteLine($"Добавлено правил: {Rules.Count}\n");
        }

        public void Run()
        {
            for (int i = 0; i < Facts.Count; i++)
            {
                if (Facts[i].IsTrue == false)
                {
                    Facts[i].IsTrue = CheckFact(Facts[i].Line);
                    CalcRules();
                }
            }

            Console.WriteLine("\n===================================\n" +
                "Результат выполнения программы: \nФакты:");

            string str;
            for (int i = 0; i < Facts.Count; i++)
            {
                str = Facts[i].IsTrue ? "истина" : "ложь";

                Console.WriteLine($"{i}. {Facts[i].Line} = {str}");
            }

            Console.WriteLine("Правила:");
            for (int i = 0; i < Rules.Count; i++)
            {
                str = Rules[i].Toggled ? "выполнено" : "не выполнено";


                Console.WriteLine($"{i}. {Rules[i]} = {str}");
            }
        }
    }
}
