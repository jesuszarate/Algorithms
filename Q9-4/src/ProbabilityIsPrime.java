import java.math.BigInteger;
import java.util.*;



/**
 * Created by Jesus Zarate on 3/30/16.
 */
public class ProbabilityIsPrime
{
    public static int n = 128;

    public static void main(String[] args){
        int range = 100000;

        double A = ProbNIsPrime(n, range);
        System.out.println( "Probability A: " + A);


        System.out.println( "Probability B: " +
                FoolsPrimalityTest(n, range, A));

        System.out.println( "Probability C: " +
                notFoolPrimalityTest(n, range));

    }

    public static float FoolsPrimalityTest(int intLen, int range, double A){
        Random rand = new Random(System.currentTimeMillis());
        BigInteger bigInteger;

        int count = 0;
        for(int i = 0; i < range; i++){
            bigInteger = new BigInteger(intLen, rand);

            bigInteger = correctLength(bigInteger, intLen, rand);

            if(FermatsTest(bigInteger))
                count++;
        }

        System.out.println("Count: " + count);
        System.out.println("Range: " + range);

        System.out.println("(A - B): " +
                ((float)A - ((float)count / (float) range)));

        System.out.println("(B - A): " +
                (((float)count/ (float) range) - (float)A));

        return ((float)count / (float) range);
        //return ((float)count/ (float) range) - (float)A;
    }

    public static BigInteger correctLength(BigInteger i, int intLen, Random rand){
        while (i.bitLength() != n)
        {
            i = new BigInteger(intLen, rand);
        }
        return i;
    }

    public static double notFoolPrimalityTest(int intLen, int range){

        Random rand = new Random(System.currentTimeMillis());
        BigInteger bigInteger;

        double count = 0;
        for(int i = 0; i < range; i++){
            bigInteger = new BigInteger(intLen, rand);

            bigInteger = correctLength(bigInteger, intLen, rand);

            if (!FermatsTest(bigInteger))
            {
                count++;
            }
        }

        System.out.println(count);
        System.out.println(range);
        return (count / range);
    }

    public static boolean FermatsTest(BigInteger N){
        BigInteger a = new BigInteger("2");

        if(a.modPow(N.subtract(BigInteger.ONE), N).equals(BigInteger.ONE)){
            return true;
        }
        return false;
    }

    public static float ProbNIsPrime(int intLen, int range)
    {
        Random rand = new Random(System.currentTimeMillis());

        BigInteger bigInteger;

        float count = 0;
        for(int i = 0; i < range; i++){
            bigInteger = new BigInteger(intLen, rand);

            bigInteger = correctLength(bigInteger, intLen, rand);
            if (bigInteger.isProbablePrime(50))
            {
                count++;
            }
        }

        System.out.println(count);
        System.out.println(range);
        return count / range;
    }


}
