using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MathActions
{
    class Test_Instersection
    {
        MyMath myMath = new MyMath();
        private static int count = 0;
        private int chose, numberTest;
        public Test_Instersection(int chose)
        {
            this.chose = chose;
            this.numberTest = ++count;
        }
        public void WorkGood()
        {
            if (myMath.IsIntersect(new Rectangle(20, 20, 100, 100), new Rectangle(20, 20, 100, 100)))
                Console.WriteLine("Test_Instersection : Option: 1 => passed!!!");
            else
                Console.WriteLine("Test_Instersection : Option: 1 => dont passed!!!");
        }
        public void ReturnBool()
        {
 
            if ((myMath.IsIntersect(new Rectangle(20, 20, 100, 100), new Rectangle(20, 20, 100, 100))) == true)
                Console.WriteLine("Test_Instersection : Option: 2 => passed!!!");
            else
                Console.WriteLine("Test_Instersection : Option: 2 => dont passed!!!");
        }
        public int getChose()
        {
            return this.chose;
        }

    }
}
