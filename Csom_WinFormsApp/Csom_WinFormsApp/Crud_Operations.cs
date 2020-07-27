using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using Microsoft.SharePoint.Client;

namespace Csom_WinFormsApp
{
    public partial class Crud_Operations : System.Windows.Forms.Form
    {
        public Crud_Operations()
        {
            InitializeComponent();
        }
        string userName = "user@o365boss.onmicrosoft.com";
        SecureString password = getPassword("Octopus@321");

        private static SecureString getPassword(string v)
        {
            SecureString _tPassword = new SecureString();
            foreach (char c in v)
            {
                _tPassword.AppendChar(c);
            }
            return _tPassword;
        }

        string webUrl = @"https://o365boss.sharepoint.com/sites/MO";




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ClientContext(webUrl))
                {
                    context.Credentials = new SharePointOnlineCredentials(userName, password);
                    List GList = context.Web.Lists.GetByTitle("Guawa");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem newItem = GList.AddItem(itemCreateInfo);
                    newItem["Title"] = txtTitle.Text;
                    newItem["PINcode"] = txtPinCode.Text;
                    newItem.Update();
                    context.ExecuteQuery();
                    button1.BackColor = System.Drawing.Color.GreenYellow;
                }
            }
            catch (Exception ex)
            {
                button1.BackColor = System.Drawing.Color.Red;
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
