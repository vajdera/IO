using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{



    public partial class Form1 : Form
    {

        private MyQuerry mq;
        BindingSource pracownicyBindingSource;
        BindingNavigator pracownicyBindingNavigator;

        BindingSource SoftBBindingSource;
        BindingNavigator SoftBBindingNavigator;

        BindingSource SoftZBindingSource;
        BindingNavigator SoftZBindingNavigator;

        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;

        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn4;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn5;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn6;

        private string currentFile { get; set; }
    
        public Form1()
        {
            InitializeComponent();

            this.dataGridViewComboBoxColumn1 = new DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn3 = new DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn4 = new DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn5 = new DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn6 = new DataGridViewComboBoxColumn();
            // 
            // dataGridViewComboBoxColumn4
            // 
            this.dataGridViewComboBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewComboBoxColumn4.HeaderText = "Poziom Techniczny";
            this.dataGridViewComboBoxColumn4.DataSource = Enum.GetValues(typeof(Ocena));
            this.dataGridViewComboBoxColumn4.Name = "dataGridViewComboBoxColumn4";
            this.dataGridViewComboBoxColumn4.DataPropertyName = "Poziom";
            //
            // dataGridViewComboBoxColumn5
            // 
            this.dataGridViewComboBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewComboBoxColumn5.HeaderText = "Przydatność";
            this.dataGridViewComboBoxColumn5.DataSource = Enum.GetValues(typeof(Ocena));
            this.dataGridViewComboBoxColumn5.Name = "dataGridViewComboBoxColumn5";
            this.dataGridViewComboBoxColumn5.DataPropertyName = "Przydatnosc";
            // 
            // dataGridViewComboBoxColumn6
            // 
            this.dataGridViewComboBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewComboBoxColumn6.HeaderText = "Ocena";
            this.dataGridViewComboBoxColumn6.DataSource = Enum.GetValues(typeof(Ocena));
            this.dataGridViewComboBoxColumn6.Name = "dataGridViewComboBoxColumn6";
            this.dataGridViewComboBoxColumn6.DataPropertyName = "Wydajnosc";

            OprogramowanieBiuroweDataGridView.Columns.AddRange(new DataGridViewColumn[] {
            this.dataGridViewComboBoxColumn4,
            this.dataGridViewComboBoxColumn5,
            this.dataGridViewComboBoxColumn6 });

            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewComboBoxColumn1.HeaderText = "Poziom Techniczny";
            this.dataGridViewComboBoxColumn1.DataSource = Enum.GetValues(typeof(Ocena));
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.DataPropertyName = "Poziom";
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewComboBoxColumn2.HeaderText = "Przydatność";
            this.dataGridViewComboBoxColumn2.DataSource = Enum.GetValues(typeof(Ocena));
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.DataPropertyName = "Przydatnosc";
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewComboBoxColumn3.HeaderText = "Ocena";
            this.dataGridViewComboBoxColumn3.DataSource = Enum.GetValues(typeof(Ocena));
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.DataPropertyName = "Wydajnosc";

            OprogramowanieDoZarzadzaniaDataGridView.Columns.AddRange(new DataGridViewColumn[] {
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewComboBoxColumn2,
            this.dataGridViewComboBoxColumn3 });



            pracownicyBindingSource = new BindingSource();
            pracownicyBindingNavigator = new BindingNavigator();

            SoftBBindingSource = new BindingSource();
            SoftBBindingNavigator = new BindingNavigator();

            SoftZBindingSource = new BindingSource();
            SoftZBindingNavigator = new BindingNavigator();


            PopulateListBox(listBox1, "*.xml");

            mq = new MyQuerry();

        }

       


        private void Form1_Load(object sender, EventArgs e)
        {
            pracownicyBindingNavigator.BindingSource = pracownicyBindingSource;
            pracownicyBindingSource.DataSource = mq.Pracownicy;
            PracownicyDataGridView.DataSource = pracownicyBindingSource;

            SoftBBindingNavigator.BindingSource = SoftBBindingSource;
            SoftBBindingSource.DataSource = mq.SoftB;
            OprogramowanieBiuroweDataGridView.DataSource = SoftBBindingSource;

            SoftZBindingNavigator.BindingSource = SoftZBindingSource;
            SoftZBindingSource.DataSource = mq.SoftZ;
            OprogramowanieDoZarzadzaniaDataGridView.DataSource = SoftZBindingSource;

            this.FormClosing += new FormClosingEventHandler(Form1_Closing);
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serialize(currentFile);
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }


        private void PopulateListBox(ListBox lsb, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            if (listBox1.SelectedItem != null && listBox1.SelectedItem.ToString() != currentFile)
            {
                //zapis
                Serialize(currentFile);
             
                currentFile = listBox1.SelectedItem.ToString();
                //odczyt
                Deserialize(currentFile);
            }


        }

        private void Deserialize(string file)
        {
            //wczytanie nowego pliku                
            var deserializer = new XmlSerializer(typeof(MyQuerry));
            var reader = new StreamReader(file);

            mq = deserializer.Deserialize(reader) as MyQuerry;
            reader.Close();

            //bindowanie datagridview
            pracownicyBindingSource.DataSource = mq.Pracownicy;
            PracownicyDataGridView.DataSource = pracownicyBindingSource;

            SoftBBindingSource.DataSource = mq.SoftB;
            OprogramowanieBiuroweDataGridView.DataSource = SoftBBindingSource;

            SoftZBindingSource.DataSource = mq.SoftZ;
            OprogramowanieDoZarzadzaniaDataGridView.DataSource = SoftZBindingSource;


            AdresTextBox.Text = mq.Adres;
            TelefonTextBox.Text = mq.Telefon;
            NIPTextBox.Text = mq.Nip;
            RegonTextBox.Text = mq.Regon;
            
        }

        private void Serialize(string file)
        {
            //zapisanie starego pliku
            if (file != null)
            {
                //przepisanie textboxow do myQuery                   
                mq.Adres = AdresTextBox.Text;
                mq.Telefon = TelefonTextBox.Text;
                mq.Nip = NIPTextBox.Text;
                mq.Regon = RegonTextBox.Text;

                var serializer = new XmlSerializer(typeof(MyQuerry));
                var writer = new StreamWriter(file);
                serializer.Serialize(writer, mq);
                writer.Close();
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Serialize(currentFile);
        }

        private void pokażToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pokaż pomoc");
        }
    }       
            
            
            
            
}           
            
            
            