using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;    
using System.Configuration;         
using System.Data;
public partial class rowlog : System.Web.UI.Page
{
    SqlConnection connectionStringConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

    //connectionStringConnection.Open();
    //connectionStringConnection.Close();
   
    protected void Page_Load(object sender, EventArgs e)
    {   //Class contains: Checking if user is connected, Defining user Level, Displaying table of members, Just displaying some basic info for him.

        //Are you logged in?
        
        if (Session["id_user_session"] != null)
        {

            // checking user level
            int userlevel = 1; // setting default level

            SqlCommand UserLevelReader = new SqlCommand();
            UserLevelReader.CommandText = "SELECT id_user_level" + " FROM exam_user_table" + " WHERE id_user='" + Session["id_user_session"].ToString() + "'";
            UserLevelReader.CommandType = CommandType.Text;
            UserLevelReader.Connection = connectionStringConnection;
            connectionStringConnection.Open();
            SqlDataReader UserLevelValue = UserLevelReader.ExecuteReader();
            while (UserLevelValue.Read())
            {
                userlevel = UserLevelValue.GetInt32(0); // Converting raw material into int
            };

            UserLevelValue.Close();
            connectionStringConnection.Close();

            // displaying user Level 
            string statusText = "";

            if (userlevel == 1)
            {
                statusText = "Rower";
                membersTable.Visible = false; //hiding tables
                registerContainer.Visible = false; //and registration
            }
            else if (userlevel == 2)
            {
                statusText = "Moderator";
                memberinfo.Visible = false;
                registerContainer.Visible = false; // no registration, but table is visible
            }
            else if (userlevel == 3)
            {
                updatingDistance.Visible = false;
                memberinfo.Visible = false;
                statusText = "Admin"; // You can guess.
            }
            // nothing else for admin, due to information could be displayed to any other level. just to be sure, that there is no bugs and gaps.

            LevelLabel.Text = "Your status is - " + statusText + " (Level: " + userlevel.ToString() + ")"; //usable to check the gained values while testing

            // information panel for simple user:

            string lastRowedDistanceString;
            string lastRowedTimeString;
            string AllDistanceString;
            string registrationDateString;

            SqlCommand GettingDataForuserInfo = new SqlCommand();
            GettingDataForuserInfo.CommandText = "SELECT id_user_last_distance, id_user_last_update_time,id_user_all_distance,id_user_creation_date FROM exam_user_table WHERE id_user='" + Session["id_user_session"].ToString() + "'";
            GettingDataForuserInfo.CommandType = CommandType.Text;
            GettingDataForuserInfo.Connection = connectionStringConnection;
            connectionStringConnection.Open();
            SqlDataReader DataTableWithUserInfoValues = GettingDataForuserInfo.ExecuteReader();
            while (DataTableWithUserInfoValues.Read())
            {
                lastRowedDistanceString = (string)DataTableWithUserInfoValues["id_user_last_distance"].ToString();
                lastRowedTimeString = (string)DataTableWithUserInfoValues["id_user_last_update_time"].ToString();
                AllDistanceString = (string)DataTableWithUserInfoValues["id_user_all_distance"].ToString();
                registrationDateString = (string)DataTableWithUserInfoValues["id_user_creation_date"].ToString();
                lastRowedDistanceAndUpdateDate.Text = "Your last row distance was: " + lastRowedDistanceString + " Km, and the date was: " + lastRowedTimeString;
                AllDistance.Text = "Your distance since you have start rowing is: " + AllDistanceString + " Km.";
                registrationDate.Text = "You are rowing since  " + registrationDateString + " Good Job, keep it up!";

            };



            DataTableWithUserInfoValues.Close(); // Closing reader
            connectionStringConnection.Close(); // Closing connection



            


            SqlCommand GettingDataForTable = new SqlCommand();
                GettingDataForTable.CommandText = "SELECT * FROM exam_user_table";
                GettingDataForTable.CommandType = CommandType.Text;
                GettingDataForTable.Connection = connectionStringConnection;
                connectionStringConnection.Open();
                SqlDataReader DataTableWithValues = GettingDataForTable.ExecuteReader();
            //while (DataTableWithValues.Read())
            //{
                    // could use this, but it does somehow skip first row. "reader.Read() advances to the next item in the result set"
            //};

            if (DataTableWithValues.HasRows)
                    {
                        membersTable.DataSource = DataTableWithValues;
                        membersTable.DataBind();
                    }

            DataTableWithValues.Close(); // Closing reader
            connectionStringConnection.Close(); // Closing connection

            // A warm welcome and time

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm");

            string welcome;
              SqlCommand UserNameReader = new SqlCommand();
              UserNameReader.CommandText = "SELECT id_user_name " + "FROM exam_user_table " + "WHERE id_user='" + Session["id_user_session"].ToString() + "'";
              UserNameReader.CommandType = CommandType.Text;
              UserNameReader.Connection = connectionStringConnection;
              connectionStringConnection.Open();
              SqlDataReader UserNameValue = UserNameReader.ExecuteReader();
              while (UserNameValue.Read())
                {
                  welcome = (string)UserNameValue["id_user_name"];
                HelloLabel.Text = "Hey there, " + welcome + ", Present time is: " + sqlFormattedDate;
                }

            UserNameValue.Close();
            connectionStringConnection.Close();

        }
            // if session value is null a.k.a. user not logged in, he gets:
        else
        {
           
            infoContent.Visible = false; // it can be hidden programaticaly
            registerContainer.Visible = false;
            newPassContainer.Visible = false;
            memberinfo.Visible = false;
            LevelLabel.Style["display"] = "none"; // either editing css
            // we can also create one div wraping up all the stuff, but since we are using same elements and conditionally
            // display different info on them, it's better to do it like this. nevertheless, next time thinking about
            // doing as i said firstly. 
            HelloLabel.Text = "You have to log in first!";
            logOut.Text = "Go to main page";
        }
    }

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {   // Let's update our distance

        DateTime myDateTime = DateTime.Now;
        string sqlFormattedDateForTable = myDateTime.ToString("yyyy-MM-dd HH:mm");

        int TodayDistanceVar = 0; // setting default distance

        SqlCommand TodayDistanceReader = new SqlCommand();
        TodayDistanceReader.CommandText = "SELECT id_user_all_distance" + " FROM exam_user_table" + " WHERE id_user='" + Session["id_user_session"].ToString() + "'";
        TodayDistanceReader.CommandType = CommandType.Text;
        TodayDistanceReader.Connection = connectionStringConnection;
        connectionStringConnection.Open();
        SqlDataReader TodayDistanceValue = TodayDistanceReader.ExecuteReader();
        while (TodayDistanceValue.Read())
        {
            TodayDistanceVar = TodayDistanceValue.GetInt32(0);
        };

        TodayDistanceValue.Close();
        connectionStringConnection.Close();

                                                                 
        string commandText = "UPDATE exam_user_table " +
                     "SET id_user_last_distance=@lastDist, id_user_all_distance=@allDist, id_user_last_update_time=@updtTime WHERE id_user=@userID";
  
            SqlCommand command = new SqlCommand(commandText, connectionStringConnection);
            
            command.Parameters.AddWithValue("@lastDist", DistanceBox.Text);
            command.Parameters.AddWithValue("@userID", Session["id_user_session"].ToString());
            command.Parameters.AddWithValue("@allDist", (TodayDistanceVar + Int32.Parse(DistanceBox.Text)).ToString());
            command.Parameters.AddWithValue("@updtTime", sqlFormattedDateForTable);

            try
            {
                connectionStringConnection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
    
            }
            finally
            {
                connectionStringConnection.Close();
                Response.Redirect("rowlog.aspx");
            }
    }

    protected void newMemberBtn_Click(object sender, EventArgs e)
    {   // new member Registration system. visible and usable for admin only

        if (newMemberName.Text == null || newMemberLevel.Text == null || newMemberPass.Text == null)
        {
            newMemberBtn.Text = "Please fill all fields!";
        }

        else
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDateForTable = myDateTime.ToString("yyyy-MM-dd HH:mm");
            string registrationCommand = "INSERT INTO exam_user_table (id_user_name,id_user_level,id_user_creation_date,id_user_all_distance) VALUES (@userName, @userLevel, @userCreateDate,@defaultDistance)";

            SqlCommand userRegComand = new SqlCommand(registrationCommand, connectionStringConnection);
            userRegComand.Parameters.AddWithValue("@userName", newMemberName.Text);
            userRegComand.Parameters.AddWithValue("@userLevel", newMemberLevel.Text);
            userRegComand.Parameters.AddWithValue("@userCreateDate", sqlFormattedDateForTable.ToString());
            userRegComand.Parameters.AddWithValue("@defaultDistance", "0");

            try
            {
                connectionStringConnection.Open();
                userRegComand.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                connectionStringConnection.Close();
                newMemberBtn.Text = "Member Created!";
            }
        }

        // Getting Last user ID+1 from pass table
        int LastID = 0;

        SqlCommand GettingLastIDCommand = new SqlCommand();
        GettingLastIDCommand.CommandText = "SELECT MAX(fk_id_user) FROM exam_user_pass_table";
        GettingLastIDCommand.CommandType = CommandType.Text;
        GettingLastIDCommand.Connection = connectionStringConnection;
        connectionStringConnection.Open();
        SqlDataReader LastIDValue = GettingLastIDCommand.ExecuteReader();
        while (LastIDValue.Read())
        {
            LastID = LastIDValue.GetInt32(0) + 1;
        };
        LastIDValue.Close();
        connectionStringConnection.Close();
        // Better to use joints. Not the smartest choice. Yet, it works perfectly.
        
        useridlabel.Text = "New User ID:" + LastID.ToString();

        string RegistrationPasswordCommand = "INSERT INTO exam_user_pass_table (fk_id_user,id_user_pass) VALUES (@fkuserID, @userPass)";
        
        SqlCommand command = new SqlCommand(RegistrationPasswordCommand, connectionStringConnection);
        command.Parameters.AddWithValue("@fkuserID", LastID.ToString());
        command.Parameters.AddWithValue("@userPass", newMemberPass.Text);
        try
        {
            connectionStringConnection.Open();
            command.ExecuteNonQuery();
        }
        catch
        {

        }
        finally
        {
            connectionStringConnection.Close();
            Response.Redirect("rowlog.aspx");
        }

    }

    protected void newPassButton_Click(object sender, EventArgs e)
    { // changing Password                                              

        string commandText = "UPDATE exam_user_pass_table " + "SET id_user_pass=@newUserPass WHERE fk_id_user='" + Session["id_user_session"].ToString() + "'";

        SqlCommand command = new SqlCommand(commandText, connectionStringConnection);
        command.Parameters.AddWithValue("@newUserPass", newPassBox.Text);

        try
        {
            connectionStringConnection.Open();
            command.ExecuteNonQuery();
        }
        catch
        {

        }
        finally
        {
            connectionStringConnection.Close();
            newPassButton.Text ="Password changed!";
        }

    }

    // informational Stuff for a member 



    protected void logOut_Click(object sender, EventArgs e)
    {// Loging out 
        Session.Remove("id_user_session"); 
        Session.RemoveAll();                
        Response.Redirect("../index.html");
    }

    protected void membersTable_RowDataBound(object sender, GridViewRowEventArgs e)
    {// just to bound data in Table

    }
}
// SOLUTION BELONGS TO LIUTAURAS AND DEIVIDAS.GROUP 1. UCN 3'rd SEMESTER EXAM. 
