﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace CSOM_ConsoleApp
{
    class Program
    {
        static String _url = "https://o365boss.sharepoint.com/sites/MO";
        static void Main(string[] args)
        {
            //Retrieve the properties of a website
            _GetWebsiteproperties();
            // _SetSelectedWebsiteproperties();
            //Retrieve only selected properties of a website
            // _GetSelectedWebsiteproperties();

            //Set to website's properties
            // _SetSelectedWebsiteproperties();

            //Create a new SharePoint website
            //_CreateWebsite();

            // _Retrievefields();
            // _RetrieveWeblists();
            // _CreateLists();
            // _AddField();
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
        //Retrieve the properties of a website
        static void _GetWebsiteproperties()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);
            //context.Credentials = new System.Net.NetworkCredential("", "", "");
            // The SharePoint web at the URL.
            Web web = context.Web;

            // We want to retrieve the web's properties.
            context.Load(web);

            // Execute the query to the server.
            context.ExecuteQuery();

            // Now, the web's properties are available and we could display 
            // web properties, such as title. 

            Console.WriteLine("Web Title:" + web.Title);


        }

        //Retrieve only selected properties of a website
        static void _GetSelectedWebsiteproperties()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);

            // The SharePoint web at the URL.
            Web web = context.Web;

            // We want to retrieve the web's title and description. 
            context.Load(web, w => w.Title, w => w.Description);

            // Execute the query to server.
            context.ExecuteQuery();

            // Now, only the web's title and description are available. If you 
            // try to print out other properties, the code will throw 
            // an exception because other properties are not available.            
            Console.WriteLine("Web Title:" + web.Title);
            Console.WriteLine("Web Description:" + web.Description);

        }


        //Set to website's properties
        static void _SetSelectedWebsiteproperties()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);

            // The SharePoint web at the URL.
            Web web = context.Web;

            web.Title = "SharePointIQ | SharePoint Training institute";
            web.Description = "SharePoint Training institute -Team B";

            // Note that the web.Update() does not trigger a request to the server
            // because the client library until ExecuteQuery() is called. 
            web.Update();

            // Execute the query to server.
            context.ExecuteQuery();
            Console.WriteLine("Done");

        }

        //Create a new SharePoint website
        static void _CreateWebsite()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);


            WebCreationInformation creation = new WebCreationInformation();
            creation.Url = "welcomeweb1";
            creation.Title = "Hello web1";
            Web newWeb = context.Web.Webs.Add(creation);

            // Retrieve the new web information. 
            context.Load(newWeb, w => w.Title);
            context.ExecuteQuery();

            Console.WriteLine("Done New Web Title:" + newWeb);

        }

        //Retrieve all SharePoint lists in a web
        static void _RetrieveWeblists()
        {
            ClientContext context = new ClientContext(_url);

            // The SharePoint web at the URL.
            Web web = context.Web;

            // Retrieve all lists from the server. 
            context.Load(web.Lists,
                         lists => lists.Include(list => list.Title, // For each list, retrieve Title and Id. 
                                                list => list.Id, list => list.BaseType));

            // Execute query. 
            context.ExecuteQuery();

            // Enumerate the web.Lists. 
            foreach (List list in web.Lists)
                if (list.BaseType == BaseType.GenericList)
                {
                    Console.WriteLine(list.Title);
                }
        }
        //Create and update a SharePoint list
        static void _CreateLists()
        {
            ClientContext context = new ClientContext(_url);

            // The SharePoint web at the URL.
            Web web = context.Web;

            ListCreationInformation creationInfo = new ListCreationInformation();
            creationInfo.Title = "My List";
            creationInfo.TemplateType = (int)ListTemplateType.Announcements;
            List list = web.Lists.Add(creationInfo);
            list.Description = "New Description";

            list.Update();
            context.ExecuteQuery();
        }
        //Delete a SharePoint list
        static void _DeleteLists()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);

            // The SharePoint web at the URL.
            Web web = context.Web;

            List list = web.Lists.GetByTitle("My List");
            list.DeleteObject();

            context.ExecuteQuery();

        }
        //Add a field to a SharePoint list
        static void _AddField()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);
            List list = context.Web.Lists.GetByTitle("My List");
            Field field = list.Fields.AddFieldAsXml("<Field DisplayName='MyField2' Type='Number' />",
                                                       true,
                                                       AddFieldOptions.DefaultValue);
            FieldNumber fldNumber = context.CastTo<FieldNumber>(field);

            fldNumber.MaximumValue = 100;
            fldNumber.MinimumValue = 35;
            fldNumber.Update();
            context.ExecuteQuery();
        }
        //Retrieve all of the fields in a list
        static void _Retrievefields()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);

            List list = context.Web.Lists.GetByTitle("Shared Documents");
            context.Load(list.Fields);

            // We must call ExecuteQuery before enumerate list.Fields. 
            context.ExecuteQuery();

            foreach (Field field in list.Fields)
            {
                Console.WriteLine(field.InternalName);

            }

        }
        //Retrieve items from a SharePoint list
        static void _Retrieveitems()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);

            // Assume the web has a list named "Announcements". 
            List announcementsList = context.Web.Lists.GetByTitle("Announcements");

            // This creates a CamlQuery that has a RowLimit of 100, and also specifies Scope="RecursiveAll" 
            // so that it grabs all list items, regardless of the folder they are in. 
            CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
            query.ViewXml = "";
            ListItemCollection items = announcementsList.GetItems(query);

            // Retrieve all items in the ListItemCollection from List.GetItems(Query). 
            context.Load(items);
            context.ExecuteQuery();
            foreach (ListItem listItem in items)
            {
                // We have all the list item data. For example, Title. 

                Console.WriteLine(Convert.ToString(listItem["Title"]));
            }
        }

        // Create a new list item
        static void _Createitems()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);

            // Assume that the web has a list named "Announcements". 
            List announcementsList = context.Web.Lists.GetByTitle("Announcements");

            // We are just creating a regular list item, so we don't need to 
            // set any properties. If we wanted to create a new folder, for 
            // example, we would have to set properties such as 
            // UnderlyingObjectType to FileSystemObjectType.Folder. 
            ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
            ListItem newItem = announcementsList.AddItem(itemCreateInfo);
            newItem["Title"] = "My New Item!";
            newItem["Body"] = "Hello World!";
            newItem.Update();

            context.ExecuteQuery();
        }
        //Update a list item
        static void _Updateitems()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);


            // Assume that the web has a list named "Announcements". 
            List announcementsList = context.Web.Lists.GetByTitle("Announcements");

            // Assume there is a list item with ID=1. 
            ListItem listItem = announcementsList.GetItemById(1);

            // Write a new value to the Body field of the Announcement item.
            listItem["Body"] = "This is my new value!!";
            listItem.Update();

            context.ExecuteQuery();
        }
        //Delete a list item
        static void _Deleteitems()
        {
            // Starting with ClientContext, the constructor requires a URL to the 
            // server running SharePoint. 
            ClientContext context = new ClientContext(_url);

            // Assume that the web has a list named "Announcements". 
            List announcementsList = context.Web.Lists.GetByTitle("Announcements");

            // Assume that there is a list item with ID=2. 
            ListItem listItem = announcementsList.GetItemById(2);
            listItem.DeleteObject();

            context.ExecuteQuery();
        }
    }
}
