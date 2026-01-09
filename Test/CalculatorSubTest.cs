using Core;

namespace Test;

public class CalculatorSubTest {
    // Calculator.Sub()
    [Theory]
    [InlineData(0,0,0)]
    [InlineData(3_445,76_441,-72_996)]
    [InlineData(-12,-45,33)]
    public void TestCalculator_Sub_SubtractTwoInts_ReturnInt(int firstNumber, int secondNumber, int expect)
    {

        int result = Calculator.Sub(firstNumber,secondNumber);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Sub_SubtractFromBigInt_ExpectOverflowException()
    {        
        int maxInt = int.MaxValue;
        int createPositiveOverflow = -1;
        int minInt = int.MinValue;
        int createNegativeOverflow = 1;
        
        Assert.Throws<OverflowException>(() => Calculator.Sub(maxInt,createPositiveOverflow));
        Assert.Throws<OverflowException>(() => Calculator.Sub(minInt,createNegativeOverflow));
    }

    [Fact]
    public void TestCalculator_Sub_SubtractsArrayOfInts_ReturnInt()
    {
        int[] numbers = [23,45,66,-66,-22,34,12];
        int expect = -46;

        int result = Calculator.Sub(numbers);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Sub_SubtractsArrayOfBigInts_ExpectOverflowException()
    {        
        int[] numbers = [int.MinValue,int.MinValue,int.MinValue];
        
        Assert.Throws<OverflowException>(() => Calculator.Sub(numbers));
    }

    [Theory]
    [InlineData(0.0,0.0,0.0,15)]
    [InlineData(3.123122,6.345321,-3.222088,3)]
    [InlineData(-12.6666,-45.3333,32.6667,4)]
    public void TestCalculator_Sub_SubtractTwoDoubles_ReturnDouble(double firstNumber, double secondNumber, double expect, int precision)
    {

        double result = Calculator.Sub(firstNumber,secondNumber);

        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Sub_SubtractFromBigDouble_ExpectOverflowException()
    {        
        double maxDouble = 7.997e307;
        double createPositiveOverflow = -9.985e307;
        double minDouble = -9.985e307;
        double createNegativeOverflow = 7.997e307;
        
        Assert.Throws<OverflowException>(() => Calculator.Sub(maxDouble,createPositiveOverflow));
        Assert.Throws<OverflowException>(() => Calculator.Sub(minDouble,createNegativeOverflow));
    }
}
