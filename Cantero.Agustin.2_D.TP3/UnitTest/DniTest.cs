using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace UnitTest
{
    [TestClass]
    public class DniTest
    {

        [TestMethod]
        public void DniInvalidoTest()
        {
            try
            {
                Instructor instructor = new Instructor(1, "Agustin", "Cantero", "0", Persona.ENacionalidad.Argentino);
                Assert.Fail(); 
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));  
            }
            
            
            

            
        }
    }
}
