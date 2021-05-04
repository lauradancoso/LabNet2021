using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Presentation
{
    interface IUI
    {
        bool Menu();
        void ShowAll();
        //void GoBack();
        void Add();
        void Delete();
        void Update();

    }
}
