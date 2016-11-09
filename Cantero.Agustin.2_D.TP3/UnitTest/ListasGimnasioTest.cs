using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace UnitTest
{
    [TestClass]
    public class ListasGimnasioTest
    {
        Gimnasio gimnasioPrueba = new Gimnasio();

        [TestMethod]
        public void listaAlumnosTest()
        {
            
            Assert.IsNotNull(gimnasioPrueba.Alumnos);
            
        }

        [TestMethod]
        public void listaInstructoresTest()
        {
            Assert.IsNotNull(gimnasioPrueba.Instructores);
        }

        [TestMethod]
        public void listaJornadasTest()
        {
            Assert.IsNotNull(gimnasioPrueba.Jornada);
        }
    }
}
