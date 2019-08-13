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
using System.Configuration;

namespace CasoProp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Kobu"].ConnectionString);

        private void dgPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ListaPedidos()
        {
            using (SqlDataAdapter df = new SqlDataAdapter("Usp_ListaPedidos_Neptuno", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                df.SelectCommand.Parameters.AddWithValue("@Name", txtName.Text);
                using (DataSet Da = new DataSet())
                {
                    df.Fill(Da, "Pedidos");
                    dgPedidos.DataSource = Da.Tables["Pedidos"];
                    lblTotal.Text = Da.Tables["Pedidos"].Rows.Count.ToString();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaPedidos();
        }
    }
}
