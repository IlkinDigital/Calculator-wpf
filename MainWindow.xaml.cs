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

        private string Number { get; set; } = "";
        private bool IsPositive { get; set; } = true;
        private EOperationState OperationState { get; set; }

        private bool Started { get; set; } = false;
        private int Ans { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNumber(string num)
        {
            if (!Started)
            {
                Number = num;
                Started = true;
            }
            else
            {
                Number += num;
            }

            UpdateOutput();
        }

        private void InitOutput()
        {
            Number = "0";
            IsPositive = true;
            Started = false;

            UpdateOutput();
        }

        private void UpdateOutput()
        {
            if (IsPositive)
                CalculationOutput.Text = Number;
            else
                CalculationOutput.Text = "-" + Number;
        }

        private void SwitchSign()
        {
            if (Started)
            {
                IsPositive = IsPositive ? false : true;
                UpdateOutput();
            }
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

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            InitOutput();
            Ans = 0;
        }
        private void btnC_Click(object sender, RoutedEventArgs e) => InitOutput();

        private void btnBS_Click(object sender, RoutedEventArgs e)
        {
            if (Started)
            {
                if (Number.Length == 1)
                    InitOutput();
                else
                    Number = Number.Remove(Number.Length - 1);

                UpdateOutput();
            }
        }

        private void btnPM_Click(object sender, RoutedEventArgs e) => SwitchSign();

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            OperationState = EOperationState.Divide;
            Started = false;
        }
    }
}
