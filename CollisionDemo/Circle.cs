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

namespace CollisionDemo
{
    /// <summary>
    ///     A simple structure that defines the values of a circle.
    /// </summary>
    public struct Circle
    {
        /// <summary>
        ///     The center xy-coordinate location of the circle.
        /// </summary>
        public Point Center;

        /// <summary>
        ///     The length of the radius of the circle.
        /// </summary>
        public int Radius;

        /// <summary>
        ///     Creates a new Circle structure.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate position of the center of the circle.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate position of the center of the circle.
        /// </param>
        /// <param name="radius">
        ///     The length of the radius of the circle.
        /// </param>
        public Circle(int x, int y, int radius)
        {
            Center = new Point(x, y);
            Radius = radius;
        }
    }
}