using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;
using System.Drawing;


namespace COREBASE.COMMAND.CSVUtils
{
    public class CSVFile
    {
        private OdbcConnection conn;

        public CSVFile()
        {
            
        }
        public CSVFile(OdbcConnection odbcConnection)
        {
            conn = odbcConnection;
        }
        public OdbcConnection dbConnection
        {
            get { return conn; }
            set { conn = value; }
        }

        public string ExecuteQueryCSV(string strQuery)
        {
            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(strQuery, dbConnection);
            dt.Clear();
            da.Fill(dt);
            if (dt.Rows.Count.Equals(0))
            {
                MessageBox.Show("Khong tim thay tai nguyen nay!");
                return string.Empty;
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }
        public DataTable ExecuteQueryCSV2(string strQuery)
        {
            DataTable dt = new DataTable();

            OdbcDataAdapter da = new OdbcDataAdapter(strQuery, dbConnection);
            dt.Clear();
            da.Fill(dt);
            if (dt.Rows.Count.Equals(0))
            {
                MessageBox.Show("Khong tim thay tai nguyen nay!");
            }

            return dt;
        }

        private CSVInfo MappingCSV(DataTable dtSource)
        {
            CSVInfo csvInfo = new CSVInfo();

            csvInfo.ID = dtSource.Rows[0]["ID"].ToString();
            csvInfo.Name = dtSource.Rows[0]["NAME"].ToString();
            return csvInfo;
        }

        public Image getImagefromResource(string strImageId)
        {
            string commText = "SELECT * FROM [" + Constant.ImageFile + "] WHERE ID='" + strImageId + "'";
            string strImage = ExecuteQueryCSV(commText);
            Image imageResult = Convert.Convert.byteArrayToImage(Convert.Convert.RawSerialize(strImage));
            return imageResult;
        }
        public Image getSoundfromResource(string strSoundId)
        {
            string commText = "SELECT * FROM [" + Constant.ImageFile + "] WHERE ID='" + strSoundId + "'";
            string strSound = ExecuteQueryCSV(commText);
            Image imageResult = Convert.Convert.byteArrayToImage(Convert.Convert.RawSerialize(strSound));
            return imageResult;
        }
        public Image getMoviefromResource(string strMovieId)
        {
            string commText = "SELECT * FROM [" + Constant.ImageFile + "] WHERE ID='" + strMovieId + "'";
            string strMovie= ExecuteQueryCSV(commText);
            Image imageResult = Convert.Convert.byteArrayToImage(Convert.Convert.RawSerialize(strMovie));
            return imageResult;
        }
    }
}
