using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Apso.Control.DataTable
{
    /// <summary>
    /// Define column for Datatable
    /// </summary>
    public class DataTableColumn
    {
        public string name { get; set; }
        public string title { get; set; }
        public int width { get; set; }
        public bool filterIgnore { get; set; }
        public Binding binding { get; set; }

        public Style cellStyle { get; set; }
        public Style titleStyle { get; set; }

        /// <summary>
        /// Initialize new column for datatable
        /// </summary>
        /// <param name="name">Name of the data field column</param>
        /// <param name="header">Title in the header of datatable</param>
        /// <param name="width">Min width of the column</param>
        public DataTableColumn(string name, string header, int width)
        {
            this.name = name;
            this.title = header;
            this.width = width;
            this.binding = new Binding(name);
        }

        /// <summary>
        /// Initialize new column for datatable
        /// </summary>
        /// <param name="name">Name of the data field column</param>
        /// <param name="header">Title in the header of datatable</param>
        /// <param name="width">Min width of the column</param>
        /// <param name="cellStyle">Style for the column in datatable</param>
        public DataTableColumn(string name, string header, int width, Style cellStyle)
        {
            this.name = name;
            this.title = header;
            this.width = width;
            this.binding = new Binding(name);
            this.cellStyle = cellStyle;
        }

        /// <summary>
        /// Initialize new column for datatable
        /// </summary>
        /// <param name="name">Name of data field column</param>
        /// <param name="header">Title in header of datatable</param>
        /// <param name="width">Min width of column</param>
        /// <param name="cellStyle">Style for column in datatable</param>
        /// <param name="titleStyle">Style for header</param>
        public DataTableColumn(string name, string header, int width, Style cellStyle, Style titleStyle)
        {
            this.name = name;
            this.title = header;
            this.width = width;
            this.binding = new Binding(name);

            this.cellStyle = cellStyle;
            this.titleStyle = titleStyle;
        }

        /// <summary>
        /// Generate the column to add in DataGrid WPF control
        /// </summary>
        /// <returns>DataGridTextColumn to add in "columns" of DataGrid</returns>
        public DataGridTextColumn get()
        {
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = title;
            column.Width = new DataGridLength(width, DataGridLengthUnitType.Star);
            column.MinWidth = width;
            column.Binding = binding;
            column.CanUserSort = !this.filterIgnore;
            column.IsReadOnly = true;

            if (cellStyle != null)
                column.CellStyle = cellStyle;

            if (titleStyle != null)
                column.HeaderStyle = titleStyle;

            return column;
        }
    }
}
