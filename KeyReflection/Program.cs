using System;
using System.Collections.Generic;

namespace KeyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var dictK = new Dictionary<string, int>();
            var dictV = new SortedDictionary<int, List <string>>();
            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine();
                WriteBiggestKeys(dictK, dictV, input);
            }
        }

        private static void WriteBiggestKeys(Dictionary<string, int> dictK
, SortedDictionary<int, List<string>> dictV, string input)
        {
            Tuple<string, int> inpKartel = Tuple.Create(input.Split(' ')[0],
                                               int.Parse(input.Split(' ')[1]));

            if (dictK.ContainsKey(inpKartel.Item1))
                AddValueToDictsOld(dictK, dictV, inpKartel);

            else
                AddValueToDictsNew(dictK, dictV, inpKartel);
            WriteResult(dictV);
        }

        private static void WriteResult(SortedDictionary<int, List<string>> dictV)
        {
            ICollection<int> values = dictV.Keys;
            var counter = 10;

            Console.WriteLine();
            foreach (var value in values)
            {
                foreach (var key in dictV[value])
                {
                    Console.Write(key + " ");
                    counter--;
                    if (counter < 1) return;
                }
            }
        }

        private static void AddValueToDictsNew(Dictionary<string, int> dictK
            , SortedDictionary<int, List<string>> dictV, Tuple<string, int> inpKartel)
        {
            dictK[inpKartel.Item1] = inpKartel.Item2;
            var newVal = dictK[inpKartel.Item1];
            AddToDictVal(newVal, inpKartel.Item1, dictV);
        }

        private static void AddValueToDictsOld(Dictionary<string, int> dictK
            , SortedDictionary<int, List<string>> dictV, Tuple<string, int> inpKartel)
        {
            var oldVal = dictK[inpKartel.Item1];
            dictV[oldVal].Remove(inpKartel.Item1);

            if (dictV[oldVal].Count == 0)
                dictV.Remove(oldVal);

            dictK[inpKartel.Item1] += inpKartel.Item2;

            var newVal = dictK[inpKartel.Item1];

            AddToDictVal(newVal, inpKartel.Item1, dictV);
        }

        private static void AddToDictVal(int newVal, string key, SortedDictionary<int, List<string>> dictV)
        {
            if (dictV.ContainsKey(newVal))
                dictV[newVal].Add(key);
            else
                dictV[newVal] = new List<string> { key };
        }
    }
}
