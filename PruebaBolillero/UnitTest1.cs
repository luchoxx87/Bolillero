using System;
using TPBolillero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PruebaBolillero
{
    [TestClass]
    public class UnitTest1
    {
        byte cantBolillas;
        Bolillero bolillero;
        ulong cantidadSimulaciones;
        List<Byte> jugada;

        [TestInitialize]
        public void iniciar()
        {
            cantBolillas = 10;
            bolillero = new Bolillero(cantBolillas);
            cantidadSimulaciones = 5000;
            jugada = new List<byte> { 0 };            
        }

        [TestMethod]
        public void cantidadDeBolillas()
        {
            Assert.AreEqual(cantBolillas, bolillero.BolillasAdentro.Count);
            Assert.AreEqual(0, bolillero.BolillasFuera.Count);
        }

        [TestMethod]
        public void efectoDelBolillero()
        {
            byte bolilla = bolillero.sacarBolillaAlAzar();
            Assert.IsFalse(bolillero.BolillasAdentro.Contains(bolilla));
            Assert.IsTrue(bolillero.BolillasFuera.Contains(bolilla));
        }

        [TestMethod]
        public void probandoClon()
        {
            Bolillero otroBolillero = (Bolillero)bolillero.Clone();
            Assert.AreEqual(otroBolillero.CantidadDeBolillas, bolillero.CantidadDeBolillas);
            Assert.AreEqual(otroBolillero.BolillasAdentro.Count, bolillero.BolillasAdentro.Count);
            Assert.IsTrue(otroBolillero.BolillasAdentro.TrueForAll(bolilla => bolillero.BolillasAdentro.Contains(bolilla)));
        }
        [TestMethod]
        public void cantSimulacionesSinHilo()
        {
            ulong resultado = Simulacion.cantidadDeVecesQueGano(bolillero, jugada, cantidadSimulaciones);
            Assert.AreEqual(cantidadSimulaciones/10 , resultado);
        }

        [TestMethod]
        public void cantSimulacionesConHilo()
        {
            //TODO
        }
    }
}
