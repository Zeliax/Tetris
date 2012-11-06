using Tetris.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Command
{
    // Bruges til at flytte punkt.
    public class MoveBrickCommand : IUndoRedoCommand
    {
        private Brick brick;
        private int x;
        private int y;
        private int newX;
        private int newY;

        public MoveBrickCommand(Brick _brick, int _newX, int _newY, int _x, int _y) 
        { 
            brick = _brick; 
            newX = _newX; 
            newY = _newY; 
            x = _x; 
            y = _y; 
        }

        public void Execute()
        {
        //    brick.CanvasCenterX = newX;
        //    brick.CanvasCenterY = newY;
        }

        public void UnExecute()
        {
        //    brick.CanvasCenterX = x;
        //    brick.CanvasCenterY = y;
        }
    }
}