using System;
using System.Collections.Generic;
using System.Text;

namespace u_t6_data_1
{
    class Rule
    {
        public List<string> Dependency;
        public List<string> Affects;
        public bool Toggled = false;

        public Rule()
        {
            Dependency = new List<string>();
            Affects = new List<string>();
        }

        public bool Calculate(List<Fact> facts)
        {
            int count = 0;
            Fact factObj = null;

            if (Toggled)
                return false;

            foreach (var dep in Dependency)
            {
                factObj = facts.Find(x => x.Line == dep);
                if (factObj != null && factObj.IsTrue)
                    count++;
            }

            // Deps contented
            if (count == Dependency.Count)
            {
                foreach (var af in Affects)
                {
                    factObj = facts.Find(x => x.Line == af);
                    if (factObj != null)
                    {
                        factObj.IsTrue = true;
                    }
                }

                if (Affects.Count != 0)
                {
                    Console.Write("Выполнено правило: ");
                    foreach (var dep in Dependency)
                    {
                        Console.Write($"'{dep}' & ");
                    }
                    Console.Write($"\b\b=> ");
                    foreach (var dep in Affects)
                    {
                        Console.Write($"'{dep}' & ");
                    }
                    Console.Write($"\b\b- истина!\n");
                }

                Toggled = true;

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string finalString = "";

            foreach (var dep in Affects)
            {
                finalString += $"'{dep}' & ";
            }

            finalString = finalString[..^3];

            return finalString;
        }
    }
}
