using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    
    public partial class MainWindow : Window
    {
        enum EOperationState { None, Plus, Minus, Multiply, Divide };

        private string OutputNumber { get; set; } = "";
        private bool IsPositive { get; set; } = true;

        EOperationState _OperationState = EOperationState.None;
        private EOperationState OperationState 
        { 
            get => _OperationState; 
            set
            {
                _OperationState = value;
                LastNumber = OutputToDouble();

                Started = false;
                if (!IsPositive)
                    IsPositive = true;
            }
        }

        private bool Started { get; set; } = false;
        private double LastNumber { get; set; } = 0;
        private double Ans { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNumber(string num)
        {
            if (!Started)
            {
                OutputNumber = num;
                Started = true;
            }
            else
            {
                OutputNumber += num;
            }

            UpdateOutput();
        }

        private void InitOutput()
        {
            OutputNumber = "0";
            IsPositive = true;
            Started = false;

            UpdateOutput();
        }

        private void UpdateOutput()
        {
            if (IsPositive)
                CalculationOutput.Text = OutputNumber;
            else
                CalculationOutput.Text = "-" + OutputNumber;
        }

        private void SwitchSign()
        {
            if (Started)
            {
                IsPositive = IsPositive ? false : true;
                UpdateOutput();
            }
        }

        private double OutputToDouble()
        {
            return Convert.ToDouble(OutputNumber) * (IsPositive ? 1 : -1);
        }

        private void btnN0_Click(object sender, RoutedEventArgs e)
        {
            if (!(CalculationOutput.Text == "0"))
                AddNumber("0");
        }
        private void btnN1_Click(object sender, RoutedEventArgs e) => AddNumber("1");
        private void btnN2_Click(object sender, RoutedEventArgs e) => AddNumber("2");
        private void btnN3_Click(object sender, RoutedEventArgs e) => AddNumber("3");
        private void btnN4_Click(object sender, RoutedEventArgs e) => AddNumber("4");
        private void btnN5_Click(object sender, RoutedEventArgs e) => AddNumber("5");
        private void btnN6_Click(object sender, RoutedEventArgs e) => AddNumber("6");
        private void btnN7_Click(object sender, RoutedEventArgs e) => AddNumber("7");
        private void btnN8_Click(object sender, RoutedEventArgs e) => AddNumber("8");
        private void btnN9_Click(object sender, RoutedEventArgs e) => AddNumber("9");

        private void btnCE_Click(object sender, RoutedEventArgs e) => InitOutput();
        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            InitOutput();
            Ans = 0;
            LastNumber = 0;
            OperationState = EOperationState.None;
        }

        private void btnBS_Click(object sender, RoutedEventArgs e)
        {
            if (Started)
            {
                if (OutputNumber.Length == 1)
                    InitOutput();
                else
                    OutputNumber = OutputNumber.Remove(OutputNumber.Length - 1);

                UpdateOutput();
            }
        }

        private void btnAns_Click(object sender, RoutedEventArgs e)
        {
            OutputNumber = Convert.ToString(Ans);
            UpdateOutput();
        }

        private void btnPM_Click(object sender, RoutedEventArgs e) => SwitchSign();

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            OperationState = EOperationState.Multiply;
        }
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            OperationState = EOperationState.Plus;
        }
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            OperationState = EOperationState.Minus;
        }
        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            OperationState = EOperationState.Divide;
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            switch (OperationState)
            {
                case EOperationState.None:
                    Ans = OutputToDouble();
                    OutputNumber = Convert.ToString(Ans);
                    UpdateOutput();
                    break;
                case EOperationState.Plus:
                    Ans = LastNumber + OutputToDouble();
                    OutputNumber = Convert.ToString(Ans);
                    UpdateOutput();
                    break;
                case EOperationState.Minus:
                    Ans = LastNumber - OutputToDouble();
                    OutputNumber = Convert.ToString(Ans);
                    UpdateOutput();
                    break;
                case EOperationState.Multiply:
                    Ans = LastNumber * OutputToDouble();
                    OutputNumber = Convert.ToString(Ans);
                    UpdateOutput();
                    break;               
                case EOperationState.Divide:
                    double recent = OutputToDouble();
                    if (recent == 0)
                    {
                        CalculationOutput.Text = "Cannot divide by zero";
                    }
                    else
                    {
                        Ans = LastNumber / OutputToDouble();
                        OutputNumber = Convert.ToString(Ans);
                        UpdateOutput();
                    }
                    break;
            }

            OperationState = EOperationState.None;
            Started = false;
        }

    }
}
