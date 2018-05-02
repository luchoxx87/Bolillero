using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPBolillero
{
    public interface ILogicaSimulacion
    {
        bool acierta(Bolillero bolillero, List<byte> lista);
    }
}
