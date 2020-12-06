using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Remoting;
using System.Data.Common;
using App.Entity;
using App.Entity.Structs;
using App.Entity.IDispose;
using App.Entity.IModels;
using App.Entity.Models;
using System.Reflection;
namespace App.Entity
{
    /// <summary>
    /// Designed by Eng:Mohamad Alsaid for call Sql Tables
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class SqlTables<T> : TModel, IRepository<T>
    {

        #region Variable
        SqlConnection conn;
        SqlCommand cmd;
        Returened _res;
        DbReturned<T> _returnedValues;
        Returened _returnedState;

        #endregion


        #region Constructor

        public SqlTables()
        {
            conn = new SqlConnection();
            conn.ConnectionString =@"Data Source=DESKTOP-2DH1V9A\SQLEXPRESS;Initial Catalog=News;Integrated Security=True"; 
            cmd = new SqlCommand();
            cmd.Connection = conn;
            _res = new Returened();
            _returnedValues = new DbReturned<T>();
        }


        public SqlTables(string connectionString)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connectionString; 
            cmd = new SqlCommand();
            cmd.Connection = conn;
            _res = new Returened();
            _returnedValues = new DbReturned<T>();
        }


        #endregion


        #region Method

        /// <summary>
        /// Clear Info Sql Returned from Every Function
        /// </summary>
        public void InitParams()
        {
            // Set Sql Parameters values
            cmd.Parameters.Clear();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;

            // Clear Obj returned from methods
            _returnedValues.Clear();
        }

        /// <summary>
        /// Stop Conection with Sql Database
        /// </summary>
        public void StopConnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        /// <summary>
        /// Set Error and State Information for methods
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public DbReturned<T> SetException(Exception exp, Int32 RowID)
        {
            // Set Parameters
            DbReturned<T> res = new App.Entity.Structs.DbReturned<T>();
            _returnedState.State = false;
            _returnedValues.RowEffected = 0;
            _returnedState.ErrorMessage = exp.Message;
            _returnedState.RowID = RowID;
            _returnedValues.Exp = exp;
            res.Returened = _returnedState;
            return res;
        }

        /// <summary>
        /// Select Data from Tables
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DbReturned<T> Select(StoredProcedure sp)
        {
            try
            {
                var t = typeof(T).Name;
                InitParams();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp.StoredProcedureName;
                if (sp.arr != null)
                {
                    for (int i = 0; i < sp.arr.Count; i++)
                    {
                        SqlParameter spData = new SqlParameter();
                        spData.ParameterName = sp.Params[i];
                        spData.Value = sp.arr[i];
                        cmd.Parameters.Add(spData);
                    }
                }
                List<T> results;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    results = new List<T>().FromDataReader(dr).ToList();
                }
                conn.Close();
                _returnedValues.Data = results;
                _returnedState.State = true;
                _returnedValues.RowEffected = results.Count;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;


            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }


        /// <summary>
        /// Get All Rows from Table
        /// </summary>
        /// <returns></returns>
        public DbReturned<T> AllData()
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;
                Type TableType = typeof(T);
                string Query = string.Format("SELECT * FROM  {0}", TableType.Name);
                cmd.CommandText = Query;
                List<T> results;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    results = new List<T>().FromDataReader(dr).ToList();
                }
                conn.Close();
                _returnedValues.Data = results;
                _returnedState.State = true;
                _returnedValues.RowEffected = results.Count;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;


            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }



        /// <summary>
        ///  Execute Function with Parameter Out
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DbReturned<T> Execute(StoredProcedure sp)
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp.StoredProcedureName;
                if (sp.Params != null)
                {
                    for (int i = 0; i < sp.arr.Count; i++)
                    {
                        SqlParameter spData = new SqlParameter();
                        spData.ParameterName = sp.Params[i];
                        spData.Value = sp.arr[i] != null ? sp.arr[i] : "";
                        cmd.Parameters.Add(spData);
                    }
                }

                if (sp.OutParam != null)
                {
                    foreach (var item in sp.OutParam)
                    {
                        if (item.TypeOutParam == DataTypes._bool)
                        {
                            cmd.Parameters.Add(item.ColumnName, SqlDbType.Bit);
                        }
                        else if (item.TypeOutParam == DataTypes._decimal)
                        {
                            cmd.Parameters.Add(item.ColumnName, SqlDbType.Decimal);
                        }
                        else if (item.TypeOutParam == DataTypes._double)
                        {
                            cmd.Parameters.Add(item.ColumnName, SqlDbType.BigInt);
                        }
                        else if (item.TypeOutParam == DataTypes._guid)
                        {
                            cmd.Parameters.Add(item.ColumnName, SqlDbType.UniqueIdentifier);
                        }
                        else if (item.TypeOutParam == DataTypes._int)
                        {
                            cmd.Parameters.Add(item.ColumnName, SqlDbType.Int);
                        }
                        else if (item.TypeOutParam == DataTypes._string)
                        {
                            cmd.Parameters.Add(item.ColumnName, SqlDbType.NVarChar);
                        }
                        cmd.Parameters[item.ColumnName].Direction = ParameterDirection.Output;
                    }

                }


                Int32 rowEffected = cmd.ExecuteNonQuery();
                dynamic result = "Successfully Completed !?";
                List<dynamic> outputs = new List<dynamic>();
                if (sp.OutParam != null)
                {
                    foreach (var item in sp.OutParam)
                    {
                        if (item.TypeOutParam == DataTypes._bool)
                        {
                            conn.Close();
                            outputs.Add(Convert.ToBoolean(cmd.Parameters[item.ColumnName].Value.ToString()));
                        }
                        else if (item.TypeOutParam == DataTypes._decimal)
                        {
                            conn.Close();
                            outputs.Add(Convert.ToDecimal(cmd.Parameters[item.ColumnName].Value.ToString()));
                        }
                        else if (item.TypeOutParam == DataTypes._double)
                        {
                            conn.Close();
                            outputs.Add(Convert.ToDouble(cmd.Parameters[item.ColumnName].Value.ToString()));
                        }
                        else if (item.TypeOutParam == DataTypes._guid)
                        {
                            conn.Close();
                            outputs.Add(new Guid(cmd.Parameters[item.ColumnName].Value.ToString()));
                        }
                        else if (item.TypeOutParam == DataTypes._int)
                        {
                            conn.Close();
                            outputs.Add(Convert.ToInt32(cmd.Parameters[item.ColumnName].Value.ToString()));
                        }
                        else
                        {
                            conn.Close();
                            outputs.Add(cmd.Parameters[item.ColumnName].Value.ToString());
                        }
                    }

                }
                conn.Close();
                _returnedValues.Return = outputs;
                _res.State = true;
                _returnedValues.RowEffected = rowEffected;
                _returnedValues.Returened = _res;
                return _returnedValues;
            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }


        /// <summary>
        /// Insert Row to table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        public DbReturned<T> Insert(T param)
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;
                string query = string.Empty;
                Type TableType = typeof(T);

                string parameters = string.Empty;
                PropertyInfo[] Properties = TableType.GetProperties();
                Array.Sort(Properties, new DeclarationOrderComparator());
                for (int i = 0; i < Properties.Count(); i++)
                {
                    if (i != 0)
                    {
                        var type = param.GetType()
                            .GetProperty(Properties[i].Name).PropertyType;
                        //if (type == typeof(System.DateTime))
                        //{
                        //    var sqlFormattedDate = Convert.ToDateTime(param.GetType().GetProperty(Properties[i].Name).GetValue(param, null))
                        //        .Date.ToString("yyyy-MM-dd HH:mm:ss");
                        //    parameters += " Convert( datetime ,'" + sqlFormattedDate + "',21) ,";
                        //}
                        //else
                        if (type == typeof(System.String))
                        {
                            parameters += "  N'" + param.GetType()
                            .GetProperty(Properties[i].Name).GetValue(param, null) + "' ,";
                        }
                        else
                        {
                            parameters += " '" + param.GetType()
                            .GetProperty(Properties[i].Name).GetValue(param, null) + "' ,";
                        }
                    }
                }
                parameters = parameters.TrimEnd(',');
                query = String.Format("INSERT INTO   {0} VALUES( {1} )", TableType.Name, parameters);
                //string parameters = string.Empty;
                //string p2 = string.Empty;
                //for (int i = 0; i < TableType.GetProperties().OrderBy(x => x.MetadataToken).Count(); i++)
                //{
                //    if (i != 0)
                //    {
                //        p2 += "@p" + i.ToString() + ",";
                //        parameters += " '" + param.GetType().GetProperty(TableType.GetProperties()[i].Name).GetValue(param, null) + "' ,";

                //    }
                //}
                //parameters = parameters.TrimEnd(',');
                //p2 = p2.TrimEnd(',');
                //query = String.Format("INSERT INTO   {0} VALUES({1} )", TableType.Name, p2);

                //cmd.CommandText = query;
                //for (int i = 0; i < TableType.GetProperties().OrderBy(x => x.MetadataToken).Count(); i++)
                //{
                //    if (i != 0)
                //    {
                //        cmd.Parameters.AddWithValue("@p" + i.ToString(), param.GetType().GetProperty(TableType.GetProperties()[i].Name).GetValue(param, null));
                //    }
                //}
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
                _returnedState.State = true;
                _returnedValues.RowEffected = 1;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;

            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }

        /// <summary>
        /// Update Row in Table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        public DbReturned<T> Update(T param)
        {
            Int32 RowID = 0;
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;
                string query = string.Empty;
                Type TableType = typeof(T);

                string parameters = string.Empty;
                for (int i = 0; i < TableType.GetProperties().Length; i++)
                {
                    if (i != 0)
                    {
                        var type = param.GetType()
                            .GetProperty(TableType.GetProperties()[i].Name).PropertyType;
                        //if (type == typeof(System.DateTime))
                        //{
                        //    var sqlFormattedDate = Convert.ToDateTime(param.GetType().GetProperty(TableType.GetProperties()[i].Name).GetValue(param, null))
                        //        .Date.ToString("yyyy-MM-dd HH:mm:ss");
                        //    parameters += TableType.GetProperties()[i].Name
                        //   + " = Convert( datetime ,'" + sqlFormattedDate + "',21) ,";
                        //}
                        //else 
                        if (type == typeof(System.String))
                        {
                            parameters += TableType.GetProperties()[i].Name
                                + " =  N'" + param.GetType()
                                .GetProperty(TableType.GetProperties()[i].Name).GetValue(param, null) + "' ,";
                        }
                        else
                        {
                            parameters += TableType.GetProperties()[i].Name
                                + " =  '" + param.GetType()
                                .GetProperty(TableType.GetProperties()[i].Name).GetValue(param, null) + "' ,";
                        }

                    }
                    else
                    {
                        RowID = Convert.ToInt32(param.GetType()
                                .GetProperty(TableType.GetProperties()[i].Name).GetValue(param, null));
                    }
                }
                parameters = parameters.TrimEnd(',');

                string where = string.Empty;
                where += TableType.GetProperties()[0].Name + " = " +
                    param.GetType().GetProperty(TableType.GetProperties()[0].Name).GetValue(param, null);


                query = String.Format("UPDATE  {0} SET {1} WHERE {2}", TableType.Name, parameters, where);
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                conn.Close();
                _returnedState.State = true;
                _returnedState.RowID = RowID;
                _returnedValues.RowEffected = 1;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;

            }
            catch (Exception exp)
            {
                return SetException(exp, RowID);
            }
            finally
            {
                StopConnect();
            }
        }




        /// <summary>
        /// First Record in Table
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public DbReturned<T> FirstOrDefault()
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;


                Type TableType = typeof(T);
                cmd.CommandText = String.Format("SELECT TOP(1)* FROM {0}", TableType.Name);
                List<T> results;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    results = new List<T>().FromDataReader(dr).ToList();
                }
                conn.Close();
                _returnedState.State = true;
                _returnedValues.SingleData = results.FirstOrDefault();
                _returnedValues.RowEffected = 1;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;

            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }




        /// <summary>
        /// Delete Row where PK is Int or Guid
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DbReturned<T> Delete(dynamic ID)
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;


                Type TableType = typeof(T);
                cmd.CommandText = String.Format("DELETE FROM {0} WHERE {1} = '{2}'",
                    TableType.Name, TableType.GetProperties()[0].Name, ID);

                Int32 RowEffect = cmd.ExecuteNonQuery();
                conn.Close();
                _returnedState.State = true;
                _returnedState.RowID = ID;
                _returnedValues.RowEffected = RowEffect;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;
            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }


        /// <summary>
        /// Last Record in Table
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DbReturned<T> LastOrDefault()
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;
                Type TableType = typeof(T);

                cmd.CommandText = String.Format("SELECT TOP(1)* FROM {0} ORDER BY {1} DESC",
                    TableType.Name, TableType.GetProperties()[0].Name);
                List<T> results;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    results = new List<T>().FromDataReader(dr).ToList();
                }
                conn.Close();
                _returnedState.State = true;
                _returnedState.RowID = 0;
                _returnedValues.SingleData = results.FirstOrDefault();
                _returnedValues.RowEffected = 1;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;

            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }

        /// <summary>
        /// Find Record by ID
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ColumnName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DbReturned<T> Find(dynamic ID)
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;
                Type TableType = typeof(T);
                cmd.CommandText = String.Format("SELECT * FROM {0} WHERE {1} = '{2}'",
                    TableType.Name, TableType.GetProperties()[0].Name, ID);
                List<T> results;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    results = new List<T>().FromDataReader(dr).ToList();
                }
                conn.Close();

                _returnedState.State = true;
                _returnedState.RowID = 0;
                _returnedValues.SingleData = results.FirstOrDefault();
                _returnedValues.RowEffected = 1;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;
            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }


        /// <summary>
        /// Get all rows that a specefic word inside cell
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public DbReturned<T> Contains(Func func)
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;
                Type TableType = typeof(T);
                cmd.CommandText = String.Format("SELECT * FROM {0} WHERE {1} LIKE '%{2}%'",
                    TableType.Name, func.ColumnName, func.Value);
                List<T> results;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    results = new List<T>().FromDataReader(dr).ToList();
                }
                conn.Close();

                _returnedState.State = true;
                _returnedState.RowID = 0;
                _returnedValues.Data = results;
                _returnedValues.RowEffected = results.Count;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;


            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }


        /// <summary>
        /// Execute condition and return result data
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public DbReturned<T> Where(Where cond)
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;
                Type TableType = typeof(T);
                string Conditions = string.Empty;
                string Groupby = string.Empty;

                foreach (var item in cond.Conditions)
                {
                    Conditions += "    " + item.Key.ColumnName +
                                  "  = " + item.Key.Value + " " +
                                  item.Value;
                }
                if (cond.isGroupBy)
                {
                    Groupby += " GROUP BY " + cond.GroupBy;
                }
                cmd.CommandText = String.Format("SELECT * FROM {0} WHERE {1} {2}",
                    TableType.Name, Conditions, Groupby);
                List<T> results;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    results = new List<T>().FromDataReader(dr).ToList();
                }
                conn.Close();

                _returnedState.State = true;
                _returnedState.RowID = 0;
                _returnedValues.Data = results;
                _returnedValues.RowEffected = results.Count;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;


            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }

        #endregion


        #region Function

        /// <summary>
        /// Build Insert Statement
        /// </summary>
        /// <param name="D"></param>
        /// <returns></returns>
        public string GetInsertStatement(dynamic D)
        {
            string query = string.Empty;


            Type TableType = D.GetType();
            string parameters = string.Empty;
            for (int i = 0; i < TableType.GetProperties().Length; i++)
            {
                if (i != 0)
                {
                    parameters += " '" + D.GetType().GetProperty(TableType.GetProperties()[i].Name).GetValue(D, null) + "' ,";

                }
            }
            parameters = parameters.TrimEnd(',');
            query = String.Format("INSERT INTO   {0} VALUES( {1} )", TableType.Name, parameters);
            return query;
        }


        /// <summary>
        /// Buils Update Statement
        /// </summary>
        /// <param name="D"></param>
        /// <returns></returns>
        public string GetUpdateStatement(dynamic D)
        {
            string query = string.Empty;

            Type TableType = D.GetType();

            string parameters = string.Empty;
            for (int i = 0; i < TableType.GetProperties().Length; i++)
            {
                if (i != 0)
                {
                    parameters += TableType.GetProperties()[i].Name
                        + " =  '" + D.GetType().GetProperty(TableType.GetProperties()[i].Name).GetValue(D, null) + "' ,";

                }
            }
            parameters = parameters.TrimEnd(',');

            string where = string.Empty;
            where += TableType.GetProperties()[0].Name + " = " +
                D.GetType().GetProperty(TableType.GetProperties()[0].Name).GetValue(D, null);


            query = String.Format("UPDATE  {0} SET {1} WHERE {2}", TableType.Name, parameters, where);
            return query;
        }

        /// <summary>
        /// Build Delete Statement
        /// </summary>
        /// <param name="D"></param>
        /// <returns></returns>
        public string GetDeleteStatement(dynamic D)
        {
            string query = string.Empty;
            Type TableType = D.GetType();
            query = String.Format("DELETE FROM   {0}  WHERE {1} = '{2}'", TableType.Name,
                TableType.GetProperties()[0].Name,
                D.GetType().GetProperty(TableType.GetProperties()[0].Name).GetValue(D, null));
            return query;
        }



        #endregion


        #region Triggers

        /// <summary>
        /// Build trigger for table (Insert - Update - Delete)
        /// </summary>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public DbReturned<T> Trigger(Trigger trigger)
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.Text;
                Type TableType = typeof(T);
                StringBuilder sp = new StringBuilder();
                sp.Append("Use[" + trigger.DataBaseName + "] Go");
                sp.AppendLine();
                sp.Append("Create Trigger [dbo].[" + trigger.TriggerName + "]");
                sp.Append("ON  [dbo].[" + typeof(T).Name + "]");
                sp.Append("FOR ");
                if (trigger.Insert) sp.Append("Insert");
                else if (trigger.Update && !trigger.Insert) sp.Append("Update");
                else if (trigger.Update && trigger.Insert) sp.Append(", Update");
                else if (trigger.Delete && (trigger.Insert || trigger.Update)) sp.Append(", Delete ");
                else if (trigger.Delete && (!trigger.Insert && !trigger.Update)) sp.Append("Delete ");
                sp.Append("AS ");
                sp.AppendLine();
                sp.Append("Begin ");
                sp.AppendLine();
                sp.Append(trigger.Code);
                sp.Append("End ");
                cmd.CommandText = sp.ToString();
                Int32 RowEffect = cmd.ExecuteNonQuery();
                conn.Close();
                _returnedState.State = true;
                _returnedState.RowID = 0;
                _returnedValues.RowEffected = RowEffect;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;
            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }

        #endregion


        #region Transaction 

        /// <summary>
        /// Execute Transaction
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DbReturned<T> Transaction(Trans param)
        {
            InitParams();
            SqlTransaction transaction;
            transaction = conn.BeginTransaction();
            try
            {
                if (param.Insert)
                {
                    foreach (var item in param.lstTypes)
                    {
                        new SqlCommand(GetInsertStatement(item), conn, transaction)
                       .ExecuteNonQuery();
                    }

                }
                else if (param.Update)
                {
                    foreach (var item in param.lstTypes)
                    {
                        new SqlCommand(GetUpdateStatement(item), conn, transaction)
                      .ExecuteNonQuery();
                    }
                }
                else
                {
                    foreach (var item in param.lstTypes)
                    {
                        new SqlCommand(GetDeleteStatement(item), conn, transaction)
                      .ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                _returnedState.State = true;
                _returnedState.RowID = 0;
                _returnedValues.RowEffected = 0;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;
            }
            catch (Exception exp)
            {
                transaction.Rollback();
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }

        }
        #endregion


        #region DataTable

        /// <summary>
        /// Return Data Table from Stored Procedure
        /// </summary>
        /// <param name="StoredProcedureName"></param>
        /// <returns></returns>
        public DbReturned<T> GetListDataTable(StoredProcedure sp)
        {
            try
            {
                InitParams();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp.StoredProcedureName;
                if (sp.arr != null)
                {
                    for (int i = 0; i < sp.arr.Count; i++)
                    {
                        SqlParameter spData = new SqlParameter();
                        spData.ParameterName = sp.Params[i];
                        spData.Value = sp.arr[i];
                        cmd.Parameters.Add(spData);
                    }
                }

                DataTable lResults = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(lResults);

                _returnedState.State = true;
                _returnedState.RowID = 0;
                _returnedValues.dataTable = lResults;
                _returnedValues.RowEffected = lResults.Rows.Count;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;
            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }


        /// <summary>
        /// Convet Select * from Table to DataTable
        /// </summary>
        /// <returns></returns>
        public DbReturned<T> GetListDataTable()
        {
            try
            {
                cmd.Parameters.Clear();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                Type TableType = typeof(T);
                string Query = string.Format("SELECT * FROM  {0}", TableType.Name);
                cmd.CommandText = Query;

                DataTable lResults = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(lResults);
                _returnedState.State = true;
                _returnedState.RowID = 0;
                _returnedValues.dataTable = lResults;
                _returnedValues.RowEffected = lResults.Rows.Count;
                _returnedValues.Returened = _returnedState;
                return _returnedValues;
            }
            catch (Exception exp)
            {
                return SetException(exp, 0);
            }
            finally
            {
                StopConnect();
            }
        }

        #endregion

        ~SqlTables() // dtor or finalize
        {

        }

    }

}
