﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    class Program {
        //コマンドライン引数
        static void Main(string[] args) {
            if (args.Length >= 1 && args[0] == "-tom") {
                //フィートからメートルへの対応力を出力
                PrintFeetToMeterList(1, 10);
            }
            else {
                //メートルからフィートへの対応力を出力
                PrintFeetToMeterList(1, 10);
            }
        }

        //メートルからフィートへの対応力を出力
        private static void PrintFeetToMeterList() {
            for (int meter = 1; meter <= 10; meter++) {
                double feet = FeetToMeter(meter);
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
            }
        }

        //フィートからメートルへの対応力を出力
        private static void PrintFeetToMeterList(int stsrt, int stop) {
            for (int feet = 1; feet <= 10; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
            }
        }

        //フィートからメートルを求める
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        //メートルからフィートを求める
        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }
    }
}
