using AverageConsoleProject;
using NUnit.Framework;

namespace AverageProjectTest
{
    /// <summary>
    /// Test class for the Average calculator
    /// Tests all scenarios including addition, average calculation, count, and reset functionality
    /// </summary>
    [TestFixture]
    public class AverageTest
    {
        private Average _averageCalculator;

        [SetUp]
        public void Setup()
        {
            _averageCalculator = new Average();
        }

        [Test]
        public void Add_SinglePositiveNumber_StoresCorrectly()
        {
            // Arrange & Act
            _averageCalculator.Add(5.0);

            // Assert
            Assert.That(_averageCalculator.Count, Is.EqualTo(1));
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(5.0));
        }

        [Test]
        public void Add_SingleNegativeNumber_StoresCorrectly()
        {
            // Arrange & Act
            _averageCalculator.Add(-10.0);

            // Assert
            Assert.That(_averageCalculator.Count, Is.EqualTo(1));
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(-10.0));
        }

        [Test]
        public void Add_SingleZero_StoresCorrectly()
        {
            // Arrange & Act
            _averageCalculator.Add(0.0);

            // Assert
            Assert.That(_averageCalculator.Count, Is.EqualTo(1));
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(0.0));
        }

        [Test]
        public void Add_MultipleNumbers_CountIncrementsCorrectly()
        {
            // Arrange & Act
            _averageCalculator.Add(5.0);
            _averageCalculator.Add(10.0);
            _averageCalculator.Add(15.0);

            // Assert
            Assert.That(_averageCalculator.Count, Is.EqualTo(3));
        }

        [Test]
        public void Add_MultiplePositiveNumbers_CalculatesCorrectAverage()
        {
            // Arrange & Act
            _averageCalculator.Add(7.5);
            _averageCalculator.Add(20.5);
            _averageCalculator.Add(-10);

            // Assert
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(6.0).Within(0.0001));
        }

        [Test]
        public void Add_LargeNumbers_CalculatesCorrectly()
        {
            // Arrange & Act
            _averageCalculator.Add(1000000.0);
            _averageCalculator.Add(2000000.0);
            _averageCalculator.Add(3000000.0);

            // Assert
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(2000000.0).Within(0.0001));
        }

        [Test]
        public void Add_SmallDecimals_CalculatesCorrectly()
        {
            // Arrange & Act
            _averageCalculator.Add(0.1);
            _averageCalculator.Add(0.2);
            _averageCalculator.Add(0.3);

            // Assert
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(0.2).Within(0.0001));
        }

        [Test]
        public void Add_MixedPositiveAndNegative_CalculatesCorrectly()
        {
            // Arrange & Act
            _averageCalculator.Add(100.0);
            _averageCalculator.Add(-50.0);
            _averageCalculator.Add(50.0);

            // Assert
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(33.333333333).Within(0.0001));
        }

       
        [Test]
        public void CurrentAverage_WithNoNumbers_ReturnsZero()
        {
            // Arrange & Act
            var average = _averageCalculator.CurrentAverage;

            // Assert
            Assert.That(average, Is.EqualTo(0.0));
        }

        [Test]
        public void CurrentAverage_WithSingleNumber_ReturnsThatNumber()
        {
            // Arrange & Act
            _averageCalculator.Add(42.5);
            var average = _averageCalculator.CurrentAverage;

            // Assert
            Assert.That(average, Is.EqualTo(42.5));
        }
       
        [Test]
        public void CurrentAverage_UpdatesAfterEachAdd()
        {
            // Arrange & Act & Assert
            _averageCalculator.Add(10.0);
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(10.0));

            _averageCalculator.Add(20.0);
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(15.0));

            _averageCalculator.Add(30.0);
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(20.0));
        }

        [Test]
        public void Average_WithVeryManyNumbers_CalculatesCorrectly()
        {
            // Arrange & Act
            for (int i = 0; i < 1000; i++)
            {
                _averageCalculator.Add(1.0);
            }

            // Assert
            Assert.That(_averageCalculator.Count, Is.EqualTo(1000));
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(1.0));
        }

        [Test]
        public void Average_WithZeroAndNonZeroNumbers_CalculatesCorrectly()
        {
            // Arrange & Act
            _averageCalculator.Add(0.0);
            _averageCalculator.Add(10.0);
            _averageCalculator.Add(0.0);
            _averageCalculator.Add(20.0);

            // Assert
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(7.5));
        }

        #region (Optional) Reset Method Tests

        [Test]
        public void Reset_WithData_ClearsEverything()
        {
            // Arrange
            _averageCalculator.Add(10.0);
            _averageCalculator.Add(20.0);
            _averageCalculator.Add(30.0);

            // Act
            _averageCalculator.Reset();

            // Assert
            Assert.That(_averageCalculator.Count, Is.EqualTo(0));
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(0.0));
        }

        [Test]
        public void Reset_WithoutData_DoesNotThrow()
        {
            // Arrange & Act & Assert
            Assert.DoesNotThrow(() => _averageCalculator.Reset());
            Assert.That(_averageCalculator.Count, Is.EqualTo(0));
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(0.0));
        }

        [Test]
        public void Reset_AllowsResumeAfterReset()
        {
            // Arrange
            _averageCalculator.Add(100.0);
            _averageCalculator.Reset();

            // Act
            _averageCalculator.Add(50.0);
            _averageCalculator.Add(50.0);

            // Assert
            Assert.That(_averageCalculator.Count, Is.EqualTo(2));
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(50.0));
        }

        [Test]
        public void Reset_MultipleTimes_WorksCorrectly()
        {
            // Arrange & Act
            _averageCalculator.Add(10.0);
            _averageCalculator.Reset();
            _averageCalculator.Add(20.0);
            _averageCalculator.Reset();
            _averageCalculator.Add(30.0);

            // Assert
            Assert.That(_averageCalculator.Count, Is.EqualTo(1));
            Assert.That(_averageCalculator.CurrentAverage, Is.EqualTo(30.0));
        }

        #endregion       
    }
}
