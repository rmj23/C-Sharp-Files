using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoralesExtraCredit
{
    public partial class ExtraCredit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ShowAdviseesButton_Click(object sender, EventArgs e)
        {
            AdviseesListBox.Items.Clear();
            if (DistinctAdvisorListBox.SelectedIndex == -1)
            {
                AdviseesListBox.Items.Add("No Advisor Selected");
            }
            else
            {
                Int32 counter;
                    for (counter=0;counter<BusinessMajorsGridView.Rows.Count;++counter)
                {
                    if (DistinctAdvisorListBox.SelectedValue == BusinessMajorsGridView.Rows[counter].Cells[4].Text)
                    {
                        AdviseesListBox.Items.Add(BusinessMajorsGridView.Rows[counter].Cells[0].Text);
                    }
                }
            }

        }
    }
}