using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    public class MainWindowViewModel : ViewModel {
        private double metricValue, imperialValue;

        public double MetricValue {
            get { return this.metricValue; }
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }
        public double ImperialValue {
            get { return this.imperialValue; }
            set {
                this.ImperialValue = value;
                this.OnPropertyChanged();
            }
        }
        public MetricUnit CurrentMetricUnit { get; set; }

        public ImperialUnit CurrentImperialUnit { get; set; }

        public ICommand ImperialUnitToMetric { get; private set; }

        public ICommand MetricToImperialUnit { get; private set; }

        public MainWindowViewModel() {
            this.MetricToImperialUnit = new DelegateCommand(
                () => this.ImperialValue = this.CurrentImperialUnit.FromMetricUnit(
                    this.CurrentMetricUnit, this.MetricValue));

            this.ImperialUnitToMetric = new DelegateCommand(
                () => this.MetricValue = this.CurrentMetricUnit.FromImperialUnit(
                    this.CurrentImperialUnit, this.ImperialValue));
        }
    }
}
