using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCak
{

    public partial class MainForm : Form
    {
        private string formula;
        public MainForm()
        {
            InitializeComponent();

            btOne.Click += BtCommon_Click;
            btTwo.Click += BtCommon_Click;
            btThree.Click += BtCommon_Click;
            btFour.Click += BtCommon_Click;
            btFive.Click += BtCommon_Click;
            btSix.Click += BtCommon_Click;
            btSeven.Click += BtCommon_Click;
            btEight.Click += BtCommon_Click;
            btNine.Click += BtCommon_Click;
            btZero.Click += BtCommon_Click;
            btPlus.Click += BtCommon_Click;
            btMinus.Click += BtCommon_Click;
            btMultiply.Click += BtCommon_Click;
            btDivision.Click += BtCommon_Click;
            btPercentage.Click += BtCommon_Click;
            btFloat.Click += BtCommon_Click;

            btRemoveAll.Click += BtRemoveAll_Click;

            btResult.Click += BtResult_Click;
        }

        private void BtResult_Click(object sender, EventArgs e)
        {
            string result = TbResult.Text;


            //if (result.Contains("*"))
            //{
            //    TbResult.Text = Mul(result.Split('*')[0], result.Split('*')[1]).ToString();
            //}
            //if (result.Contains("÷"))
            //{
            //    TbResult.Text = Div(result.Split('÷')[0], result.Split('÷')[1]).ToString();
            //}
            //if (result.Contains("+"))
            //{
            //    TbResult.Text = Plus(result.Split('+')[0], result.Split('+')[1]).ToString();
            //}
            //if (result.Contains("-"))
            //{
            //    TbResult.Text = Minus(result.Split('-')[0], result.Split('-')[1]).ToString();
            //}

            //만약에 *가 있으면 앞뒤로 분리하여 값을 곱한다
            //만약에 *, +가 있으면 *앞뒤로 분리하여 값을 
            decimal mul_result;
            string mul_f;
            string mul_b;

            decimal div_result;
            string div_f;
            string div_b;

            decimal plus_result;
            string plus_f;
            string plus_b;

            decimal minus_result;
            string minus_f;
            string minus_b;

            //함수로 만들어서 해보기
            
            //추가 필요. +를 포함하지 않고 다른 연산자를 포함하는 경우 추가 필요
            if (result.Contains("+"))
            {
                plus_f = result.Split('+')[0];

                if (plus_f.Contains("*"))
                //*포함하지않고도 진행할 수 있도록 추가 필요
                {
                    mul_f = plus_f.Split('*')[0];
                    if (mul_f.Contains("÷"))
                    {
                        div_f = mul_f.Split('÷')[0];
                        div_b = mul_f.Split('÷')[1];
                        div_result = Div(div_f, div_b);
                        mul_f = div_result.ToString();
                        div_result = 0;
                    }
                    mul_b = plus_f.Split('*')[1];
                    if (mul_b.Contains("÷"))
                    {
                        div_f = mul_b.Split('÷')[0];
                        div_b = mul_b.Split('÷')[1];
                        div_result = Div(div_f, div_b);
                        mul_b = div_result.ToString();
                    }
                    mul_result = Mul(mul_f, mul_b);
                    plus_f = mul_result.ToString();
                }
                //if (!plus_f.Contains("*") && plus_f.Contains('÷'))

                plus_b = result.Split('+')[1];
                if (plus_b.Contains("*"))
                {
                    mul_f = plus_b.Split('*')[0];
                    if (mul_f.Contains("÷"))
                    {
                        div_f = mul_f.Split('÷')[0];
                        div_b = mul_f.Split('÷')[1];
                        div_result = Div(div_f, div_b);
                        mul_f = div_result.ToString();
                    }
                    mul_b = plus_b.Split('*')[1];
                    if (mul_b.Contains("÷"))
                    {
                        div_f = mul_b.Split('÷')[0];
                        div_b = mul_b.Split('÷')[1];
                        div_result = Div(div_f, div_b);
                        mul_b = div_result.ToString();
                    }
                    mul_result = Mul(mul_f, mul_b);
                    plus_f = mul_result.ToString();
                }

                plus_result = Plus(plus_f, plus_b);
                TbResult.Text = plus_result.ToString();
            }


            if (result.Contains("*") && !result.Contains("+"))
            {
                mul_f = result.Split('*')[0];
                if (mul_f.Contains("÷"))
                {
                    div_f = mul_f.Split('÷')[0];
                    div_b = mul_f.Split('÷')[1];
                    div_result = Div(div_f, div_b);
                    mul_f = div_result.ToString();
                    div_result = 0;
                }
                mul_b = result.Split('*')[1];
                if (mul_b.Contains("÷"))
                {
                    div_f = mul_b.Split('÷')[0];
                    div_b = mul_b.Split('÷')[1];
                    div_result = Div(div_f, div_b);
                    mul_b = div_result.ToString();
                }
                mul_result = Mul(mul_f, mul_b);
                TbResult.Text = mul_result.ToString();
            }

            //복습 필요!
            // 2+3*4 = 14
            // 12345
            // 숫자는 홀수
            // 연산자는 짝수
            // 연산자의 갯수는 숫자의 갯수-1
            // [숫자]는 0,1,2,3,4,5,6,7,8,9 중 하나 이상을 반드시 포함하는 문자다
            // 연산자는 [숫자]에 포함되지 않는 모든 문자열이다.

            //public void Calc(string formula)
            //{
            //    // formula : 2+3*4

            //    char[] formulas = formula.ToCharArray();
            //    //formulas[0];
            //    //formulas[0 + 2];
            //    //formulas[0 + 2 + 2];
            //    //formulas[1];
            //    //formulas[1 + 2];

            //    List<int> numbers = new List<int>();
            //    List<string> oper = new List<string>();

            //    for (int i = 0; i < formulas.Length / 2 + 1; i += 2)
            //    {
            //        numbers.Add(int.Parse(formulas[i].ToString()));
            //    }

            //    for (int i = 1; i < formulas.Length / 2; i += 2)
            //    {
            //        oper.Add(formulas[i].ToString());
            //    }

            //    int temp = 0;

            //    for (int i = 0; i < oper.Count; i++)
            //    {
            //        if ("*" == (oper[i]))
            //        {
            //            temp = mul(numbers[i], numbers[i + 1]);
            //            oper.RemoveAt(i);
            //            numbers.RemoveAt(i);
            //            numbers.RemoveAt(i + 1);
            //            break;
            //        }

            //        if ("/" == (oper[i]))
            //        {
            //            temp = div(numbers[i], numbers[i + 1]);
            //            oper.RemoveAt(i);
            //            numbers.RemoveAt(i);
            //            numbers.RemoveAt(i + 1);
            //            break;
            //        }
            //    }
            //    for (int i = 0; i < oper.Count; i++)
            //    {
            //        if (numbers.Count < 2)
            //        {
            //            if (oper[i] == "+")
            //            {
            //                temp = plus(numbers[i], temp);
            //            }

            //            if (oper[i] == "-")
            //            {
            //                temp = minus(numbers[i], temp);
            //            }
            //        }
            //    }
            //}

            //private int plus(int first, int second)
            //{
            //    return first + second;
            //}

            //private int minus(int first, int second)
            //{
            //    return first - second;
            //}

            //private int div(int first, int second)
            //{
            //    return first / second;
            //}

            //private int mul(int first, int second)
            //{
            //    return first * second;
            //}


        }

        private decimal Plus(string first, string second)
        {
            return decimal.Parse(first) + decimal.Parse(second);
        }
        private decimal Minus(string first, string second)
        {
            return decimal.Parse(first) - decimal.Parse(second);
        }
        private decimal Div(string first, string second)
        {
            return decimal.Parse(first) / decimal.Parse(second);
        }
        private decimal Mul(string first, string second)
        {
            return decimal.Parse(first) * decimal.Parse(second);
        }


        private void BtRemoveAll_Click(object sender, EventArgs e)
        {
            formula = "";
            TbResult.Text = formula;
        }

        private void BtCommon_Click(object sender, EventArgs e)
        {
            formula += ((Button)sender).Text;
            TbResult.Text = formula;
        }
    }
}
