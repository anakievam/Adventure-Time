using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Time
{
    public class Scene
    {
        public Character Character1 { get; set; }

        public Character Character2 { get; set; }

        public List<Obstacle> Obstacles { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool Multiplayer { get; set; }

        public int Score { get; set; } = 0;

        public Scene(int width, int height)
        {
            Width = width;
            Height = height;
            Character1 = new Character(Properties.Resources.finn, this.Width, this.Height, 1);
            Character2 = new Character(Properties.Resources.jake, this.Width, this.Height, 2);
            Obstacles = new List<Obstacle>();   
        }

        public void DrawCharacters(Graphics g)
        {
            Character1.Draw(g);
            if (Multiplayer)
                Character2.Draw(g);
        }

        public void MoveCharacters()
        {
           Character1.Move();
           if (Multiplayer)
                Character2.Move();   
        }

        public void AddObstacle()
        {
            Obstacles.Add(new Obstacle(Width, Height));
        }

        public void DrawObstacles(Graphics g)
        {
            foreach (Obstacle obstacle in Obstacles)
            {
                obstacle.Draw(g);
            }
        }
        public void MoveObstacles()
        {
            for (int i = 0; i < Obstacles.Count; i++)
            {
                Obstacles[i].Move();
                if (Obstacles[i].Center.Y > Height - 100 || (Obstacles[i].Direction == 3 && Obstacles[i].Center.X < 0)
                    || (Obstacles[i].Direction == 4 && Obstacles[i].Center.X > Width))
                {
                    Obstacles.Remove(Obstacles[i]);
                }
            }
            checkCollision();
        }

        public void checkCollision()
        {
            for (int i = 0; i < Obstacles.Count; i++)
            {
                Rectangle r = new Rectangle(Character1.Position.X + 20, Character1.Position.Y + 20,
                    Character1.Image.Width - 50, Character1.Image.Height);
                if (r.Contains(Obstacles[i].Center))
                {
                    Character1.Lives--;
                    Obstacles.Remove(Obstacles[i]);
                }
            }
            if (Multiplayer)
            {
                for (int i = 0; i < Obstacles.Count; i++)
                {
                    Rectangle r1 = new Rectangle(Character2.Position.X + 20, Character2.Position.Y + 20, 
                        Character2.Image.Width - 50, Character2.Image.Height);
                    if (r1.Contains(Obstacles[i].Center))
                    {
                        Character2.Lives--;
                        Obstacles.Remove(Obstacles[i]);
                    }
                }
            }
        }
    }
}
