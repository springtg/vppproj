using System.Data;

namespace COREBASE.COMMAND.VPP_COMMAND
{
    public class CWareHouse
    {
        public static DataTable ListWareHouse(COMMAND.Config.ConfigItem _confItem)
        {
            COMMAND.SQL.AccessSQL _sql = new SQL.AccessSQL(_confItem);
            return _sql.GetDataByStoredProcedure("USP_SEL_USER");
        }
    }
}
