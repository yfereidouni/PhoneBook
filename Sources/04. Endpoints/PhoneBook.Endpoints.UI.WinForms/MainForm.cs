using PhoneBook.Core.Entities.Phones;

namespace PhoneBook.Endpoints.UI.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Phone> phones = new List<Phone>()
            {
                new Phone
                {
                    Id = 1,
                    PhoneNumber = "09123233233"
                },
                new Phone
                {
                    Id = 2,
                    PhoneNumber = "09123255233"
                },
            };


            bindingSource1.DataSource = phones;
            dataGridView1.DataSource = bindingSource1;
            
            textBox1.Text = bindingSource1.Count.ToString();

        }



        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
            textBox1.Text = bindingSource1.Position.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }
    }
}