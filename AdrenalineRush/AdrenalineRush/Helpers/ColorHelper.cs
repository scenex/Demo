using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AdrenalineRush
{
    public static class ColorHelper
    {
        static Random random = new Random(100);
        static Color randomColor;
        public static Color GetRandomColor()
        {
            switch (random.Next(0, 2))
            {
                case 0:
                    randomColor = Color.White;
                    break;

                case 1:
                    randomColor = Color.Black;
                    break;

                case 2:
                    randomColor = Color.WhiteSmoke;
                    break;

                default:
                    break;
            }

            return randomColor;               
        }
    }
}
