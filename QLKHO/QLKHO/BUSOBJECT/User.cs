using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKHO.BUSOBJECT
{
    class User
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _idDis;

        public string Id_Dis
        {
            get { return _idDis; }
            set { _idDis = value; }
        }

        private string _nameDis;

        public string Name_Dis
        {
            get { return _nameDis; }
            set { _nameDis = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private System.DateTime _crtDt;

        public System.DateTime Crt_Dt
        {
            get { return _crtDt; }
            set { _crtDt = value; }
        }

        private string _crtBy;

        public string Crt_By
        {
            get { return _crtBy; }
            set { _crtBy = value; }
        }

        private System.DateTime _modDt;

        public System.DateTime Mod_Dt
        {
            get { return _modDt; }
            set { _modDt = value; }
        }

        private string _modBy;

        public string Mod_By
        {
            get { return _modBy; }
            set { _modBy = value; }
        }

        private int _isDel;

        public int Is_Del
        {
            get { return _isDel; }
            set { _isDel = value; }
        }

        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }


    }
}
