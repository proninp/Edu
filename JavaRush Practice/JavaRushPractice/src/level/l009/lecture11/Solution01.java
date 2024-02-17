package level.l009.lecture11;

public class Solution01 {
    public static void main(String[] args) {
        try
        {
            divideByZero();
        }
        catch(ArithmeticException e)
        {
            e.printStackTrace();
        }

    }
    public static void divideByZero() {
        int a = 4;
        a /= 0;
        System.out.println(a);
    }
}
