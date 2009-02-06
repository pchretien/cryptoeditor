using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.License
{
    public partial class CryptoLicenseDetail : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private CryptoLicenseItem item = null;

        public CryptoLicenseDetail(ICryptoEditor plugin)
        {
            this.plugin = plugin;
            InitializeComponent();
        }

        #region ICryptoEditorDetail Members

        public virtual ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public virtual void DisplayItem(object item)
        {
            this.item = (CryptoLicenseItem) item;

            if (item == null)
            {
                this.licenseName2.Clear();
                this.licenseEmail.Clear();
                this.licenseKey.Clear();
                this.licenseName.Clear();
                this.licenseNotes.Clear();
                this.productCompany.Clear();
                this.productName.Clear();
                this.productWebsite.Clear();
                
                this.Enabled = false;
            }
            else
            {
                this.licenseName2.Text = this.item.LicenseKeyUser2;
                this.licenseEmail.Text = this.item.LicenseKeyEmail;
                this.licenseKey.Text = this.item.LicenseKey;
                this.licenseName.Text = this.item.LicenseKeyUser;
                this.licenseNotes.Text = this.item.Notes;
                this.productCompany.Text = this.item.Company;
                this.productName.Text = this.item.ProductName;
                this.productWebsite.Text = this.item.ProductWebsite;
                
                this.Enabled = true;
            }

            BringToFront();
        }

        #endregion

        private void licenseNotes_Validated(object sender, EventArgs e)
        {
            if (!item.Notes.Equals(licenseNotes.Text))
            {
                item.Notes = licenseNotes.Text;
                item.Update();
                plugin.SetChanged();
            }
        }
    }
}
