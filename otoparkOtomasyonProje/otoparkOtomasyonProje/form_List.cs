using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace otoparkOtomasyonProje
{
    public partial class form_List : Form
    {
        public form_List()
        {
            InitializeComponent();
        }
        public OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=otoPark.mdb;");
        public OleDbDataAdapter adap;
        public DataSet dataSet = new DataSet();
        public string com = "";
        public void conOpen()
        {
            try
            {
                connect.Close();
                connect.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show("Bağlantı açılamadı");
                MessageBox.Show(a.ToString());

            }
        }
        private void button_Min_Click(object sender, EventArgs e)
        {
           
            form_Ana formAna = new form_Ana();
            formAna.Show();
            this.Hide();
        }

        private void form_List_Load(object sender, EventArgs e)
        {
            com = "SELECT * FROM exitCust";
            conOpen();
            adap = new OleDbDataAdapter(com, connect);
            adap.Fill(dataSet,"hello");
            
            adap.Dispose();
            connect.Close();
            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "hello";

        }
    }
}
