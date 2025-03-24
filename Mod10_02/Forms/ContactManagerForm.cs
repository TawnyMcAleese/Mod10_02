using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod10_02.Forms
{
    public partial class ContactManagerForm : Form
    {
        public ContactManagerForm() => InitializeComponent();

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ContactManagerForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ContactManagerForm";
            this.ResumeLayout(false);
        }
    }
}
