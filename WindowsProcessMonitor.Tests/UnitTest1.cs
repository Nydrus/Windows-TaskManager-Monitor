using NUnit.Framework.Constraints;
using System.Diagnostics;
using System.Linq.Expressions;
using WindowsProcessMonitor;

namespace WindowsProcessMonitor.Tests
{
    public class Tests
    {
        Logic? logic;
        ConsoleLogs? logs;
        string[]? args;
        
        [SetUp]
        public void Setup()
        {
            logic = new();
            logs = new();
        }
        [TearDown]
        public void Teardown()
        {
            logic = null;
            logs = null;
           
        }

        [Test]
        public void ArgsCast_WhenNoProcessIsFound_BooleanSendErrorMessage_ReturnsTrue()
        {
            try
            {
                args = new string[] { "1", "1" };
                Logic.sendErrorMessage = false;
                logic.ArgsCast(args);
                Assert.That(Logic.sendErrorMessage, Is.EqualTo(true));
            }
            catch (NullReferenceException ex)
            {
                
            }
        }
        
        [Test]
        public void ChangeSendErrorMessage_WhenFalseBooleanIsProvidedAsParameter_ReturnsFalse()
        {
            Logic.sendErrorMessage = true;
            Assert.That(logic.ChangeSendErrorMessage(false),Is.False);
            
        }
        [Test]
        public void ChangeSendErrorMessage_WhenTrueBooleanIsProvidedAsParameter_ReturnsTrue()
        {
            Logic.sendErrorMessage = false;
            Assert.That(logic.ChangeSendErrorMessage(true), Is.True);
        }
        [Test]
        public void ChangeInfoMessage_WhenFalseBooleanIsProvidedAsParameter_ReturnsFalse()
        {
            Logic.infoMessage = true;
            Assert.That(Logic.ChangeInfoMessage(false), Is.False);
        }
        [Test]
        public void ChangeInfoMessage_WhenTrueBooleanIsProvidedAsParameter_ReturnsTrue()
        {
            Logic.infoMessage = false;
            Assert.That(Logic.ChangeInfoMessage(true), Is.True);
        }
    }
}