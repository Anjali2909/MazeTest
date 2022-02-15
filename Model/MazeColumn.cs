using Prism.Mvvm;

namespace MazeTest.Model
{
    public class MazeColumn : BindableBase

    {
        #region private fields
        private MazeColumnDetails[] _columns;
        private MazeColumnDetails _col1;
        private MazeColumnDetails _col2;
        private MazeColumnDetails _col3;
        private MazeColumnDetails _col4;
        private MazeColumnDetails _col5;
        #endregion

        #region Props
        public MazeColumnDetails[] Columns
        {
            get { return _columns; }
            set { SetProperty(ref _columns, value); }
        }
        public MazeColumnDetails Col1
        {
            get { return _col1; }
            set { SetProperty(ref _col1, value); }
        }
        public MazeColumnDetails Col2
        {
            get { return _col2; }
            set { SetProperty(ref _col2, value); }
        }
        public MazeColumnDetails Col3
        {
            get { return _col3; }
            set { SetProperty(ref _col3, value); }
        }
        public MazeColumnDetails Col4
        {
            get { return _col4; }
            set { SetProperty(ref _col4, value); }
        }
        public MazeColumnDetails Col5
        {
            get { return _col5; }
            set { SetProperty(ref _col5, value); }
        }
        #endregion
    }
}
