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


            if (result.Contains("+"))
            {
                TbResult.Text = Plus(result.Split('+')[0], result.Split('+')[1]).ToString();
            }
            if (result.Contains("-"))
            {
                TbResult.Text = Minus(result.Split('-')[0], result.Split('-')[1]).ToString();
            }
            if (result.Contains("*"))
            {
                TbResult.Text = Mul(result.Split('*')[0], result.Split('*')[1]).ToString();
            }
            if (result.Contains("÷"))
            {
                TbResult.Text = Div(result.Split('÷')[0], result.Split('÷')[1]).ToString();
            }
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
