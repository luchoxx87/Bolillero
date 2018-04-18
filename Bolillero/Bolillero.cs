using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPBolillero
{
    public class Bolillero: ICloneable
    {
        Random r;
        public List<Byte> BolillasAdentro { get; private set; }

        public List<Byte> BolillasFuera { get; private set; }

        public Byte CantidadDeBolillas { get; private set; }

        public Bolillero(byte cantidadDebolillas)
        {
            BolillasAdentro = new List<byte>();
            BolillasFuera = new List<byte>();
            crearBolillas(cantidadDebolillas);
            r = new Random(DateTime.Now.Millisecond);
        }

        private Bolillero() 
        {
            r = new Random(DateTime.Now.Millisecond);
        }

        private void crearBolillas(byte cantidadBolillas)
        {            
            for (byte bolilla = 0; bolilla < cantidadBolillas; bolilla++)
            {
                BolillasAdentro.Add(bolilla);
            }
        }

        public byte sacarBolillaAlAzar()
        {
            byte posicionBolilla = posicionDeBolillaAlAzar();
            byte bolillaASacar = BolillasAdentro[posicionBolilla];
            BolillasFuera.Add(bolillaASacar);
            BolillasAdentro.RemoveAt(posicionBolilla);
            return bolillaASacar;
        }

        public void volverAColocarBolillas()
        {
            BolillasAdentro.AddRange(BolillasFuera);
            BolillasFuera.Clear();
        }

        private byte posicionDeBolillaAlAzar()
        {
            return (byte)r.Next(0, BolillasAdentro.Count);
        }

        public object Clone()
        {
            Bolillero clon = new Bolillero();
            clon.CantidadDeBolillas = this.CantidadDeBolillas;
            clon.BolillasAdentro = new List<byte>(this.BolillasAdentro);
            clon.BolillasFuera = new List<byte>(this.BolillasFuera);
            return clon;
        }
    }
}
