using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SequenceVerification
{
    public partial class VerificationForm : Form
    {
        public VerificationForm()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string inputRows = textBox1.Text;
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void VerifyBtn_Click(object sender, EventArgs e)
        {

            //Strategy pattern - Välj vilken typ av verifiering som ska ske
            ISequenceVerification verificationObject = new VerificationUsingLINA();

            //Förbered sekvens med info från inputarea
            verificationObject.prepareSequence(new StringBuilder(textBox1.Text));

            //Kör igenom sekvens
            verificationObject.executeSequence();

            //Ladda resultatet i resultatarea
            textBox2.Text = verificationObject.getResult("").ToString();


        }
    }
}
