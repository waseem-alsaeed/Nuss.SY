using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using App.Entity.Structs;
using App.Entity.Models;

namespace App.Entity.IModels
{
    public partial interface IRepository<T> : Entity.Interfaces.IEntity<T>
    {
        DbReturned<T> Select(StoredProcedure sp);
        DbReturned<T> AllData();
        DbReturned<T> Execute(StoredProcedure sp);
        DbReturned<T> FirstOrDefault();
        DbReturned<T> LastOrDefault();
        DbReturned<T> Find(dynamic ID);
        DbReturned<T> Contains(Func func);
        DbReturned<T> GetListDataTable(StoredProcedure sp);
        DbReturned<T> GetListDataTable();
        DbReturned<T> Delete(dynamic ID);
        DbReturned<T> Insert(T param);
        DbReturned<T> Update(T param);
        DbReturned<T> Transaction(Trans param);
        DbReturned<T> Where(Where cond);
        DbReturned<T> Trigger(Trigger trigger);
    }
}
