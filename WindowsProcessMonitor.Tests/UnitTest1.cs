using NUnit.Framework.Constraints;
using System.Diagnostics;
using System.Linq.Expressions;
using WindowsProcessMonitor;

namespace WindowsProcessMonitor.Tests
{
    public class Tests
    {
        Logic logic;
        ConsoleLogs logs;
        Process? process;
        string[] args;
        int _frequency = 1;
        string _name;
        
        [SetUp]
        public void Setup()
        {
            
        }
        [TearDown] 
        public void Teardown() { 
            
        }

        [Test]
        public void ArgsCast_WhenNoProcessIsFound_SendErrorMessage_ShouldBeTrue()
        {
            try
            {
                logic = new();
                logs = new();
                args = new string[] { "1", "1" };
                Logic.sendErrorMessage = false;
                logic.ArgsCast(args);
            }
            catch(Exception ex)
            {

            }
             Assert.That(Logic.sendErrorMessage, Is.EqualTo(true));
        }
    }
}