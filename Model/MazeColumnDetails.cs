using Prism.Mvvm;

namespace MazeTest.Model
{
    public class MazeColumnDetails : BindableBase
    {
        #region private fields
        private string _columnStr;
        private bool _isChecked;
        private int _columnValue;
        #endregion

        #region Props
        public string ColumnStr
        {
            get { return _columnStr; }
            set { SetProperty(ref _columnStr, value); }
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }
        public int ColumnValue
        {
            get { return _columnValue; }
            set { SetProperty(ref _columnValue, value); }
        }
        #endregion
    }
}
