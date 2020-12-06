using App.Entity.Models;
using App.Entity.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entity.IModels
{
    public interface ITData<T> : Interfaces.IEntity<T>
    {
        Task<DbReturned<T>> SelectAsync();
        DbReturned<T> Select();
        Task<DbReturned<T>> SelectAsync(StoredProcedure sp);
        DbReturned<T> Select(StoredProcedure sp);
        Task<DbReturned<T>> FirstOrDefaultAsync();
        DbReturned<T> FirstOrDefault();
        Task<DbReturned<T>> LastAsync();
        DbReturned<T> Last();
        Task<DbReturned<T>> ExecuteAsync(StoredProcedure sp);
        DbReturned<T> Execute(StoredProcedure sp);
        Task<DbReturned<T>> InsertAsync(T Param);
        DbReturned<T> Insert(T Param);
        Task<DbReturned<T>> UpdateAsync(T Param);
        DbReturned<T> Update(T Param);
        Task<DbReturned<T>> DeleteAsync(Int32 ID);
        DbReturned<T> Delete(Int32 ID);
        Task<DbReturned<T>> FindAsync(Int32 ID);
        DbReturned<T> Find(Int32 ID);
        Task<DbReturned<T>> WhereAsync(Where cond);
        DbReturned<T> Where(Where cond);
        Task<DbReturned<T>> ContainsAsync(Func func);
        DbReturned<T> Contains(Func func);



    }
}
