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
        string[] args;
        int _frequency = 1;
        string _name;
        public TimeSpan _lifetime = TimeSpan.FromMinutes(2);

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
        public void KillProcess_WhenProcessIsFoundAndTimeSpanLifetimeIsGreaterThanDeclared_BooleanSendErrorMessage_ReturnsFalse()
        {
            _name = "notepad";
            args = new string[] {_name,"1", "1" };
            Logic.sendErrorMessage = true;
            Process? process = Process.GetProcessesByName(_name).FirstOrDefault();
            logic.KillProcess(process);
            Assert.That(Logic.sendErrorMessage, Is.EqualTo(false));

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
    }
}