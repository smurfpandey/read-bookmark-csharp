using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookmarkImporter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/bookmarks/");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string newName = Guid.NewGuid().ToString();
            string fileExtn = Path.GetExtension(fuBookmark.FileName);
            string newFileName = newName + fileExtn;
            string filePath = folderPath+newFileName;
            fuBookmark.SaveAs(filePath);

            string bookmarks = ReadBookmarks(filePath);

            Response.Write(bookmarks);
        }

        private string ReadBookmarks(string filePath)
        {
            List<Bookmark> lstBookmark = new List<Bookmark>();

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            //// There are various options, set as needed
            //htmlDoc.OptionFixNestedTags = true;

            // filePath is a path to a file containing the html
            htmlDoc.Load(filePath, true);

            // ParseErrors is an ArrayList containing any errors from the Load statement
            if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
            {
                // Handle any parse errors as required

            }
            else
            {
                var docNode = htmlDoc.DocumentNode;

                foreach (HtmlNode link in docNode.Descendants("A"))
                {
                    Bookmark objBook = new Bookmark();

                    objBook.href = link.Attributes["HREF"].Value;
                    objBook.title = link.InnerText;
                    objBook.add_date = link.Attributes["ADD_DATE"].Value;

                    lstBookmark.Add(objBook);
                }                
            }

            return JsonConvert.SerializeObject(lstBookmark);
        }

        private class Bookmark
        {
            public string href { get; set; }
            public string title { get; set; }
            public string add_date { get; set; }
        }
    }
}