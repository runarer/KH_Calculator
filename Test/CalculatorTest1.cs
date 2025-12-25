using Core;

namespace Test;

public class CalculatorTest
{
    [Theory]
    [InlineData(0,0,0)]
    [InlineData(3_445,76_441,79_886)]
    [InlineData(-12,-45,-57)]
    public void TestCalculator_Add_AddTwoInts_ReturnInt(int firstNumber, int secondNumber, int expect)
    {
        Calculator calculator = new();

        int result = calculator.Add(firstNumber,secondNumber);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Add_AddToBigInts_ExpectOverflowException()
    {        
        Calculator calculator = new();
        int maxInt = int.MaxValue;
        int createPositiveOverflow = 1;
        int minInt = int.MinValue;
        int createNegativeOverflow = -1;
        
        Assert.Throws<OverflowException>(() => calculator.Add(maxInt,createPositiveOverflow));
        Assert.Throws<OverflowException>(() => calculator.Add(minInt,createNegativeOverflow));
    }

    [Theory]
    [InlineData(0,0,0)]
    [InlineData(3_445,76_441,-72_986)]
    [InlineData(-12,-45,33)]
    public void TestCalculator_Sub_SubtractTwoInts_ReturnInt(int firstNumber, int secondNumber, int expect)
    {
        Calculator calculator = new();

        int result = calculator.Sub(firstNumber,secondNumber);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Sub_SubtractFromBigInt_ExpectOverflowException()
    {        
        Calculator calculator = new();
        int maxInt = int.MaxValue;
        int createPositiveOverflow = -1;
        int minInt = int.MinValue;
        int createNegativeOverflow = 1;
        
        Assert.Throws<OverflowException>(() => calculator.Sub(maxInt,createPositiveOverflow));
        Assert.Throws<OverflowException>(() => calculator.Sub(minInt,createNegativeOverflow));
    }

    [Theory]
    [InlineData(1,1,1)]
    [InlineData(445,441,196_245)]
    [InlineData(-12,34,-408)]
    public void TestCalculator_Multi_MultiplyTwoInts_ReturnInt(int firstNumber, int secondNumber, int expect)
    {
        Calculator calculator = new();

        int result = calculator.Multi(firstNumber,secondNumber);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Multi_MultiplyTwoBigInts_ExpectOverflowException()
    {        
        Calculator calculator = new();
        int maxInt = int.MaxValue;        
        int minInt = int.MinValue;
                
        Assert.Throws<OverflowException>(() => calculator.Multi(maxInt,maxInt));
        Assert.Throws<OverflowException>(() => calculator.Multi(minInt,minInt));
    }

    [Theory]
    [InlineData(1,1,1)]
    [InlineData(445,97,5)]
    [InlineData(875,5,175)]
    [InlineData(74,9,8)]
    public void TestCalculator_Div_DivideTwoInts_ReturnRoundedInt(int firstNumber, int secondNumber, int expect)
    {
        Calculator calculator = new();

        int result = calculator.Div(firstNumber,secondNumber);
        
        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Div_DivideANumberWithZero_ExpectDivideByZeroException()
    {   
        Calculator calculator = new();
        int number = 123;
                
        Assert.Throws<DivideByZeroException>(() => calculator.Div(number,0));
    }

}
