// Ref local and return
using System;

namespace Sol_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Exmaple One
            Example1 example = new Example1();
            int[] numbers = new[] { 1, 2, -4, 5, 6 };
            int notFoundValue = 0;

            // Without Ref
            int result = example.GetFirstNegativeNumberWithoutRef(numbers);
            Console.WriteLine(result);// -4
            result++; //-3
            Console.WriteLine(result);// -3
            result = example.GetFirstNegativeNumberWithoutRef(numbers); 
            Console.WriteLine(result);// -4 (without ref return it would chnaged the value)

            // With Ref
            ref int result1 = ref example.GetFirstNegativeNumberWithRef(numbers, ref notFoundValue); 
            Console.WriteLine(result);// -4
            result1++; //-3
            Console.WriteLine(result1);//-3
            result1 = ref example.GetFirstNegativeNumberWithRef(numbers, ref notFoundValue);
            Console.WriteLine(result1);// -3 (With ref return it would changed the value)
            #endregion

            #region Example1
            Example2 example2 = new Example2();
            // Without Ref
            int result2 =example2.AddWithoutRef(2, 2);
            Console.WriteLine(result2); // 4
            Console.WriteLine(example2.result);// 4

            result2 = result2 + 1; 
            Console.WriteLine(result2); // 5
            Console.WriteLine(example2.result);// 4 (Without Ref Return it would not changed the value)

            result2 = example2.AddWithoutRef(2, 2);
            Console.WriteLine(result2); // 4
            Console.WriteLine(example2.result);// 4


            // With Ref
            ref int result3 = ref example2.AddWithRef(2, 2);
            Console.WriteLine(result3); // 4
            Console.WriteLine(example2.result);// 4

            result3 = result2 + 1;
            Console.WriteLine(result2); // 5
            Console.WriteLine(example2.result);// 5 (with Ref Return it would changed the value)

            result3 = ref example2.AddWithRef(2, 2);
            Console.WriteLine(result3); // 4
            Console.WriteLine(example2.result);// 5



            #endregion
        }
    }


    public class Example1
    {
        public int GetFirstNegativeNumberWithoutRef(int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    return numbers[i];
                }
            }

            return 0;
        }

        public ref int GetFirstNegativeNumberWithRef(int[] numbers,ref int notFoundValue)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    return ref numbers[i];
                }
            }
            return ref notFoundValue;
        }
    }

    public class Example2
    {
        public int result = 0;

        public int AddWithoutRef(int value1, int value2)
        {
            result = value1 + value2;
            return  result;
        }

        public ref int AddWithRef(int value1,int value2)
        {
            result = value1 + value2;
            return ref result;
        }
    }

}
