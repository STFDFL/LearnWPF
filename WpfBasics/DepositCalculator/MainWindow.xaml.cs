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

namespace DepositCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float _value = 0;
        private float _funds = 0;
        private float _weeklySavings = 0;
        private float _depositPercentage = 0;
        private bool _firstH = false;
        private float FHOG = 10000;

        private float _upfrontCost;
        private float _depositRequired;
        private float _weeksToGoal;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateDepositAndGoal(object sender, RoutedEventArgs e)
        {
            try
            {
                _value = float.Parse(this.PropertyValueBox.Text);
                _funds = float.Parse(this.SavedFundsBox.Text);
                _weeklySavings = float.Parse(this.SavingsPerWeekBox.Text);

                CalculateUpfrontCost(_value);

                _depositRequired = (_value / 100) * _depositPercentage;
                _weeksToGoal = (_upfrontCost + _depositRequired - _funds) / _weeklySavings;

                this.UpfrontCostBox.Text = _upfrontCost.ToString();
                this.DepositRequiredBox.Text = _depositRequired.ToString();
                this.WeeksToGoalBox.Text = _weeksToGoal.ToString();
            }
            catch
            {

            }
        }

        private float CalculateUpfrontCost(float homeValue)
        {
            if(_firstH)
            {
                _upfrontCost = (homeValue / 100) * 4;
            }
            else
            {
                _upfrontCost = (homeValue / 100) * 9;
            }
            return _upfrontCost;
        }

        private void FHCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            _firstH = true;
        }

        private void FHCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            _firstH = false;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBDeposit.SelectedIndex == 0)
                _depositPercentage = 5;
            if (CBDeposit.SelectedIndex == 1)
                _depositPercentage = 10;
            if (CBDeposit.SelectedIndex == 2)
                _depositPercentage = 15;
            if (CBDeposit.SelectedIndex == 3)
                _depositPercentage = 20;
        }

        private void FHOGButton_Click(object sender, RoutedEventArgs e)
        {
            fhogWindow p = new fhogWindow();
            p.Show();
        }
    }
}
