using System;
using System.Numerics;
using TrajectoryCalculator;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = Console.WindowHeight;
            var w = Console.WindowWidth;
            Rectangle rectangle = new Rectangle(0, 0, w, h);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Kérlek add meg a szöget(fokban)!");
                int degree = int.Parse(Console.ReadLine());
                Console.WriteLine("Kérlek add meg az irányvektort!");
                Console.Write("Hosszúság: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Magasság: ");
                int y = int.Parse(Console.ReadLine());

                // 20 10 45
                foreach (Vector2 position in Trajectory.CalculatePosition(new Vector2(x, y), degree)
                {
                    if (rectangle.Intersects((int)position.X, (int)position.Y))
                    {
                        // The problem is that the vector2(0, 0) position is the top left corner and so our path is upsidedown. So we need to rotate it.
                        // This is a fast solution only. In a real application we using matrixes. (Translate and Scale)
                        var result = new Vector2((float)position.X, (float)position.Y);
                        result -= new Vector2(0, h);
                        result *= new Vector2(1, -1);

                        Console.SetCursorPosition((int)result.X, (int)result.Y);
                        Console.Write('#');
                    }
                }
                Console.SetCursorPosition(0, h);
                Console.WriteLine("ENTER az újrakezdéshez.");
                Console.ReadLine();
            }
        }
    }
}
