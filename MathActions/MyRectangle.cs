using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MathActions
{
    public class MyRectangle 
    {
        protected Rectangle rectangle;
        protected static int uniqNumber = 0;
        protected int id = uniqNumber;
        protected Color color;
        protected bool isBorder = false;
        protected bool inGroup = false;

        public MyRectangle(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }
        public MyRectangle(Rectangle rectangle,Color color)
        {
            this.rectangle = rectangle;
            this.color = color;
        }
        public void SetRectangle(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }
        public Rectangle GetRectangle()
        {
            return this.rectangle;
        }
        public void SetId(int number)
        {
            this.id = number;
        }
        public int GetId()
        {
            return this.id;
        }
        public void SetColor(Color color)
        {
            this.color = color;
        }
        public Color GetColor()
        {
            return this.color;
        }
        public void SetIsBorder(bool flag)
        {
            this.isBorder = flag;
        }
        public bool getIsBorder()
        {
            return this.isBorder;
        }
        public void SetInGroup(bool flag)
        {
            this.inGroup = flag;
        }
        public bool GetInGroup()
        {
            return this.inGroup;
        }
        public void SetUniqNum(int number)
        {
            uniqNumber = number;
        }
        public int GetUniqNum()
        {
            return uniqNumber;
        }

        public String toString()
        {
            return "[id = " + id + " x:" + this.rectangle.X + " y:" + this.rectangle.Y + " width:" + this.rectangle.Width + " height:" + this.rectangle.Height + "]";
        }

    }
}
