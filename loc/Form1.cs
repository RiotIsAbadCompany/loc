using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace loc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            label1.Text = "LOC";
            label2.Text = "L2";
            label3.Text = "L1";
            label4.Text = "F";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            var lineCount = File.ReadLines(@"C:\folder\file.txt").Count();
          var nonBlank =  File.ReadLines(@"C:\folder\file.txt").Count(line => !string.IsNullOrWhiteSpace(line));
            String line = "";
            int count = 0;


            TextReader reader = new StreamReader(@"C:\folder\file.txt");
            while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("//"))
                    {
                        count++;
                    }
                    else if (line.Contains("/*"))
                    {
                        count++;
                        while (!line.Contains("*/") && !(line = reader.ReadLine()).Contains("*/")) ;
                    }
                }
            reader.Close();

            var comment = count;
            var blank = lineCount - nonBlank;
            var comAndBlank = count + blank;
            var legitCode =nonBlank - count;
            var f = Convert.ToDouble(comment)/ Convert.ToDouble(lineCount);
            textBox1.Text = lineCount.ToString();
            textBox2.Text = legitCode.ToString();
            textBox3.Text = comAndBlank.ToString();
            textBox4.Text =Math.Round( f,2).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String path = @"C:\folder\file.txt";
            string readText = File.ReadAllText(path);
            richTextBox1.Text = readText;


        }
        
    }
}