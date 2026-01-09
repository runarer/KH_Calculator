using Core;

namespace Test;

public class CalculatorDivTest {

    // Calculator.Div()
    [Theory]
    [InlineData(1,1,1)]
    [InlineData(445,97,5)]
    [InlineData(875,5,175)]
    [InlineData(74,9,8)]
    public void TestCalculator_Div_DivideTwoInts_ReturnRoundedInt(int firstNumber, int secondNumber, int expect)
    {

        int result = Calculator.Div(firstNumber,secondNumber);
        
        Assert.Equal(expect,result);
    }

    [Fact]
    public void TestCalculator_Div_DivideANumberWithZero_ExpectDivideByZeroException()
    {   
        int number = 123;
                
        Assert.Throws<DivideByZeroException>(() => Calculator.Div(number,0));
    }
    
    [Theory]
    [InlineData((int[])[15,3,1,2],3)]
    [InlineData((int[])[15,3,1,4],1)]
    public void TestCalculator_Div_DividesArrayOfInts_ReturnInt(int[] numbers, int expect)
    {      

        int result = Calculator.Div(numbers);

        Assert.Equal(expect,result);        
    }

    [Fact]
    public void TestCalculator_Div_DivideArrayOfIntWithAZeroInside_ExpectDivideByZeroException()
    {   
        int[] numbers = [2,3,4,0];
                
        Assert.Throws<DivideByZeroException>(() => Calculator.Div(numbers));
    }

    [Theory]
    [InlineData(1.0,1.0,1.0,15)]
    [InlineData(3.123567,765.556,0.00408012869,10)]
    [InlineData(3.5,0.5,7.0,15)]
    [InlineData(74.98,-9.2,-8.15,15)]
    public void TestCalculator_Div_DivideTwoDoubles_ReturnRoundedDouble(double firstNumber, double secondNumber, double expect, int precision)
    {

        double result = Calculator.Div(firstNumber,secondNumber);
        
        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Div_DivideADoubleWithZero_ExpectDivideByZeroException()
    {   
        double positiveNumber = 123.0;
        double negativeNumber = -33.0;
        double zero = 0.0;
                
        Assert.Throws<DivideByZeroException>(() => Calculator.Div(positiveNumber,zero));
        Assert.Throws<DivideByZeroException>(() => Calculator.Div(negativeNumber,zero));
        Assert.Throws<DivideByZeroException>(() => Calculator.Div(zero,zero));
    }

    [Fact]
    public void TestCalculator_Div_DividesArrayOfDoubles_ReturnDouble()
    {
        double[] numbers = [3.2,4.55,67.02];
        double expect = 0.010493;
        int precision = 5;

        double result = Calculator.Div(numbers);

        Assert.Equal(expect,result,precision);
    }

    [Fact]
    public void TestCalculator_Div_DivideArrayOfDoubleWithAZeroInside_ExpectDivideByZeroException()
    {   
        double[] numbers = [2.2,3.4,4.4,0.0];
                
        Assert.Throws<DivideByZeroException>(() => Calculator.Div(numbers));
    }
}
