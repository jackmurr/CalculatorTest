using Calculator.Core.Services;

namespace Calculator.Core.Test
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService sut;
        public CalculatorServiceTests() { sut = new CalculatorService(); }
        
        
        [Fact]
        public void CalculatorService_Add_PositiveNumbers()
        {
            var res = sut.Add(50, 100);
            Assert.Equal(150, res);
        }

        [Fact]
        public void CalculatorService_Add_NegativeNumbers()
        {
            var res = sut.Add(-50, -100);
            Assert.Equal(-150, res);
        }

        [Fact]
        public void CalculatorService_Add_MixedNumbers()
        {
            var res = sut.Add(50, -100);
            Assert.Equal(-50, res);
        }

        [Fact]
        public void CalculatorService_Add_GreaterThanBounds()
        {
            Assert.Throws<OverflowException>(() => sut.Add(2147483647, 1));    
        }

        [Fact]
        public void CalculatorService_Add_LessThanBounds()
        {
            Assert.Throws<OverflowException>(() => sut.Add(-2147483647, -5));
        }

        [Fact]
        public void CalculatorService_Subtract_PositiveNumbers()
        {
            var res = sut.Subtract(100, 50);
            Assert.Equal(50, res);
        }

        [Fact]
        public void CalculatorService_Subtract_NegativeNumbers()
        {
            var res = sut.Subtract(-100, -50);
            Assert.Equal(-50, res);
        }

        [Fact]
        public void CalculatorService_Subtract_MixedNumbers()
        {
            var res = sut.Subtract(100, -50);
            Assert.Equal(150, res);
        }

        [Fact]
        public void CalculatorService_Subtract_LessThanBounds()
        {
            Assert.Throws<OverflowException>(() => sut.Subtract(-2147483648, 100));
        }
    }
}