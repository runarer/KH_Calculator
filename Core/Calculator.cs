namespace Core;

public static class Calculator
{
    public static int Add(int numberA, int numberB)
    {
        checked
        {
            return numberA + numberB;
        }
    }

    public static double Add(double numberA, double numberB)
    {
        double result = numberA + numberB;
        if(Double.IsInfinity(result)) 
            throw new OverflowException();
        return result;
    }

    public static int Sub(int numberA, int numberB)
    {
        checked
        {
            return numberA - numberB;
        }
    }

    public static double Sub(double numberA, double numberB)
    {
        double result = numberA - numberB;
        if(Double.IsInfinity(result)) 
            throw new OverflowException();
        return result;
    }    


    public static int Multi(int numberA, int numberB)
    {
        checked
        {
            return numberA*numberB;
        }
    }

    public static double Multi(double numberA, double numberB)
    {
        double result = numberA * numberB;
        if(Double.IsInfinity(result)) 
            throw new OverflowException();
        return result;
    }    


    public static int Div(int numberA, int numberB)
    {
        return (int)Math.Round(Div((double)numberA,(double)numberB),MidpointRounding.AwayFromZero);
    }

    public static double Div(double numberA, double numberB)
    {
        double result = numberA / numberB;
        if(Double.IsInfinity(result) || Double.IsNaN(result))
            throw new DivideByZeroException();
        return result;
    }

    public static int Add(int[] numbers) => numbers.Aggregate( Add );
 
    public static int Sub(int[] numbers) => numbers.Aggregate( Sub );

    public static int Div(int[] numbers) => numbers.Aggregate( Div );

    public static int Multi(int[] numbers) => numbers.Aggregate( Multi );

    public static double Add(double[] numbers) => numbers.Aggregate( Add );

    public static double Sub(double[] numbers) => numbers.Aggregate( Sub );

    public static double Div(double[] numbers) => numbers.Aggregate( Div );

    public static double Multi(double[] numbers) => numbers.Aggregate( Multi );
}
