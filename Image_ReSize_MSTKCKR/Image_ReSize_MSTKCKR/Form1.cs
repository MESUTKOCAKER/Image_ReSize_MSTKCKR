using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_ReSize_MSTKCKR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap img;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Image Resize Application and Developer: Mesut Koçaker";
            file.Filter = "png image|*.png|jpg image|*.jpg|All Files|*.*";
            #region file.filters
            /*
            *.*     All File
            *.jpg   jpg file
            *.png   png file
            *.gif   gif file
            *.bmp   bmp file
            *.txt   txt file
            .
            .
            .
            */
            #endregion
            if (file.ShowDialog() == DialogResult.OK)
            {// if value is ok
                //  picOriginal.ImageLocation = file.FileName;
                img = new Bitmap(file.FileName);     // new Bitmap Object
                txtWidth.Text = img.Width.ToString();       // image width
                txtHeight.Text = img.Height.ToString();     // image height
                picOriginal.ImageLocation = file.FileName;  // original image show

                btnRun.Enabled = true;
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWidth.Text == txtHeight.Text && txtHeight.Text == "")
                {//     width and height == ""
                    btnRun.Enabled = false;
                    btnSaveAs.Enabled = false;
                }
                else
                {
                    img = new Bitmap(img, new Size(int.Parse(txtWidth.Text), int.Parse(txtHeight.Text)));
                    picNewSize.Image = img;
                    btnSaveAs.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                btnRun.Enabled = false;
                btnSaveAs.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWidth.Text == txtHeight.Text && txtHeight.Text == "")
                {//     width and height == ""
                    btnRun.Enabled = false;
                    btnSaveAs.Enabled = false;
                }
                else
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "png image|*.png|jpg image|*.jpg|All Files|*.*";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        picNewSize.Image.Save(saveFile.FileName);
                        MessageBox.Show("Correct Save As");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                autoSize("txtWidth");
            }
        }

        private void autoSize(string txtName)
        {
            if (txtWidth.Text != "" && txtName==txtWidth.Name)
            {
                try
                {
                    int width = int.Parse(txtWidth.Text);
                    int originalWidth = img.Width;
                    int originalHeight = img.Height;

                    int height = (originalHeight * width) / originalWidth;

                    txtHeight.Text = Math.Abs(height).ToString();
                }
                catch
                {
                }
            }
            else if (txtHeight.Text != "" && txtName == txtHeight.Name)
            {
                try
                {
                    int height = int.Parse(txtHeight.Text);
                    int originalWidth = img.Width;
                    int originalHeight = img.Height;

                    int width = (originalWidth * height) / originalHeight;

                    txtWidth.Text = Math.Abs(width).ToString();
                }
                catch
                {

                }
            }
        }

        private void txtWidth_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (checkBox1.Checked)
            {
                    autoSize(txt.Name);
            }
        }
    }
}
