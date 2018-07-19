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

namespace TreeViewApplication
{
    public partial class DeleteForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = .\SQLEXPRESS; Integrated Security = true; Initial Catalog = TreeViewDatabase;");
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("delete from links where idparent = "+Properties.Settings.Default.id, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);

            SqlCommand commandUpd = new SqlCommand("update links set idchild = null where idchild = " + Properties.Settings.Default.id, connection);
            SqlDataAdapter adapterUpd = new SqlDataAdapter(commandUpd);
            DataTable dataUpd = new DataTable();
            adapterUpd.Fill(dataUpd);

            this.Close();
        }
    }
}
