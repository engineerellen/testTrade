using Domain.Servico;
using Domain.Servico.Interface;
using NUnit.Framework;

namespace ConsoleTest
{
    [TestFixture]
    public class Tests
    {
        private readonly IProccessService _processoService = new ProccessService();

        [Test]
        public void EnvioNovosRegistros()
        {
          
        }

        [Test]
        [Ignore("este método não será executado")]
        public void AtualizacaoCodigoBarras()
        {
         //
        }

 
    }
}
