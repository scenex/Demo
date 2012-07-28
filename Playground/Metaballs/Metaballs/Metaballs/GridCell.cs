// -----------------------------------------------------------------------
// <copyright file="GridCell.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Metaballs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class GridCell
    {
        public Vector3[] p;

        public double[] val;

        public GridCell()
        {
            p = new Vector3[8];
            val = new double[8];
        }


    }
}

   //XYZ p[8];
   //double val[8];
