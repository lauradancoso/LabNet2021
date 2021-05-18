using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Presentation
{
    interface IUI
    {
        bool Menu();
        void ShowAll();
        void Add();
        void Delete();
        void Update();

    }
}
