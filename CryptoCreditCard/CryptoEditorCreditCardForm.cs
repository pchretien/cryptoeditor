using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoEditor.CreditCard
{
    public partial class CryptoEditorCreditCardForm : Form
    {
        private CryptoEditorCreditCardItem item;

        public CryptoEditorCreditCardForm(CryptoEditorCreditCardItem item)
        {
            this.item = item;
            InitializeComponent();

            for (int i = 2010; i <= 2050; i++)
            {
                year.Items.Add(i);
            }

            creditcard.Text = item.Type;
            name.Text = item.Name;
            company.Text = item.Company;
            notes.Text = item.Notes;
            number.Text = item.Number;
            verification.Text = item.Security;
            month.Text = item.ExpMonth;
            year.Text = item.ExpYear;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            item.Type = creditcard.Text;
            item.Name = name.Text;
            item.Company = company.Text;
            item.Notes = notes.Text;
            item.Number = number.Text;
            item.Security = verification.Text;
            item.ExpMonth = month.Text;
            item.ExpYear = year.Text;

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
