using NUnit.Framework;
using log4net;

namespace Abot.Tests.Unit
{
    [SetUpFixture]
    public class AssemblySetup
    {
        [SetUp]
        public void Setup()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
