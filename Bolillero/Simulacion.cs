using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPBolillero
{
    public class Simulacion
    {
        DateTime InicioSimulacion { get; set; }
        DateTime FinSimulacion { get; set; }

        public double PorcentajeAcierto { get; private set; }
        int MilisegundosDuracion
        {
            get
            {
                return ((TimeSpan)(FinSimulacion - InicioSimulacion)).Milliseconds;
            }
        }
        public ILogicaSimulacion LogicaSimulacion { get; set; }
        public ulong cantidadVecesQueGano(Bolillero bolillero, List<Byte> lista, ulong cantidadDeSimulaciones, byte cantHilos)
        {
            InicioSimulacion = DateTime.Now;
            ulong resultado = Simulacion.cantidadDeVecesQueGano(bolillero, lista, cantidadDeSimulaciones, LogicaSimulacion, cantHilos);
            FinSimulacion = DateTime.Now;
            PorcentajeAcierto = resultado * 100.0 / cantidadDeSimulaciones;
            return resultado;
        }

        public ulong cantidadVecesQueGano(Bolillero bolillero, List<Byte> lista, ulong cantidadDeSimulaciones)
        {
            InicioSimulacion = DateTime.Now;
            ulong resultado = Simulacion.cantidadDeVecesQueGano(bolillero, lista, cantidadDeSimulaciones, LogicaSimulacion);
            FinSimulacion = DateTime.Now;
            PorcentajeAcierto = resultado * 100.0 / cantidadDeSimulaciones;
            return resultado;
        }

        

        public static bool acierta(Bolillero bolillero, List<Byte> lista, ILogicaSimulacion LogicaSimulacion)
        {
            return LogicaSimulacion.acierta(bolillero, lista);
        }

        public static ulong cantidadDeVecesQueGano(Bolillero bolillero, List<Byte> lista, ulong cantidadDeSimulaciones, ILogicaSimulacion LogicaSimulacion)
        {
            ulong cont = 0;
            for (ulong i = 0; i < cantidadDeSimulaciones; i++, incrementarContadorSiEsNecesario(bolillero, lista, ref cont, LogicaSimulacion)) ;
            return cont;
        }

        private static void incrementarContadorSiEsNecesario(Bolillero bolillero, List<Byte> lista, ref ulong cont, ILogicaSimulacion LogicaSimulacion)
        {
            bolillero.volverAColocarBolillas();
            if (LogicaSimulacion.acierta(bolillero, lista))
            {
                cont++;
            }
        }

        public static ulong cantidadDeVecesQueGano(Bolillero bolillero, List<Byte> lista, ulong cantidadDeSimulaciones, ILogicaSimulacion LogicaSimulacion, byte cantHilos)
        {
            Task<ulong>[] hilos = new Task<ulong>[cantHilos];
            asignarTareas(bolillero, hilos, lista, cantidadDeSimulaciones, LogicaSimulacion);
            //Arranco todos los hilos
            Array.ForEach(hilos, hilo => hilo.Start());
            //Espero que todos los hilos terminen
            Task<ulong>.WaitAll(hilos);
            return sumarResultadoHilos(hilos);
        }

        private static ulong sumarResultadoHilos(Task<ulong>[] hilos)
        {
            ulong resultado = 0;
            Array.ForEach(hilos, hilo => resultado += hilo.Result);
            return resultado;
        }

        private static void asignarTareas(Bolillero bolillero, Task<ulong>[] hilos, List<Byte> lista, ulong cantidadDeSimulaciones, ILogicaSimulacion logicaSimulacion)
        {
            ulong simulacionesPorHilo = cantidadDeSimulaciones / (ulong)hilos.Length;
            for (byte i = 0; i < hilos.Length; i++)
            {
                Bolillero clon = (Bolillero)bolillero.Clone();
                hilos[i] = new Task<ulong>(()=>Simulacion.cantidadDeVecesQueGano(clon, lista, simulacionesPorHilo, logicaSimulacion));
            }
        }



    }
}
