using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InitialDesign
{
    public partial class ss : Form
    {
       
        public ss()
        {
            InitializeComponent();
            AddFundsForm.Hide();
            SettingsPannel.Hide();
            PayPanel.Hide();
            WithdrawFundsForm.Hide();
        }

        // Loads needed values
        private void ss_Load(object sender, EventArgs e)
        {
            AddFunds.Enabled = false;
            WithdrawFunds.Enabled = false;
            SortCode.MaxLength = 6;
            AccountNumber.MaxLength = 8;
            CardNumber.MaxLength = 16;
            ExpiryDateYear.MaxLength = 4;
            ExpiryDateMonth.MaxLength = 2;
            CVV.MaxLength = 3;
        }

        //Makes Text box only accept Alphabetic values
        private void AlphabeticValuesOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        // Makes Text box only accept Numeric values
        private void NumericValuesOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        // Check if all inputs are valid
        private void CheckAllValid_MouseMove(object sender, MouseEventArgs e)
        {
            int AddFundsAmount = int.Parse(AmoutToAdd.Text);
            int WithdrawAmount = int.Parse(AmountToWithdraw.Text);
            int TotalBalance = int.Parse(CurrentBalance.Text);

            if (ExpiryDateMonth.TextLength == 2 && ExpiryDateYear.TextLength == 4 && CVV.TextLength == 3 && FirstName.TextLength > 0 && LastName.TextLength > 0 && AddFundsAmount > 0)
            {
                AddFunds.Enabled = true;
            }
            else
            {
                AddFunds.Enabled = false;
            }

            if (FirstName_Withdraw.TextLength > 0 && LastName_Withdraw.TextLength > 0 && SortCode.TextLength == 6 && AccountNumber.TextLength == 8 && WithdrawAmount > 0 && WithdrawAmount <= TotalBalance)
            {
                WithdrawFunds.Enabled = true;
            }
            else
            {
                WithdrawFunds.Enabled = false;
            }


        }

        // Saves all the settings the user has selected
        private void SaveSettings_Click(object sender, EventArgs e)
        {
            int AmountA = int.Parse(MonthlyIncome.Text);
            int AmountB = int.Parse(StudentFinanceIncome.Text);
            int AmountC = int.Parse(MonthlyExpenses.Text);
            int AmountD = int.Parse(CurrentBalance.Text);
            int Total = (((AmountB / 3) + AmountA + AmountD) - AmountC) / 30;
            if (Total < 0) 
            {
                MessageBox.Show("Error: It seems like you dont have the funds to sustain your bills");
            }
            else
            {
                DailyBalance.Text = Total.ToString();
            }

        }

        // Adding Funds to wallet
        private void AddFundsButton_Click(object sender, EventArgs e)
        {
            int AmountA = int.Parse(MonthlyIncome.Text);
            int AmountB = int.Parse(StudentFinanceIncome.Text);
            int AmountC = int.Parse(MonthlyExpenses.Text);
            int AmountD = int.Parse(AmoutToAdd.Text);
            int AmountE = int.Parse(CurrentBalance.Text);
            int Total = AmountD + AmountE;
            CurrentBalance.Text = Total.ToString();
            int DailySpend = (((AmountB / 3) + AmountA + Total) - AmountC) / 30;
            DailyBalance.Text = DailySpend.ToString();
        }

        // Withdraw Funds from wallet
        private void WithdrawFundsButton_Click(object sender, EventArgs e)
        {
            int AmountA = int.Parse(MonthlyIncome.Text);
            int AmountB = int.Parse(StudentFinanceIncome.Text);
            int AmountC = int.Parse(MonthlyExpenses.Text);
            int AmountD = int.Parse(AmountToWithdraw.Text);
            int AmountE = int.Parse(CurrentBalance.Text);
            int Total = AmountE - AmountD;
            if (Total < 0)
            {
                
            }
            else
            {
                CurrentBalance.Text = Total.ToString();
                int DailySpend = (((AmountB / 3) + AmountA + Total) - AmountC) / 30;
                DailyBalance.Text = DailySpend.ToString();
            }


        }

        // Navigates to payment panel
        private void PayPanelButton_Click(object sender, EventArgs e)
        {
            PayPanel.Show();
            HomePanel.Hide();
            WithdrawFundsForm.Hide();
            AddFundsForm.Hide();
            BalancePanel.Hide();
            SettingsPannel.Hide();
        }

        // Navigates to Withdraw panel
        private void WithdrawPanelButton_Click(object sender, EventArgs e)
        {
            HomePanel.Hide();
            BalancePanel.Show();
            WithdrawFundsForm.Show();
            AddFundsForm.Hide();
            PayPanel.Hide();
            SettingsPannel.Hide();
        }

        // Navigates to Home panel
        private void HomePanelButton_Click(object sender, EventArgs e)
        {
            HomePanel.Show();
            BalancePanel.Show();
            WithdrawFundsForm.Hide();
            AddFundsForm.Hide();
            SettingsPannel.Hide();
            PayPanel.Hide();
        }

        // Navigates to Add funds panel
        private void AddFundsPanelButton_Click(object sender, EventArgs e)
        {
            HomePanel.Hide();
            BalancePanel.Show();
            AddFundsForm.Show();
            PayPanel.Hide();
            WithdrawFundsForm.Hide();
            SettingsPannel.Hide();
        }

        // Navigates to Settings panel
        private void SettingsPanelButton_Click(object sender, EventArgs e)
        {
            SettingsPannel.Show();
            HomePanel.Hide();
            BalancePanel.Hide();
            AddFundsForm.Hide();
            WithdrawFundsForm.Hide();
            PayPanel.Hide();
        }


        private void label37_Click(object sender, EventArgs e)
        {

        }
    }
}
