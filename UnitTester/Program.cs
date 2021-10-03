using MathActions;
using System;
using System.Collections.Generic;
namespace UnitTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<Test_BoundBox> testB = new Stack<Test_BoundBox>();
            Stack<Test_Instersection> testI = new Stack<Test_Instersection>();
            bool success = false;
            bool successChose = false;
            int number,num;
            Console.WriteLine("Unit Tester - chose test do you want\nif you want to run all your test press 0\npress 1 to add Test Instersection\npress 2 to add Test BoundBox");
            do
            {
                Console.WriteLine("Enter choice: ");
                string input = Console.ReadLine();
              
                success = Int32.TryParse(input, out num);
                if (!success || (num != 1 && num!= 2 && num != 0)) { 
                    Console.WriteLine("ERORR: Enter Only number | 1 | 2 | 0 |");
                    success = false;
                    continue;
                }
                if (num == 1)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("chose category of test in test bound box:\n1 - workGood\n2 - returnRectangle\n3 - to check all tests\nEnter choice: ");
                        string inputChose = Console.ReadLine();
                        successChose = Int32.TryParse(inputChose, out number);
                        if (!successChose || (number != 1 && number != 2 && number != 3))
                        {
                            Console.WriteLine("ERORR: Enter Only number | 1 | 2 | 3");
                            successChose = false;
                            continue;
                        }else if (number == 3)
                            {
                            testB.Push(new Test_BoundBox(2));
                            testB.Push(new Test_BoundBox(1));      
                            }
                            else
                                testB.Push(new Test_BoundBox(number));
                    } while (!successChose);
                }
                if(num == 2)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("chose category of test in test Instersection:\n1 - workGood: check if the function works good\n2 - returnBool: check if the return type of function is a boolean\n3 - to check all tests\nEnter choice: ");
                        string inputChose = Console.ReadLine();
                        successChose = Int32.TryParse(inputChose, out number);
                        if (!successChose || (number != 1 && number != 2 && number != 3))
                        {
                            Console.WriteLine("ERORR: Enter Only number | 1 | 2 | 3");
                            successChose = false;
                            continue;
                        }
                        else if (number == 3)
                            {
                                testI.Push(new Test_Instersection(2));
                                testI.Push(new Test_Instersection(1));
                            }
                            else
                                testI.Push(new Test_Instersection(number));
                        } while (!successChose);
                }
            } while (!success);
            if(num == 0)
            {
                testB.Push(new Test_BoundBox(2));
                testB.Push(new Test_BoundBox(1));
                testI.Push(new Test_Instersection(2));
                testI.Push(new Test_Instersection(1));
            }
            if(testB.Count > 0)
            {
                foreach(var test in testB)
                {
                    if (test.getChose() == 1)
                     test.WorkGood();
                    if (test.getChose() == 2)
                        test.ReturnRectangle();
                    if (test.getChose() == 3) {
                        test.WorkGood();
                        test.ReturnRectangle();
                    }
                }
            }
            if(testI.Count > 0)
            {
                foreach(var test in testI)
                {
                    if (test.getChose() == 1)
                        test.WorkGood();
                    if (test.getChose() == 2)
                        test.ReturnBool();
                    if (test.getChose() == 3)
                    {
                        test.WorkGood();
                        test.ReturnBool();
                    }
                }
            }
            Console.WriteLine("Finish Testing");
            Console.ReadKey();
        }
    }
}
