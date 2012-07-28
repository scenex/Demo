using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Metaballs.Tests
{
    using Xunit;

    public class MarchingCubeAlgorithmTests
    {
        private GridCell gridCell;
        private double isolevel = 2.0;
        private Triangle[] triangles;


        private MarchingCubeAlgorithm testee;

        public MarchingCubeAlgorithmTests()
        {
            this.gridCell = new GridCell();
            this.gridCell.val[0] = 0.0;
            this.gridCell.val[1] = 0.0;
            this.gridCell.val[2] = 0.0;
            this.gridCell.val[3] = 3.0;
            this.gridCell.val[4] = 0.0;
            this.gridCell.val[5] = 0.0;
            this.gridCell.val[6] = 0.0;
            this.gridCell.val[7] = 3.0;

            this.gridCell.p[0].X = 0;
            this.gridCell.p[0].Y = 0;
            this.gridCell.p[0].Z = 0;

            this.gridCell.p[1].X = 1;
            this.gridCell.p[1].Y = 0;
            this.gridCell.p[1].Z = 0;

            this.gridCell.p[2].X = 1;
            this.gridCell.p[2].Y = 0;
            this.gridCell.p[2].Z = 1;

            this.gridCell.p[3].X = 0;
            this.gridCell.p[3].Y = 0;
            this.gridCell.p[3].Z = 1;

            this.gridCell.p[4].X = 0;
            this.gridCell.p[4].Y = 1;
            this.gridCell.p[4].Z = 0;

            this.gridCell.p[5].X = 1;
            this.gridCell.p[5].Y = 1;
            this.gridCell.p[5].Z = 0;

            this.gridCell.p[6].X = 1;
            this.gridCell.p[6].Y = 1;
            this.gridCell.p[6].Z = 1;

            this.gridCell.p[7].X = 0;
            this.gridCell.p[7].Y = 1;
            this.gridCell.p[7].Z = 1;



            this.testee = new MarchingCubeAlgorithm();
        }

        [Fact]
        public void Test()
        {
            this.testee.Polygonise(gridCell, isolevel, out triangles);
        }
    }
}
