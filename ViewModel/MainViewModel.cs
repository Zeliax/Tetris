using Tetris.Command;
using Tetris.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System;
using System.ComponentModel;


namespace Tetris.ViewModel
{
    class MainViewModel : ViewModelBase
    {

        private UndoRedoController undoRedoController = UndoRedoController.GetInstance();
        public ObservableCollection<Brick> Bricks { get; set; }
        public ICommand UndoCommand { get; private set; }
        public ICommand RedoCommand { get; private set; }
        public ICommand MoveBrickCommand { get; private set; }
        Brick[,] GameField = new Brick[10, 20];
        BaseBlock currentBlock;
        bool Paused;
        MoveBlock BlockMover;


        public MainViewModel()
        {
            Paused =false;
            MoveBrickCommand = new RelayCommand<KeyEventArgs>(Move);
            Bricks = new ObservableCollection<Brick>(); //Data-structure containing the building pieces bricks.
            UndoCommand = new RelayCommand(undoRedoController.Undo, undoRedoController.CanUndo);
            RedoCommand = new RelayCommand(undoRedoController.Redo, undoRedoController.CanRedo);
         //   while (!Paused)
        //    {
                BaseBlock block = new LineBlock();
                currentBlock = block;

                foreach (Brick child in block.Block)
                {
                    Bricks.Add(child);
                }


                // Bricks.Remove(brick1);
                BlockMover = new MoveBlock(currentBlock,this);
        //    }
            
        }
        public void Move(KeyEventArgs e)
        {

            if (e.Key == Key.Left)
            {
                if (!WouldMoveOutsideLeftX()) {
                currentBlock.MoveLeft();
                }
            }
            if (e.Key == Key.Right )
            {
                if (!WouldMoveOutsideRightX())
                {
                    currentBlock.MoveRight();
                }
            }
            if (e.Key == Key.Up)
            {
                if (!WouldMoveOutsideLeftX() && !WouldMoveOutsideRightX())
                {
                currentBlock.RotateRight();
                }
            }
            if (e.Key == Key.Down)
                if (!WouldMoveOutsideLeftX() && !WouldMoveOutsideRightX())
                {
                    currentBlock.RotateLeft();
                }

        }
        void Collided()
        {
            foreach (Brick child in currentBlock.Block)
            {
                foreach (Brick game in Bricks)
                {
                    if (child.X == game.X)
                    {
                        currentBlock.Active = false;
                    }
                }
            }
        }
        bool WouldMoveOutsideLeftX()
        {
            foreach (Brick child in currentBlock.Block)
            {
                if (child.X <= 0)
                {
                    return true;
                }
            }
            return false;
        }
        bool WouldMoveOutsideRightX()
        {
            foreach (Brick child in currentBlock.Block)
            {
                if (child.X >= 9)
                {
                    return true;
                }
            }
            return false;
        }
      public bool WouldMoveOutsideY()
        {
            foreach (Brick child in currentBlock.Block)
            {
                if (child.Y >= 19)
                {
                    return true;
                }
            }
           return false;
        }



    }
}

