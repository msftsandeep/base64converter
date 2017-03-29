using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConverter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            label2.Visible = false;
            textBox1.Text = "Upload  image";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
        
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "png";
            openFileDialog1.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.RestoreDirectory = true;
         
           // openFileDialog1.ReadOnlyChecked = true;
           // openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            
            if((!String.IsNullOrEmpty(openFileDialog1.FileName)))
            { 
            using (Image image = Image.FromFile(openFileDialog1.FileName))
            { try
                    {
                        using (MemoryStream m = new MemoryStream())
                        {

                            byte[] imageArray = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                           // MessageBox.Show(base64ImageRepresentation);
                            //image.Save(m, image.RawFormat);
                           
                           // byte[] imageBytes = m.ToArray();

                            // Convert byte[] to Base64 String
                           // string base64String = Convert.ToBase64String(imageBytes);
                            //  textBox2.Text = base64String;
                            textBox2.Text = base64ImageRepresentation;
                            textBox2.ShortcutsEnabled = true;
                         
                        }

                    }
                    catch(OutOfMemoryException ex)
                   
                    {
                        label2.Text = ex.Message;
                    }
            }
            }
            else
            {
                label2.Text = "Please select file ";
               
                label2.ForeColor = System.Drawing.Color.Red;
                label2.Visible = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
