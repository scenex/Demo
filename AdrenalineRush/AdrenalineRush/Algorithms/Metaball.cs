// -----------------------------------------------------------------------
// <copyright file="Metaball.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace AdrenalineRush.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Metaball
    {
        public Metaball()
        {
            
        }

        public int Calculate(int x, int y, int z, int x0, int y0, int z0)
        {
            return 1 / (((x - x0) * (x - x0)) + ((y - y0) * (y - y0)) + ((z - z0) * (z - z0)));
        }
    }
}
