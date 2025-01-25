using System.ComponentModel;
using System.Security.Principal;

namespace AdvancedC_03
{
    //step 0. delegate Declaration 
    public delegate int CustomFunc(string arg1);
    //New Delegate (Class)
    //Reference from this Delegate Can refer to function or more  (pointer To Function)
    //This Function Can  Be Class Member Or Object Member 
    // this Function Must Has The same Signature of the Delegate 
    //Regardless Function Access Modifier  and Regardless Naming [Function Name and Parameters]

    public delegate bool CustomFunc<T>(T arg1,T arg2);
    
  
    internal class Program
    {
        static void Main(string[] args)
        {
            #region What is  Delegate
            //Delegate is a C# feature [C# 2.0 ]
            //Has a 2 Usages
            //1. Functional programming[function as parameter, function return function,storage function in variable]
            //2. Event_Driven programming
            //delegate transform to Class  in CLR 

            #endregion
            #region Delegate Example01
            // //step 1. Declare Delegate Reference
            // CustomFunc reference;
            // //step 2. initialize the delegate reference;
            //// reference = new CustomFunc(StringHelper.GetCountOfUpperCaseChars);
            // reference = StringHelper.GetCountOfUpperCaseChars;//Syntax Sugar
            // reference += StringHelper.GetCountOfLowerCaseChars;
            // reference -= StringHelper.GetCountOfUpperCaseChars;
            // // step 3. Use the Reference delegate
            // //  reference.Invoke("Nada AHmed");
            // int Result=reference("Nada AHmed");//syntax Sugar
            // Console.WriteLine($"Result:{Result}");



            #endregion
            #region Delegate Example02
            //int[] Numbers = [2, 8, 7, 1, 4, 3, 10, 9, 5, 6];
            ////SortingAlgorithms.BubbleSort(Numbers,new AscComparer());
            //CustomFunc<int> func = SortingTypes.ComparerGRT;
            //Numbers.BubbleSort(func);
            //for (int i = 0; i < Numbers.Length; i++)
            //{
            //    Console.WriteLine(Numbers[i]);
            //}
            #endregion
        }
    }
    class StringHelper
    {
        public static int GetCountOfUpperCaseChars(string str)
        {
            int count = 0;
            if (str != null)
            {
                for (int i = 0; i < str.Length; i++)
                    if (Char.IsUpper(str[i]))
                        count++;


            }
            return count;
        }
        public static int GetCountOfLowerCaseChars(string str)
        {
            int count = 0;
            if (str != null)
            {
                for (int i = 0; i < str.Length; i++)
                    if (Char.IsLower(str[i]))
                        count++;


            }
            return count;
        }
    }
    static class  SortingAlgorithms
    {
        //public static void BubbleSort(this int[] array,CustomComparer customComparer)
        public static void BubbleSort(this int[] array,CustomFunc<int> func)
        {
            if(array != null && func !=null)
            {
                for(int i = 0; i < array.Length; i++)
                {
                    for(int j = 0; j < array.Length - 1 - i; j++)
                    {
                        // if(array[j] > array[j+1])
                        //if (customComparer.Compare(array[j], array[j+1]))
                        if (func(array[j], array[j+1]))
                            Swap(ref array[j], ref array[j+1]);
                        
                    }
                }
            }
        }
        //redundancy of code 
        //public static void BubbleSortDec(int[] array)
        //{
        //    if (array != null)
        //    {
        //        for (int i = 0; i < array.Length; i++)
        //        {
        //            for (int j = 0; j < array.Length - 1 - i; j++)
        //            {
        //                if (array[j] < array[j + 1])
        //                {
        //                    Swap(ref array[j], ref array[j + 1]);
        //                }
        //            }
        //        }
        //    }
        //}
        private static void Swap(ref int x,ref  int y)
        {
            int temp = x;
            x=y;
            y=temp;
        }
    }
    class SortingTypes
    {
        public static bool ComparerGRT(int x, int y) => x > y;
        public static bool Comparerless(int x, int y) => x < y;

    }
}
