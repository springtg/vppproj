using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;

namespace COREBASE.COMMAND.XML
{
    public class XPath_XML
    {
        private string strPathrsMessage = @"Resource\rsMessage.xml";

        XmlDocument doc = new XmlDocument();

        public DataTable readDoc()
        {
            return readDoc(strPathrsMessage);
        }
        public DataTable readDoc(string filename)
        {
            DataTable dt = new DataTable("rsMessage");
            dt.Columns.Add("MsgID", typeof(string));
            dt.Columns.Add("MsgContent", typeof(string));
            dt.Columns.Add("MsgType", typeof(string));
            doc.Load(strPathrsMessage);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                XmlElement element = doc.GetElementById(node.Attributes["MsgID"].Value);
                dt.Rows.Add(node.Attributes["MsgID"].Value, element.ChildNodes[0].InnerText,
                    element.ChildNodes[1].InnerText, element.ChildNodes[2].InnerText, element.ChildNodes[3].InnerText);

            }
            return dt;
        }

        public XmlNodeList SeacNode(string filename, string strnodevalue)
        {
            XmlNodeList lst = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            lst = doc.SelectNodes(string.Format("//AppMsg[./MsgContent/text()='{0}']", strnodevalue));
            return lst;
        }
        public DataTable readXML(string filename)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filename);
            return ds.Tables[0];
        }

        public void writeXML(DataTable dtSource, string filename)
        {
            dtSource.WriteXml(filename);
            dtSource.AcceptChanges();
        }
    }
}

