using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1POO.Interfaces
{
    interface IAvion
    {
        //Métodos de mando de vuelo (movimientos que realiza un avión)
        string Cabeceo();
        string Alabeo();
        string Guiñada();
    }
}
