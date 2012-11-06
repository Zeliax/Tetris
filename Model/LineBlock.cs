using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Tetris.Model
{
    class LineBlock : BaseBlock
    {
        Color LineColor = Colors.Red;
        public LineBlock()
        {

            for (int i = 0; i < 4; ++i)
            {
                Block[i] = new Brick(5, i);
            }
        }
        public override void MoveRight()
        {
            for (int i = 0; i < 4; i++)
            {
                Block[i].MoveXRight();
            }
        }
        public override void MoveLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                Block[i].MoveXLeft();
            }
        }
        public override void RotateRight()
        {
            if (state == 0)
            {
                Block[0].X++;
                Block[0].Y++;

                Block[2].X--;
                Block[2].Y--;

                Block[3].X -= 2;
                Block[3].Y -= 2;
                state = 1;
            }
            else if (state == 1)
            {
                Block[0].X--;
                Block[0].Y++;

                Block[2].X++;
                Block[2].Y--;

                Block[3].X += 2;
                Block[3].Y -= 2;
                state = 2;
            }
            else if (state == 2)
            {
                Block[0].X--;
                Block[0].Y--;

                Block[2].X++;
                Block[2].Y++;

                Block[3].X += 2;
                Block[3].Y += 2;
                state = 3;
            }
            else if (state == 3)
            {
                Block[0].X++;
                Block[0].Y--;

                Block[2].X--;
                Block[2].Y++;

                Block[3].X -= 2;
                Block[3].Y += 2;
                state = 0;
            }


        }
        public override void RotateLeft()
        {
            if (state == 0)
            {
                Block[0].X--;
                Block[0].Y++;

                Block[2].X++;
                Block[2].Y--;

                Block[3].X += 2;
                Block[3].Y -= 2;
                state = 3;
            }
            else if (state == 1)
            {
                Block[0].X--;
                Block[0].Y--;

                Block[2].X++;
                Block[2].Y++;

                Block[3].X += 2;
                Block[3].Y += 2;
                state = 0;
            }
            else if (state == 2)
            {
                Block[0].X++;
                Block[0].Y--;

                Block[2].X--;
                Block[2].Y++;

                Block[3].X -= 2;
                Block[3].Y += 2;
                state = 1;
            }
            else if (state == 3)
            {
                Block[0].X++;
                Block[0].Y++;

                Block[2].X--;
                Block[2].Y--;

                Block[3].X -= 2;
                Block[3].Y -= 2;
                state = 2;
            }

        }
        public override void MoveDown()
        {
            for (int i = 0; i < 4; i++)
            {
                Block[i].MoveYDown();
            }
        }
        public override void DropDown()
        {
            for (int i = 0; i < 4; i++)
            {
                Block[i].MoveXRight();
            }
        }
        public override void StoreBlock()
        {
            for (int i = 0; i < 3; i++)
            {
                Block[i].MoveXRight();
            }
        }

    }
}
