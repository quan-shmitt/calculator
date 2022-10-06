using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace calculator
{
    public partial class Form1 : Form
    {
        public List<string> currentOperation = new List<string>();
        Label operationText;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Calculator";           //defines the background info
            this.BackColor = Color.AliceBlue;

            operationText = new Label();
            operationText.Text = "";
            operationText.Padding = new Padding(5, 5, 5, 5);
            operationText.Location = new Point (50, 25);
            this.Controls.Add(operationText);

            for (int y = 0; y < 3; y++) //number buttons 0 - 9
            {
                for (int x = 0; x < 3; x++)
                {
                    Button numButton = new Button();
                    numButton.Text = Convert.ToString(x + y*3);
                    numButton.Location = new Point(x*50, 50 + y*50);
                    numButton.Width = 50;
                    numButton.Height = 50;
                    numButton.Click += TypeButton_Click;
                    this.Controls.Add(numButton);
                }
            }
            
            Button numButtonNine = new Button(); //number button 9
            numButtonNine.Text = Convert.ToString(9);
            numButtonNine.Location = new Point(1 * 50, 50 + 3 * 50);
            numButtonNine.Width = 50;
            numButtonNine.Height = 50;
            numButtonNine.Click += TypeButton_Click;
            this.Controls.Add(numButtonNine);

            Button plusButton = new Button();
            plusButton.Text = " + ";
            plusButton.Location = new Point(3 * 50, 50 + 0 * 50);
            plusButton.Width = 50;
            plusButton.Height = 50;
            plusButton.Click += TypeButton_Click;
            this.Controls.Add(plusButton);

            Button minusButton = new Button();
            minusButton.Text = " - ";
            minusButton.Location = new Point(3 * 50, 50 + 1 * 50);
            minusButton.Width = 50;
            minusButton.Height = 50;
            minusButton.Click += TypeButton_Click;
            this.Controls.Add(minusButton);

            Button enterButton = new Button();
            enterButton.Text = "enter";
            enterButton.Location = new Point(3 * 50, 50 + 2 * 50);
            enterButton.Width = 50;
            enterButton.Height = 100;
            enterButton.Click += EnterButton_Click; ;
            this.Controls.Add(enterButton);

            Button deleteButton = new Button();
            deleteButton.Text = "del";
            deleteButton.Location = new Point(2 * 50, 50 + 3 * 50);
            deleteButton.Width = 50;
            deleteButton.Height = 50;
            deleteButton.Click += DeleteButton_Click;
            this.Controls.Add(deleteButton);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            operationText.Text = "";
            currentOperation.Clear();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            string num1 = "";

            int pos = 0;
            while (currentOperation[pos] != " + " && currentOperation[pos] != " - ")
            {
                num1 += (currentOperation[pos]);
                pos++;
            }
            string operation = currentOperation[pos];
            pos++;

            string num2 = "";
            while (pos < currentOperation.Count)
            {
                num2 += (currentOperation[pos]);
                pos++;
            }

            int output = 0;

            if (operation == " + ")
            {
                output = Convert.ToInt32(num1) + Convert.ToInt32(num2);
            }
            else if (operation == " - ")
            {
                output = Convert.ToInt32(num1) - Convert.ToInt32(num2);
            }

            currentOperation.Clear();
            for(int digit = 0; digit < output.ToString().Length; digit++)
            {
                currentOperation.Add(output.ToString()[digit].ToString());
            }

            operationText.Text = (output.ToString());
        }

        private void TypeButton_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            currentOperation.Add(thisButton.Text);

            string print = "";
            for (int i = 0; i < currentOperation.Count; i++)
            {
                print += currentOperation[i].ToString();
            }
            
            operationText.Text = print;
        }
    }
}
