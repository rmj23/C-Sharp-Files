using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class Project3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MonthListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DayListBox.Items.Clear();
            Int32 maxDays;
            switch ( MonthListBox.SelectedIndex )
            {
                case 0:
                case 2:
                case 4:
                case 6:
                case 7:
                case 9:
                case 11:
                    maxDays = 31;
                    break;
                case 3:
                case 5:
                case 8:
                case 20:
                    maxDays = 30;
                    break;
                case 1:
                    maxDays = 29;
                    break;
                default:
                    maxDays = 0;
                    break;
            }
            Int32 counter;
            for (counter = 1; counter <= maxDays; ++counter)
            {
                DayListBox.Items.Add(counter.ToString());
            }
            DayListBox.SelectedIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime currentDate;
            currentDate = DateTime.Now;
            DateLabel.Text = currentDate.ToShortDateString();

            DateTime currentTime;
            currentTime = DateTime.Now;
            TimeLabel.Text = currentTime.ToShortTimeString();

            OutputLabel.Text = string.Empty;

            if (FirstNameTextBox.Text == string.Empty)
            {
                OutputLabel.Text = "Must enter a first name";
                FirstNameTextBox.Focus();
                return;
            }

            if (LastNameTextBox.Text == string.Empty)
            {
                OutputLabel.Text = "Must enter a last name";
                LastNameTextBox.Focus();
                return;
            }

            if (AreaCodeTextBox.Text == string.Empty)
            {
                OutputLabel.Text = "Must enter an area code";
                AreaCodeTextBox.Focus();
                return;
            }

            if (AreaCodeTextBox.Text.Length < 3)
            {
                OutputLabel.Text = "Area code must be 3 digits";
                AreaCodeTextBox.Text = string.Empty;
                AreaCodeTextBox.Focus();
                return;
            }

            Int32 AreaCodeEnterednumber;
            if (!Int32.TryParse(AreaCodeTextBox.Text, out AreaCodeEnterednumber))
            {
                OutputLabel.Text = "Area code must be 3 digits";
                AreaCodeTextBox.Text = string.Empty;
                return;
            }

            if (ExchangeTextBox.Text == string.Empty)
            {
                OutputLabel.Text = "Must enter an exchange";
                ExchangeTextBox.Focus();
                return;
            }

            if (ExchangeTextBox.Text.Length < 3)
            {
                OutputLabel.Text = "Exchange must be 3 digits";
                ExchangeTextBox.Text = string.Empty;
                ExchangeTextBox.Focus();
                return;
            }

            Int32 ExchangeEnterednumber;
            if (!Int32.TryParse(ExchangeTextBox.Text, out ExchangeEnterednumber))
            {
                OutputLabel.Text = "Exchange must be 3 digits";
                ExchangeTextBox.Text = string.Empty;
                ExchangeTextBox.Focus();
                return;
            }

            if (NumberTextBox.Text == string.Empty)
            {
                OutputLabel.Text = "Must enter number";
                NumberTextBox.Focus();
                return;
            }

            if (NumberTextBox.Text.Length < 4)
            {
                OutputLabel.Text = "Number must be 4 digits";
                NumberTextBox.Text = string.Empty;
                NumberTextBox.Focus();
                return;
            }

            Int32 NumberEnterednumber;
            if (!Int32.TryParse(NumberTextBox.Text, out NumberEnterednumber))
            {
                OutputLabel.Text = "Number must be 4 digits";
                NumberTextBox.Text = string.Empty;
                NumberTextBox.Focus();
                return;
            }

            if (EmailTextBox.Text.Length < 5)
            {
                OutputLabel.Text = "Must be at least 5 characters";
                return;
            }

            if (!EmailTextBox.Text.Contains("@"))
            {
                OutputLabel.Text = "Must contain @";
                return;
            }

            if (EmailTextBox.Text.Substring(0,1) == "@" || EmailTextBox.Text.Substring(EmailTextBox.Text.Length - 2, 1) == "@" || EmailTextBox.Text.Substring(EmailTextBox.Text.Length - 1, 1) == "@")
            {
                OutputLabel.Text = "@ Character may not be the 1st character nor one of the last 2";
                return;
            }

            if (EmailTextBox.Text.Substring(2,1) == "." || EmailTextBox.Text.Substring(EmailTextBox.Text.Length - 1, 1) == ".")
            {

            }
        }
    }
}