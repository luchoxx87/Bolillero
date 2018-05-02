using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPBolillero
{
    public class Simulacion
    {
        public static bool acierta(Bolillero bolillero, List<Byte> lista, ILogicaSimulacion LogicaSimulacion)
        {
            //return lista.All(numero => numero == bolillero.sacarBolillaAlAzar());
            return LogicaSimulacion.acierta(bolillero, lista);
        }

        public static ulong cantidadDeVecesQueGano(Bolillero bolillero, List<Byte> lista, ulong cantidadDeSimulaciones, ILogicaSimulacion LogicaSimulacion)
        {
            ulong cont = 0;
            for (ulong i = 0; i < cantidadDeSimulaciones; i++, incrementarContadorSiEsNecesario(bolillero, lista, ref cont, ILogicaSimulacion LogicaSimulacion)) ;
            return cont;
        }

        private static void incrementarContadorSiEsNecesario(Bolillero bolillero, List<Byte> lista, ref ulong cont, ILogicaSimulacion LogicaSimulacion)
        {
            //TODO
        }

        public static ulong cantidadDeVecesQueGano(Bolillero bolillero, List<Byte> lista, ulong cantidadDeSimulaciones, ILogicaSimulacion LogicaSimulacion, byte cantHilos)
        {
            //TODO
        }

        private static ulong sumarResultadoHilos(Task<ulong>[] hilos)
        {
            //TODO
        }

        private static void asignarTareas(Bolillero bolillero, Task<ulong>[] hilos, List<Byte> lista, ulong cantidadDeSimulaciones)
        {
            //TODO
        }

    }
}
