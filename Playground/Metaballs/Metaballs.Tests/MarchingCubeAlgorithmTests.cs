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
            this.gridCell.value[0] = 0.0;
            this.gridCell.value[1] = 0.0;
            this.gridCell.value[2] = 0.0;
            this.gridCell.value[3] = 3.0;
            this.gridCell.value[4] = 0.0;
            this.gridCell.value[5] = 0.0;
            this.gridCell.value[6] = 0.0;
            this.gridCell.value[7] = 3.0;

            this.gridCell.point[0].X = 0;
            this.gridCell.point[0].Y = 0;
            this.gridCell.point[0].Z = 0;

            this.gridCell.point[1].X = 1;
            this.gridCell.point[1].Y = 0;
            this.gridCell.point[1].Z = 0;

            this.gridCell.point[2].X = 1;
            this.gridCell.point[2].Y = 0;
            this.gridCell.point[2].Z = 1;

            this.gridCell.point[3].X = 0;
            this.gridCell.point[3].Y = 0;
            this.gridCell.point[3].Z = 1;

            this.gridCell.point[4].X = 0;
            this.gridCell.point[4].Y = 1;
            this.gridCell.point[4].Z = 0;

            this.gridCell.point[5].X = 1;
            this.gridCell.point[5].Y = 1;
            this.gridCell.point[5].Z = 0;

            this.gridCell.point[6].X = 1;
            this.gridCell.point[6].Y = 1;
            this.gridCell.point[6].Z = 1;

            this.gridCell.point[7].X = 0;
            this.gridCell.point[7].Y = 1;
            this.gridCell.point[7].Z = 1;



            this.testee = new MarchingCubeAlgorithm();
        }

        [Fact]
        public void Test()
        {
            this.testee.Polygonise(gridCell, isolevel, out triangles);
        }
    }
}
