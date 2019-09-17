using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MinimalMVVM.Models;

namespace MinimalMVVM.ViewModels
{
    public class Presenter : ObservableObject
    {
        private readonly TextConverter _textConverter = new TextConverter(s => s.ToUpper());
        private BlackScholes blackScholes = new BlackScholes();

        private string _someText;
        private string _stockPrice;
        private string _strikePrice;
        private string _timeToMaturity;
        private string _standardDev;
        private string _riskFreeRate;
        private string _callPrice;
        private string _putPrice;

        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public string StockPrice
        {
            get { return _stockPrice; }
            set
            {
                _stockPrice = value;
                RaisePropertyChangedEvent("StockPrice");
            }
        }

        public string StrikePrice
        {
            get { return _strikePrice; }
            set
            {
                _strikePrice = value;
                RaisePropertyChangedEvent("StrikePrice");
            }
        }

        public string TimeToMaturity
        {
            get { return _timeToMaturity; }
            set
            {
                _timeToMaturity = value;
                RaisePropertyChangedEvent("TimeToMaturity");
            }
        }

        public string StandardDeviation
        {
            get { return _standardDev; }
            set
            {
                _standardDev = value;
                RaisePropertyChangedEvent("StandardDeviation");
            }
        }

        public string RiskFreeRate
        {
            get { return _riskFreeRate; }
            set
            {
                _riskFreeRate = value;
                RaisePropertyChangedEvent("RiskFreeRate");
            }
        }

        public string CallPrice
        {
            get { return _callPrice; }
            set
            {
                _callPrice = value;
                RaisePropertyChangedEvent("CallPrice");
            }
        }

        public string PutPrice
        {
            get { return _putPrice; }
            set
            {
                _putPrice = value;
                RaisePropertyChangedEvent("PutPrice");
            }
        }

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        public ICommand ConvertTextCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }

        public ICommand ComputeBSCommand
        {
            get { return new DelegateCommand(ComputeBS); }
        }

        private void ConvertText()
        {
            if (string.IsNullOrWhiteSpace(SomeText)) return;
            AddToHistory(_textConverter.ConvertText(SomeText));
            SomeText = string.Empty;
        }

        private void ComputeBS()
        {
            double S;
            bool isSOk = double.TryParse(StockPrice, out S);
            if (!isSOk ||  S<=0)
            {
                CallPrice = "Stock price must be a positive number";
                PutPrice = "Stock price must be a positive number";
                return;
            }

            double K;
            bool isKOk = double.TryParse(StrikePrice, out K);
            if (!isKOk || K <= 0)
            {
                CallPrice = "Strike price must be a positive number";
                PutPrice = "Strike price must be a positive number";
                return;
            }

            double t;
            bool istOk = double.TryParse(TimeToMaturity, out t);
            if (!istOk || t <= 0)
            {
                CallPrice = "Time to maturity price must be a positive number";
                PutPrice = "Time to maturity price must be a positive number";
                return;
            }

            double sigma;
            bool issigmaOk = double.TryParse(StandardDeviation, out sigma);
            if (!issigmaOk || sigma <= 0)
            {
                CallPrice = "Sigma must be a positive number";
                PutPrice = "Sigma must be a positive number";
                return;
            }

            double r;
            bool isrOk = double.TryParse(RiskFreeRate, out r);
            if (!isrOk)
            {
                CallPrice = "Sigma must be a number";
                PutPrice = "Sigma must be a number";
                return;
            }

            CallPrice = blackScholes.ComputeCallPrice(S, K,t,sigma,r).ToString();
            PutPrice = blackScholes.ComputePutPrice(S, K, t, sigma, r).ToString();
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}
