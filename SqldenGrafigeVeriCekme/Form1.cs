using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqldenGrafigeVeriCekme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // This opreration connection to mssql database
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-T2GKN5C\SQLEXPRESS;Initial Catalog=Dbo_FilmArsiv;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            
            SqlCommand command = new SqlCommand("Select FilmAd,FilmPaun from Tbl_Filmler", con);

            SqlDataReader read = command.ExecuteReader();
            
            while (read.Read())
            {
                chart1.Series["Filmler"].Points.AddXY(read[0].ToString(), read[1]);
            }

            con.Close();
        }
    }
}
