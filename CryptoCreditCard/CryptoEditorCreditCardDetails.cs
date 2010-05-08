using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.CreditCard
{
    public partial class CryptoEditorCreditCardDetails : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private CryptoEditorCreditCardItem item = null;

        public CryptoEditorCreditCardDetails(ICryptoEditor plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        public virtual ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public virtual void DisplayItem(object itemIn)
        {
            item = (CryptoEditorCreditCardItem)itemIn;

            creditcard.Text = "";
            name.Clear();
            name2.Clear();
            company.Clear();
            number.Clear();
            verification.Clear();
            month.Text = "";
            year.Text = "";
            notes.Clear();
            
            BringToFront();

            if (item == null)
            {
                this.Enabled = false;
                return;
            }

            this.Enabled = true;

            // Fill in fields ...
            creditcard.Text = item.Type;
            name.Text = item.Name;
            name2.Text = item.Name2;
            company.Text = item.Company;
            number.Text = item.Number;
            verification.Text = item.Security;
            month.Text = item.ExpMonth;
            year.Text = item.ExpYear;
            notes.Text = item.Notes;
        }

        private void notes_Validated(object sender, EventArgs e)
        {
            if (!item.Notes.Equals(notes.Text))
            {
                item.Notes = notes.Text;
                item.Update();
                plugin.SetChanged();
            }
        }
    }
}
