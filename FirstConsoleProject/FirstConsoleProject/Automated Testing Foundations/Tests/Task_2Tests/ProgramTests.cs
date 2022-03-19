using NUnit.Framework;
using Task_2;

namespace Task_2Tests
{
    public class ProgramTests
    {
        [Test]
        public void COnverTo_WhenDataValid_ShouldValidResult()
        {
            // Arrange
            var expected = "1A";
            int value = 21;
            int baseNumber = 11;
            Program program = new Program();

            // Act
            string actual = Program.ConverTo(value, baseNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1A", 21, 11)]
        [TestCase("2A", 32, 11)]
        [TestCase("3A", 43, 11)]
        [TestCase("4A", 54, 11)]
        public void COnverTo_WhenDataValide_ShouldValidResult(
            string expected, int value, int baseNumber)
        {
            // Arrange
            Program program = new Program();

            // Act
            string actual = Program.ConverTo(value, baseNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}