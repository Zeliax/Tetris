using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tetris.ViewModel;
using Tetris.Model;
using System.Timers;

namespace Tetris.ViewModel
{
    class MoveBlock
    {
        Timer timer;
        BaseBlock block;
        MainViewModel Main;
        public MoveBlock(BaseBlock block,MainViewModel Main)
        {
            this.Main = Main;
            this.block = block;
            timer = new Timer(700);
            timer.Elapsed +=new ElapsedEventHandler(run);
            timer.Start();
        }
        public void run(object sender, ElapsedEventArgs e)
        {
            
            if (Main.WouldMoveOutsideY())
            {
                timer.Stop();
            }
            else
            {
                block.MoveDown();
            }
            
        }
    }
}
