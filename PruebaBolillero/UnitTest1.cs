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
        Simulacion simulacion;
        LogicaConOrden logicaOrden;

        [TestInitialize]
        public void iniciar()
        {
            cantBolillas = 10;
            bolillero = new Bolillero(cantBolillas);
            cantidadSimulaciones = 500000;
            jugada = new List<byte> { 0 };
            simulacion = new Simulacion();
            logicaOrden = new LogicaConOrden();
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
        public void probandoSimulacionSinHilosConOrden()
        {
            simulacion.LogicaSimulacion = logicaOrden;
            simulacion.cantidadVecesQueGano(bolillero, jugada, cantidadSimulaciones);
            Assert.AreEqual(10.0, simulacion.PorcentajeAcierto, 0.01);
        }

        [TestMethod]
        public void probandoSimulacionConHilosConOrden()
        {
            simulacion.LogicaSimulacion = logicaOrden;
            Assert.AreEqual(cantidadSimulaciones / 10, simulacion.cantidadVecesQueGano(bolillero, jugada, cantidadSimulaciones, 4));
        }

    }
}
