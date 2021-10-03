using MathActions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UnitTester
{
    class Test_BoundBox
    {
        MyMath myMath = new MyMath();
        private static int count = 0;
        private int chose,numberTest;
        public Test_BoundBox(int chose)
        {
            this.chose = chose;
            this.numberTest = ++count;
        }
        public void WorkGood()
        {
            Rectangle res = myMath.BuildBoundBox(new Point(20,20), new Point(100, 100));
            myMath.print(res.ToString());
            if (res.Equals(new Rectangle(19, 19, 81, 81)))
                Console.WriteLine("Test_BoundBox : Option: 1 => passed!!!");
            else
                Console.WriteLine("Test_BoundBox : Option: 1 => dont passed!!!");
        }
        public void ReturnRectangle()
        {
            Rectangle res = myMath.BuildBoundBox(new Point(20, 20), new Point(100, 100));
            myMath.print(res.ToString());
            if (res.GetType() == typeof(Rectangle))
                Console.WriteLine("Test_BoundBox : Option: 2 => passed!!!");
            else
                Console.WriteLine("Test_BoundBox : Option: 2 => dont passed!!!");
        }
        public int getChose()
        {
            return this.chose;
        }
    }
}
