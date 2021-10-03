using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MathActions
{
    interface IMyMath 
    {
        public bool IsIntersect(Rectangle rect1, Rectangle rect2);
        public Rectangle BuildBoundBox(Point XY, Point WH);
        public void updateDefectsGroup(MyRectangle r1, Stack<MyRectangle> toDisplay, Stack<MyRectangle> defectsGroup);
        public void removeBorder(int id, Stack<MyRectangle> defectsGroup);
        public void replaceBorder(MyRectangle border, Stack<MyRectangle> defectsGroup);
        public bool exist(int id, Stack<MyRectangle> defectsGroup);
        public Point getMinRect(Stack<MyRectangle> SameID);
        public Point getMaxRect(Stack<MyRectangle> SameID);

    }
}
