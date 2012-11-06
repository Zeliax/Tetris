using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Tetris.Model
{
    abstract class BaseBlock
    {
        public Brick[] Block = new Brick[4];
        public abstract void MoveRight();
        public abstract void MoveLeft();
        public abstract void RotateRight();
        public abstract void RotateLeft();
        public abstract void DropDown();
        public abstract void MoveDown();
        public abstract void StoreBlock();
        public int state = 0;
        public bool Active = true;
    
    }
}
