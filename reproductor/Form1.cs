using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace reproductor
{
    public partial class Form1 : Form
    {
        int contador = -1;

        List<album> cancioness = new List<album>();

        public string nom;
        public List<string> lista = new List<string>();
        public string can = "";

        XmlDocument xDoc = new XmlDocument();
        XmlDocument xDoc2 = new XmlDocument();
        public Form1()
        {
            InitializeComponent();
        }        
        private void misListasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reproductor.Ctlcontrols.stop();
            Form2 f2 = new Form2();
            f2.ShowDialog();           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
            //reproductor\reproductor\bin\Debug\imagenes 
            button1.Visible = false;
            //mostrar lista
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"E:\reproductor\reproductor\bin\Debug\musicas.txt");
            XmlNodeList canciones = xDoc.GetElementsByTagName("canciones");
            XmlNodeList lista = ((XmlElement)canciones[0]).GetElementsByTagName("cancion");

            foreach (XmlElement nodo in lista)
            {
                int i = 0;

                album musicatemp = new album();

                XmlNodeList Nombre = nodo.GetElementsByTagName("nombre");
                XmlNodeList Ubicacion = nodo.GetElementsByTagName("ubicacion");

                musicatemp.Nombre = Nombre[i].InnerText;
                musicatemp.Ubicacion = Ubicacion[i].InnerText;

                cancioness.Add(musicatemp);
                contador = contador + 1;
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = cancioness;
            dataGridView1.Columns[0].DisplayIndex = 1;
            dataGridView1.Update();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int ind;

            ind = dataGridView1.CurrentRow.Index;
            reproductor.URL = dataGridView1[0, ind].Value.ToString();
            label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);

            try
            {
                pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");          
                listBox1.Items.Clear();
                listBox1.Visible = true;

                StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                string r;
                while ((r = R.ReadLine()) != null)
                {
                    listBox1.Items.Add(r);
                }
                R.Close();
            }
            catch (Exception )
            {
               listBox1.Visible = false;
                pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");                         
            }
        }          
        private void button5_Click(object sender, EventArgs e)
        {
            int ind;
            ind = dataGridView1.CurrentRow.Index;
            //obtiene el valor de la celda
            // int cont=dataGridView1.RowCount ;
            // int asu=0;
            if (ind < contador)
            {
                dataGridView1.CurrentCell = dataGridView1[0, ind + 1];
                int inu;

                inu = dataGridView1.CurrentRow.Index;

                reproductor.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    
                    listBox1.Items.Clear();
                    listBox1.Visible = true;

                    StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");             
                }
            }
            else
            {
                dataGridView1.CurrentCell = dataGridView1[0, 0];
                int inu;

                inu = dataGridView1.CurrentRow.Index;
                reproductor.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");

                    listBox1.Items.Clear();
                   listBox1.Visible = true;

                    StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                   listBox1.Visible = false;
                   pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int ind;
            ind = dataGridView1.CurrentRow.Index;
            //obtiene el valor de la celda
            // int cont=dataGridView1.RowCount ;
            // int asu=0;
            if (ind > 0)
            {
                dataGridView1.CurrentCell = dataGridView1[0, ind - 1];
                int inu;

                inu = dataGridView1.CurrentRow.Index;

                reproductor.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);
                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    listBox1.Items.Clear();
                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");

                }
            }
            else
            {
                dataGridView1.CurrentCell = dataGridView1[0, contador];

                int inu;

                inu = dataGridView1.CurrentRow.Index;

                reproductor.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");

                    listBox1.Items.Clear();

                   listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();

                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog mi_pc = new OpenFileDialog();
            mi_pc.InitialDirectory = @"E:\reproductor\music\";
            if (mi_pc.ShowDialog() == DialogResult.OK)
            {
                string nombre = mi_pc.FileName;
                label2.Text = mi_pc.FileName;
                label1.Text = Path.GetFileNameWithoutExtension(label2.Text);
            }
            //agrega cancion
            string pathxml = @"E:\reproductor\reproductor\bin\Debug\musicas.txt";

            XmlDocument doc = new XmlDocument();
            doc.Load(pathxml);

            XmlNode nodecanciones = doc.CreateElement("cancion");

            XmlNode nodenombre = doc.CreateElement("nombre");
            nodenombre.InnerText = label1.Text;

            XmlNode nodeubicacion = doc.CreateElement("ubicacion");
            nodeubicacion.InnerText = label2.Text;
            nodecanciones.AppendChild(nodenombre);
            nodecanciones.AppendChild(nodeubicacion);

            doc.SelectSingleNode("canciones").AppendChild(nodecanciones);

            doc.Save(pathxml);

            dataGridView1.Update();          
            //limpiar lista
            cancioness.Clear();
            //mostrar lista
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"E:\reproductor\reproductor\bin\Debug\musicas.txt");
            XmlNodeList canciones = xDoc.GetElementsByTagName("canciones");
            XmlNodeList lista = ((XmlElement)canciones[0]).GetElementsByTagName("cancion");

            foreach (XmlElement nodo in lista)
            {
                int i = 0;

                album musicatemp = new album();
                XmlNodeList Nombre = nodo.GetElementsByTagName("nombre");
                XmlNodeList Ubicacion = nodo.GetElementsByTagName("ubicacion");
                musicatemp.Nombre = Nombre[i].InnerText;
                musicatemp.Ubicacion = Ubicacion[i].InnerText;
                cancioness.Add(musicatemp);
                // contador = contador + 1;
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = cancioness;
            dataGridView1.Columns[0].DisplayIndex = 1;
            dataGridView1.Update();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            reproductor.Ctlcontrols.stop();
        }
        private void agregarCancionABibliotecaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog mi_pc = new OpenFileDialog();
            mi_pc.InitialDirectory = @"E:\reproductor\music\";
            if (mi_pc.ShowDialog() == DialogResult.OK)
            {
                string nombre = mi_pc.FileName;
                label2.Text = mi_pc.FileName;
                label1.Text = Path.GetFileNameWithoutExtension(label2.Text);
            }
            //agrega cancion
            string pathxml = @"E:\reproductor\reproductor\bin\Debug\musicas.txt";

            XmlDocument doc = new XmlDocument();
            doc.Load(pathxml);
            XmlNode nodecanciones = doc.CreateElement("cancion");
            XmlNode nodenombre = doc.CreateElement("nombre");
            nodenombre.InnerText = label1.Text;
            XmlNode nodeubicacion = doc.CreateElement("ubicacion");
            nodeubicacion.InnerText = label2.Text;
            nodecanciones.AppendChild(nodenombre);
            nodecanciones.AppendChild(nodeubicacion);
            doc.SelectSingleNode("canciones").AppendChild(nodecanciones);
            doc.Save(pathxml);
            dataGridView1.Update();     
            //limpiar lista
            cancioness.Clear();      
            //mostrar lista
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"E:\reproductor\reproductor\bin\Debug\musicas.txt");
            XmlNodeList canciones = xDoc.GetElementsByTagName("canciones");
            XmlNodeList lista = ((XmlElement)canciones[0]).GetElementsByTagName("cancion");

            foreach (XmlElement nodo in lista)
            {
                int i = 0;

                album musicatemp = new album();
                XmlNodeList Nombre = nodo.GetElementsByTagName("nombre");
                XmlNodeList Ubicacion = nodo.GetElementsByTagName("ubicacion");
                musicatemp.Nombre = Nombre[i].InnerText;
                musicatemp.Ubicacion = Ubicacion[i].InnerText;
                cancioness.Add(musicatemp);
                // contador = contador + 1;
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = cancioness;

            dataGridView1.Columns[0].DisplayIndex = 1;
            dataGridView1.Update();
        }
        private void reproducirCancionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"E:\reproductor\music\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {               
                reproductor.URL = openFileDialog1.FileName;
            }
            listBox1.Visible = false;
            reproductor.Ctlcontrols.play();
            pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int ind;
            ind = dataGridView1.CurrentRow.Index;
            reproductor.URL = dataGridView1[0, ind].Value.ToString();
            label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);

            try
            {
                pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                listBox1.Items.Clear();
                listBox1.Visible = true;
                StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                string r;
                while ((r = R.ReadLine()) != null)
                {
                    listBox1.Items.Add(r);
                }
                R.Close();
            }
            catch (Exception)
            {
                listBox1.Visible = false;
                pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
            }
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int ind;
            ind = dataGridView1.CurrentRow.Index;
            //obtiene el valor de la celda
            // int cont=dataGridView1.RowCount ;
            // int asu=0;
            if (ind < contador)
            {
                dataGridView1.CurrentCell = dataGridView1[0, ind + 1];
                int inu;

                inu = dataGridView1.CurrentRow.Index;

                reproductor.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    listBox1.Items.Clear();
                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                }
            }
            else
            {
                dataGridView1.CurrentCell = dataGridView1[0, 0];
                int inu;

                inu = dataGridView1.CurrentRow.Index;

                reproductor.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    listBox1.Items.Clear();
                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            reproductor.Ctlcontrols.stop();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int ind;
            ind = dataGridView1.CurrentRow.Index;
            //obtiene el valor de la celda
            // int cont=dataGridView1.RowCount ;
            // int asu=0;
            if (ind > 0)
            {
                dataGridView1.CurrentCell = dataGridView1[0, ind - 1];
                int inu;
                inu = dataGridView1.CurrentRow.Index;
                reproductor.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    listBox1.Items.Clear();
                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                }
            }
            else
            {
                dataGridView1.CurrentCell = dataGridView1[0, contador];

                int inu;
                inu = dataGridView1.CurrentRow.Index;
                reproductor.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(reproductor.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    listBox1.Items.Clear();
                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"E:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"E:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

