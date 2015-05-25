using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiningManagementSystem.com.infy.presentation.UI
{
    public partial class PicturalRepresentationUI : Form
    {
        public PicturalRepresentationUI()
        {
            InitializeComponent();
        }

        private void PicturalRepresentation_Load(object sender, EventArgs e)
        {
            fillChart();

        }

        private void fillChart()
        {
            SqlConnection con = new SqlConnection("Data Source=RONOKPC;Initial Catalog=DiningManagementSystem;Integrated Security=true;");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select memberId,noOfMeals from mealEntryTable", con);
            adapt.Fill(ds);
            chart1.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series
            chart1.Series["noOfMeals"].XValueMember = "memberId";
            //set the member columns of the chart data source used to data bind to the X-values of the series
            chart1.Series["noOfMeals"].YValueMembers = "noOfMeals";
            chart1.Titles.Add("Meal Entry Chart");
            con.Close();

        }
    }
}
