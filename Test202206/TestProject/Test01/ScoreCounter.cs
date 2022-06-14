﻿using System.Collections.Generic;
using System.IO;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {

                List<Student> students = new List<Student>();
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines) {
                    string[] items = line.Split(',');
                Student student = new Student {
                        Name = items[0],
                        subject = items[1],
                        score = int.Parse(items[2])
                    };
                    students.Add(student);
                }
                return students;
            }






        }

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {





            
        }
    }
}
