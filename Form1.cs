using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace JavaScriptFunction
{
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            //Method which calls the C# code to the javascript function
            webBrowser1.ObjectForScripting = this;
            webBrowser1.ScriptErrorsSuppressed = false;

            //Disables right click on webbrowser control 
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.AllowWebBrowserDrop = false;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Focuses on Web Browser control when form is loaded 
            webBrowser1.Focus();

            //Call report method which contains the report content 
            Report();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Gets current directory of the application 
            string CurrentDirectory = Directory.GetCurrentDirectory();
            //Calls HTML page using navigate method
            webBrowser1.Navigate(Path.Combine(CurrentDirectory, "HTMLPageForJavaScript"));
        }

        private void Report()
        {
            //Gets HTML div from the id of div
            HtmlElement div = webBrowser1.Document.GetElementById("reportContent");

            //HTML Content 
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr><td><B> Hi this is my report demo </B></td></tr>");
            sb.Append("</table>");

            //Assigns content to HTML page div which is displayed on web browser control 
            div.InnerHtml = sb.ToString();
        }

        public void PrintReport() 
        {
            //If statment used for calling print method of web browser control 
            DialogResult dr = printDialog1.ShowDialog();
            
            if (dr.ToString() == "OK")
            {
                webBrowser1.Print();
            }
            else
            {
                return;
            }
        }
    }
}
