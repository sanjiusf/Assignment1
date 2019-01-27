using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)                              //Start of Main
        {
            int a = 5, b = 15;
            Console.WriteLine("The prime numbers are:");            //Print Prime numbers between range 5 and 15
            printPrimeNumbers(a, b);

            Console.Write("\n");
            Console.WriteLine("--------------------------------------------------------------------");


            int n1 = 5;
            double r1 = getSeriesResult(n1);                        
            Console.WriteLine("The sum of the series is: " + r1);   //Print the sum of series

            Console.Write("\n");
            Console.WriteLine("--------------------------------------------------------------------");


            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);   //Print the binary to decimal conversion

            Console.Write("\n");
            Console.WriteLine("--------------------------------------------------------------------");

            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);  //Print decimal to binary conversion

            Console.Write("\n");
            Console.WriteLine("--------------------------------------------------------------------");

            int n4 = 5;
            printTriangle(n4);                                                                   //Print the equilateral triangle

            Console.Write("\n");
            Console.WriteLine("--------------------------------------------------------------------");


            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);                                                              //Print the frequency of each number in the array

            Console.Write("\n");
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);

            //Self Reflection: This assignment helped me revise my basics.I had practiced these programs during the first year of my undergrad.This assignment has given enough practice and made my coding faster.
            
            /* Recommendation: I feel it would be better if the scope of the assignment is not limited.For example in case of finding the prime numbers between range,
               it is asked to create a method isPrime().I feel it would be better if we are allowed to apply our own logic instead of limiting ourselves.Otherwise overall the assignment is a great revision of the basics.
               The best thing of this assignment is that the skeleton is provided. */

        }  // End of Main


        public static void printPrimeNumbers(int x, int y)           //Print Prime method
        {
            try
            {                                                                                       

                for (int i = x; i <= y; i++)                         //Parse the range (x-y) and check if the numbers are prime or not using isPrime()
                {
                    if (isPrime(i))
                    {
                        Console.Write(i + " ");                      //Print the prime numbers
                    }
                }
            } //End of try
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            } //End of catch
        } //End of function

        public static Boolean isPrime(int n)                      // isPrime() method to check if a number is prime or not
        {
            if (n == 0 || n == 1)                                 //If the number is 0 or 1 then the number is not prime(return false)
            {
                return false;
            }
            else
            {
                for (int i = 2; i <= n / 2; i++)                 //if the number(n) is divisible by any number from 2 to n/2, then it is not a prime number(return false)
                {
                    if (n % i == 0)
                    {
                        return false;
                    }
                }
            }
            return true;                                         //The number is a prime number if the above statements are not satisfied(return true)

        }

        public static double getSeriesResult(int n)              //Method to get result of series
        {
            try
            {
                double s1 = 0.0;                                //variable to store result of the series
                for (int i = 1; i <= n; i++)                    
                {

                    double s = fact(i) / (i + 1);                //stores individual terms in s (eg:- 1/2,2!/3) usine fact()
                    if (i % 2 == 0)                              //If the term is even then substract it from the previous terms else add it
                    {
                        s1 = s1 - s;
                    }
                    else
                    {
                        s1 = s1 + s;
                    }

                }
                return s1;                                      //return the result
            } //End of Try
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
                return 0;
            } //End of Catch


        }  //End of function

        static double fact(int n)                           //Method to compute Factorial of a number
        {
            int f = 1;
            for (int i = 1; i <= n; i++)                   //Parses from 1-n and multiplies with each other (1*2*3*4*...*n) finding the factorial in f
            {
                f = f * i;
            }
            return f;                                      //Returns factorial
        } //End of function


        public static long binaryToDecimal(long n)         //Method to convert binary to decimal number
        {
            long dec = 0;
            int length = n.ToString().Length;              //Finding length of binary number
            long[] array1 = new long[length];              //Creating an empty array with length of binary number

            try
            {
                for (int i = length - 1; i >= 0; i--)      //Storing the remainder digit(last digit) of binary number in the array 
                {
                    long a = n % 10;
                    n = n / 10;
                    array1[i] = a;

                }
                int j = length - 1;                        
                int k = 0;
                while (j >= 0)                            
                {

                    dec += array1[j] * (long)power(k);         //Calculating the decimal number by using power() method. PS:- since power() return int and binaryTODecimal() returns long, power() is type casted to long 
                    j--;
                    k++;

                }
                return dec;                                    //Return decimal number
            }  //End of Try
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }  //End of Catch

            return 0;
        }  //End of Function

        public static int power(int k)                    //Compute 2^k (2^0,2^1...2^k)
        {
            int a = 1;
            if (k == 0)                                   //If k=0, 2^0 returns 1
            {
                return 1;
            }
            else
            {

                for (int i = 0; i < k; i++)              //Compute 2^k and return the same
                {
                    a = a * 2;
                }
                return a;
            }

        }  //End of Function

        public static long decimalToBinary(long n)            //Converts decimal number to binary
        {
            try
            {
                long r, res;
                String result = "";
                while (n > 0)                                //Finds the remainder and concats the remainder to result
                {
                    r = n % 2;
                    n = n / 2;
                    result = r.ToString() + result;          //remainder(r) is converted to string to allow concatenation of all the remainder digits to form the binary number
                }
                res = Convert.ToInt64(result);               //String result id converted to long
                return res;
            }  //End of Try
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
                return 0;
            }  //End of Catch


        }

        public static void printTriangle(int n)               //Method to print equilateral triangle
        {
            try
            {
                for (int i = 1; i <= n; i++)                 //Loop to access every line of the triangle
                {
                    int k = 0;


                    for (int j = 1; j <= n - i; j++)         //Loop to print the spaces before the * to form the triangle
                    {
                        Console.Write("  ");
                    }

                    while (k < (2 * i - 1))                 //Loop to form the * triangle
                    {
                        Console.Write(" *");
                        k++;
                    }
                    Console.WriteLine("");                     //To go on the next line in the triangle
                }  //End of Try

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }  //End of Catch
        }  //End of Function

        public static void computeFrequency(int[] a)                 //To compute frequency of each element in the array
        {
            try
            {
                int k = 1;
                int[] b = new int[50];                               //Creating a new array length a and assigning -1 to it
                for (int p = 0; p < a.Length; p++)
                {
                    b[p] = -1;
                }
                Console.WriteLine("Element" + " " +"Frequency");     
                for (int i = 0; i < a.Length; i++)                   //Comparing each element of array a with each other and increamenting the pointer if the same element repeats(frequency)
                {
                    for (int j = i + 1; j < a.Length; j++)
                    {
                        if (a[i] == a[j])
                        {
                            k++;
                            b[j] = 0;                               //Making the next positions of the repeated elements zero in array b(this is done to display the elments once)
                        }

                    }

                    if (b[i] != 0)                                  //If the number is not a repeated number(i.e it's frequency is not already printed) then print the number with its frequency
                    {

                        Console.WriteLine(a[i] + "           " + k);
                    }
                    k = 1;                                         //Make the pointer to 1, for the frequency of next element 
                }




            }  //End of Try
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }  //End of Catch

        }  //End of Function
    }
}
