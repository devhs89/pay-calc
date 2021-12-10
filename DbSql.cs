using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.OleDb;
using System.Data;

namespace PayCalculator
{
    class DbSql
    {
        OleDbConnection dataCon; OleDbDataAdapter dataAdapter; DataSet dataSet; DataRow row; OleDbCommandBuilder cmdBuilder;

        public void Entry(int agentID, double lvl, string wrkPlace, string sftDt, string stTime, string edTime, string hrs, string amPmNd, bool breakCheck, string lau, string unf)
        {
            string providerStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=PayCal.mdb;";
            dataCon = new OleDbConnection(providerStr);
            dataCon.Open();

            dataSet = new DataSet();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM shifts;", dataCon);
            cmdBuilder = new OleDbCommandBuilder(dataAdapter);

            dataAdapter.Fill(dataSet, "shifts");
            row = dataSet.Tables["shifts"].NewRow();

            string table = "INSERT INTO shifts ( agentID, nurseLevel, workPlace, shiftDate, shiftStart, shiftEnd, totalHours, shiftTime, meal, laundry, uniform ) VALUES ( @agentID, '" + lvl + "','" + wrkPlace + "','" + sftDt + "', @start, @end, @hours, '" + amPmNd + "', " + breakCheck + ", '" + lau + "', '" + unf + "' );";
            dataAdapter.InsertCommand = new OleDbCommand(table, dataCon);
            dataAdapter.InsertCommand.CommandType = CommandType.Text;
            dataAdapter.InsertCommand.Parameters.AddWithValue("@agentID", agentID);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@start", stTime);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@end", edTime);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@hours", hrs);

            dataSet.Tables["shifts"].Rows.Add(row);
            dataAdapter.UpdateCommand = cmdBuilder.GetUpdateCommand();
            dataAdapter.Update(dataSet, "shifts");
            dataCon.Close();
        }
    }
}
