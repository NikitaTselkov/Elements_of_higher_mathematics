using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using ViewModel.Navigation;

namespace ViewModel
{
    public class MatrixViewModel : NavigateViewModel
    {
        /// <summary>
        /// Количество колонок в матрице.
        /// </summary>
        private int _matrixColumnCount = 4;
        public int MatrixColumnCount
        {
            get { return _matrixColumnCount; }
            set 
            {
                _matrixColumnCount = value;
                UpdateMatrix();
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Количество строчек в матрице.
        /// </summary>
        private int _matrixRowCount = 4;
        public int MatrixRowCount
        {
            get { return _matrixRowCount; }
            set
            {
                _matrixRowCount = value;
                UpdateMatrix();
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Название текущей матрицы.
        /// </summary>
        private string _currentMatrixName = "A";
        public string CurrentMatrixName
        {
            get { return _currentMatrixName; }
            set
            {
                _currentMatrixName = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Матрица A.
        /// </summary>
        private DataTable _matrixA;
        public DataTable MatrixA
        {
            get
            {
                return _matrixA;
            }
            set
            {
                _matrixA = value;

                for (int i = 0; i < MatrixColumnCount; i++)
                {
                    this._matrixA.Columns.Add(new DataColumn());
                }

                RaisePropertyChanged();
            }
        }

        public MatrixViewModel()
        {
            UpdateMatrix();
        }

        private void UpdateMatrix()
        {
            this.MatrixA = new DataTable();

            for (int j = 0; j < MatrixRowCount; j++)
            {
                var row = this.MatrixA.NewRow();

                for (int i = 0; i < MatrixColumnCount; i++)
                {
                    row[i] = 0;
                }

                this.MatrixA.Rows.Add(row);
            }

           

        }

    }
}
