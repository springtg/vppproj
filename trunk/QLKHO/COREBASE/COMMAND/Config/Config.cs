using System.Xml;

namespace COREBASE.COMMAND.Config
{
    public class Config
    {
        #region Private Members
        private string m_config_file;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Config()
        {
            this.m_config_file = getConfigPath();
        }

        /// <summary>
        /// doc thong tin cua form setting thong qua key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ReadSetting(string key)
        {
            try
            {
                XmlDocument doc = this.LoadingConfiguration();
                XmlNode node = doc.SelectSingleNode("//appSettings");
                if (node != null)
                {
                    XmlElement em = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                    return em.GetAttribute("value");
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// Doc thong tin cua cua file config
        /// </summary>
        /// <returns></returns>
        private XmlDocument LoadingConfiguration()
        {
            try
            {
                XmlDocument doc;
                doc = new XmlDocument();
                doc.Load(this.m_config_file);
                return doc;
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// ghi gia tri thay doi cua file config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteSetting(string key, string value)
        {
            try
            {
                XmlDocument doc = this.LoadingConfiguration();
                XmlNode node = doc.SelectSingleNode("//appSettings");
                if (node != null)
                {
                    XmlElement em = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                    if (em != null)
                    {
                        em.SetAttribute("value", value);
                    }
                    else
                    {
                        em = doc.CreateElement("add");
                        em.SetAttribute("key", key);
                        em.SetAttribute("value", value);
                        node.AppendChild(em);
                    }
                    doc.Save(this.m_config_file);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// xoa mot key trong file config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool RemoveSetting(string key)
        {
            try
            {
                XmlDocument doc = this.LoadingConfiguration();
                XmlNode node = doc.SelectSingleNode("//appSettings");
                if (node != null)
                {
                    XmlNode cnode = node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                    if (cnode != null)
                    {
                        node.RemoveChild(cnode);
                        doc.Save(this.m_config_file);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// lay duong dan file config
        /// </summary>
        /// <returns></returns>
        public string getConfigPath()
        {
            return System.Reflection.Assembly.GetEntryAssembly().Location + ".config";
        }
    }
}
