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
using System.Text.RegularExpressions;

namespace Tema2_CalculadoraBasica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sign1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void operandoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String text = operandoTextBox.Text;
            Regex operandoReg = new Regex("^[*+/-]$");


            if (operandoReg.Match(text).Success)
            {
                calcularButton.IsEnabled = true;
                sign1 = text;
            }             
            else
                calcularButton.IsEnabled = false;


        }

        private void calcularButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float op1 = float.Parse(operador1TextBox.Text);
                float op2 = float.Parse(operador2TextBox.Text);
                switch (sign1)
                {
                    case "*":
                        resultadoTexBox.Text = $"{op1 * op2}";
                        break;
                    case "+":
                        resultadoTexBox.Text = $"{op1 + op2}";
                        break;
                    case "-":
                        resultadoTexBox.Text = $"{op1 - op2}";
                        break;
                    case "/":
                        resultadoTexBox.Text = $"{op1 / op2}";
                        break;

                    default:
                        resultadoTexBox.Text = "";
                        break;
                }
            } catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            resultadoTexBox.Text = "";
            operador1TextBox.Text = "";
            operador2TextBox.Text = "";
            operandoTextBox.Text = "";
            
        }
    }
}
