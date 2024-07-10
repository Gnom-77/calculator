using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Сalculator
{
    public partial class Form1 : Form
    {
        private string arithmetic_operation;
        private string number1;
        private bool check_for_action;
        private bool numer = false;
        private bool skip = false;
        private int exit = 0;
        public Form1()
        {
            check_for_action = false;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == 'I' || textBox1.Text[i] == 'V' || textBox1.Text[i] == 'X' || textBox1.Text[i] == 'L' || textBox1.Text[i] == 'C' || textBox1.Text[i] == 'D' || textBox1.Text[i] == 'M')
                {
                    count++;
                }
            }
            bool isNumber = int.TryParse(textBox1.Text, out int numericValue);
            if (isNumber == false)
            {
                if(count== textBox1.Text.Length)
                {
                    textBox1.Text = decimalization(textBox1.Text).ToString();
                    numer = true;
                }
                else
                {
                    exit += 1;
                    MessageBox.Show($"Я, конечно, не грек, но что-то тут не так.\nЗа работу программы вы вызвали ошибку {exit} раз.\n\t\tМолодец!!!");
                    textBox1.Text = "";
                }
                    
            }
            else
            {
                textBox1.Text = conversion_to_Roman_numeral_system(Convert.ToInt32(textBox1.Text));
                numer = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (check_for_action)
            {
                check_for_action = false;
                textBox1.Text = "";
            }
            Button B = (Button)sender;
            textBox1.Text = textBox1.Text + B.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            arithmetic_operation = B.Text;
            number1 = textBox1.Text;
            check_for_action = true;
            textBox1.Text = "";
        }

        private bool chek(string number)
        {
            bool answer = true;
            int chek_kount = decimalization(number);
            bool ch = true, vvodxz = false;
            if (number == null)
                vvodxz = true;
            if (vvodxz == false)
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == 'I' || number[i] == 'V' || number[i] == 'X' || number[i] == 'L' || number[i] == 'C' || number[i] == 'D' || number[i] == 'M')
                        ch = true;
                    else
                    {
                        ch = false;
                        break;
                    }
                }
                string numb = number + " ";
                int count = 0;
                char repetition;
                for (int i = 0; i < numb.Length - 1; i++)
                {
                    repetition = numb[i];
                    if (numb[i + 1] == repetition)
                    {
                        count++;
                        repetition = numb[i];
                        if (count > 3)
                            answer = false;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if ((chek_kount > 3999 || ch == false) && chek_kount > -1)
                {
                    answer = false;
                }
                int count1 = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == 'I' || number[i] == 'V' || number[i] == 'X' || number[i] == 'L' || number[i] == 'C' || number[i] == 'D' || number[i] == 'M')
                    {
                        count1++;
                    }
                }
                bool isNumber = int.TryParse(number, out int numericValue);
                if (isNumber == false)
                {
                    if (count1 != number.Length)
                    {
                        answer = false;
                    }

                }
                return answer;
            }
            else 
                return false;
            
        }
        private bool chekResult(int number)
        {
            bool answer = true;
            if (number > 3999)
            {
                answer = false;
            }
            else if (number < 0)
            {
                answer = false;
            }
            return answer;
        }
        private string conversion_to_Roman_numeral_system(int number)
        {
            if (number == 0) return "N";

            int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numerals = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    result.Append(numerals[i]);
                }
            }
            return result.ToString();
        }
        private int decimalization(string number)
        {

            int count = 0;
            skip = false;
            string numb = number + " ";
            char repetition;
            for (int i = 0; i < numb.Length - 1; i++)
            {
                repetition = numb[i];
                if (numb[i + 1] == repetition)
                {
                    count++;
                    repetition = numb[i];
                    if (count >= 3)
                    {
                        exit += 1;
                        MessageBox.Show($"Я, конечно, не грек, но что-то тут не так.\nЗа работу программы вы вызвали ошибку {exit} раз.\n\t\tМолодеч!!!");
                        check_for_action = true;
                        numer = false;
                        arithmetic_operation = "=";
                        textBox1.Text = "N";
                        skip = true;

                        break;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            if(skip == false)
            {
                string ResNumber = " " + number + " ";
                int int_number = 0;
                for (int i = 1; i < ResNumber.Length - 1; i++)
                {
                    if (ResNumber[i] == 'M' && ResNumber[i - 1] != 'C')
                    {
                        int_number += 1000;
                    }
                    else if (ResNumber[i] == 'M' && ResNumber[i - 1] == 'C')
                    {
                        int_number += 900;
                    }
                    else if (ResNumber[i] == 'D' && ResNumber[i - 1] != 'C')
                    {
                        int_number += 500;
                    }
                    else if (ResNumber[i] == 'D' && ResNumber[i - 1] == 'C')
                    {
                        int_number += 400;
                    }
                    else if (ResNumber[i] == 'C' && ResNumber[i - 1] != 'X' && ResNumber[i + 1] != 'D' && ResNumber[i + 1] != 'M')
                    {
                        int_number += 100;
                    }
                    else if (ResNumber[i] == 'C' && ResNumber[i - 1] == 'X' && ResNumber[i + 1] != 'D' && ResNumber[i + 1] != 'M')
                    {
                        int_number += 90;
                    }
                    else if (ResNumber[i] == 'L' && ResNumber[i - 1] != 'X')
                    {
                        int_number += 50;
                    }
                    else if (ResNumber[i] == 'L' && ResNumber[i - 1] == 'X')
                    {
                        int_number += 40;
                    }

                    //
                    else if (ResNumber[i] == 'X' && ResNumber[i - 1] != 'I' && ResNumber[i + 1] != 'C' && ResNumber[i + 1] != 'L')
                    {
                        int_number += 10;
                    }
                    else if (ResNumber[i] == 'X' && ResNumber[i - 1] == 'I')
                    {
                        int_number += 9;
                    }
                    else if (ResNumber[i] == 'V' && ResNumber[i - 1] != 'I')
                    {
                        int_number += 5;
                    }
                    else if (ResNumber[i] == 'V' && ResNumber[i - 1] == 'I')
                    {
                        int_number += 4;
                    }

                    else if (ResNumber[i] == 'I' && ResNumber[i + 1] != 'X' && ResNumber[i + 1] != 'V')
                    {
                        int_number += 1;
                    }
                }
                if(int_number < 4000)
                    return int_number;
                else
                    return 0;
            }
            else
            {
                return 0;
            }

        }
        private void button15_Click(object sender, EventArgs e)
        {
            
            int count1 = decimalization(number1), count2 = decimalization(textBox1.Text), result = 0;
            
            bool operationBool, proov = false;
            string replica = arithmetic_operation;
            if (chek(number1) == true && chek(textBox1.Text) == true)
            {
                if (arithmetic_operation == "+")
                {
                    result = count1 + count2;
                }
                if (arithmetic_operation == "-")
                {
                    result = count1 - count2;
                }
                if (arithmetic_operation == "x")
                {
                    result = count1 * count2;
                }
                if (arithmetic_operation == "div")
                {
                    result = count1 / count2;
                }
                if (arithmetic_operation == "mod")
                {
                    result = count1 % count2;
                }
                if (arithmetic_operation == ">")
                {
                    if (count1 > count2)
                    {
                        operationBool = true;
                    }
                    else
                    {
                        operationBool = false;
                    }
                    proov = true;
                    textBox2.Text = number1 + " " + replica + " " + textBox1.Text;
                    textBox1.Text =  operationBool.ToString();
                    check_for_action = true;
                    numer = false;
                    arithmetic_operation = "=";
                    proov = true;
                }
                if (arithmetic_operation == "<")
                {
                    if (count1 < count2)
                    {
                        operationBool = true;
                    }
                    else
                    {
                        operationBool = false;
                    }
                    proov = true;
                    textBox2.Text = number1 + " " + replica + " " + textBox1.Text;
                    textBox1.Text = operationBool.ToString();
                    check_for_action = true;
                    numer = false;
                    arithmetic_operation = "=";
                    proov = true;
                }
                if (proov == false)
                {
                    if (((chek(number1) == false || chek(textBox1.Text) == false || chekResult(result) == false) && skip == true) || chekResult(result) == false)
                    {
                        exit += 1;
                        MessageBox.Show($"Я, конечно, не грек, но что-то тут не так.\nЗа работу программы вы вызвали ошибку {exit} раз.\n\t\tМолодеч!!!");
                        check_for_action = true;
                        numer = false;
                        arithmetic_operation = "=";
                        textBox1.Text = "N";
                        proov = true;
                        skip = false;
                    }
                    else
                    {
                        string print;
                        print = conversion_to_Roman_numeral_system(result);
                        check_for_action = true;
                        numer = false;
                        arithmetic_operation = "=";
                        textBox2.Text = number1 + " " + replica + " " + textBox1.Text + " = " + print;
                        textBox1.Text = print;
                        proov = true;
                    }
                }
            }
            else
            {
                exit += 1;
                MessageBox.Show($"Я, конечно, не грек, но что-то тут не так.\nЗа работу программы вы вызвали ошибку {exit} раз.\n\t\tМолодеч!!!");
                textBox1.Text = "";
            }
        }
            
            

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if (textBox1.Text == "")
            {
                check_for_action = true;
                numer = false;
                textBox1.Text = "N";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            arithmetic_operation = B.Text;
            number1 = textBox1.Text;
            check_for_action = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}