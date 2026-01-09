using Core;

namespace Test;

public class CalculatorMultiTest
{
    // Calculator.Multi()
    [Theory]
    [InlineData(1,1,1)]
    [InlineData(445,441,196_245)]
    [InlineData(-12,34,-408)]
    public void TestCalculator_Multi_MultiplyTwoInts_ReturnInt(int firstNumber, int secondNumber, int expect)
    {

        int result = Calculator.Multi(firstNumber,secondNumber);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Multi_MultiplyTwoBigInts_ExpectOverflowException()
    {        
        int maxInt = int.MaxValue;        
        int minInt = int.MinValue;
                
        Assert.Throws<OverflowException>(() => Calculator.Multi(maxInt,maxInt));
        Assert.Throws<OverflowException>(() => Calculator.Multi(minInt,minInt));
    }

    [Fact]
    public void TestCalculator_Multi_MultiplysArrayOfInts_ReturnInt()
    {
        int[] numbers = [23,45,66,66,22];
        int expect = 99_186_120;

        int result = Calculator.Multi(numbers);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Multi_MultiplysArrayOfBigInts_ExpectOverflowException()
    {        
        int[] numbers = [23,45,66,66,22,int.MaxValue];
        
        Assert.Throws<OverflowException>(() => Calculator.Multi(numbers));
    }


    [Theory]
    [InlineData(1.0,1.0,1.0,15)]
    [InlineData(445.0,441.1233123,196_299.8739735,7)]
    [InlineData(-12.451,34.6,-430.8046,4)]
    public void TestCalculator_Multi_MultiplyTwoDoubles_ReturnDouble(double firstNumber, double secondNumber, double expect, int precision)
    {
        double result = Calculator.Multi(firstNumber,secondNumber);

        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Multi_MultiplyTwoBigDoubles_ExpectOverflowException()
    {        
        double maxDouble = double.MaxValue;        
        double minDouble = double.MinValue;
                
        Assert.Throws<OverflowException>(() => Calculator.Multi(maxDouble,maxDouble));
        Assert.Throws<OverflowException>(() => Calculator.Multi(minDouble,minDouble));
    }

    [Fact]
    public void TestCalculator_Multi_MultiplyArrayOfDoubles_ReturnDouble()
    {
        double[] numbers = [66.45663,22.44321,34.98764];
        double expect = 52_184.06866;
        int precision = 5;

        double result = Calculator.Multi(numbers);

        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Multi_MultiplyArrayOfBigDoubles_ExpectOverflowException()
    {        
        double[] numbers = [9.985e307,9.985e307,9.985e307];
        
        Assert.Throws<OverflowException>(() => Calculator.Multi(numbers));
    }
} 

