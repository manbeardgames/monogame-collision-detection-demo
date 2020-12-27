/* ----------------------------------------------------------------------------
    This is free and unencumbered software released into the public domain.

    Anyone is free to copy, modify, publish, use, compile, sell, or
    distribute this software, either in source code form or as a compiled
    binary, for any purpose, commercial or non-commercial, and by any
    means.

    In jurisdictions that recognize copyright laws, the author or authors
    of this software dedicate any and all copyright interest in the
    software to the public domain. We make this dedication for the benefit
    of the public at large and to the detriment of our heirs and
    successors. We intend this dedication to be an overt act of
    relinquishment in perpetuity of all present and future rights to this
    software under copyright law.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
    IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
    OTHER DEALINGS IN THE SOFTWARE.

    For more information, please refer to <http://unlicense.org/>
---------------------------------------------------------------------------- */

using Microsoft.Xna.Framework;
using System;

namespace CollisionDemo
{
    public static class CollisionChecks
    {
        /// <summary>
        ///     Checks for collision between two rectangular structures using
        ///     Axis-Aligned Bounding Box collision detection.
        /// </summary>
        /// <param name="boxA">
        ///     The bounding box of the first structure.
        /// </param>
        /// <param name="boxB">
        ///     The bounding box of the second structure.
        /// </param>
        /// <returns>
        ///     True if the two structures are colliding; otherwise, false.
        /// </returns>
        public static bool AABB(Rectangle boxA, Rectangle boxB)
        {
            return boxA.Left < boxB.Right &&
                   boxA.Right > boxB.Left &&
                   boxA.Top < boxB.Bottom &&
                   boxA.Bottom > boxB.Top;
        }

        /// <summary>
        ///     Checks for collision between two circle structures.
        /// </summary>
        /// <param name="circleA">
        ///     The first circle.
        /// </param>
        /// <param name="circleB">
        ///     The second circle.
        /// </param>
        /// <returns>
        ///     True if the two circles are colliding; otherwise, false.
        /// </returns>
        public static bool Circle(Circle circleA, Circle circleB)
        {
            //  Get the sum of the radii
            int radii = circleA.Radius + circleB.Radius;

            //  Get the distance from the center of each circle.
            float distance = Distance(circleA, circleB);

            //  If the distance is less than the radii sum, then it is a collision
            return distance < radii;
        }


        /// <summary>
        ///     Calculates the distance between the center points of two circles.
        /// </summary>
        /// <param name="circleA">
        ///     The first circle.
        /// </param>
        /// <param name="circleB">
        ///     The second circle.
        /// </param>
        /// <returns>
        ///     The distance between the center point of both circles.
        /// </returns>
        public static float Distance(Circle circleA, Circle circleB)
        {
            //  Get the distance between the x-coordinates of each circle.
            int dx = circleA.Center.X - circleB.Center.X;

            //  Get the distance between the y-coordinates of each circle.
            int dy = circleA.Center.Y - circleB.Center.Y;

            //  Use Pythagorean's Theorem to calculate the distance between the two and return it.
            return (float)Math.Sqrt((dx * dx) + (dy * dy));
        }
    }
}
