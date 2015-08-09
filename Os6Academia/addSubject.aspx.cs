using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Os6Academia
{
    public partial class addSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //step 1
            string conString = @"Data Source=.\SQLEXPRESS; Initial Catalog = StudentData; Integrated Security = True";

            //step 2
            SqlConnection conObject = new SqlConnection(conString);

            //step 3
            string qryInsert = "insert into MySubject values(@SubjectName, @FinalMark)";

            //Step 4
            SqlCommand cmdInsertObject = new SqlCommand(qryInsert, conObject);

            //Step 5
            cmdInsertObject.Parameters.Add("@SubjectName", SqlDbType.Char).Value = subjectNameBox.Text;
            cmdInsertObject.Parameters.Add("@FinalMark", SqlDbType.Int).Value = Convert.ToInt16(markBox.Text);

            //Step 6
            conObject.Open();

            //Step 7
            cmdInsertObject.ExecuteNonQuery();

            //Step 8
            conObject.Close();

            subjectNameBox.Text = "";
            markBox.Text = "";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.html");
        }
    }
}