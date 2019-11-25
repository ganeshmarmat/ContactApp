using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Contract
{
    public interface IDataMapper<T1,T2> where T1: class
    {
        List<T1> GetAll();
        T1 GetById(T2 id);
        bool Remove(T1 obj);
        bool Add(T1 obj);
        bool Edit(T1 obj);
    }
}
