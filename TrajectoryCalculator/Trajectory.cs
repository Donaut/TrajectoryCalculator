using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace TrajectoryCalculator
{
    public static class Trajectory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initalVelocity">The velocity of the object</param>
        /// <param name="angle">The angle in degree</param>
        /// <param name="gravity"></param>
        /// <returns>A Vector2 that represents a position at a time.</returns>
        public static IEnumerable<Vector2> CalculatePosition(Vector2 initalVelocity, double angle, float gravity = 9.81f)
        {
            //float gravity = 9.81f;
            //Vector2 initalVelocity = new Vector2(20, 50);

            // Kezdő szög. nekünk radián kell a számoláshoz szóval át kell konvetálni
            // 45* a jelenlegi szögünk
            //double angle = 45 * (180 / Math.PI);
            angle = angle * (180 / Math.PI);
            // The total time in the Air!
            double totalTimeInAir = (2 * initalVelocity.Y * Math.Sin(angle)) / gravity;

            // Max height!
            double height = Math.Pow(initalVelocity.Y, 2) * Math.Pow(Math.Sin(angle), 2);
            
            // Hogyha nem megfelelően lépünk akkor a rajz darabos lesz. 
            double step = initalVelocity.Y > initalVelocity.X ? 1 / initalVelocity.Y : 1 / initalVelocity.X;
            for (double t = 0; t < totalTimeInAir; t += step)
            {
                var h = Console.WindowHeight;
                var w = Console.WindowWidth;

                // Dont forget to add the inital position.
                //x = Vx * t
                //y = Vy * t - g * t² 
                double x = initalVelocity.X * t;
                double y = initalVelocity.Y * t - gravity * Math.Pow(t, 2);
                var currentPosition = new Vector2((float)x, (float)y);

                yield return currentPosition;
            }
        }

        /// <inheritdoc cref="CalculatePosition(Vector2, double, float)"/>
        /// <param name="position">The position of the vector.</param>
        public static IEnumerable<Vector2> CalculatePosition(Vector2 initalVelocity, double angle, Vector2 position, float gravity = 9.81f)
        {
            //float gravity = 9.81f;
            //Vector2 initalVelocity = new Vector2(20, 50);

            // Kezdő szög. nekünk radián kell a számoláshoz szóval át kell konvetálni
            // 45* a jelenlegi szögünk
            //double angle = 45 * (180 / Math.PI);
            angle = angle * (180 / Math.PI);
            // The total time in the Air!
            double totalTimeInAir = (2 * initalVelocity.Y * Math.Sin(angle)) / gravity;

            // Max height!
            double height = Math.Pow(initalVelocity.Y, 2) * Math.Pow(Math.Sin(angle), 2);

            Vector2 Position = new Vector2(0, 0);

            // Hogyha nem megfelelően lépünk akkor a rajz darabos lesz. 
            double step = initalVelocity.Y > initalVelocity.X ? 1 / initalVelocity.Y : 1 / initalVelocity.X;
            for (double t = 0; t < totalTimeInAir; t += step)
            {
                var h = Console.WindowHeight;
                var w = Console.WindowWidth;

                // Dont forget to add the inital position.
                //x = Vx * t
                //y = Vy * t - g * t² 
                double x = initalVelocity.X * t;
                double y = initalVelocity.Y * t - gravity * Math.Pow(t, 2);
                var currentPosition = new Vector2((float)x, (float)y);

                yield return currentPosition + position;
            }
        }
    }
}
