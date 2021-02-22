using System;
using System.Drawing;
using System.Windows.Forms;
using TravelExpertsData;

namespace Workshop4Group8
{
    
    public partial class frm1 : Form
    {
        //to set the main location and zise of every component
        public Size orgFrm;
        public Rectangle orgPackge;
        public Rectangle orgProduct;
       
        public frm1()
        {

            InitializeComponent();
            
        }

        private void Packages_Click(object sender, EventArgs e)
        {
            frmPackages newform = new frmPackages();
            DialogResult result = newform.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPS newform = new frmPS();
            DialogResult result = newform.ShowDialog();
        }

        private void frm1_Load(object sender, EventArgs e)
        {
            orgFrm = Size;
            orgPackge = new Rectangle(Packages.Location.X, Packages.Location.Y, Packages.Width, Packages.Height);
            orgProduct = new Rectangle(product.Location.X, product.Location.Y, product.Width, product.Height);
            
            frmGuardian guardian = new frmGuardian();
            DialogResult result = guardian.ShowDialog();

            DateTime today = DateTime.Today;
            DateTime passwordLastChangedDate = PasswordDB.GetLastUpdateDate();
            if ((today - passwordLastChangedDate).Days >=90)
            {
                frmNewPassword newForm = new frmNewPassword();
                newForm.ninetyDayUpdate = true;
                DialogResult npresult = newForm.ShowDialog();
            }

        }
        public void resize()
        {
            changezise(orgPackge, Packages);
            changezise(orgProduct, product);
        }
        //this is for changing the size and location
        public void changezise(Rectangle org,Control cntrl)
        {
            float xratio = (float)(Size.Width)/(float)(orgFrm.Width);
            float yratio = (float)(Size.Height)/(float)(orgFrm.Height);


            int newx = (int)(org.X * xratio);
            int newy = (int)(org.Y * yratio);
            int newwidth = (int)(org.Width * xratio);
            int newheight = (int)(org.Height * yratio);
          
            cntrl.Location = new Point(newx, newy);
            cntrl.Size = new Size(newwidth, newheight);
        }
        
        //event resize when the main screen is resized every control in it resizes with it
        private void frm1_Resize(object sender, EventArgs e)
        {
         resize();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewPassword newForm = new frmNewPassword();
            newForm.ninetyDayUpdate = false;
            DialogResult npresult = newForm.ShowDialog();
        }
    }
}
