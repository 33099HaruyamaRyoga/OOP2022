using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise {
    class Program {
        static void Main(string[] args) {
            //2,1.3
            var songs = new Song[] {
                new Song("Habit", "SEKAI NO OWARI", 230),
                new Song("MAKAFUKA", "RADWIMPS", 331),
                new Song("幽居のワルツ", "Noel", 233),
                new Song("The Beginning", "ONE OK ROCK", 293),
                new Song("お気に召すまま", "Eve", 247)
            };

            PrintSongs(songs);
        }
        //2,1.4
        private static void PrintSongs(Song[] songs) {
            foreach (var song in songs) {
                //var span = new TimeSpan(0, 0, song.Length);
                Console.WriteLine("{0}, {1}, {2:m\\:ss}",
                   song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            }
        }


    }
}
