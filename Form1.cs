using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TreeViewApplication
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = .\SQLEXPRESS; Integrated Security = true; Initial Catalog = TreeViewDatabase;");
        Label[] labels = new Label[100];
        TextBox[] textBoxes = new TextBox[100];
        int attributeCount = 0;
        string idNow = null;
        string productNow = null;
        TextBox nameID;
        TextBox valueID;
        int senderTB;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetTree();
        }

        public void GetTree()
        {
            treeViewData.Nodes.Clear();

            SqlCommand commandGetCatalogs = new SqlCommand("select distinct idparent from links", connection);
            SqlDataAdapter adapterGetCatalogs = new SqlDataAdapter(commandGetCatalogs);
            DataTable dataCatalogs = new DataTable();
            adapterGetCatalogs.Fill(dataCatalogs);

            SqlCommand commandGetLinks = new SqlCommand("select idchild, idparent from links", connection);
            SqlDataAdapter adapterGetLinks = new SqlDataAdapter(commandGetLinks);
            DataTable dataLinks = new DataTable();
            adapterGetLinks.Fill(dataLinks);

            for (int i = 0; i < dataCatalogs.Rows.Count; i++)
            {
                bool isChild = false;

                for (int j = 0; j < dataLinks.Rows.Count; j++)
                {
                    if (dataCatalogs.Rows[i][0].ToString() == dataLinks.Rows[j][0].ToString())
                    {
                        isChild = true;
                    }
                }
                if (!isChild)
                {
                    SqlCommand commandGetObjects = new SqlCommand("select * from objects where id = " + dataCatalogs.Rows[i][0].ToString(), connection);
                    SqlDataAdapter adapterGetObjects = new SqlDataAdapter(commandGetObjects);
                    DataTable dataObjects = new DataTable();
                    adapterGetObjects.Fill(dataObjects);

                    TreeNode node = new TreeNode();
                    node.Text = dataObjects.Rows[0][2].ToString();
                    treeViewData.Nodes.Add(node);

                    for (int k = 0; k < dataLinks.Rows.Count; k++)
                    {
                        try
                        {
                            if (dataLinks.Rows[k][1].ToString() == dataObjects.Rows[0][0].ToString())
                            {
                                SqlCommand commandGetChildObjects = new SqlCommand("select * from objects where id = '" + dataLinks.Rows[k][0].ToString() + "'", connection);
                                SqlDataAdapter adapterGetChildObjects = new SqlDataAdapter(commandGetChildObjects);
                                DataTable dataChildObjects = new DataTable();
                                adapterGetChildObjects.Fill(dataChildObjects);

                                TreeNode childNode = new TreeNode();
                                childNode.Text = dataChildObjects.Rows[0][2].ToString();
                                node.Nodes.Add(childNode);

                                DataTable Child = GetChild(dataLinks.Rows[k][0].ToString());

                                if (Child.Rows[0][0].ToString() != "nochilds")
                                {
                                    for (int l = 0; l < Child.Rows.Count; l++)
                                    {
                                        SqlCommand commandGetName = new SqlCommand("select product from objects where id = " + Child.Rows[l][0].ToString(), connection);
                                        SqlDataAdapter adapterGetName = new SqlDataAdapter(commandGetName);
                                        DataTable dataName = new DataTable();
                                        adapterGetName.Fill(dataName);

                                        childNode.Nodes.Add(dataName.Rows[0][0].ToString());
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        public DataTable GetChild(string Parent)
        {
            SqlCommand commandGetCO = new SqlCommand("if (select count(idchild) from links where idparent = " + Parent + ")>0 select idchild from links where idparent = " + Parent + " else select 'nochilds'", connection);
            SqlDataAdapter adapterGetCO = new SqlDataAdapter(commandGetCO);
            DataTable dataCO = new DataTable();
            adapterGetCO.Fill(dataCO);

            return dataCO;
        }

        public DataTable GetAttributes(string product)
        {
            SqlCommand commandGetCO = new SqlCommand("select a.name, a.value, a.id from attributes a, objects o where o.id = a.id and o.product = '"+ product+"'", connection);
            SqlDataAdapter adapterGetCO = new SqlDataAdapter(commandGetCO);
            DataTable dataCO = new DataTable();
            adapterGetCO.Fill(dataCO);

            return dataCO;
        }

        public string GetIDFromProduct(string product)
        {
            SqlCommand commandGetCO = new SqlCommand("select id from objects where product = '" + product + "'", connection);
            SqlDataAdapter adapterGetCO = new SqlDataAdapter(commandGetCO);
            DataTable dataCO = new DataTable();
            adapterGetCO.Fill(dataCO);

            return dataCO.Rows[0][0].ToString();
        }

        private void treeViewData_AfterSelect(object sender, TreeViewEventArgs e)
        {
            productNow = (sender as TreeView).SelectedNode.Text;
            idNow = GetIDFromProduct(productNow);
            ShowAttributes();
        }

        public void ShowAttributes()
        {
            groupBox1.Controls.Clear();

            DataTable attributesData = GetAttributes(productNow);

            try
            {
                attributeCount = attributesData.Rows.Count;

                for (int i = 0; i < attributesData.Rows.Count; i++)
                {
                    Label l = new Label();
                    l.Text = attributesData.Rows[i][0].ToString();
                    l.Location = new System.Drawing.Point(20, 30 * i + 20);
                    l.Width = 150;
                    labels[i] = l;

                    TextBox t = new TextBox();
                    t.Text = attributesData.Rows[i][1].ToString();
                    t.Location = new System.Drawing.Point(180, 30 * i + 20);
                    t.Width = 250;
                    t.Tag = i.ToString();
                    textBoxes[i] = t;
                    t.TextChanged += T_TextChanged;

                    Button b = new Button();
                    b.Text = "Удалить";
                    b.Width = 80;
                    b.Tag = attributesData.Rows[i][0].ToString();
                    b.Location = new System.Drawing.Point(440, 30 * i + 19);
                    b.Click += B_Click;

                    groupBox1.Controls.Add(l);
                    groupBox1.Controls.Add(t);
                    groupBox1.Controls.Add(b);
                }
            }
            catch
            {
                attributeCount = 0;
            }

            TextBox name = new TextBox();
            name.Location = new System.Drawing.Point(20, 30 * attributesData.Rows.Count + 20);
            name.Width = 150;
            nameID = name;

            TextBox value = new TextBox();
            value.Location = new System.Drawing.Point(180, 30 * attributesData.Rows.Count + 20);
            value.Width = 250;
            valueID = value;

            Button add = new Button();
            add.Text = "Добавить аттрибут";
            add.Location = new System.Drawing.Point(440, 30 * attributesData.Rows.Count + 20);
            add.Width = 80;
            add.Click += Add_Click;

            groupBox1.Controls.Add(name);
            groupBox1.Controls.Add(value);
            groupBox1.Controls.Add(add);
        }

        private void T_TextChanged(object sender, EventArgs e)
        {
            senderTB = Int32.Parse((sender as TextBox).Tag.ToString());
            Save();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            SqlCommand commandGetCO = new SqlCommand("insert into attributes values ("+idNow+", '"+nameID.Text+"', '"+valueID.Text+"')", connection);
            SqlDataAdapter adapterGetCO = new SqlDataAdapter(commandGetCO);
            DataTable dataCO = new DataTable();
            adapterGetCO.Fill(dataCO);

            ShowAttributes();
        }

        private void B_Click(object sender, EventArgs e)
        {
            SqlCommand commandGetCO = new SqlCommand("delete from attributes where name = '"+ (sender as Button).Tag.ToString() + "' and id = " + idNow, connection);
            SqlDataAdapter adapterGetCO = new SqlDataAdapter(commandGetCO);
            DataTable dataCO = new DataTable();
            adapterGetCO.Fill(dataCO);

            ShowAttributes();
        }

        public void Save()
        {
            if (attributeCount != 0)
            {
                SqlCommand commandGetCO = new SqlCommand("delete from attributes where id = " + idNow, connection);
                SqlDataAdapter adapterGetCO = new SqlDataAdapter(commandGetCO);
                DataTable dataCO = new DataTable();
                adapterGetCO.Fill(dataCO);

                for (int i = 0; i < attributeCount; i++)
                {
                    SqlCommand commandSet = new SqlCommand("insert into attributes values(" + idNow + ", '" + labels[i].Text + "', '" + textBoxes[i].Text + "')", connection);
                    SqlDataAdapter adapterSet = new SqlDataAdapter(commandSet);
                    DataTable dataSet = new DataTable();
                    adapterSet.Fill(dataSet);
                }
            }

            ShowAttributes();

            textBoxes[senderTB].Select();
            textBoxes[senderTB].Select(textBoxes[senderTB].Text.Length, textBoxes[senderTB].Text.Length);
        }

        private void добавитьНовуюВеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.path = null;
            Properties.Settings.Default.edit = false;

            AddItem ai = new AddItem();
            ai.ShowDialog();

            GetTree();
        }

        private void добавитьВТекущуюВеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Path = null;

            TreeNode node = treeViewData.SelectedNode;
            while (node != null)
            {
                Path = node.Text + "/" + Path;
                node = node.Parent;
            }

            Properties.Settings.Default.path = Path;
            Properties.Settings.Default.edit = false;

            AddItem ai = new AddItem();
            ai.ShowDialog();

            GetTree();
        }

        private void добавитьНовуюВеткуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.path = null;
            Properties.Settings.Default.edit = false;

            AddItem ai = new AddItem();
            ai.ShowDialog();

            GetTree();
        }

        private void добавитьВТекущуюВеткуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string Path = null;

            TreeNode node = treeViewData.SelectedNode;
            while (node != null)
            {
                Path = node.Text+"/"+Path;
                node = node.Parent;
            }

            Properties.Settings.Default.path = Path;
            Properties.Settings.Default.edit = false;

            AddItem ai = new AddItem();
            ai.ShowDialog();

            GetTree();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Path = null;

            TreeNode node = treeViewData.SelectedNode;
            while (node != null)
            {
                Path = node.Text + "/" + Path;
                node = node.Parent;
            }

            Properties.Settings.Default.path = Path;
            Properties.Settings.Default.edit = true;
            Properties.Settings.Default.id = idNow;

            AddItem ai = new AddItem();
            ai.ShowDialog();

            GetTree();
        }

        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            изменитьToolStripMenuItem_Click(sender, e);
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.id = idNow;

            DeleteForm df = new DeleteForm();
            df.ShowDialog();

            GetTree();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            удалитьToolStripMenuItem1_Click(sender, e);
        }
    }
}
