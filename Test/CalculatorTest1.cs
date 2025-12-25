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

    [Fact]
    public void TestCalculator_Add_AddsArrayOfInts_ReturnInt()
    {
        Calculator calculator = new();
        int[] numbers = [23,45,66,66,22,34];
        int expect = 256;

        int result = calculator.Add(numbers);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Add_AddsArrayOfBigInts_ExpectOverflowException()
    {        
        Calculator calculator = new();
        int[] numbers = [23,45,66,66,22,34,int.MaxValue];
        
        Assert.Throws<OverflowException>(() => calculator.Add(numbers));
    }


    [Theory]
    [InlineData(0.0,0.0,0.0,15)]
    [InlineData(3.123122,6.345321,9.468443,6)]
    [InlineData(-12.6666,-45.3333,-57.9999,4)]
    public void TestCalculator_Add_AddTwoDoubles_ReturnDouble(double firstNumber, double secondNumber, double expect, int precision)
    {
        Calculator calculator = new();

        double result = calculator.Add(firstNumber,secondNumber);

        Assert.Equal(expect,result,precision);
    }
    
    [Fact]
    public void TestCalculator_Add_AddToBigDoubles_ExpectOverflowException()
    {        
        Calculator calculator = new();
        double bigDouble = 7.997e307;
        double createPositiveOverflow =  9.985e307;
        double bigNegativeDouble = -7.997e307;
        double createNegativeOverflow = -9.985e307;
        
        Assert.Throws<OverflowException>(() => calculator.Add(bigDouble,createPositiveOverflow));
        Assert.Throws<OverflowException>(() => calculator.Add(bigNegativeDouble,createNegativeOverflow));
    }

    [Fact]
    public void TestCalculator_Add_AddsArrayOfDoubles_ReturnDouble()
    {
        Calculator calculator = new();
        double[] numbers = [66.45663,22.44321,34.98764];
        double expect = 123.88748;
        int precision = 5;

        double result = calculator.Add(numbers);

        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Add_AddsArrayOfBigDoubles_ExpectOverflowException()
    {        
        Calculator calculator = new();
        double[] numbers = [9.985e307,9.985e307,9.985e307];
        
        Assert.Throws<OverflowException>(() => calculator.Add(numbers));
    }


    // Calculator.Sub()
    [Theory]
    [InlineData(0,0,0)]
    [InlineData(3_445,76_441,-72_996)]
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

    [Fact]
    public void TestCalculator_Sub_SubtractsArrayOfInts_ReturnInt()
    {
        Calculator calculator = new();
        int[] numbers = [23,45,66,-66,-22,34,12];
        int expect = -46;

        int result = calculator.Sub(numbers);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Sub_SubtractsArrayOfBigInts_ExpectOverflowException()
    {        
        Calculator calculator = new();
        int[] numbers = [int.MinValue,int.MinValue,int.MinValue];
        
        Assert.Throws<OverflowException>(() => calculator.Sub(numbers));
    }

    [Theory]
    [InlineData(0.0,0.0,0.0,15)]
    [InlineData(3.123122,6.345321,-3.222088,3)]
    [InlineData(-12.6666,-45.3333,32.6667,4)]
    public void TestCalculator_Sub_SubtractTwoDoubles_ReturnDouble(double firstNumber, double secondNumber, double expect, int precision)
    {
        Calculator calculator = new();

        double result = calculator.Sub(firstNumber,secondNumber);

        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Sub_SubtractFromBigDouble_ExpectOverflowException()
    {        
        Calculator calculator = new();
        double maxDouble = 7.997e307;
        double createPositiveOverflow = -9.985e307;
        double minDouble = -9.985e307;
        double createNegativeOverflow = 7.997e307;
        
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

    [Fact]
    public void TestCalculator_Multi_MultiplysArrayOfInts_ReturnInt()
    {
        Calculator calculator = new();
        int[] numbers = [23,45,66,66,22];
        int expect = 99_186_120;

        int result = calculator.Multi(numbers);

        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Multi_MultiplysArrayOfBigInts_ExpectOverflowException()
    {        
        Calculator calculator = new();
        int[] numbers = [23,45,66,66,22,int.MaxValue];
        
        Assert.Throws<OverflowException>(() => calculator.Multi(numbers));
    }


    [Theory]
    [InlineData(1.0,1.0,1.0,15)]
    [InlineData(445.0,441.1233123,196_299.8739735,7)]
    [InlineData(-12.451,34.6,-430.8046,4)]
    public void TestCalculator_Multi_MultiplyTwoDoubles_ReturnDouble(double firstNumber, double secondNumber, double expect, int precision)
    {
        Calculator calculator = new();

        double result = calculator.Multi(firstNumber,secondNumber);

        Assert.Equal(expect,result,precision);
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

    [Fact]
    public void TestCalculator_Multi_MultiplyArrayOfDoubles_ReturnDouble()
    {
        Calculator calculator = new();
        double[] numbers = [66.45663,22.44321,34.98764];
        double expect = 52_184.06866;
        int precision = 5;

        double result = calculator.Multi(numbers);

        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Multi_MultiplyArrayOfBigDoubles_ExpectOverflowException()
    {        
        Calculator calculator = new();
        double[] numbers = [9.985e307,9.985e307,9.985e307];
        
        Assert.Throws<OverflowException>(() => calculator.Multi(numbers));
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
    [InlineData((int[])[15,3,1,2],3)]
    [InlineData((int[])[15,3,1,4],1)]
    public void TestCalculator_Div_DividesArrayOfInts_ReturnInt(int[] numbers, int expect)
    {
        Calculator calculator = new();        

        int result = calculator.Div(numbers);

        Assert.Equal(expect,result);        
    }

    [Fact]
    public void TestCalculator_Div_DivideArrayOfIntWithAZeroInside_ExpectDivideByZeroException()
    {   
        Calculator calculator = new();
        int[] numbers = [2,3,4,0];
                
        Assert.Throws<DivideByZeroException>(() => calculator.Div(numbers));
    }

    [Theory]
    [InlineData(1.0,1.0,1.0,15)]
    [InlineData(3.123567,765.556,0.00408012869,10)]
    [InlineData(3.5,0.5,7.0,15)]
    [InlineData(74.98,-9.2,-8.15,15)]
    public void TestCalculator_Div_DivideTwoDoubles_ReturnRoundedDouble(double firstNumber, double secondNumber, double expect, int precision)
    {
        Calculator calculator = new();

        double result = calculator.Div(firstNumber,secondNumber);
        
        Assert.Equal(expect,result,precision);
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

    [Fact]
    public void TestCalculator_Div_DividesArrayOfDoubles_ReturnDouble()
    {
        Calculator calculator = new();
        double[] numbers = [3.2,4.55,67.02];
        double expect = 0.010493;
        int precision = 5;

        double result = calculator.Div(numbers);

        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Div_DivideArrayOfDoubleWithAZeroInside_ExpectDivideByZeroException()
    {   
        Calculator calculator = new();
        double[] numbers = [2.2,3.4,4.4,0.0];
                
        Assert.Throws<DivideByZeroException>(() => calculator.Div(numbers));
    }

}
