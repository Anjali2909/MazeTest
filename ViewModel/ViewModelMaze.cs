using MazeTest.Model;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MazeTest.Constants;

namespace MazeTest.ViewModel
{
    public class ViewModelMaze:BindableBase
    {
        #region Props
        public List<MazeColumn> DispCol { get; set; }
        #endregion

        #region private Fields
        MazeColumnDetails ExplorerKey;
        MazeColumnDetails CheckKey;
        public int rowNumber { get; set; }
        #endregion

        #region ctor
        public ViewModelMaze()
        {
            UpCommand = new DelegateCommand(ExplorerUp);
            LeftCommand = new DelegateCommand(ExplorerLeft);
            RightCommand = new DelegateCommand(ExplorerRight);
            DownCommand = new DelegateCommand(ExplorerDown);
            ResetMaze();
        }
        #endregion
        

        #region ICommand
        public ICommand UpCommand { get; set; }
        public ICommand LeftCommand { get; set; }
        public ICommand RightCommand { get; set; }
        public ICommand DownCommand { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// reset the default Maze
        /// </summary>
        public void ResetMaze()
        {
            SetDefaultMaze();
            ExplorerKey = new MazeColumnDetails() { ColumnStr = "S", IsChecked = true, ColumnValue = 2 };
            rowNumber = 0;
            CheckKey = new MazeColumnDetails();
            this.RaisePropertyChanged(nameof(DispCol));
        }

        /// <summary>
        /// decreses row value for down movement calls for new position
        /// </summary>
        private void ExplorerUp()
        {
            rowNumber--;
            if (rowNumber < 0)
            {
                MessageBox.Show(MazeTestConstants.GAME_OVER); ResetMaze();
                return;
            }
            ExplorerUpDown();
        }

        /// <summary>
        /// finds column of next position for left movement
        /// </summary>
        private void ExplorerLeft()
        {
            var currentKey = DispCol[rowNumber];
            if (currentKey.Col1.ColumnValue == 0)
            {
                MessageBox.Show(MazeTestConstants.GAME_OVER); ResetMaze();
            }
            if (CheckColumn(currentKey.Col2, currentKey.Col1, DispCol[rowNumber].Col1) || CheckColumn(currentKey.Col3, currentKey.Col2, DispCol[rowNumber].Col2) || CheckColumn(currentKey.Col4, currentKey.Col3, DispCol[rowNumber].Col3) || CheckColumn(currentKey.Col5, currentKey.Col4, DispCol[rowNumber].Col4))
                return;
            
        }

        /// <summary>
        /// sets coulmn number to next position for right left movement
        /// </summary>
        private bool CheckColumn(MazeColumnDetails mazeColDetails, MazeColumnDetails mazeColDetailsSet, MazeColumnDetails DipColIsCheckSetter)
        {
            if (mazeColDetails.ColumnStr == ExplorerKey.ColumnStr && mazeColDetails.ColumnValue == ExplorerKey.ColumnValue &&
                mazeColDetails.IsChecked == ExplorerKey.IsChecked)
            {
                CheckKey.ColumnStr = mazeColDetailsSet.ColumnStr;
                CheckKey.IsChecked = mazeColDetailsSet.IsChecked;
                CheckKey.ColumnValue = mazeColDetailsSet.ColumnValue;
                SetExplorer(DipColIsCheckSetter);
                return true;
            }
            return false;
        }

        /// <summary>
        /// finds column of next position for right movement
        /// </summary>
        private void ExplorerRight()
        {
            var currentKey = DispCol[rowNumber];
            if(CheckColumn(currentKey.Col1, currentKey.Col2, DispCol[rowNumber].Col2) || CheckColumn(currentKey.Col2, currentKey.Col3, DispCol[rowNumber].Col3)
                || CheckColumn(currentKey.Col3, currentKey.Col4, DispCol[rowNumber].Col4) || CheckColumn(currentKey.Col4, currentKey.Col5, DispCol[rowNumber].Col5))
                return;
            if (currentKey.Col5.ColumnValue == 5)
            {
                MessageBox.Show(MazeTestConstants.GAME_OVER); ResetMaze();
            }
        }

        /// <summary>
        /// increses row value for down movement calls for new position
        /// </summary>
        private void ExplorerDown()
        {
            rowNumber++;
            if(rowNumber > 4)
            {
                MessageBox.Show("Game Over !!.."); ResetMaze();
                return;
            }
            ExplorerUpDown();
        }

        /// <summary>
        /// sets row number to next position for up down movement
        /// </summary>
        private bool CheckRow(MazeColumnDetails mazeColDetails, MazeColumnDetails DipColIsCheckSetter)
        {
            if (mazeColDetails.ColumnValue == ExplorerKey.ColumnValue)
            {
                CheckKey.ColumnStr = mazeColDetails.ColumnStr;
                CheckKey.IsChecked = mazeColDetails.IsChecked;
                CheckKey.ColumnValue = mazeColDetails.ColumnValue;
                SetExplorer(DipColIsCheckSetter);
                return true;
            }
            return false;
        }
        /// <summary>
        /// finds column of next position for up down movement
        /// </summary>
        private void ExplorerUpDown()
        {
            var currentKey = DispCol[rowNumber];
            if (CheckRow(currentKey.Col1, DispCol[rowNumber].Col1) || CheckRow(currentKey.Col2, DispCol[rowNumber].Col2) || CheckRow(currentKey.Col3, DispCol[rowNumber].Col3) ||
                CheckRow(currentKey.Col4, DispCol[rowNumber].Col4) || CheckRow(currentKey.Col5, DispCol[rowNumber].Col5))
                return;
        }

        /// <summary>
        /// Checks the next string on moving forward
        /// </summary>
        private void SetExplorer(MazeColumnDetails mazeColDetailsSet)
        {
            if(CheckKey.ColumnStr=="X")
            {
                MessageBox.Show(MazeTestConstants.GAME_OVER); 
                ExplorerKey.IsChecked = false;
                ResetMaze(); return;
            }
            if (CheckKey.ColumnStr == "F")
            {
                MessageBox.Show(MazeTestConstants.GAME_SUCCESS);
                mazeColDetailsSet.IsChecked = true;
                ExplorerKey.IsChecked = true;
                ResetMaze(); return;
            }
            else
            {
                mazeColDetailsSet.IsChecked = true;
                ExplorerKey = CheckKey;
                ExplorerKey.IsChecked = true;
            }
        }
        #endregion
        /// <summary>
        /// Sets up the default Maze
        /// </summary>
        public void SetDefaultMaze()
        {
            DispCol = new List<MazeColumn>();

            DispCol.Add(new MazeColumn()
            {
                Col1 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 1 },
                Col2 = new MazeColumnDetails() { ColumnStr = "S", IsChecked = true, ColumnValue = 2 },
                Col3 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 3 },
                Col4 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 4 },
                Col5 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 5 }
            });

            DispCol.Add(new MazeColumn()
            {
                Col1 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 1 },
                Col2 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 2 },
                Col3 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 3 },
                Col4 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 4 },
                Col5 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 5 }
            });

            DispCol.Add(new MazeColumn()
            {
                Col1 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 1 },
                Col2 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 2 },
                Col3 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 3 },
                Col4 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 4 },
                Col5 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 5 }
            });
            DispCol.Add(new MazeColumn()
            {
                Col1 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 1 },
                Col2 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 2 },
                Col3 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 3 },
                Col4 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 4 },
                Col5 = new MazeColumnDetails() { ColumnStr = " ", IsChecked = false, ColumnValue = 5 }
            });
            DispCol.Add(new MazeColumn()
            {
                Col1 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 1 },
                Col2 = new MazeColumnDetails() { ColumnStr = "F", IsChecked = false, ColumnValue = 2 },
                Col3 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 3 },
                Col4 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 4 },
                Col5 = new MazeColumnDetails() { ColumnStr = "X", IsChecked = false, ColumnValue = 5 }
            });
            this.RaisePropertyChanged(nameof(DispCol));
        }
    }
}
