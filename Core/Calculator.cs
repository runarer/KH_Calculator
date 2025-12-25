namespace Core;

public class Calculator
{
    public int Add(int numberA, int numberB)
    {
        checked
        {
            return numberA + numberB;
        }
    }

    public double Add(double numberA, double numberB)
    {
        double result = numberA + numberB;
        if(Double.IsInfinity(result)) 
            throw new OverflowException();
        return result;
    }

    public int Sub(int numberA, int numberB)
    {
        checked
        {
            return numberA - numberB;
        }
    }

    public double Sub(double numberA, double numberB)
    {
        double result = numberA - numberB;
        if(Double.IsInfinity(result)) 
            throw new OverflowException();
        return result;
    }    

    public int Multi(int numberA, int numberB)
    {
        checked
        {
            return numberA*numberB;
        }
    }

    public double Multi(double numberA, double numberB)
    {
        double result = numberA * numberB;
        if(Double.IsInfinity(result)) 
            throw new OverflowException();
        return result;
    }    

    public int Div(int numberA, int numberB)
    {
        return (int)Math.Round(Div((double)numberA,(double)numberB),MidpointRounding.AwayFromZero);
    }

    public double Div(double numberA, double numberB)
    {
        double result = numberA / numberB;
        if(Double.IsInfinity(result) || Double.IsNaN(result))
            throw new DivideByZeroException();
        return result;
    }
}
