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
    public partial class form_Regist : Form
    {
        public form_Regist()
        {
            InitializeComponent();
        }
        string[] parklar = new string[16];
        //veri tabanı değişkenleri
        public OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=otoPark.mdb;");
        public OleDbCommand command = new OleDbCommand();
        public OleDbDataAdapter adap = new OleDbDataAdapter();
        public OleDbDataReader dr;
        public DataSet dataSet = new DataSet();
        public string com = "";

        //veri tabanına bağlanır
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
         public void conClose()
            {
                this.dr.Dispose();
                this.command.Dispose();
                this.com = "";
                this.connect.Close();
            }
        
        public void clearData()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.Items.Add("-");
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

        }
        public void doldurPark()
        {
            comboBox4.Items.Clear();
            comboBox4.Items.Add("-");
            comboBox4.SelectedIndex = 0;
            int j=0;
            bool varMi = false;
            for (int i = 0; i < parklar.Length; i++)
            {
                parklar[i] = " ";
            }
            string parkName = "P";
            com = "SELECT park_name FROM proccessing";
            conOpen();
            command.CommandText = com;
            command.Connection = connect;
            dr = command.ExecuteReader();
            while (dr.Read())
            {

                parklar[j] =dr["park_name"].ToString();
                j++;
               
            }
            for (int i = 1; i <= 16; i++)
            {
               
                parkName += i.ToString();
                foreach (string item in parklar)
                {
                    if (parkName == item)
                    {
                        varMi = true;
                    }

                }
                if (varMi != true)
                {
                    comboBox4.Items.Add(parkName);
                }
                
                varMi = false;
                parkName = "P";
            }
            conClose();
        }
        private void form_Regist_Load(object sender, EventArgs e)
        {
            clearData();
            doldurPark();

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void button_Min_Click(object sender, EventArgs e)
        {
            
            clearData();
            form_Ana formAna = new form_Ana();
            formAna.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {

                comboBox2.Items.Clear();
                comboBox2.Items.Add("-");
                comboBox2.Items.Add("Passat");
                comboBox2.Items.Add("Golf");
                comboBox2.Items.Add("Polo");
                comboBox2.Items.Add("Arteon");
                comboBox2.Text = "";
                comboBox2.SelectedIndex = 0;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("-");
                comboBox2.Items.Add("Corsa");
                comboBox2.Items.Add("Astra");
                comboBox2.Items.Add("Grandland");
                comboBox2.Items.Add("Corssland");
                comboBox2.Text = "";
                comboBox2.SelectedIndex = 0;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.Items.Clear();
                
                comboBox2.Items.Add("-");
                comboBox2.Items.Add("Egea");
                comboBox2.Items.Add("Linea");
                comboBox2.Items.Add("Punto");
                comboBox2.Items.Add("Panda");
                comboBox2.Text = "";
                comboBox2.SelectedIndex = 0;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("-");
                comboBox2.Items.Add("Mercedes-Benz");
                comboBox2.Items.Add("Sedan");
                comboBox2.Items.Add("Estate");
                comboBox2.Items.Add("Coupé");
                comboBox2.Text = "";
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button_Regist_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Kayıt işlemi gerçekleşsin mi", "REGIST", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                com = "INSERT INTO customers(cost_tc,cost_name,cost_surname,cost_phone,cost_mail) VALUES(@cost_tc,@cost_name,@cost_surname,@cost_phone,@cost_mail)";
                conOpen();
                command.Connection = connect;
                command.CommandText = com;
                command.Parameters.AddWithValue("@cost_tc", textBox3.Text);
                command.Parameters.AddWithValue("@cost_name", textBox1.Text);
                command.Parameters.AddWithValue("@cost_surname", textBox2.Text);
                command.Parameters.AddWithValue("@cost_phone", textBox4.Text);
                command.Parameters.AddWithValue("@cost_mail", textBox5.Text);

                command.ExecuteNonQuery();
                conClose();
                com = "INSERT INTO cars(car_plaka,car_marka,car_model,car_renk) VALUES(@car_plaka,@car_marka,@car_model,@car_renk)";
                conOpen();
                command.Connection = connect;
                command.CommandText = com;
                command.Parameters.AddWithValue("@car_plaka", textBox6.Text);
                command.Parameters.AddWithValue("@car_marka", comboBox1.Text);
                command.Parameters.AddWithValue("@car_model", comboBox2.Text);
                command.Parameters.AddWithValue("@car_renk", comboBox3.Text);

                command.ExecuteNonQuery();
                conClose();

                com = "INSERT INTO proccessing(cust_tc,car_plaka,park_name,pro_start) VALUES(@cust_tc,@car_plaka,@park_name,@pro_start)";
                conOpen();
                command.Connection = connect;
                command.CommandText = com;
                command.Parameters.AddWithValue("@cust_tc", textBox3.Text);
                command.Parameters.AddWithValue("@car_plaka", textBox6.Text);
                command.Parameters.AddWithValue("@park_name", comboBox4.Text);
                command.Parameters.AddWithValue("@pro_start", DateTime.Now.ToString());

                command.ExecuteNonQuery();
                conClose();
                MessageBox.Show("Kayıt Tamalanmıştır");
                clearData();
                doldurPark();

            }
            
        }


        
    }
}
