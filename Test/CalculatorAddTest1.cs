using Core;

namespace Test;

public class CalculatorAddTest
{
    // Calculator.Add()
    [Theory]
    [InlineData(0,0,0)]
    [InlineData(3_445,76_441,79_886)]
    [InlineData(-12,-45,-57)]
    public void TestCalculator_Add_AddTwoInts_ReturnInt(int firstNumber, int secondNumber, int expect)
    {

        int result = Calculator.Add(firstNumber,secondNumber);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Add_AddToBigInts_ExpectOverflowException()
    {
        int maxInt = int.MaxValue;
        int createPositiveOverflow = 1;
        int minInt = int.MinValue;
        int createNegativeOverflow = -1;
        
        Assert.Throws<OverflowException>(() => Calculator.Add(maxInt,createPositiveOverflow));
        Assert.Throws<OverflowException>(() => Calculator.Add(minInt,createNegativeOverflow));
    }

    [Fact]
    public void TestCalculator_Add_AddsArrayOfInts_ReturnInt()
    {
        int[] numbers = [23,45,66,66,22,34];
        int expect = 256;

        int result = Calculator.Add(numbers);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Add_AddsArrayOfBigInts_ExpectOverflowException()
    {        
        int[] numbers = [23,45,66,66,22,34,int.MaxValue];
        
        Assert.Throws<OverflowException>(() => Calculator.Add(numbers));
    }


    [Theory]
    [InlineData(0.0,0.0,0.0,15)]
    [InlineData(3.123122,6.345321,9.468443,6)]
    [InlineData(-12.6666,-45.3333,-57.9999,4)]
    public void TestCalculator_Add_AddTwoDoubles_ReturnDouble(double firstNumber, double secondNumber, double expect, int precision)
    {

        double result = Calculator.Add(firstNumber,secondNumber);

        Assert.Equal(expect,result,precision);
    }
    
    [Fact]
    public void TestCalculator_Add_AddToBigDoubles_ExpectOverflowException()
    {        
        double bigDouble = 7.997e307;
        double createPositiveOverflow =  9.985e307;
        double bigNegativeDouble = -7.997e307;
        double createNegativeOverflow = -9.985e307;
        
        Assert.Throws<OverflowException>(() => Calculator.Add(bigDouble,createPositiveOverflow));
        Assert.Throws<OverflowException>(() => Calculator.Add(bigNegativeDouble,createNegativeOverflow));
    }

    [Fact]
    public void TestCalculator_Add_AddsArrayOfDoubles_ReturnDouble()
    {
        double[] numbers = [66.45663,22.44321,34.98764];
        double expect = 123.88748;
        int precision = 5;

        double result = Calculator.Add(numbers);

        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Add_AddsArrayOfBigDoubles_ExpectOverflowException()
    {        
        double[] numbers = [9.985e307,9.985e307,9.985e307];
        
        Assert.Throws<OverflowException>(() => Calculator.Add(numbers));
    }
}


