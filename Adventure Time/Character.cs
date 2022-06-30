using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Time
{
    public class Character
    {
        public Image Image { get; set; }

        public Point Position { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Lives { get; set; }

        public int numCharacter { get; set; }

        public bool Right { get; set; } = false;

        public bool Left { get; set; } = false;

        public bool Up { get; set; } = false;

        public bool Down { get; set; } = false;

        public Character(Image image, int width, int height, int numcharacter)
        {
            Image = image;
            Width = width;
            Height = height;
            numCharacter = numcharacter;
            if(numcharacter == 1)
                Position = new Point(Width / 2, Height - 300);
            else
                Position = new Point(Width / 2 - 200, Height - 220);
            Lives = 3;           
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(Image, Position);   
        }

        public void Move()
        {
            int dx = 0;
            int dy = 0;
            if (Right && !Left && Position.X + 150 < Width) 
            { 
                if (numCharacter == 1)
                    Image = new Bitmap(Properties.Resources.finnRight);
                else
                    Image = new Bitmap(Properties.Resources.jake);
                dx += 10;
            }
            if(Left && !Right && Position.X + 20 > 0)
            { 
                if (numCharacter == 1)
                    Image = new Bitmap(Properties.Resources.finn);
                else
                    Image = new Bitmap(Properties.Resources.jakeLeft);
                dx -= 10;
            }
            if (Up && !Down)
                dy -= 10;
            if (Down && !Up)
                dy += 10;
            Position = new Point(Position.X + dx, Position.Y + dy);
        }
    }
}
