using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    interface IABM <T>
    {
        List<T> GetAll();
        void Add(T newT);
        void Delete(int id);
        void Update(T updatedT);
    }
}
