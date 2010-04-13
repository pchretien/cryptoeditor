using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditor.License
{
    [CryptoEditorPlugin("Licenses")]
    public class CryptoLicense : CryptoEditorPlugin<CryptoLicenseItem>
    {
        public CryptoLicense()
        {
            detail = new CryptoLicenseDetail(this);
        }

        /// <summary>
        /// You must override this method to create a new item for your plugin
        /// otherwise the base class will throw a NoImplementation exception
        /// </summary>
        public override object CreateItem()
        {
            //
            // A new form must be implemented by the user to get item details ...
            //
            CryptoLicenseEditionForm form = new CryptoLicenseEditionForm();
            if(form.ShowDialog() != DialogResult.OK)
                return null;

            CryptoLicenseItem item = new CryptoLicenseItem();
            item.Company = form.productCompany.Text;
            item.ProductName = form.productName.Text;
            item.ProductWebsite = form.productWebsite.Text;

            item.LicenseKey = form.licenseKey.Text;
            item.LicenseKeyUser2 = form.licenseCompany.Text;
            item.LicenseKeyEmail = form.licenseEmail.Text;
            item.LicenseKeyUser = form.licenseName.Text;

            item.Notes = form.licenseNotes.Text;

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoLicenseItem item = (CryptoLicenseItem)itemIn;

            CryptoLicenseEditionForm form = new CryptoLicenseEditionForm();
            form.productCompany.Text = item.Company;
            form.productName.Text = item.ProductName;
            form.productWebsite.Text = item.ProductWebsite;

            form.licenseKey.Text = item.LicenseKey;
            form.licenseCompany.Text = item.LicenseKeyUser2;
            form.licenseEmail.Text = item.LicenseKeyEmail;
            form.licenseName.Text = item.LicenseKeyUser;

            form.licenseNotes.Text = item.Notes;

            if (form.ShowDialog() != DialogResult.OK)
                return null;

            item.Company = form.productCompany.Text;
            item.ProductName = form.productName.Text;
            item.ProductWebsite = form.productWebsite.Text;

            item.LicenseKey = form.licenseKey.Text;
            item.LicenseKeyUser2 = form.licenseCompany.Text;
            item.LicenseKeyEmail = form.licenseEmail.Text;
            item.LicenseKeyUser = form.licenseName.Text;

            item.Notes = form.licenseNotes.Text;

            base.UpdateItem(item);
            return item;
        }

        public override bool IsSearchable()
        {
            return true;
        }
    }
}
