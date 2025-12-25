using Core;

namespace Test;

public class CalculatorTest
{
    // Calculator.Add()
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
    [InlineData(0.0,0.0,0.0)]
    [InlineData(3.123122,6.345321,9.468443)]
    [InlineData(-12.6666,-45.3333,-57.9999)]
    public void TestCalculator_Add_AddTwoDoubles_ReturnDouble(double firstNumber, double secondNumber, double expect)
    {
        Calculator calculator = new();

        double result = calculator.Add(firstNumber,secondNumber);

        Assert.Equal(expect,result);
    }
    
    [Fact]
    public void TestCalculator_Add_AddToBigDoubles_ExpectOverflowException()
    {        
        Calculator calculator = new();
        double maxDouble = double.MaxValue;
        double createPositiveOverflow = 1.0;
        double minDouble = double.MinValue;
        double createNegativeOverflow = -1.0;
        
        Assert.Throws<OverflowException>(() => calculator.Add(maxDouble,createPositiveOverflow));
        Assert.Throws<OverflowException>(() => calculator.Add(minDouble,createNegativeOverflow));
    }


    // Calculator.Sub()
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
    [InlineData(0.0,0.0,0.0)]
    [InlineData(3.123122,6.345321,-3.222088)]
    [InlineData(-12.6666,-45.3333,32.6667)]
    public void TestCalculator_Sub_SubtractTwoDoubles_ReturnDouble(double firstNumber, double secondNumber, double expect)
    {
        Calculator calculator = new();

        double result = calculator.Sub(firstNumber,secondNumber);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Sub_SubtractFromBigDouble_ExpectOverflowException()
    {        
        Calculator calculator = new();
        double maxDouble = double.MaxValue;
        double createPositiveOverflow = -1.0;
        double minDouble = double.MinValue;
        double createNegativeOverflow = 1.0;
        
        Assert.Throws<OverflowException>(() => calculator.Sub(maxDouble,createPositiveOverflow));
        Assert.Throws<OverflowException>(() => calculator.Sub(minDouble,createNegativeOverflow));
    }


    // Calculator.Multi()
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
    [InlineData(1.0,1.0,1.0)]
    [InlineData(445.0,441.1233123,196_299.8739735)]
    [InlineData(-12.451,34.6,-430.8046)]
    [InlineData(double.MaxValue,2.0,double.PositiveInfinity)]
    [InlineData(double.MinValue,2.0,double.NegativeInfinity)]
    public void TestCalculator_Multi_MultiplyTwoDoubles_ReturnDouble(double firstNumber, double secondNumber, double expect)
    {
        Calculator calculator = new();

        double result = calculator.Multi(firstNumber,secondNumber);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Multi_MultiplyTwoBigDoubles_ExpectOverflowException()
    {        
        Calculator calculator = new();
        double maxDouble = double.MaxValue;        
        double minDouble = double.MinValue;
                
        Assert.Throws<OverflowException>(() => calculator.Multi(maxDouble,maxDouble));
        Assert.Throws<OverflowException>(() => calculator.Multi(minDouble,minDouble));
    }

    // Calculator.Div()
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

    [Theory]
    [InlineData(1.0,1.0,1.0)]
    [InlineData(3.123567,765.556,0.00408012869)]
    [InlineData(3.5,0.5,7.0)]
    [InlineData(74.98,-9.2,-8.15)]
    public void TestCalculator_Div_DivideTwoDoubles_ReturnRoundedDouble(double firstNumber, double secondNumber, double expect)
    {
        Calculator calculator = new();

        double result = calculator.Div(firstNumber,secondNumber);
        
        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Div_DivideADoubleWithZero_ExpectDivideByZeroException()
    {   
        Calculator calculator = new();
        double positiveNumber = 123.0;
        double negativeNumber = -33.0;
        double zero = 0.0;
                
        Assert.Throws<DivideByZeroException>(() => calculator.Div(positiveNumber,zero));
        Assert.Throws<DivideByZeroException>(() => calculator.Div(negativeNumber,zero));
        Assert.Throws<DivideByZeroException>(() => calculator.Div(zero,zero));
    }

}
