using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        enum ArgType { Undefined, Integer, Float, Bool, Incorrect}
        int arg1_int, arg2_int;
        double arg1_float, arg2_float;
        bool arg1_bool, arg2_bool;
        ArgType curentType = ArgType.Undefined;
        byte operationNeedArgs = 0;
        int incorrectArgNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        bool getArgs()
        {
            string s1 = textBox1.Text.Trim(), s2 = textBox2.Text.Trim();
            curentType = ArgType.Incorrect;
            if(operationNeedArgs == 2)
            {
                if(s1=="" || s2 == "")
                {
                    curentType = ArgType.Undefined;
                    incorrectArgNum = s1 == "" ? 1 : 2;
                    MessageBox.Show("Пустое поле ввода! Аргумент № "+ incorrectArgNum + " не может быть пустым.",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if(bool.TryParse(s1, out arg1_bool) && bool.TryParse(s2, out arg2_bool))
                {
                    curentType = ArgType.Bool; return true;
                }
                if (int.TryParse(s1, out arg1_int) && int.TryParse(s2, out arg2_int))
                {
                    curentType = ArgType.Integer; return true;
                }
                if (double.TryParse(s1, out arg1_float) && double.TryParse(s2, out arg2_float))
                {
                    curentType = ArgType.Float; return true;
                }

                if(bool.TryParse(s1, out arg1_bool) || int.TryParse(s1, out arg1_int)||double.TryParse(s1, out arg1_float))
                {
                    MessageBox.Show("Аргумент № 2 некорректен! Он не совпадает по типу с первым или не является допустимым типом (число или значение \"true\" или \"false\")!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Аргумент № 1 некорректен! Он должен быть числом или значением \"true\" или \"false\"",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (s1 == "")
                {
                    curentType = ArgType.Undefined;
                    incorrectArgNum = 1;
                    MessageBox.Show("Пустое поле ввода! Аргумент № 1 не может быть пустым!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (bool.TryParse(s1, out arg1_bool))
                {
                    curentType = ArgType.Bool; return true;
                }
                if (int.TryParse(s1, out arg1_int))
                {
                    curentType = ArgType.Integer; return true;
                }
                if (double.TryParse(s1, out arg1_float))
                {
                    curentType = ArgType.Float; return true;
                }
                MessageBox.Show("Аргумент № 1 некорректен! Он должен быть числом или значением \"true\" или \"false\"",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        //Sum
        private void button1_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(arg1_float + arg2_float, "+");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int + arg2_int, "+");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //Minus
        private void button2_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(arg1_float - arg2_float, "-");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int - arg2_int, "-");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //Multiply
        private void button3_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(arg1_float * arg2_float, "*");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int * arg2_int, "*");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //Divide
        private void button4_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        if(arg2_float == 0)
                        {
                            MessageBox.Show("Делить на 0 нельзя!", "Пользователь дурак!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        drawResult(arg1_float / arg2_float, "/");
                        break;
                    case ArgType.Integer:
                        if (arg2_int == 0)
                        {
                            MessageBox.Show("Делить на 0 нельзя!", "Пользователь дурак!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        drawResult(arg1_int / arg2_int, "/");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //residue
        private void button5_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        if (arg2_float == 0)
                        {
                            MessageBox.Show("Делить на 0 нельзя!", "Пользователь дурак!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        drawResult(arg1_float % arg2_float, "%");
                        break;
                    case ArgType.Integer:
                        if (arg2_int == 0)
                        {
                            MessageBox.Show("Делить на 0 нельзя!", "Пользователь дурак!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        drawResult(arg1_int % arg2_int, "%");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //And
        private void button6_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Bool :
                        drawResult(arg1_bool && arg2_bool, "&");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int & arg2_int, "&");
                        break;
                    case ArgType.Float:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к дробным числам!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //or
        private void button7_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Bool:
                        drawResult(arg1_bool || arg2_bool, "|");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int | arg2_int, "|");
                        break;
                    case ArgType.Float:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к дробным числам!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //xor
        private void button8_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Bool:
                        drawResult(arg1_bool ^ arg2_bool, "^");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int ^ arg2_int, "^");
                        break;
                    case ArgType.Float:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к дробным числам!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //Not
        private void button9_Click(object sender, EventArgs e)
        {
            {
                operationNeedArgs = 1;
                if (getArgs())
                {
                    switch (curentType)
                    {
                        case ArgType.Bool:
                            drawResult(!arg1_bool, "!");
                            break;
                        case ArgType.Integer:
                            drawResult(~arg1_int, "~");
                            break;
                        case ArgType.Float:
                            MessageBox.Show("Некорректные аргументы! Невозможно применить к дробным числам!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }
        //>
        private void button10_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(arg1_float > arg2_float, ">");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int > arg2_int, ">");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //<
        private void button11_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(arg1_float < arg2_float, "<");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int < arg2_int, "<");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //>=
        private void button12_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(arg1_float >= arg2_float, ">=");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int >= arg2_int, ">=");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //<=
        private void button13_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(arg1_float <= arg2_float, "<=");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int <= arg2_int, "<=");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //==
        private void button14_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 2;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(arg1_float == arg2_float, "==");
                        break;
                    case ArgType.Integer:
                        drawResult(arg1_int == arg2_int, "==");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //x^5? 
        private void button15_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 1;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        if (arg1_float <= 0 ||
                            (ulong)arg1_float != arg1_float)
                        {

                            listBox1.Items.Add(arg1_float.ToString() + "^5 ? = False");
                            return;
                        }
                        bool c = true;
                        double t = arg1_float, s = 0;
                        while (t > 0 && c)
                        {
                            if (t % 5 != 0)
                            {
                                if (((int)t / 5) != 0 || t !=1)
                                {
                                    c = false;
                                    break;
                                }
                                else break;
                            }
                            s++;
                            t /= 5;
                        }
                        string str = (arg1_float.ToString()) + "^5 ? = " + c;
                        str += c ? " log(" + arg1_float + ") = " + s : "";
                        listBox1.Items.Add(str);
                        break;
                    case ArgType.Integer:
                        if (arg1_int <= 0)
                        {

                            listBox1.Items.Add(arg1_int.ToString() + "^5 ? = False");
                            return;
                        }
                        c = true;
                        int ti = arg1_int, si = 0;
                        while (ti > 0 && c)
                        {
                            if (ti % 5 != 0)
                            {
                                if (ti / 5 != 0 || ti!=1)
                                {
                                    c = false;
                                    break;
                                }if (ti == 1)
                                    break;
                            }
                            si++;
                            ti /= 5;
                        }
                        string stri = (arg1_int.ToString()) + "^5 ? = " + c;
                        stri += c ? " log(" + arg1_int + ") = " + si : "";
                        listBox1.Items.Add(stri);
                        break;
                    default:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                
            }
        }
        //arctg
        private void button16_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 1;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(Math.Atan(arg1_float), "Arctan");
                        break;
                    case ArgType.Integer:
                        drawResult(Math.Atan(arg1_int), "Arctan");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //arccos
        private void button17_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 1;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(Math.Acos(arg1_float), "Arccos");
                        break;
                    case ArgType.Integer:
                        drawResult(Math.Acos(arg1_int), "Arccos");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //ln
        private void button18_Click(object sender, EventArgs e)
        {
            operationNeedArgs = 1;
            if (getArgs())
            {
                switch (curentType)
                {
                    case ArgType.Float:
                        drawResult(Math.Log(arg1_float), "Ln");
                        break;
                    case ArgType.Integer:
                        drawResult(Math.Log(arg1_int), "Ln");
                        break;
                    case ArgType.Bool:
                        MessageBox.Show("Некорректные аргументы! Невозможно применить к логическим значениям!",
                        "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        //chenging texts
        private void button21_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = s;
        }
        //clear
        private void button19_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        //dell
        private void button20_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
        //add to one
        private void button22_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                if (listBox1.SelectedItem == null)
                {
                    string s = listBox1.Items[listBox1.Items.Count - 1] as string;
                    s = s.Substring(s.LastIndexOf(' ') + 1);
                    textBox1.Text = s;
                }
                else
                {
                    string s = listBox1.Items[listBox1.SelectedIndex] as string;
                    s = s.Substring(s.LastIndexOf(' ') + 1);
                    textBox1.Text = s;
                }
            }  
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                if (listBox1.SelectedItem == null)
                {
                    string s = listBox1.Items[listBox1.Items.Count - 1] as string;
                    s = s.Substring(s.LastIndexOf(' ') + 1);
                    textBox2.Text = s;
                }
                else
                {
                    string s = listBox1.Items[listBox1.SelectedIndex] as string;
                    s = s.Substring(s.LastIndexOf(' ') + 1);
                    textBox2.Text = s;
                }
            }
        }
        #region drawing
        private void drawResult(bool v, string sign)
        {
            switch (curentType)
            {
                case ArgType.Float:
                    listBox1.Items.Add(operationNeedArgs == 2 ?
                        arg1_float.ToString() + " " + sign + " " + arg2_float + " = " + v :
                        sign.ToString() + " " + arg1_float + " = " + v);
                    break;
                case ArgType.Integer:
                    listBox1.Items.Add(operationNeedArgs == 2 ?
                        arg1_int.ToString() + " " + sign + " " + arg2_int + " = " + v :
                        sign.ToString() + " " + arg1_int + " = " + v);
                    break;
                case ArgType.Bool:
                    listBox1.Items.Add(operationNeedArgs == 2 ?
                        arg1_bool.ToString() + " " + sign + " " + arg2_bool + " = " + v :
                        sign.ToString() + " " + arg1_bool + " = " + v);
                    break;
            }
        }

        private void drawResult(int v, string sign)
        {
            switch (curentType)
            {
                case ArgType.Float:
                    listBox1.Items.Add(operationNeedArgs == 2 ?
                        arg1_float.ToString() + " " + sign + " " + arg2_float + " = " + v :
                        sign.ToString() + " " + arg1_float + " = " + v);
                    break;
                case ArgType.Integer:
                    listBox1.Items.Add(operationNeedArgs == 2 ?
                        arg1_int.ToString() + " " + sign + " " + arg2_int + " = " + v :
                        sign.ToString() + " " + arg1_int + " = " + v);
                    break;
                case ArgType.Bool:
                    listBox1.Items.Add(operationNeedArgs == 2 ?
                        arg1_bool.ToString() + " " + sign + " " + arg2_bool + " = " + v :
                        sign.ToString() + " " + arg1_bool + " = " + v);
                    break;
            }
        }
        private void drawResult(double v, string sign)
        {
            switch (curentType)
            {
                case ArgType.Float:
                    listBox1.Items.Add(operationNeedArgs == 2 ?
                        arg1_float.ToString() + " " + sign + " " + arg2_float + " = " + v :
                        sign.ToString() + " " + arg1_float + " = " + v);
                    break;
                case ArgType.Integer:
                    listBox1.Items.Add(operationNeedArgs == 2 ?
                        arg1_int.ToString() + " " + sign + " " + arg2_int + " = " + v :
                        sign.ToString() + " " + arg1_int + " = " + v);
                    break;
                case ArgType.Bool:
                    listBox1.Items.Add(operationNeedArgs == 2 ?
                        arg1_bool.ToString() + " " + sign + " " + arg2_bool + " = " + v :
                        sign.ToString() + " " + arg1_bool + " = " + v);
                    break;
            }

        }
        #endregion
    }
}
