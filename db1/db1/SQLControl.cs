using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace db1
{

    public class SQLControl
    {
        private SqlConnection _DBCon;
     
        //DBData
        public dset11 _ds = new dset11();

        //QueryParameters
        public List<SqlParameter> _Params = new List<SqlParameter> {null } ;

        //QueryStatistics
        public int nRecordCount;
        public String sException;

        //Allow ConnectionString override
        public void fNew(String sConnectionString)
        {
            _DBCon = new SqlConnection(sConnectionString);
    
        }

        //Execute QuerySub
        public void fExecQuery(String sQuery)
        {
            //Reset QueryStats
            nRecordCount = 0;
            sException = null;

            try
            {

                //Create DBCommand
                _DBCon.Open();
                SqlCommand _DBCmd = new SqlCommand(sQuery, _DBCon);
                _DBCmd.ExecuteNonQuery();

                _Params.Clear();
            
                //Execute Command + FillDataset
                SqlDataAdapter DBDA = new SqlDataAdapter(_DBCmd);
                DBDA.Fill(_ds);
                nRecordCount = DBDA.TableMappings.Count;

            }
            catch (Exception e)
            {
                sException = "ExecQueryError: " + e.Message;
                MessageBox.Show(sException, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                //CloseConnection
                if (_DBCon.State == System.Data.ConnectionState.Open)
                {
                    _DBCon.Close();
                }
            };
        }

        //AddParams
        public void fAddParam(String sName, Object oValue)
        {
            SqlParameter _newparam = new SqlParameter(sName, oValue);

            _Params.Add(_newparam);
        }


        //ErrorChecking
        public bool fHasException(bool bReport)
        {
            if (String.IsNullOrEmpty(sException)){
                return false;
            }
            if (bReport)
            {
                MessageBox.Show(sException, "Exception:");
            }
            return true;
        }
    }
}