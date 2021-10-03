using MathActions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace DefectsViewer
{
    public partial class Form1 : Form
    {
        public static Stack<MyRectangle> rectangles = new Stack<MyRectangle>();
        public static Stack<MyRectangle> defectsGroup = new Stack<MyRectangle>();
        Point LocationXY, LocationX1Y1;
        bool IsMouseDown = false;
        Rectangle rect;
        private Graphics gObject;
        private Random rnd = new Random();
        MyMath myMath = new MyMath();
        public Form1()
        {
            InitializeComponent();
            this.gObject = MainPanel.CreateGraphics();
        }
    
        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            LocationXY = e.Location;
        }
        private void MainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;
                IsMouseDown = false;
                if (!IsMouseDown)
                {
                    Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    MyRectangle temp = new MyRectangle(new Rectangle(rect.X, rect.Y, rect.Width, rect.Height), randomColor);
                    temp.SetUniqNum(temp.GetUniqNum() + 1);
                    temp.SetId(temp.GetUniqNum());
                    CheckRect(temp);
                    if (temp.GetInGroup())
                        temp.SetUniqNum(temp.GetUniqNum() - 1);
                    creatGraphiceRect(temp);
                    rectangles.Push(temp);
                   
                    refresh();
                }
            }
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;
                Refresh();
            }
        }
        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                gObject.DrawRectangle(Pens.White, GetRect());
                refresh();
            }
        }

        private Rectangle GetRect()
        {
            int x = Math.Min(LocationX1Y1.X, LocationXY.X);
            if (x < 1)
                x = 1;
            if (x > MainPanel.Width-1)
                x = MainPanel.Width - 1;
            int y = Math.Min(LocationX1Y1.Y, LocationXY.Y);
            if (y < 1)
                y = 1;
            if (y > MainPanel.Height-1)
                y = MainPanel.Height -1;
            int width = Math.Abs(LocationXY.X - LocationX1Y1.X);
            if(x + width > MainPanel.Width)
            {
                width = (MainPanel.Width - 1)-x;
            }
            int height = Math.Abs(LocationXY.Y - LocationX1Y1.Y);
            if (y + height > MainPanel.Height)
                height = (MainPanel.Height - 1)-y;
            rect = new Rectangle(x, y, width, height);

            return rect;
        }
        private void AddDefect_MouseClick(object sender, MouseEventArgs e)
        {
            int width = 100, height = 100;
            int y = rnd.Next(0, MainPanel.Height), x = rnd.Next(0, MainPanel.Width);
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            do
            {
                y = rnd.Next(0, MainPanel.Height - 1);
                x = rnd.Next(0, MainPanel.Width - 1);
            } while (height + y > MainPanel.Height || width + x > MainPanel.Width);
            MyRectangle temp = new MyRectangle(new Rectangle(x, y, width, height), randomColor);
            temp.SetUniqNum(temp.GetUniqNum() + 1);
            temp.SetId(temp.GetUniqNum());
            CheckRect(temp);
            if (temp.GetInGroup())
                temp.SetUniqNum(temp.GetUniqNum() - 1);
            creatGraphiceRect(temp);
            rectangles.Push(temp);
            refresh();
        }
        private void creatGraphiceRect(MyRectangle r1)
        {
            Color color = r1.GetColor();
            int x = r1.GetRectangle().X, y = r1.GetRectangle().Y, height = r1.GetRectangle().Height, width = r1.GetRectangle().Width;

            Brush colorp = new SolidBrush(color);
            gObject.FillRectangle(colorp, x, y, width, height);
            Pen pen;
            if (r1.GetInGroup())
            {
               pen = new Pen(Color.Empty);
               myMath.updateDefectsGroup(r1, rectangles, defectsGroup);
            }
            else
               pen = new Pen(Color.White);
            gObject.DrawRectangle(pen, r1.GetRectangle().X, r1.GetRectangle().Y, r1.GetRectangle().Width, r1.GetRectangle().Height);
            Font myFont = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Regular);
            string id = r1.GetId().ToString();
            //draw id in the rectangle
            gObject.DrawString(id, myFont, Brushes.Black, (r1.GetRectangle().X + (r1.GetRectangle().Width / 2)), (r1.GetRectangle().Y + (r1.GetRectangle().Height / 2)));
        }
        public void clearPanel()
        {
            this.gObject.Clear(Color.Black);
        }

        private void CheckRect(MyRectangle rect)
        {
            int id = 0;
            foreach (var item in rectangles)
                if (myMath.IsIntersect(rect.GetRectangle(), item.GetRectangle()))
                {
                    item.SetInGroup(true);
                    rect.SetInGroup(true);
                    rect.SetColor(item.GetColor());
                    id = rect.GetId();
                    rect.SetId(item.GetId());
                    if (id != 0)
                    {
                        foreach (var itemRect in rectangles)
                            if (id == itemRect.GetId())
                            {
                                itemRect.SetInGroup(true);
                                itemRect.SetId(rect.GetId());
                                itemRect.SetColor(rect.GetColor());
                            }
                        myMath.removeBorder(id, defectsGroup);
                        
                    }

                }
            refresh();
        }

        //draw border group
        private void BorderGroup(MyRectangle r1)
        {
            int x = r1.GetRectangle().X, y = r1.GetRectangle().Y, height = r1.GetRectangle().Height, width = r1.GetRectangle().Width;
            Pen pen = new Pen(Color.Orange, 1);
            pen.Alignment = PenAlignment.Inset;
            this.gObject.DrawRectangle(pen, x, y, width, height);
        }
        private void Display(Stack<MyRectangle> s)
        {
            Stack<MyRectangle> temp = new Stack<MyRectangle>();
            while (s.Count > 0)
            {
                if (s.Peek().getIsBorder())
                {
                    BorderGroup(s.Peek());
                }
                else
                {
                    creatGraphiceRect(s.Peek());
                }
                temp.Push(s.Pop());
            }
            while (temp.Count > 0)
                s.Push(temp.Pop());
        }

        public void refresh()
        {
            clearPanel();
            
            this.gObject = MainPanel.CreateGraphics();
            Stack<MyRectangle> res = new Stack<MyRectangle>();
            
            foreach (var item in defectsGroup)
            {
                item.SetIsBorder(true);
                res.Push(item);
            }
            foreach (var item in rectangles)
            {
                res.Push(item);
            }           
            Display(res);
        }
        Point savePos1 = new Point();
        private void ResizeMainPanel()
        {
              double x, y,width,height;
            foreach (var rect in rectangles)
            {
                x = (double)rect.GetRectangle().X / savePos1.X * MainPanel.Width;
                y = (double)rect.GetRectangle().Y / savePos1.Y * MainPanel.Height;
                width = (double)rect.GetRectangle().Width / savePos1.X * MainPanel.Width;
                height = (double)rect.GetRectangle().Height / savePos1.Y * MainPanel.Height;
                rect.SetRectangle(new Rectangle((int) x, (int) y,(int) width,(int) height));
            }
            
            foreach (var rect in defectsGroup)
            {
                x = (double)rect.GetRectangle().X / savePos1.X * MainPanel.Width;
                y = (double)rect.GetRectangle().Y / savePos1.Y * MainPanel.Height;
                width = (double)rect.GetRectangle().Width / savePos1.X * MainPanel.Width;
                height = (double)rect.GetRectangle().Height / savePos1.Y * MainPanel.Height;
                rect.SetRectangle(new Rectangle((int)x, (int)y, (int)width, (int)height));
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeMainPanel();
            savePos1 = new Point(MainPanel.Width, MainPanel.Height);
            refresh();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            savePos1 = new Point(MainPanel.Width, MainPanel.Height);
        }

        private void ToBitMap_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bitmap = new Bitmap(MainPanel.Width, MainPanel.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rectg = MainPanel.RectangleToScreen(MainPanel.ClientRectangle);
            graphics.CopyFromScreen(rectg.Location, Point.Empty, MainPanel.Size);
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            sf.ShowDialog();
            var path = sf.FileName;
            bitmap.Save(path, ImageFormat.Jpeg);
        }
    }
}
