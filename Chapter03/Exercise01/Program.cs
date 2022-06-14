using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            
            Exercise1_1(numbers);
            Console.WriteLine("-------------");

            Exercise1_2(numbers);
            Console.WriteLine("-------------");

            Exercise1_3(numbers);
            Console.WriteLine("-------------");

            Exercise1_4(numbers);
            Console.WriteLine("-------------");
            

            Exercise1_5(numbers);
            Console.WriteLine("-------------");

            Exercise1_6(numbers);
            Console.WriteLine("-------------");

            Exercise1_7(numbers);
            Console.WriteLine("-------------");
        }

        private static void Exercise1_7(List<int> numbers) {
            
        }

        private static void Exercise1_6(List<int> numbers) {
            var max = numbers.Max(n => n % 2 == 0);
            Console.WriteLine();
                
        }

        private static void Exercise1_5(List<int> numbers) {
            var sum = numbers.Sum();
            Console.WriteLine(sum);
        }

        
        private static void Exercise1_1(List<int> numbers) {
            var exist = numbers.Exists(n => n % 8 == 0 || n %  9 == 0);
            if (exist)
                Console.WriteLine("存在しています");
            else
                Console.WriteLine("存在していません");
        }

        private static void Exercise1_2(List<int> numbers) {
            numbers.ForEach(n => Console.WriteLine(n / 2.0));
           
        }

         private static void Exercise1_3(List<int> numbers) {
            foreach (var n in numbers.Where(n => n >= 50)){
                Console.WriteLine(n);
            }

            //var nums = numbers.Where(n => n >= 50);
            //foreach(var n in nums) {
            //Console.WriteLine(n);
        }

        private static void Exercise1_4(List<int> numbers) {
            var list = numbers.Select(n => n * 2).ToList();

            numbers[5] = 5000;

            foreach(var n in list) {  //遅延実行（即時実行）
                Console.WriteLine(n);
            }
        }
    }
}
