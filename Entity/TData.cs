using System;
using System.Linq;
using System.Threading.Tasks;
using App.Entity.IDispose;
using App.Entity.Structs;
using App.Entity.Models;
using App.Entity;
using App.Entity.IModels;

namespace App.Entity
{
    public partial class TData<T> : TModel , ITData<T>
        where T : class , new()
                                               
    {
        SqlTables<T> dc;

        #region Constructore

        /// <summary>
        /// Constructure for Init Tables and Set Connrction Sring
        /// </summary>
        /// <param name="cs"></param>
        public TData()
        {
            dc = new SqlTables<T>();
        }

        public TData(string connectionString)
        {
            dc = new SqlTables<T>(connectionString);
        }

        /// <summary>
        /// Deconstructore  => finalize
        /// </summary>
        ~TData()
        {

        }

        #endregion

        #region Methods T

        /// <summary>
        /// Select All Async
        /// </summary>
        /// <returns></returns>
        public async Task<DbReturned<T>> SelectAsync()
        {
            Func<DbReturned<T>> asyncData = delegate
            {
                return dc.AllData();
            };
            return await Task.Run(() => asyncData());
        }

        /// <summary>
        /// Select All
        /// </summary>
        /// <returns></returns>
        public DbReturned<T> Select()
        {
            return dc.AllData();
        }


        /// <summary>
        /// call stored Procedure for select between two tables or moe Async
        /// <param name="sp"></param>
        /// <returns></returns>
        public async Task<DbReturned<T>> SelectAsync(StoredProcedure sp)
        {
            Func<StoredProcedure, DbReturned<T>> asyncData = delegate
            {
                return dc.Select(sp);
            };
            return await Task.Run(() => asyncData(sp));
        }


        /// <summary>
        /// call stored Procedure for select between two tables or moe
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DbReturned<T> Select(StoredProcedure sp)
        {
            return dc.Select(sp);
        }


        /// <summary>
        /// return T type or null  Async
        /// </summary>
        /// <returns></returns>
        public async Task<DbReturned<T>> FirstOrDefaultAsync()
        {
            Func<DbReturned<T>> First = () =>
            {
                return dc.FirstOrDefault();
            };
            return await Task.Run(() => First());
        }

        /// <summary>
        /// return T type or null  
        /// </summary>
        /// <returns></returns>
        public DbReturned<T> FirstOrDefault()
        {
            return dc.FirstOrDefault();
        }

        /// <summary>
        /// return T type or null  Async
        /// </summary>
        /// <returns></returns>
        public async Task<DbReturned<T>> LastAsync()
        {
            Func<DbReturned<T>> Last = () =>
            {
                return dc.LastOrDefault();
            };
            return await Task.Run(() => Last());
        }

        /// <summary>
        /// return T type or null  
        /// </summary>
        /// <returns></returns>
        public DbReturned<T> Last()
        {
            return dc.LastOrDefault();
        }

        /// <summary>
        /// Execute Stored Procedure fpr Insert , Update , Delete   async
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public async Task<DbReturned<T>> ExecuteAsync(StoredProcedure sp)
        {
            return await Task.Run(() => dc.Execute(sp));
        }


        /// <summary>
        /// Execute Stored Procedure fpr Insert , Update , Delete
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DbReturned<T> Execute(StoredProcedure sp)
        {
            return dc.Execute(sp);
        }


        /// <summary>
        /// Insert a new record Async
        /// </summary>
        /// <param name="Param"></param>
        /// <returns></returns>
        public async Task<DbReturned<T>> InsertAsync(T Param)
        {
            return await Task.Run(() => dc.Insert(Param));
        }

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="Param"></param>
        /// <returns></returns>
        public DbReturned<T> Insert(T Param)
        {
            return dc.Insert(Param);
        }



        /// <summary>
        /// Update Record async
        /// </summary>
        /// <param name="Param"></param>
        /// <returns></returns>
        public async Task<DbReturned<T>> UpdateAsync(T Param)
        {
            return await Task.Run(() => dc.Update(Param));
        }

        /// <summary>
        /// Update Record
        /// </summary>
        /// <param name="Param"></param>
        /// <returns></returns>
        public DbReturned<T> Update(T Param)
        {
            return dc.Update(Param);
        }



        /// <summary>
        /// Delete Record  Async
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<DbReturned<T>> DeleteAsync(Int32 ID)
        {
            return await Task.Run(() => dc.Delete(ID));
        }


        /// <summary>
        /// Delete Record 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DbReturned<T> Delete(Int32 ID)
        {
            return dc.Delete(ID);
        }


        /// <summary>
        /// Find Record by PK async
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<DbReturned<T>> FindAsync(Int32 ID)
        {
            Func<Int32, DbReturned<T>> GetData = (id) =>
            {
                return dc.Find(id); ;
            };
            return await Task.Run(() => GetData(ID));
        }

        /// <summary>
        /// Find Record by PK
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DbReturned<T> Find(Int32 ID)
        {
            return dc.Find(ID); ;
        }



        /// <summary>
        /// Select from One table by where Async
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public async Task<DbReturned<T>> WhereAsync(Where cond)
        {
            return await Task.Run(() => dc.Where(cond));
        }


        /// <summary>
        /// Select from One table by where 
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public DbReturned<T> Where(Where cond)
        {
            return dc.Where(cond);
        }



        /// <summary>
        /// Select by Where from one table (Like in where in TSQL) Async
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public async Task<DbReturned<T>> ContainsAsync(Func func)
        {
            return await Task.Run(() => dc.Contains(func));
        }


        /// <summary>
        /// Select by Where from one table (Like in where in TSQL)
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public DbReturned<T> Contains(Func func)
        {
            return dc.Contains(func);
        }


        #endregion

    }
}
