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
    public partial class AddItem : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = .\SQLEXPRESS; Integrated Security = true; Initial Catalog = TreeViewDatabase;");
        public AddItem()
        {
            InitializeComponent();
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            SqlCommand commandGetTypes = new SqlCommand("select distinct type from objects", connection);
            SqlDataAdapter adapterGetTypes = new SqlDataAdapter(commandGetTypes);
            DataTable dataTypes = new DataTable();
            adapterGetTypes.Fill(dataTypes);

            for (int i = 0; i < dataTypes.Rows.Count; i++)
            {
                types.Items.Add(dataTypes.Rows[i][0].ToString());
            }

            SqlCommand commandGetLinks = new SqlCommand("select distinct linkname from links", connection);
            SqlDataAdapter adapterGetLinks = new SqlDataAdapter(commandGetLinks);
            DataTable dataLinks = new DataTable();
            adapterGetLinks.Fill(dataLinks);

            for (int i = 0; i < dataLinks.Rows.Count; i++)
            {
                links.Items.Add(dataLinks.Rows[i][0].ToString());
            }

            if (Properties.Settings.Default.edit)
            {
                Text = "Изменить";
                AddButton.Text = "Изменить";

                SqlCommand command = new SqlCommand("select * from objects o where o.id = "+Properties.Settings.Default.id+"", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);

                product.Text = data.Rows[0][2].ToString();
                types.Text = data.Rows[0][1].ToString();

                textBox1.Visible = false;
                label1.Visible = false;
                links.Visible = false;
                label4.Visible = false;
            }
            else
            {
                if (Properties.Settings.Default.path == null)
                {
                    textBox1.Visible = false;
                    label1.Visible = false;
                }
                else
                {
                    textBox1.Text = Properties.Settings.Default.path;
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.edit && types.SelectedIndex != -1 && product.Text.Length != 0)
            {
                SqlCommand commandGetID = new SqlCommand("update objects set type = '"+types.Text+"', product = '"+product.Text + "' where id = "+Properties.Settings.Default.id, connection);
                SqlDataAdapter adapterGetID = new SqlDataAdapter(commandGetID);
                DataTable dataGetID = new DataTable();
                adapterGetID.Fill(dataGetID);

                this.Close();
            }
            else
            {
                if (types.SelectedIndex != -1 && product.Text.Length != 0)
                {
                    SqlCommand commandGetID = new SqlCommand("if (select count(id) from objects)=0 select 1 else select max(id)+1 from objects", connection);
                    SqlDataAdapter adapterGetID = new SqlDataAdapter(commandGetID);
                    DataTable dataGetID = new DataTable();
                    adapterGetID.Fill(dataGetID);

                    SqlCommand commandAdd = new SqlCommand("insert into objects values(" + dataGetID.Rows[0][0].ToString() + ",'" + types.Text + "', '" + product.Text + "')", connection);
                    SqlDataAdapter adapterAdd = new SqlDataAdapter(commandAdd);
                    DataTable dataAdd = new DataTable();
                    adapterAdd.Fill(dataAdd);

                    if (textBox1.Text.Length != 0)
                    {
                        string[] getLast = textBox1.Text.Split('/');
                        string last = getLast[getLast.Length - 2];

                        SqlCommand commandGetIDParent = new SqlCommand("select id from objects where product = '" + last + "'", connection);
                        SqlDataAdapter adapterGetIDParent = new SqlDataAdapter(commandGetIDParent);
                        DataTable dataGetIDParent = new DataTable();
                        adapterGetIDParent.Fill(dataGetIDParent);

                        string idLast = dataGetIDParent.Rows[0][0].ToString();

                        SqlCommand commandAdd2 = new SqlCommand("insert into links values(" + idLast + "," + dataGetID.Rows[0][0].ToString() + ",'" + links.Text + "')", connection);
                        SqlDataAdapter adapterAdd2 = new SqlDataAdapter(commandAdd2);
                        DataTable dataAdd2 = new DataTable();
                        adapterAdd2.Fill(dataAdd2);
                    }
                    else
                    {
                        SqlCommand commandAdd2 = new SqlCommand("insert into links values(" + dataGetID.Rows[0][0].ToString() + ", null ,'" + links.Text + "')", connection);
                        SqlDataAdapter adapterAdd2 = new SqlDataAdapter(commandAdd2);
                        DataTable dataAdd2 = new DataTable();
                        adapterAdd2.Fill(dataAdd2);
                    }
                }

                this.Close();
            }
        }
    }
}
