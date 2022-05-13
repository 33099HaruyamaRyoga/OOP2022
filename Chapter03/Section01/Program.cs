using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        public delegate bool Judgement(int value); //デリゲートの宣言

        static void Main(string[] args) {
            var list = new List<string> {
                "Tokyo", "New Delhi", "bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            var names = list.FindAll(s => s.Length <= 5);
            names.ForEach(s => Console.WriteLine(s));

            /*
            foreach(var s in names) {
                Console.WriteLine(s);
            }
            */
            
        }

    }
}
