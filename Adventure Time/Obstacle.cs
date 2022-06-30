using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Time
{
    public class Obstacle
    {
        public Point Center { get; set; }

        public static Random Random = new Random();

        public Color Color { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Radius { get; set; }

        public int Direction { get; set; } 

        public Obstacle(int width, int height)
        {
            Width = width;
            Height = height;
            Radius = Random.Next(10, 20);
            int Red = Random.Next(0, 255);
            int Green = Random.Next(0, 255);
            int Blue = Random.Next(0, 255);
            Color = Color.FromArgb(Red, Green, Blue);
            Direction = Random.Next(3);
            if (Direction == 0)
                Center = new Point(Random.Next(Radius, Width - Radius), 0);
            else if (Direction == 1)
                Center = new Point(Width, Height - 100);
            else
                Center = new Point(0, Height - 100);
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();
        }

        public void Move()
        {
            if (Direction == 0)
                Center = new Point(Center.X, Center.Y + 10);
            else if (Direction == 1)
                Center = new Point(Center.X - 10, Center.Y);
            else
                Center = new Point(Center.X + 10, Center.Y);
        }
    }
}
