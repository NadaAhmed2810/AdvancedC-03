using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
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

    public delegate TResult CustomFunc<in T1,in T2,out TResult>(T1 arg1,T2 arg2);
    
  
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
            //CustomFunc<int,int,bool> func = SortingTypes.ComparerGRT;
            //SortingAlgorithms<int>.BubbleSort(Numbers,func);
            //for (int i = 0; i < Numbers.Length; i++)
            //{
            //    Console.WriteLine(Numbers[i]);
            //}
            //string[] Names = ["Nada","Noura","Nour","Nadeen","Radwa","Salma","Rania","Aya","Mohammed"];
            //CustomFunc<string, string, bool> func = SortingTypes.ComparerGRT;
            //SortingAlgorithms<string>.BubbleSort(Names, func);
            //for (int i = 0; i < Names.Length; i++)
            //{
            //    Console.WriteLine(Names[i]);
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
    static class  SortingAlgorithms<T>
    {
        //public static void BubbleSort(this int[] array,CustomComparer customComparer)
        public static void BubbleSort( T[] array,CustomFunc<T,T,bool> func)
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
        private static void Swap(ref T x,ref  T y)
        {
            T temp = x;
            x=y;
            y=temp;
        }
    }
    class SortingTypes
    {
        public static bool ComparerGRT(int x, int y) => x > y;
        public static bool Comparerless(int x, int  y) => x < y;
        public static bool ComparerGRT(string x, string y) => x .CompareTo(y)==1;
        public static bool Comparerless(string x, string y) => x .CompareTo(y)==-1;

    }
}
