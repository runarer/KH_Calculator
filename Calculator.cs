namespace KH_Kalkulator;
 
public class Calculator
{
    public static int Add(int a, int b)
    {
        checked {
            return a + b;
        }
    }

    public static int Sub(int a, int b)
    {
        checked {
            return a - b;
        }
    }

    public static int Div(int a , int b)
    {
        checked
        {
            return a / b; 
        }
    }

    public static int Multi(int a, int b)
    {
        checked
        {
            return a * b;
        }
    }
    public static double Add(double a, double b)
    {
        checked {
            return a + b;
        }
    }

    public static double Sub(double a, double b)
    {
        checked {
            return a - b;
        }
    }

    public static double Div(double a , double b)
    {
        checked
        {
            return a / b; 
        }
    }

    public static double Multi(double a, double b)
    {
        checked
        {
            return a * b;
        }
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