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

        // public delegate TResult CustomFunc<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        //public delegate bool CustomPredicate<in T>(T arg1);

        internal class Program
        {
            public static List<T> FindElements<T>(List<T> Elements, Predicate<T> predicate)
            {
                List<T> Result = new List<T>();
                if (Elements is not null && predicate != null)
                {
                    {
                        for (int i = 0; i < Elements.Count; i++)
                        {
                            if (predicate.Invoke(Elements[i]))
                                Result.Add(Elements[i]);
                        }
                    }
               
                }
                return Result;
            }
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
            ////step 1. Declare Delegate Reference
            //Func<string,int> reference;
            ////step 2. initialize the delegate reference;
            //// reference = new CustomFunc(StringHelper.GetCountOfUpperCaseChars);
            //reference = StringHelper.GetCountOfUpperCaseChars;//Syntax Sugar
            //reference += StringHelper.GetCountOfLowerCaseChars;
            //reference -= StringHelper.GetCountOfUpperCaseChars;
            //// step 3. Use the Reference delegate
            ////  reference.Invoke("Nada AHmed");
            //int Result = reference("Nada AHmed");//syntax Sugar
            //Console.WriteLine($"Result:{Result}");



            #endregion
            #region Delegate Example02
            //int[] Numbers = [2, 8, 7, 1, 4, 3, 10, 9, 5, 6];
            //SortingAlgorithms.BubbleSort(Numbers,new AscComparer());
            //Func<int, int, bool> func = SortingTypes.ComparerGRT;
            //SortingAlgorithms<int>.BubbleSort(Numbers, func);
            //for (int i = 0; i < Numbers.Length; i++)
            //{
            //    Console.WriteLine(Numbers[i]);
            //}
            //string[] Names = ["Nada", "Noura", "Nour", "Nadeen", "Radwa", "Salma", "Rania", "Aya", "Mohammed"];
            //Func<string, string, bool> func1 = SortingTypes.ComparerGRT;
            //SortingAlgorithms<string>.BubbleSort(Names, func1);
            //for (int i = 0; i < Names.Length; i++)
            //{
            //    Console.WriteLine(Names[i]);
            //}
            #endregion
            #region Delegate Example03
            //List<int> Numbers = Enumerable.Range(0, 100).ToList();
            //Predicate<int> predicate1 = ConditionFunctions.IsOdd;
            #region find odd
            //List<int> OddNumbers = FindElements(Numbers, predicate1);
            //for (int i = 0; i < OddNumbers.Count; i++)
            //{
            //    Console.WriteLine(OddNumbers[i]);
            //} 
            #endregion

            #region Find Even
            //predicate1 = ConditionFunctions.IsEven;
            //List<int> EvenNumbers = FindElements(Numbers, predicate1);
            //for (int i = 0; i < EvenNumbers.Count; i++)
            //{
            //    Console.WriteLine(EvenNumbers[i]);
            //} 
            #endregion
            #region find mod 7
            //predicate1 = ConditionFunctions.DividedBySeven;
            //List<int> DividedByseven = FindElements(Numbers, predicate1);
            //for (int i = 0; i < DividedByseven.Count; i++)
            //{
            //    Console.WriteLine(DividedByseven[i]);
            //}
            #endregion
            #region string>4
            //List<string>Names =new List<string>() { "Nada", "Nour", "Noura", "Aya", "Radwa" };
            //Predicate<string> predicate2 = ConditionFunctions.LengthGrt4;
            //List<string>list = FindElements(Names,predicate2).ToList();
            //foreach (string name in list)
            //{
            //  Console.WriteLine(name);
            //} 
            #endregion

            #endregion
            #region Built in Delegate
            //Predicate<int> predicate=SomeFunctions.test ;
            //predicate.Invoke(10);
            //Func<int,string> func = SomeFunctions.Cast ;
            //func.Invoke(10);
            //Action<string> action=SomeFunctions.Print;
            //action.Invoke("Nada");

            #endregion

            }
        }
        class SomeFunctions
        {
             public static bool test(int x)=> x > 0;
             public static string Cast(int  x)=>x.ToString();
             public static void Print(string s) => Console.WriteLine($"Hello ,{s}");

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
        static class SortingAlgorithms<T>
        {
            //public static void BubbleSort(this int[] array,CustomComparer customComparer)
            public static void BubbleSort(T[] array, Func<T, T, bool> func)
            {
                if (array != null && func != null)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        for (int j = 0; j < array.Length - 1 - i; j++)
                        {
                            // if(array[j] > array[j+1])
                            //if (customComparer.Compare(array[j], array[j+1]))
                            if (func(array[j], array[j + 1]))
                                Swap(ref array[j], ref array[j + 1]);

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
            private static void Swap(ref T x, ref T y)
            {
                T temp = x;
                x = y;
                y = temp;
            }
        }
        static class SortingTypes
        {
            public static bool ComparerGRT(int x, int y) => x > y;
            public static bool Comparerless(int x, int y) => x < y;
            public static bool ComparerGRT(string x, string y) => x.CompareTo(y) == 1;
            public static bool Comparerless(string x, string y) => x.CompareTo(y) == -1;

        }
        static class ConditionFunctions
        {
            public static bool IsOdd(int x) => x % 2 == 1;
            public static bool IsEven(int x) => x % 2 == 0;
            public static bool DividedBySeven(int x) => x % 7 == 0;
            public static bool LengthGrt4(string x) => x?.Length > 4;

        }
}


