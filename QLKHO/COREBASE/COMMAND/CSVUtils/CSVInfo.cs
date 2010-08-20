using System;
using System.Collections.Generic;
using System.Text;

namespace COREBASE.COMMAND.CSVUtils
{
    public class CSVInfo
    {
        private string _id = string.Empty;
        public string ID
        {
            get{return _id;}
            set{_id=value;}
        }
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
