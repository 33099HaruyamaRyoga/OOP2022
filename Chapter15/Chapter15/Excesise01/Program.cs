using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excesise01 {
    class Program {
        static void Main(string[] args) {

            var price = new List<Book>();

            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books
                .Max(b => b.Price);
            var book = Library.Books
                .First(b => b.Price == max);
            Console.WriteLine(book);
            
        }

        private static void Exercise1_3() {
            //var groups = Library.Books
            //    .GroupBy(b => b.PublishedYear);
            //var book = 
        }

        private static void Exercise1_4() {
            //var groups = Library.Books
            //    .GroupBy(b => b.PublishedYear)
            //    .OrderBy(g => g.Key);
        //foreach (var book in groups) {
            //Console.WriteLine($"{book}");
                
            //}
        }

        private static void Exercise1_5() {
            //var books = Library.Books
            //      .Where(b => b.PublishedYear == 2016);
            //Console.WriteLine(books);
        }

        private static void Exercise1_6() {

        }

        private static void Exercise1_7() {

        }

        private static void Exercise1_8() {

        }
    }
}
