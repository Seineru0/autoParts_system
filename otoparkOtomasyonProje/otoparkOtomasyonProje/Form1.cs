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
    public partial class form_Ana : Form
    {
        public form_Ana()
        {
            InitializeComponent();
        }
        public static string custInfo;

        //veri tabanı değişkenleri
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=otoPark.mdb;");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter adap = new OleDbDataAdapter();
        OleDbDataReader dr;
        DataSet dataSet = new DataSet();
        string com = "";

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


        //tabloyu getirir
        public void veriDoldur(string tablo)
        {

            conOpen();
            command.CommandText = "SELECT * FROM " + tablo;
            command.Connection = connect;
            dr = command.ExecuteReader();

            labelClear();
            while (dr.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is Label)
                    {
                        string parkYeri = "label_" + dr["park_name"].ToString();
                        if (item.Name == parkYeri)
                        {
                            item.Text = dr["car_plaka"].ToString();
                            item.BackColor = Color.Red;
                        }
                    }
                }



            }
            command.Dispose();
            dr.Dispose();
            connect.Close();
        }

        //label sıfırlar
        public void labelClear()
        {
            int i = 1;
            string labelPark = "label_P" + i.ToString();
            foreach (Control item in Controls)
            {

                if (item is Label)
                {
                    if (item.Name == labelPark)
                    {
                        item.Text = "BOŞ";
                        item.BackColor = Color.LimeGreen;
                    }

                }
                i++;
            }

        }
        private void form_Ana_Load(object sender, EventArgs e)
        {
            veriDoldur("proccessing");
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_Registry_Click(object sender, EventArgs e)
        {
            form_Regist formRegist = new form_Regist();
            formRegist.Show();
            this.Hide();
        }

     
        private void button_List_Click(object sender, EventArgs e)
        {
            form_List formList = new form_List();
            formList.Show();
            this.Hide();
        }

        form_Cust formCust = new form_Cust();
        private void label_P1_Click(object sender, EventArgs e)
        {
            if (label_P1.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P1.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P2_Click(object sender, EventArgs e)
        {
            if (label_P2.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P2.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P3_Click(object sender, EventArgs e)
        {
            if (label_P3.Text != "BOŞ")
            {

                connect.Close();
                custInfo = label_P3.Text;
                formCust.Show();
                this.Hide();
                
            }
        }

        private void label_P4_Click(object sender, EventArgs e)
        {
            if (label_P4.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P4.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P5_Click(object sender, EventArgs e)
        {
            if (label_P5.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P5.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P6_Click(object sender, EventArgs e)
        {
            if (label_P6.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P6.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P7_Click(object sender, EventArgs e)
        {
            if (label_P7.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P7.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P8_Click(object sender, EventArgs e)
        {
            if (label_P8.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P8.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P12_Click(object sender, EventArgs e)
        {
            if (label_P12.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P12.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P11_Click(object sender, EventArgs e)
        {
            if (label_P11.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P11.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P10_Click(object sender, EventArgs e)
        {
            if (label_P10.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P10.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P9_Click(object sender, EventArgs e)
        {
            if (label_P9.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P9.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P13_Click(object sender, EventArgs e)
        {
            if (label_P13.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P13.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P14_Click(object sender, EventArgs e)
        {
            if (label_P14.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P14.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P15_Click(object sender, EventArgs e)
        {
            if (label_P15.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P15.Text;
                formCust.Show();
                this.Hide();
            }
        }

        private void label_P16_Click(object sender, EventArgs e)
        {
            if (label_P16.Text != "BOŞ")
            {
                connect.Close();
                custInfo = label_P16.Text;
                formCust.Show();
                this.Hide();
            }
        }

    }
}
