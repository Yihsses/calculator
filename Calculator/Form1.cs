using Calculator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{


    public partial class Form1 : Form
    {
        Calcula calcula = new Calcula();
        bool judge_merge = false;
        string formula = ""; 
        public Form1()
        {
            InitializeComponent();
        }
        private void number_Click(object sender, EventArgs e)
        {

            if(calcula.Judge_last_operator() == true || label1.Text == "0")
            {
                label1.Text = (sender as Button).Text;
            }
            else
            {
                //label1.Location = new Point(label1.Location.X - 9, label1.Location.Y);
                label1.Text += (sender as Button).Text;
            }
            if (calcula.formula_list[calcula.formula_list.Count()-1].Length == 1 && calcula.formula_list[calcula.formula_list.Count() - 1] == "0")
            {
                calcula.formula_list[calcula.formula_list.Count() - 1] = (sender as Button).Text;

            }
            else
            {
                calcula.formula_list[calcula.formula_list.Count() - 1] += (sender as Button).Text;

            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {

            if ((sender as Button).Text != "=")
            {
                calcula.add_formula_operator((sender as Button).Text); 
               // calcula.formula += (sender as Button).Text;
            }
            else
            {
                label1.Text =  calcula.Cal().ToString();
                calcula.formula = label1.Text; 
              //  label1.Location =  new Point( 215-9*label1.Text.Length , label1.Location.Y);

            }
        }


        private void clean(object sender, EventArgs e)
        {
            calcula.formula_list.Clear();
            calcula.formula_list.Add("0"); 
            label1.Text = "0";
            judge_merge = false; 

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void dot_Click(object sender, EventArgs e)
        {

            if (calcula.formula_list[calcula.formula_list.Count()-1].Contains(".") == false)
            {
                calcula.add_dot();
                label1.Text += (sender as Button).Text;
            }

        }

        private void Clear_Entry(object sender, EventArgs e)
        {
            calcula.Clear_Entry();
            label1.Text = "0"; 
        }

        private void Memory_Recall(object sender, EventArgs e)
        {
            label1.Text = calcula.memory_formula;
            calcula.memory_recall(); 
        }

        private void Memory_Plus(object sender, EventArgs e)
        {
            MC.Enabled = true;
            MR.Enabled = true;
            calcula.memory_plus(label1.Text); 
        }

        private void Memory_Minus(object sender, EventArgs e)
        {
            MC.Enabled = true;
            MR.Enabled = true;
            calcula.memory_minus(label1.Text);
        }

        private void Memory_Clear(object sender, EventArgs e)
        {
            calcula.memory_clear();
            MC.Enabled = false;
            MR.Enabled = false; 
        }

        private void memory_replace(object sender, EventArgs e)
        {
            calcula.memory_formula = label1.Text; 
        }
    }
}
