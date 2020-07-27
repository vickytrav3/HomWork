using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using System.Security;

namespace Csom_WinFormsApp
{
    public partial class CsomPrac : System.Windows.Forms.Form
    {
        public CsomPrac()
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

        string webUrl = "https://o365boss.sharepoint.com/sites/MO";
        private void CsomPrac_Load(object sender, EventArgs e)
        {
            StartPage();
            GetSPLists();
        }
        void StartPage()
        {
            using (var context = new ClientContext(webUrl))
            {
                context.Credentials = new SharePointOnlineCredentials(userName, password);
                context.Load(context.Web, web => web.Title);
                context.ExecuteQuery();
                lblSiteTitle.Text = context.Web.Title;
            }
        }
        void GetSPLists()
        {
            using (var context = new ClientContext(webUrl))
            {
                context.Credentials = new SharePointOnlineCredentials(userName, password);
                // The SharePoint web at the URL.
                Web web = context.Web;

                // Retrieve all lists from the server. 
                /*context.Load(web.Lists,
                             lists => lists.Include(list => list.Title, 
                                                    list => list.Id, list => list.BaseType));
                                                    */
                context.Load(web.Lists);
                // Execute query. 
                context.ExecuteQuery();

                // Enumerate the web.Lists. 
                foreach (List list in web.Lists)
                    if (list.Hidden == false)//list.BaseType == BaseType.GenericList)
                    {
                        SPListsBox.Items.Add(list.Title);
                    }
            }
        }
        private void lblSiteTitle_Click(object sender, EventArgs e)
        {
            lblSiteTitle.Hide();
            txtSiteTitleChange.Visible = true;
            btnTitleSave.Visible = true;
        }

        private void btnTitleSave_Click(object sender, EventArgs e)
        {
            using (var context = new ClientContext(webUrl))
            {
                context.Credentials = new SharePointOnlineCredentials(userName, password);
                context.Load(context.Web, web => web.Title);
                context.Web.Title = txtSiteTitleChange.Text;
                context.Web.Update();
                context.ExecuteQuery();
                StartPage();
                lblSiteTitle.Show();
                txtSiteTitleChange.Visible = false;
                btnTitleSave.Visible = false;
            }
        }

        private void SPListsBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string ListName = SPListsBox.SelectedItem.ToString();
            using (var context = new ClientContext(webUrl))
            {
                context.Credentials = new SharePointOnlineCredentials(userName, password);

                // Assume the web has a list named "Announcements". 
                List mylist = context.Web.Lists.GetByTitle(ListName);

                // This creates a CamlQuery that has a RowLimit of 100, and also specifies Scope="RecursiveAll" 
                // so that it grabs all list items, regardless of the folder they are in. 
                CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
                query.ViewXml = "";
                ListItemCollection items = mylist.GetItems(query);

                // Retrieve all items in the ListItemCollection from List.GetItems(Query). 
                context.Load(items);
                context.ExecuteQuery();
                
                DataTable dt = new DataTable();
                dt.Columns.Add("Title");
                foreach (var item in items)
                {
                    DataRow dr = dt.NewRow();
                    dr["Title"] = item["Title"];
                    dt.Rows.Add(dr);
                }

                //ResetDataGridView(); //Clear contents of datagridview
                dtGridListItems.DataSource = dt;
            }
        }

        private void SPbuttongrid_SelectedValueChanged(object sender, EventArgs e)
        {
            string ListName = SPListsBox.SelectedItem.ToString();
            using (var context = new ClientContext(webUrl))
            {
                context.Credentials = new SharePointOnlineCredentials(userName, password);


                //// Assume that the web has a list named "Announcements". 
                //List announcementsList = context.Web.Lists.GetByTitle("ListName");

                //// Assume there is a list item with ID=1. 
                //ListItem listItem = announcementsList.GetItemById(1);

                //// Write a new value to the Body field of the Announcement item.
                //listItem["Body"] = "This is my new value!!";
                //listItem.Update();

                //context.ExecuteQuery();
            }
        }
    }
}
