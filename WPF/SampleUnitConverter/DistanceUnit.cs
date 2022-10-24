using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    public class DistanceUnit {
        public string Name { get; set; }       //単位の名称
        public double confficient { get; set; }  //係数
        public override string ToString() {
            return this.Name;
        }
    }

    //メートル単位を表すクラス
    public class MetricUnit : DistanceUnit {
        private static List<MetricUnit> units = new List<MetricUnit> {
            new MetricUnit{Name = "mm", confficient = 1,},
            new MetricUnit{Name = "cm", confficient = 10,},
            new MetricUnit{Name = "m", confficient = 10 * 100,},
            new MetricUnit{Name = "km", confficient = 10 * 100 * 1000,},
        };

        public static ICollection<MetricUnit> Units { get { return units; } }

        /// <summary>
        /// ヤード単位からメートル単位に変換します
        /// </summary>
        /// <param name="unit">ヤード単位</param>
        /// <param name="value">値</param>
        /// <returns></returns>

        public double FromImperialUnit(ImperialUnit unit, double value) {
            return (value * unit.confficient) * 25.4 / this.confficient;
        }
    }

    //ヤード単位を表すクラス
    public class ImperialUnit : DistanceUnit {
        private static List<ImperialUnit> units = new List<ImperialUnit> {
            new ImperialUnit{Name = "in", confficient = 1},
            new ImperialUnit{Name = "ft", confficient = 12},
            new ImperialUnit{Name = "yd", confficient = 12 * 3,},
            new ImperialUnit{Name = "ml", confficient = 12 * 3 * 1760,},
        };

        public static ICollection<ImperialUnit> Units { get { return units; } }

        public double FromMetricUnit(MetricUnit unit, double value) {
            return (value * unit.confficient) / 25.4 / this.confficient;
        }
    }
}
