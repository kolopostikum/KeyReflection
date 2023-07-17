using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var dictK = new Dictionary<string, long>();
            var dictV = new SortedDictionary<long, HashSet<string>>();
            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine();
                WriteBiggestKeys(dictK, dictV, input);
                Console.WriteLine();
            }
        }

        private static void WriteBiggestKeys(Dictionary<string, long> dictK
, SortedDictionary<long, HashSet<string>> dictV, string input)
        {
            var inpKartel = input.Split(' ');
            var key = inpKartel[0];
            var value = long.Parse(inpKartel[1]);

            if (dictK.ContainsKey(key))
                AddValueToDictsOld(dictK, dictV, key, value);

            else
                AddValueToDictsNew(dictK, dictV, key, value);
            WriteResult(dictV);
        }

        private static void WriteResult(SortedDictionary<long, HashSet<string>> dictV)
        {
            var counter = 10;
            foreach (var value in dictV.Keys.Reverse())
            {
                foreach (var key in dictV[value])
                {
                    Console.Write(key + " ");
                    counter--;
                    if (counter < 1) return;
                }
            }
        }

        private static void AddValueToDictsNew(Dictionary<string, long> dictK
            , SortedDictionary<long, HashSet<string>> dictV, string key, long value)
        {
            dictK[key] = value;
            var newVal = dictK[key];
            AddToDictVal(newVal, key, dictV);
        }

        private static void AddValueToDictsOld(Dictionary<string, long> dictK
            , SortedDictionary<long, HashSet<string>> dictV, string key, long value)
        {
            var oldVal = dictK[key];
            dictV[oldVal].Remove(key);

            dictK[key] += value;

            var newVal = dictK[key];

            AddToDictVal(newVal, key, dictV);
        }

        private static void AddToDictVal(long newVal, string key, SortedDictionary<long, HashSet<string>> dictV)
        {
            if (dictV.ContainsKey(newVal))
                dictV[newVal].Add(key);
            else
                dictV[newVal] = new HashSet<string> { key };
        }
    }
}
