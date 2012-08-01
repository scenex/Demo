// -----------------------------------------------------------------------
// <copyright file="Triangle.cs" company="">
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

    //typedef struct
    //{
    //    XYZ point[3];
    //} TRIANGLE;

    public class Triangle
    {
        public Vector3[] p;

        public Triangle()
        {
            p = new Vector3[3];
        }
    }
}
