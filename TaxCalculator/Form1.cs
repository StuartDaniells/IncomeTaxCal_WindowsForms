using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // exits the form when exit button or hot key (alt + x) is clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * Summary: calculates the tax value based on the income
         * @params income - only one parameter for this method of type decimal
         * @return - returns the calculated decimal tax value of type decimal
         */
        private static decimal CalculateTax(decimal income)
        {
            decimal tax = 0m;

            if (income <= 9225)
                tax = (int)(income * .10m);
            else if (income > 9225 && income <= 37450)
                tax = 922.50m + (int)((income - 9225) * .15m);
            else if (income > 37450 && income <= 90750)
                tax = 5156.25m + (int)((income - 37450) * .25m);
            else if (income > 90750 && income <= 189300)
                tax = 18481.25m + (int)((income - 90750) * .28m);
            else if (income > 189300 && income <= 411500)
                tax = 46075.25m + (int)((income - 189300) * .33m);
            else if (income > 411500 && income <= 413200)
                tax = 119401.25m + (int)((income - 411500) * .35m);
            else if (income > 413200)
                tax = 119996.25m + (int)((income - 413200) * .396m);

            return tax;
        }

        // on button click runs the CalculateTax method and displays the results
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Exception handling for format type, overflow and any other type
            try
            {
                decimal income = Convert.ToDecimal(txtIncome.Text);

                decimal tax = CalculateTax(income);

                txtTax.Text = tax.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Invalid numeric format. Please check all entries.",
                    "Entry Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "Overflow error. Please enter smaller values.",
                    "Entry Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                ex.GetType().ToString() + "\n" +
                ex.StackTrace, "Exception");
            }
        }

        // cleares 'income tax owed' text box when 'taxable income' test box values are entered
        private void ClearTextBox(object sender, EventArgs e)
        {
            txtTax.Clear();
        }
    }
}
