using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 
using System.IO;
//
namespace Project4
{
    public partial class Project4Form : Form
    {
        public Project4Form()
        {
            InitializeComponent();
        }


        private void ResetValues()
        {
            ChosenCollegeListBox.Items.Clear();
            FundingLabel.Text = string.Empty;
        }

        private void Project4Form_Load(object sender, EventArgs e)
        {
            DateTime currentTime;
            currentTime = DateTime.Now;
            DateLabel.Text = currentTime.ToShortDateString();
            TimeLabel.Text = currentTime.ToShortTimeString();
            string lineRead;
            string Description, College, Subject, CIPCCode;
            Int32 commaIndex;
            using (StreamReader readFile = new StreamReader("CIP_Code.txt"))
            {
                lineRead = readFile.ReadLine();
                commaIndex = lineRead.IndexOf(",");
                CollegeLabel.Text = lineRead.Substring(0, commaIndex);
                lineRead = lineRead.Substring(commaIndex + 1, lineRead.Length - commaIndex - 1);
                SubjectLabel.Text = lineRead.Substring(0, commaIndex);
                lineRead = lineRead.Substring(commaIndex + 1, lineRead.Length - commaIndex - 1);
                commaIndex = lineRead.IndexOf(",");
                CIPCCodeLabel.Text = lineRead.Substring(0, commaIndex);
                DescriptionLabel.Text = lineRead.Substring(commaIndex + 1, lineRead.Length - commaIndex - 1);

                while ((lineRead = readFile.ReadLine()) != null)
                {
                    commaIndex = lineRead.IndexOf(",");
                    College = lineRead.Substring(0, commaIndex);
                    lineRead = lineRead.Substring(commaIndex + 1, lineRead.Length - commaIndex - 1);
                    commaIndex = lineRead.IndexOf(",");
                    Subject = lineRead.Substring(0, commaIndex);
                    lineRead = lineRead.Substring(commaIndex + 1, lineRead.Length - commaIndex - 1);
                    commaIndex = lineRead.IndexOf(",");
                    CIPCCode = lineRead.Substring(0, commaIndex);
                    lineRead = lineRead.Substring(commaIndex + 1, lineRead.Length - commaIndex - 1);
                    Description = lineRead.Substring(0, lineRead.Length);
                    DescriptionListBox.Items.Add(Description);
                    CollegeListBox.Items.Add(College);
                    SubjectListBox.Items.Add(Subject);
                    CIPCCodeListBox.Items.Add(CIPCCode);
                }
            }
            DescriptionListBox.SelectedIndex = 0;
            ResetValues();
        }

        private void DescriptionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CollegeListBox.SelectedIndex = DescriptionListBox.SelectedIndex;
            SubjectListBox.SelectedIndex = DescriptionListBox.SelectedIndex;
            CIPCCodeListBox.SelectedIndex = DescriptionListBox.SelectedIndex;
        }

        private void CollegeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CollegeListBox.SelectedIndex = DescriptionListBox.SelectedIndex;
        }

        private void SubjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubjectListBox.SelectedIndex = DescriptionListBox.SelectedIndex;
        }

        private void CIPCCodeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CIPCCodeListBox.SelectedIndex = DescriptionListBox.SelectedIndex;
        }

        private void FundingButton_Click(object sender, EventArgs e)
        {
            string firstTwo;
            firstTwo = CIPCCodeListBox.SelectedItem.ToString().Substring(0,2);
            double code;
            switch (firstTwo)
            {
                case "09":
                case "23":
                case "27":
                case "38":
                case "42":
                case "43":
                case "45":
                case "54":
                case "90":
                    code = 113;
                    break;
                case "05":
                case "13":
                case "16":
                case "19":
                case "24":
                case "30":
                case "31":
                case "52":
                    code = 150;
                    break;
                case "01":
                case "03":
                case "04":
                case "11":
                case "15":
                case "25":
                case "26":
                case "40":
                case "44":
                case "50":
                case "51":
                    code = 197;
                    break;
                case "14":
                case "66":
                    code = 232;
                    break;
                default:
                    code = 0;
                    break;
            }
            FundingLabel.Text = code.ToString("C0");
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void DescriptionButton_Click(object sender, EventArgs e)
        {
            ChosenCollegeListBox.Items.Clear();
            string match;
            match = CollegeListBox.SelectedItem.ToString();
            Int32 counter;
            for ( counter = 0; counter < CollegeListBox.Items.Count; counter++)
            {
                DescriptionListBox.SelectedIndex = counter;
                if (match == CollegeListBox.SelectedItem.ToString())
                {
                    ChosenCollegeListBox.Items.Add(DescriptionListBox.SelectedItem.ToString());

                }
            }
            ChosenCollegeListBox.Sorted = true;
        }
    }
}
