﻿using System;
using System.Collections.Generic;

namespace TPBolillero
{
    class LogicaConOrden: ILogicaSimulacion
    {
        public bool acierta(Bolillero bolillero, List<byte> lista)
        {
            return lista.TrueForAll(numero => numero == bolillero.sacarBolillaAlAzar());
        }
    }
}
