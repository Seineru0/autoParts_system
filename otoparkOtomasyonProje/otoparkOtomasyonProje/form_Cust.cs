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

    public partial class form_Cust : Form
    {
        public form_Cust()
        {
            InitializeComponent();
        }
        public int id_car=0;
        public int id_cust = 0;
        public int id_pro = 0;
        public double custPay = 0;
        public string tc = "";
        public string plaka = "";
        public class dataBase
        {

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

            // istenilen tablodan veri getirilir
            public void veriGetir(string tabloName)
            {
                com = "SELECT * FROM " + tabloName + " WHERE car_plaka=@park";
                conOpen();
                command.CommandText = com;
                command.Connection = connect;
                command.Parameters.AddWithValue("@park", form_Ana.custInfo);

                this.dr = command.ExecuteReader();

            }
            public void veriGetirCust(string tc1)
            {


                com = "SELECT * FROM customers WHERE cost_tc=@tc";
                conOpen();
                command.CommandText = com;
                command.Connection = connect;
                command.Parameters.AddWithValue("@tc", tc1);

                this.dr = command.ExecuteReader();

            }
            public void exitRegist(string ad,string tc, string tel , string mail , string plaka, string pay, DateTime start, DateTime exit)
            {
                com = "INSERT INTO exitCust(cust_name, cust_tc, car_plaka , cust_phone, cust_mail, pro_pay, pro_start, pro_end) VALUES(@cust_name, @cust_tc, @car_plaka , @cust_phone, @cust_mail, @pro_pay, @pro_start, @pro_end)";
                conOpen();
                command.CommandText = com;
                command.Connection = connect;
                command.Parameters.AddWithValue("@cust_name", ad);
                command.Parameters.AddWithValue("@cust_tc", tc);
                command.Parameters.AddWithValue("@car_plaka", plaka);
                command.Parameters.AddWithValue("@cust_phone", tel);
                command.Parameters.AddWithValue("@cust_mail", mail);
                command.Parameters.AddWithValue("@pro_pay", pay);
                command.Parameters.Add("@pro_start", OleDbType.Date).Value = start;
                command.Parameters.Add("@pro_end", OleDbType.Date).Value = exit;
                command.ExecuteNonQuery();
                conClose();

            }
            public void conClose()
            {
                if (this.dr != null)
                {
                    this.dr.Dispose();
                }
                
                this.command.Dispose();
                this.com = "";
                this.connect.Close();
            }
            public void dataDelete(string tabloName, string sutunName, string id_data)
            {
                com = "DELETE FROM " + tabloName + " WHERE " + sutunName + "=" + id_data + ";";
                conOpen();
                command.CommandText = com;
                command.Connection = connect;
                command.ExecuteNonQuery();
                conClose();
            }
        }


        private void button_Min_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            form_Ana formAna = new form_Ana();
            formAna.Show();
            this.Hide();

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Araç Çıkış işlemi gerçekleşsin mi? ", "EXIT!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                MessageBox.Show(label26.Text, "Tutar");
                timer1.Enabled = false;
                string adCust = "", tcCust = "", carPlaka = "", phoneCust = "", mailCust = "", custPays = "";
                custPays = custPay.ToString("##,000.00")+" TL";
                DateTime custExit = DateTime.Now;
                DateTime custStart = DateTime.Parse(label24.Text);
                adCust = label14.Text;
                tcCust = label16.Text;
                carPlaka = label19.Text;
                phoneCust = label17.Text;
                mailCust = label18.Text;

                dataBase delCust = new dataBase();
                delCust.exitRegist(adCust,tcCust,phoneCust,mailCust,carPlaka, custPays, custStart,custExit);
                delCust.dataDelete("customers", "id_cost", id_cust.ToString());
                delCust.dataDelete("cars", "id_car", id_car.ToString());
                delCust.dataDelete("proccessing", "id_pro", id_pro.ToString());
                form_Ana formAna = new form_Ana();
                formAna.Show();
                this.Close();
               
                
            }




        }
        DateTime start, exit;
        TimeSpan fark;
        private void form_Cust_Load(object sender, EventArgs e)
        {
            dataBase proc = new dataBase();
            proc.conOpen();
            proc.veriGetir("proccessing");
            while (proc.dr.Read())
            {
                tc = proc.dr["cust_tc"].ToString();
                plaka = proc.dr["car_plaka"].ToString();
                id_pro = int.Parse(proc.dr["id_pro"].ToString());
                label23.Text = proc.dr["park_name"].ToString();
                label24.Text = proc.dr["pro_start"].ToString();
             
            
            }
            proc.conClose();

            dataBase car = new dataBase();
            car.conOpen();
            car.veriGetir("cars");
            while (car.dr.Read())
            {
                id_car = int.Parse(car.dr["id_car"].ToString());
                label19.Text = car.dr["car_plaka"].ToString();
                label20.Text = car.dr["car_marka"].ToString();
                label21.Text = car.dr["car_model"].ToString();
                label22.Text = car.dr["car_renk"].ToString();

            }
            car.conClose();

            dataBase cust = new dataBase();
            cust.conOpen();
            cust.veriGetirCust(tc);
            while (cust.dr.Read())
            {
                id_cust  = int.Parse(cust.dr["id_cost"].ToString());
                label14.Text = cust.dr["cost_name"].ToString();
                label15.Text = cust.dr["cost_surname"].ToString();
                label16.Text = cust.dr["cost_tc"].ToString();
                label17.Text = cust.dr["cost_phone"].ToString();
                label18.Text = cust.dr["cost_mail"].ToString();
            }
            car.conClose();

            start = DateTime.Parse(label24.Text);
            timer1.Enabled = true;



        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            exit = DateTime.Now;
            fark = exit - start;
            custPay = double.Parse(fark.TotalMinutes.ToString()) * 0.2;
            label25.Text = fark.TotalMinutes.ToString("##") + " Dakika - Yaklaşık " + fark.TotalHours.ToString("##") + " Saat";
            label26.Text = custPay.ToString("#,###.00") + " TL";
        }
    }
}
