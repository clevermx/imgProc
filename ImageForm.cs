using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obrabotka1
{
    public partial class ImageForm : Form
    {
        Image mImage;
       
        public ImageForm()
        {
            InitializeComponent();
        }
        public ImageForm(Image img)
        {
            
            InitializeComponent();

         
            mImage = img;
            pictureBox1.Image = mImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
