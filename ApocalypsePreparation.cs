using System.Collections;
using System.Globalization;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //textiles
            Queue<int> textiles = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> medications = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> keyValuePairs = new();

            while (textiles.Any() && medications.Any())
            {
                int sum = textiles.Peek() + medications.Peek();

                //Patch   30
                if (sum == 30)
                {
                    textiles.Dequeue();
                    medications.Pop();
                    if (!keyValuePairs.ContainsKey("Patch"))
                    {
                        keyValuePairs.Add("Patch", 0);
                    }
                    keyValuePairs["Patch"]++;
                }
                //Bandage 40
                else if (sum == 40)
                {
                    textiles.Dequeue();
                    medications.Pop();
                    if (!keyValuePairs.ContainsKey("Bandage"))
                    {
                        keyValuePairs.Add("Bandage", 0);
                    }
                    keyValuePairs["Bandage"]++;
                }
                //MedKit  100
                else if (sum == 100)
                {
                    textiles.Dequeue();
                    medications.Pop();
                    if (!keyValuePairs.ContainsKey("MedKit"))
                    {
                        keyValuePairs.Add("MedKit", 0);
                    }
                    keyValuePairs["MedKit"]++;
                }
                else if (sum > 100)
                {

                    int difference = sum - 100;
                    textiles.Dequeue();
                    medications.Pop();
                    int lastElement = medications.Pop() + difference;
                    medications.Push(lastElement);
                    if (!keyValuePairs.ContainsKey("MedKit"))
                    {
                        keyValuePairs.Add("MedKit", 0);
                    }
                    keyValuePairs["MedKit"]++;
                }
                else
                {
                    textiles.Dequeue();
                    int firstElement = medications.Pop() + 10;
                    medications.Push(firstElement);
                }
            }

            keyValuePairs = keyValuePairs.OrderByDescending(kv => kv.Value)
                .ThenBy(kv => kv.Key)
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            //"Textiles and medicaments are both empty."

            if (!textiles.Any() && !medications.Any())
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (!textiles.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            else
            {
                Console.WriteLine("Medicaments are empty.");
            }
            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            if (medications.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medications)}");
            }
            if (textiles.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}