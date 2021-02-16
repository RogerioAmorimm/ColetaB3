using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColetaB3.Interfaces
{
    public interface ICollect<T>
    {
         Task<T> GetCollect();
         bool IsValid();
    }
}
