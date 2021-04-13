using System;
using System.Collections.Generic;

namespace u_t6_data_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup UTF-8 Output
            Console.OutputEncoding = System.Text.UTF8Encoding.UTF8;

            // Подготавливаем интерпретатор
            var interpreter = new Interpreter();            
            interpreter.CheckFact = Interpreter_IO.CheckFactCMD;

            // Факты
            interpreter.AddBeginFacts("есть рукоятка",
                "забиваем гвозди",
                "колем дрова",
                "ремонтируем",
                "топим баню",
                "инструмент",
                "молоток",
                "колун");

            /* Правила (первый арг. - число, разделяющее зависимости и последствия 
                AddRule(2, Зависимость1, Зависимость 2, Последствие 1, Последствие 2 ...);
            */ 
            interpreter.AddRule(2, "есть рукоятка", "забиваем гвозди", "молоток");
            interpreter.AddRule(2, "есть рукоятка", "колем дрова", "колун");
            interpreter.AddRule(1, "ремонтируем", "забиваем гвозди");
            interpreter.AddRule(1, "топим баню", "колем дрова");
            interpreter.AddRule(1, "инструмент", "есть рукоятка");
            interpreter.ShowRuleCount();

            // Начальные факты
            //interpreter.SetFact("инструмент", true);
            //interpreter.SetFact("топим баню", true);

            interpreter.Run();

            /*interpreter.AddBeginFacts("расскажу анек",
                "читаю логику",
                "есть спички",
                "куришь сигареты",
                "бухаешь",
                "водятся деньги",
                "ебешь баб",
                "не пидарас");

            interpreter.AddRule(1, "читаю логику", "расскажу анек");
            interpreter.AddRule(1, "есть спички", "куришь сигареты");
            interpreter.AddRule(1, "куришь сигареты", "бухаешь");
            interpreter.AddRule(1, "бухаешь", "водятся деньги");
            interpreter.AddRule(1, "водятся деньги", "ебешь баб");
            interpreter.AddRule(1, "ебешь баб", "не пидарас");
            interpreter.ShowRuleCount();

            interpreter.SetFact("читаю логику", true);

            interpreter.Run();*/
        }
    }
}
