using System;
using System.Collections.Generic;

namespace TPBolillero
{
    public class LogicaConOrden: ILogicaSimulacion
    {
        public bool acierta(Bolillero bolillero, List<byte> lista)
        {
            return lista.TrueForAll(numero => numero == bolillero.sacarBolillaAlAzar());
        }
    }
}
