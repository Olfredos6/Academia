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
    public partial class getAcademicRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack){
                //step 1
                string conString = @"Data Source=.\SQLEXPRESS; Initial Catalog = StudentData; Integrated Security = True";

                //step 2
                SqlConnection conObject = new SqlConnection(conString);

                //step 3
                string qrySel = "select * from MySubject";

                //Step 4
                SqlCommand cmdSelObject = new SqlCommand(qrySel, conObject);

                //Step 5
                //cmdSelObject.Parameters.Add("@SubjectName", SqlDbType.Char).Value = subjectNameBox.Text;
                //cmdSelObject.Parameters.Add("@FinalMark", SqlDbType.Int).Value = Convert.ToInt16(markBox.Text);

                //Step 6
                conObject.Open();

                //Step 7
                SqlDataReader readSubject = cmdSelObject.ExecuteReader();

                //Displaying
                string stat;
                int count = 0;
                int mark = 0, total = 0;
                double average = 0;
                Response.Write("<table border='0' cellspacing='2' cellpadding='3' style='text-align:left; background-color:white'><th>ID</th><th>Subject Name</th><th>Final Mark</th><th>Qualification</th>");
                int numberOfSubject = 0; 
                while(readSubject.Read()){
                    numberOfSubject++;
                    Response.Write("<tr style='text-align:left; background-color:grey'>");
                    count++;
                    mark = Convert.ToInt16(readSubject["FinalMark"].ToString());
                    if (mark < 50) { stat = "<p style='color:red'>Fail<p>"; }
                    else if (Convert.ToInt16(readSubject["FinalMark"].ToString()) > 75) { stat = "<p style='color:green'>Pass With Distinction<p>"; }
                    else { stat = "<p style='color:white'>Pass<p>"; }
                    Response.Write("<td>" + readSubject["ID"].ToString() + "</td>");
                    Response.Write("<td>" + readSubject["SubjectName"].ToString()  + "</td>");
                    Response.Write("<td>" + readSubject["FinalMark"].ToString() + "</td>");
                    Response.Write("<td>" + stat + "</td>");
                    Response.Write("</tr>");
                    total += mark;
                    //Response.Write(count + " " + readSubject["SubjectName"].ToString() + " " + readSubject["FinalMark"].ToString() + " " + stat);
                }
                Response.Write("</table>");
                average = total / count;
                Response.Write("<hr/>");
                Response.Write("Total Average = " + average + "<br/>");

                double howFarToBTech = 0, howFarToCumLaude = 0;
                howFarToBTech = 65 - average;
                howFarToCumLaude = 75 - average;

                if (howFarToBTech > 0)
                {
                    Response.Write("<p style='color:red'>Work Hard Man, you\'re missing " + howFarToBTech + "% to be accpeted in BTech</p>");
                }
                else {
                    Response.Write("<p style='color:green'>your BTech is on its way</p>");
                }

                if (howFarToCumLaude > 0)
                {
                    Response.Write("<p style='color:red'>Work Hard Man, you\'re missing " + howFarToCumLaude + "% to achieve a niece cum laude</p>");
                }
                else {
                    Response.Write("<p style='color:green'>Holala!!! A cum Laude is awaiting</p>");
                }
                //Step 8

                conObject.Close();
                Response.Write("Subject done : " + numberOfSubject);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string conString = @"Data Source=.\sqlexpress; Initial Catalog = StudentData; Integrated Security = True";

            SqlConnection conObject = new SqlConnection(conString);

            string selectQry = "select count(*) from MySubject where (ID=@ID) and (SubjectName=@SubjectName)";

            SqlCommand cmdObject = new SqlCommand(selectQry, conObject);

            cmdObject.Parameters.Add("@SubjectName", SqlDbType.Char).Value = subjectBox.Text;
            cmdObject.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(IDBox.Text);

            conObject.Open();

            int count = Convert.ToInt16(cmdObject.ExecuteScalar());
            if (count != 0)
            {
                
                SubjectNameLabel.Visible = false;
                subjectBox.Visible = false;
                IDLabel.Visible = false;
                IDBox.Visible = false;
                Label2.Visible = true;
                newMarkBox.Visible = true;
                Button2.Visible = true;
                Button1.Visible = false;
            }
            else {
                errorLabel.Visible = true;
            }
            conObject.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source=.\sqlexpress; Initial Catalog = StudentData; Integrated Security = True";

            SqlConnection conObject = new SqlConnection(conString);

            string updateQry = "update MySubject set FinalMark=@FinalMark where(ID=@ID)";

            SqlCommand cmdObject2 = new SqlCommand(updateQry, conObject);

            cmdObject2.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(IDBox.Text);
            cmdObject2.Parameters.Add("@FinalMark", SqlDbType.Int).Value = newMarkBox.Text;

            conObject.Open();

            cmdObject2.ExecuteNonQuery();

            conObject.Close();
            Response.Redirect("getAcademicRecord.aspx");
        }
    }
}