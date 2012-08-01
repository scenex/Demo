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
        public Vector3[] point;

        public double[] value;

        public GridCell()
        {
            this.point = new Vector3[8];
            this.value = new double[8];
        }


    }
}

   //XYZ point[8];
   //double value[8];
