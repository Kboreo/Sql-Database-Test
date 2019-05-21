using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    //Add to use SQL Database functionality

namespace Local_Database_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True"); //Create a new connection to the SQL Database
        SqlCommand cmd; //Sql Command
        SqlDataReader dr;   //Sql Data Reader
        
        private void getFirstName()
        {
            //fetch data from the Database
            //con.Open(); //Open a connection to the Database
            //String syntax = "SELECT firstName FROM Students where Std_Id=2"; //Syntax used in the Database
            //cmd = new SqlCommand(syntax, con);  //New sql command
            //dr = cmd.ExecuteReader();   //Takes Temp values from the database
            //dr.Read();  //Reads the data from the database
            //MessageBox.Show("" + dr[0].ToString());

            string stuID = textBox1.Text;   //Gets text from user input (textBox1)
            //fetch data from the Database
            con.Open(); //Open a connection to the Database
            String syntaxTemplate = "SELECT firstName FROM Students where Std_Id={0}"; //Syntax used in the Database
            String syntax = string.Format(syntaxTemplate, stuID);
            cmd = new SqlCommand(syntax, con);  //New sql command
            dr = cmd.ExecuteReader();   //Takes Temp values from the database
            dr.Read();  //Reads the data from the database
            firstNameTextBox.Text = "" + dr[0].ToString();  //Display First Name in First name TextBox
            con.Close();    //Close Connection to Database
        }

        private void getLastName()
        {
            string stuID = textBox1.Text;   //Gets text from user input (textBox1)
            //fetch data from the Database
            con.Open(); //Open a connection to the Database
            String syntaxTemplate = "SELECT lastName FROM Students where Std_Id={0}"; //Syntax used in the Database
            String syntax = string.Format(syntaxTemplate, stuID);
            cmd = new SqlCommand(syntax, con);  //New sql command
            dr = cmd.ExecuteReader();   //Takes Temp values from the database
            dr.Read();  //Reads the data from the database
            lastNameTextBox.Text = "" + dr[0].ToString();  //Display First Name in First name TextBox
            con.Close();    //Close Connection to Database
        }

        private void getContactNumber()
        {
            string stuID = textBox1.Text;   //Gets text from user input (textBox1)
            //fetch data from the Database
            
            con.Open(); //Open a connection to the Database
            String syntaxTemplate = "SELECT contact FROM Students where Std_Id={0}"; //Syntax used in the Database
            String syntax = string.Format(syntaxTemplate, stuID);
            cmd = new SqlCommand(syntax, con);  //New sql command
            con.Close(); // Close the connection
            dr = cmd.ExecuteReader();   //Takes Temp values from the database
            dr.Read();  //Reads the data from the database            
            contactTextBox.Text = "" + dr[0].ToString();  //Display First Name in First name TextBox
            con.Close();    //Close Connection to Database

            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            getFirstName(); //Invoke getFirstName Function
            getLastName();  //Invoke getLastName Function
            getContactNumber(); //Invoke getContactNumber Function 
        }
    }
}
