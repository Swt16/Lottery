using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LotteryNumberGenerator
{
    public partial class Form1 : Form
    {
        private static ArrayList myList = new ArrayList();
        private static Random rand = new Random();
        private static String genNums;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDailyKeno_Click(object sender, EventArgs e)
        {
            generateNumbers("Daily Keno", 10, 80, 0);
            textBox1.Text = genNums;
        }

        private void btnHit5_Click(object sender, EventArgs e)
        {
            generateNumbers("Hit 5", 5, 39, 0);
            textBox1.Text = genNums;
        }

        private void btnLotto_Click(object sender, EventArgs e)
        {
            generateNumbers("Lotto", 6, 49, 0);
            textBox1.Text = genNums;
        }

        private void btnMatch4_Click(object sender, EventArgs e)
        {
            generateNumbers("Match 4", 4, 24, 0);
            textBox1.Text = genNums;
        }

        private void butnMegaMillions_Click(object sender, EventArgs e)
        {
            generateNumbers("Mega Millions", 5, 75, 15);
            textBox1.Text = genNums;
        }

        private void btnPowerball_Click(object sender, EventArgs e)
        {
            generateNumbers("Powerball", 5, 69, 26);
            textBox1.Text = genNums;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        // takes a name of the lottery, the number of random numbers to generate,
        // the ceiling number to generate, and the ceiling number for an extra ball
        // as parameters
        // generates a count of numbers, specified by the range, adds each one generated
        // to a list, excluding duplicates, also predicts the extra ball if necessary
        // prints out the numbers generated
        // resets the list to an empty one after the numbers get printed
        private static void generateNumbers(String name, int count, int lim1, int lim2)
        {
            for (int i = 0; i < count; i++)
            {
                int num1 = rand.Next(1, lim1 + 1);
                if (!myList.Contains(num1))
                    myList.Add(num1);
                else
                    i--;
            }
            if (lim2 > 0)
            {
                int num2 = rand.Next(1, lim2 + 1);
                genNums = name + ": " + arrayListToString(myList) + " [ " + num2 + " ]";
            }
            else
            {
                genNums = name + ": " + arrayListToString(myList);
            }
            myList.Clear();
        }

        private static String arrayListToString(ArrayList list)
        {
            list.Sort();
            String s = "[ ";
            foreach (Object o in list)
            {
                s += o + " ";
            }
            s += "]";
            return s;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnReset_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(1);
            f2.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(2);
            f2.ShowDialog();
        }
    }
}
