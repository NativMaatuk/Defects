using System;
using System.Collections.Generic;
using System.Drawing;

namespace MathActions
{
   public class MyMath : IMyMath
    {
        public bool IsIntersect(Rectangle rect1, Rectangle rect2)
        {
            bool flag = false;
            Point TopLeft = new Point(rect1.X, rect1.Y);
            Point TopRight = new Point(rect1.X + rect1.Width, rect1.Y);
            Point ButtomRight = new Point(rect1.X + rect1.Width, rect1.Y + rect1.Height);
            Point ButtomLeft = new Point(rect1.X, rect1.Y + rect1.Height);
            //check All points of Left Line
            for (int index = TopLeft.Y; index < ButtomLeft.Y; index++)
            {
                if (rect2.Contains(TopLeft.X, index))
                    flag = true;
            }
            //check All points of top Line
            for (int index = TopLeft.X; index < TopRight.X; index++)
            {
                if (rect2.Contains(index, TopLeft.Y))
                    flag = true;
            }
            //check All points of right Line
            for (int index = TopRight.Y; index < ButtomRight.Y; index++)
            {
                if (rect2.Contains(TopRight.X, index))
                    flag = true;
            }
            //check All points of buttom Line
            for (int index = ButtomLeft.X; index < ButtomRight.X; index++)
            {
                if (rect2.Contains(index, ButtomLeft.Y))
                    flag = true;
            }
            if (rect2.Contains(TopLeft) || rect2.Contains(TopRight) || rect2.Contains(ButtomRight) || rect2.Contains(ButtomLeft) || rect2.Contains(rect1))
                flag = true;
            return flag;
        }
        public Rectangle BuildBoundBox(Point XY, Point WH)
        {
            int x = XY.X, y = XY.Y, width = WH.X - XY.X, height = WH.Y - XY.Y;

            return new Rectangle(x - 1, y - 1, width + 1, height + 1);
        }
        public void updateDefectsGroup(MyRectangle r1, Stack<MyRectangle> toDisplay, Stack<MyRectangle> defectsGroup)
        {
            Stack<MyRectangle> temp = new Stack<MyRectangle>();
            Stack<MyRectangle> samId = new Stack<MyRectangle>();
            while (toDisplay.Count > 0)
            {
                if (r1.GetId() == toDisplay.Peek().GetId())
                {
                    samId.Push(toDisplay.Peek());
                }
                temp.Push(toDisplay.Pop());
            }
            while (temp.Count > 0)
                toDisplay.Push(temp.Pop());

            samId.Push(r1);
            MyRectangle border = new MyRectangle(BuildBoundBox(getMinRect(samId), getMaxRect(samId)));
            border.SetId(r1.GetId());
            if (exist(r1.GetId(), defectsGroup))
                replaceBorder(border, defectsGroup);
            else
                defectsGroup.Push(border);
        }
        public void removeBorder(int id, Stack<MyRectangle> defectsGroup)
        {
            Stack<MyRectangle> temp = new Stack<MyRectangle>();
            while (defectsGroup.Count > 0)
            {
                if (id == defectsGroup.Peek().GetId())
                {
                    defectsGroup.Pop();
                    continue;
                }

                temp.Push(defectsGroup.Pop());
            }
            while (temp.Count > 0)
                defectsGroup.Push(temp.Pop());
        }
        public void replaceBorder(MyRectangle border, Stack<MyRectangle> defectsGroup)
        {

            Stack<MyRectangle> temp = new Stack<MyRectangle>();
            while (defectsGroup.Count > 0)
            {
                if (border.GetId() == defectsGroup.Peek().GetId())
                {
                    defectsGroup.Pop();
                    temp.Push(border);
                    continue;
                }
                temp.Push(defectsGroup.Pop());
            }
            while (temp.Count > 0)
                defectsGroup.Push(temp.Pop());
        }
        //check if the id exist in the defectGroup if exist replace him else add 
        public bool exist(int id, Stack<MyRectangle> defectsGroup)
        {
            foreach (var rect in defectsGroup)
            {
                if (id == rect.GetId())
                    return true;
            }
            return false;
        }
        public Point getMinRect(Stack<MyRectangle> SameID)
        {
            Point minPoint = new Point(SameID.Peek().GetRectangle().X, SameID.Peek().GetRectangle().Y);
            foreach (var rect in SameID)
            {
                if (rect.GetRectangle().X < minPoint.X)
                    minPoint.X = rect.GetRectangle().X;
                if (rect.GetRectangle().Y < minPoint.Y)
                    minPoint.Y = rect.GetRectangle().Y;
            }
            return minPoint;
        }
        public Point getMaxRect(Stack<MyRectangle> SameID)
        {
            Point maxRect = new Point((SameID.Peek().GetRectangle().X + SameID.Peek().GetRectangle().Width), (SameID.Peek().GetRectangle().Y + SameID.Peek().GetRectangle().Height));
            foreach (var rect in SameID)
            {
                if ((rect.GetRectangle().X + rect.GetRectangle().Width) > maxRect.X)
                    maxRect.X = (rect.GetRectangle().X + rect.GetRectangle().Width);
                if ((rect.GetRectangle().Y + rect.GetRectangle().Height) > maxRect.Y)
                    maxRect.Y = (rect.GetRectangle().Y + rect.GetRectangle().Height);
            }
            return maxRect;
        }
        //only to debug
        public void print(String str)
        {
            System.Diagnostics.Debug.WriteLine(str);
        }


    }
}
