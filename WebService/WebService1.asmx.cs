using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        //lütficansay.com

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public XmlDocument DataXml()
        {
            string xml = "";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString= "Server=DESKTOP-TKJ8MV6\\SQLEXPRESS;Database=Cafedb;Trusted_Connection=True;";
                conn.Open();
                string query = "Select id_employee,id_profile,id_table,lastname,firstname,email,passwd,active,last_connection_date FROM dbo.ps_employee FOR XML RAW ('Personel'), ROOT ('Personeller'), ELEMENTS ";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read()) ;
                {
                    xml = rd[0].ToString();
                }
                conn.Close();
            }
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            return xmldoc;
        }

    }
}
