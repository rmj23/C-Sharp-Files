using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project6
{
    public partial class Project6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DistinctCoursesButton_Click(object sender, EventArgs e)
        {
            DistinctCoursesListBox.Items.Clear();
            List<String> duplicateList = new List<String>();
            Int32 counter;
            for (counter=0; counter<CoursesListBox.Items.Count; ++counter)
            {
                CoursesListBox.SelectedIndex = counter;
                duplicateList.Add(CoursesListBox.SelectedValue.Substring(0, 7));
            }

            List <String> distinctList = new List <String>();
            distinctList = duplicateList.Distinct().ToList();
            foreach (String value in distinctList)
            {
                DistinctCoursesListBox.Items.Add(value);
            }
        }   
    }
}