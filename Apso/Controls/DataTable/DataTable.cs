using Apso.Control.DataTable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Apso.Control.DataTable
{
    public abstract class DataTable<T> : INotifyPropertyChanged
    {
        #region Parameters
        protected string _url { get; set; }
        protected List<DataTableColumn> _columns { get; set; }
        protected List<DataTableButton> _actions { get; set; }
        protected List<DataTableCheckBox> _checks { get; set; }
        protected bool multiselect { get; set; }
        #endregion

        #region Attrs
        #region source
        private ObservableCollection<T> _source;
        public ObservableCollection<T> source
        {
            get { return _source; }
            set
            {
                if (value != _source)
                {
                    _source = value;
                    OnPropertyChanged("source");
                }
            }
        }
        #endregion source

        #region gridColumns
        private ObservableCollection<DataGridColumn> _gridColumns;
        public ObservableCollection<DataGridColumn> gridColumns
        {
            get { return _gridColumns; }
            set
            {
                if (value != _gridColumns)
                {
                    _gridColumns = value;
                    OnPropertyChanged("gridColumns");
                }
            }
        }
        #endregion gridColumns

        #region keyDowntimer
        private double keydownDelay = 500;
        private Timer keydownTimer = new Timer();
        #endregion
        #endregion

        #region UI Props
        #region loaderBgVisibility
        private Visibility _loaderBgVisibility;
        public Visibility loaderBgVisibility
        {
            get { return _loaderBgVisibility; }
            set
            {
                if (value != _loaderBgVisibility)
                {
                    _loaderBgVisibility = value;
                    OnPropertyChanged("loaderBgVisibility");
                }
            }
        }
        #endregion loaderBgVisibility

        #region paginationVisibility
        private Visibility _paginationVisibility;
        public Visibility paginationVisibility
        {
            get { return _paginationVisibility; }
            set
            {
                if (value != _paginationVisibility)
                {
                    _paginationVisibility = value;
                    OnPropertyChanged("paginationVisibility");
                }
            }
        }
        #endregion paginationVisibility
        #endregion

        #region Constructor
        public DataTable() { }

        /// <summary>
        /// Initialize the DataTable object
        /// </summary>
        /// <param name="columns">List of columns to render in the DataGrid WPF Control</param>
        /// <param name="url">API URL for get data for redner</param>
        /// <param name="actions">List of actions for all records in grid</param>
        public DataTable(List<DataTableColumn> columns, string url, List<DataTableButton> actions) : this(columns, url, actions, false) { }

        /// <summary>
        /// Initialize the DataTable object
        /// </summary>
        /// <param name="columns">List of columns to render in the DataGrid WPF Control</param>
        /// <param name="url">API URL for get data for redner</param>
        /// <param name="actions">List of actions for all records in grid</param>
        /// <param name="checkbox">Flag for show/hide checkbox</param>
        public DataTable(List<DataTableColumn> columns, string url, List<DataTableButton> actions, bool checkbox)
        {
            _columns = columns;
            _url = url;
            _actions = actions;

            //init(false);
            //_paginationCommand = new DelegateCommand<string>(PageChange, (s) => {
            //    if (s == null) return false;

            //    switch (s)
            //    {
            //        case "F":
            //        case "P":
            //            return pageNum > 1;

            //        case "N":
            //        case "L":
            //            return pageNum < totalPages;

            //        default:
            //            return pageNum != int.Parse(s);
            //    }
            //});
        }
        #endregion

        #region Methods
        protected void init(bool flag)
        {
            loaderBgVisibility = Visibility.Collapsed;
            gridColumns = new ObservableCollection<DataGridColumn>();
            // paginationButtons = new ObservableCollection<Button>();
            source = new ObservableCollection<T>();

            gridColumns.Clear();
            keydownTimer.Interval = keydownDelay;
            keydownTimer.AutoReset = false;

            if (flag)
            {
                CustomDataGridCheckBoxColumn chkCol = new CustomDataGridCheckBoxColumn();
                chkCol.Binding = new Binding("IsSelected");
                // chkCol.Click = OnCheckChange;

                gridColumns.Add(chkCol);
            }

            foreach (DataTableColumn col in _columns)
            {
                gridColumns.Add(col.get());
            }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

    }
}
