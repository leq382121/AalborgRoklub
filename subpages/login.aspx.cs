using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;    // SQL Query related classes - such as SqlConnection, SqlCommand
using System.Configuration; // ConfigurationManager class - to access information saved in the web.config file         
using System.Data;  // namespace for the CommandType enumerator  

public partial class _Default : System.Web.UI.Page
{

    SqlConnection connectionStringConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e){}

    protected void loginbtn_Click(object sender, EventArgs e)
    {
        SqlCommand nameChecktoID = new SqlCommand();
        nameChecktoID.CommandType = CommandType.Text;
        nameChecktoID.CommandText = "SELECT id_user " + "FROM exam_user_table " + "WHERE id_user_name ='" + usernameBox.Text + "'";
        nameChecktoID.Connection = connectionStringConnection;
        connectionStringConnection.Open();  

        int var_id_user = -1;
        bool passValidationResult = false;

        SqlDataReader IDReader = nameChecktoID.ExecuteReader(); // getting back table and reads row by row.
        while (IDReader.Read())
        {
            var_id_user = (Int32)IDReader["id_user"];
        };

        IDReader.Close();

        if (var_id_user > 0)
        {
            SqlCommand PassBoxReader = new SqlCommand();
            PassBoxReader.CommandText = "SELECT id_user_pass " + "FROM exam_user_pass_table " + "WHERE fk_id_user ='" + var_id_user.ToString() + "'";
            PassBoxReader.CommandType = CommandType.Text;
            PassBoxReader.Connection = connectionStringConnection;

            SqlDataReader passBoxValidator = PassBoxReader.ExecuteReader();
            while (passBoxValidator.Read())
            {
                if (passBoxValidator["id_user_pass"].ToString() == passwordBox.Text)
                {
                    passValidationResult = true;
                }
            };
            passBoxValidator.Close();
        }

        connectionStringConnection.Close();

        if (passValidationResult == true)
        {
            Session["id_user_session"] = var_id_user; // use session and it's name. always!
            Response.Redirect("rowlog.aspx");
        }
        else
        {
            infoLabel.InnerText = "Unlucky to find you in database :( Try again!";
        }
    }


    // used only to run the code.
    protected void usernameBox_TextChanged(object sender, EventArgs e)
    {

    }

    protected void passwordBox_TextChanged(object sender, EventArgs e)
    {

    }
}

// SOLUTION BELONGS TO LIUTAURAS AND DEIVIDAS.GROUP 1. UCN 3'rd SEMESTER EXAM. 