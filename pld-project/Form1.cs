using com.calitha.goldparser;

namespace pld_project
{
    public partial class Form1 : Form
    {
        MyParser parser;
        public Form1()
        {
            InitializeComponent();
            parser = new MyParser("pld-grammer.cgt", listBox1, listBox2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            parser.Parse(textBox1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
