using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace COREBASE.COMMAND.XML
{
    public class AccessXML
    {
        private string strFilePath;
        private XmlDocument xdoc;
        
        public string FilePath
        {
            set
            {
                this.strFilePath = value;
            }
        }
        
        public AccessXML()
        {
            xdoc = new XmlDocument();
        }

        public AccessXML(string path)
        {
            this.strFilePath = path;
            this.xdoc = new XmlDocument();
        }
   
        public bool CreateEmptyXMLDocument()
        {
            try
            {
                XmlDeclaration xmldeclaration = xdoc.CreateXmlDeclaration("1.0", "", "yes");
                xdoc.PrependChild(xmldeclaration);
                XmlElement root = xdoc.CreateElement("root");
                xdoc.AppendChild(root);
                xdoc.Save(this.strFilePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write( ex.Message);
                return false;
            }
        }
        //tao moi 1 tag vao file xml
        public bool AddTag(string tagname, string text)
        {
            try
            {
                xdoc.Load(strFilePath);
                XmlElement root = xdoc.DocumentElement;//lay nut goc
                XmlElement nodeElem = xdoc.CreateElement(tagname);//tao node
                nodeElem.Value = text;
                root.AppendChild(nodeElem);
                xdoc.Save(strFilePath);
                xdoc = null;
                return true;
            }
            catch
            {
                return false;
            }
        }
        //lay thong tin cua 1 tag
        public string ReadTagInfor(string tagname)
        {
            xdoc.Load(strFilePath);
            XmlNode root = xdoc.DocumentElement;
            foreach (XmlNode node in root.FirstChild.ChildNodes)
            {
                if( node.Name.Equals("#comment"))
                {
                    continue;
                }
                if (node.Attributes["key"].Value == tagname)
                    return node.Attributes["value"].Value;
            }
            return "";
        }
        //lay thong tin cua cong ty
        public DataTable ReadAllInfor()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("USD");
            dt.Columns.Add("GBP");
            dt.Columns.Add("HKD");
            dt.Columns.Add("FRF");
            dt.Columns.Add("CHF");
            dt.Columns.Add("DEM");
            dt.Columns.Add("JPY");
            dt.Columns.Add("AUD");
            dt.Columns.Add("CAD");
            dt.Columns.Add("SGD");
            dt.Columns.Add("EUR");
            dt.Columns.Add("NZD");
            DataRow newrow = dt.NewRow();
            dt.Rows.Add(newrow);
            dt.Rows[0]["USD"] = ReadTagInfor("USD");
            dt.Rows[0]["GBP"] = ReadTagInfor("GBP");
            dt.Rows[0]["HKD"] = ReadTagInfor("HKD");
            dt.Rows[0]["FRF"] = ReadTagInfor("FRF");
            dt.Rows[0]["CHF"] = ReadTagInfor("CHF");
            dt.Rows[0]["DEM"] = ReadTagInfor("DEM");
            dt.Rows[0]["JPY"] = ReadTagInfor("JPY");
            dt.Rows[0]["AUD"] = ReadTagInfor("AUD");
            dt.Rows[0]["CAD"] = ReadTagInfor("CAD");
            dt.Rows[0]["SGD"] = ReadTagInfor("SGD");
            dt.Rows[0]["EUR"] = ReadTagInfor("EUR");
            dt.Rows[0]["NZD"] = ReadTagInfor("NZD");            
            return dt;
        }
        
        //cap nhat thong tin cua 1 tag
        public bool UpdateTag(string tagname, string innerText)
        {
            try
            {
                xdoc.Load(strFilePath);
                XmlNode root = xdoc.DocumentElement;
                foreach (XmlNode node in root.FirstChild.ChildNodes)
                {
                    if (node.Name.Equals("#comment"))
                    {
                        continue;
                    }
                    if (node.Attributes["key"].Value == tagname)
                    {
                        node.Attributes["value"].Value = innerText;
                        xdoc.Save(strFilePath);
                        break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

    }
}
