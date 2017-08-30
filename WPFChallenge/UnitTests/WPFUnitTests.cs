using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class WPFUnitTests
    {
        public Mock<IMessageBox> _messageBox;

        [TestInitialize]
        public void TestInitialize()
        {
            _messageBox = new Mock<IMessageBox>(); // Instantiate the mock message box component
        }

        [TestMethod]
        public void Test()
        {
            _messageBox.Setup(m => m.Show("TEST"));

            var sut = new SUT(_messageBox.Object);

            // Act
            sut.TestMessageBoxShowMethod();

            // Verify
            _messageBox.Verify();
        }

    }
    public interface IMessageBox
    {
        void Show(String message);
    }

    public class SUT
    {
        private IMessageBox _messageBox;

        public SUT(IMessageBox messageBox)
        {
            _messageBox = messageBox;
        }

        public void TestMessageBoxShowMethod()
        {
            _messageBox.Show("TEST");
        }
    }


}
