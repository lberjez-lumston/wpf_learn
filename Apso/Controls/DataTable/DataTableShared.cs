using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Apso.Control.DataTable
{
    /// <summary>
    /// Internal class for datatable sorting funtions with API
    /// </summary>
    public class DataTableSort
    {
        public string column { get; set; }
        public int dir { get; set; }
        public string direction { get; set; }
    }

    /// <summary>
    /// Internal class for datatable filter functions with API
    /// </summary>
    public class DataTableFilter
    {
        public string column { get; set; }
        public string value { get; set; }

        public DataTableFilter(string column, string value)
        {
            this.column = column;
            this.value = value;
        }
    }

    /// <summary>
    /// Internal class for button created in everyrow of datatable
    /// </summary>
    public class DataTableButton
    {
        private string _icon;
        private RoutedEventHandler _ev;
        private Brush _background;

        public DataTableButton(string icon, RoutedEventHandler ev)
        {
            _icon = icon;
            _ev = ev;
            _background = (Brush)Application.Current.Resources["PrimaryColor"];
        }

        public DataTableButton(string icon, RoutedEventHandler ev, Brush background)
        {
            _icon = icon;
            _ev = ev;
            _background = background;
        }

        public FrameworkElementFactory getButton(bool first, FrameworkElementFactory spFactory)
        {
            // Create The Column
            //DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();

            //templateColumn.Header = "";
            //templateColumn.Width = first ? new DataGridLength(40, DataGridLengthUnitType.Star) : (double)40;
            //templateColumn.CanUserSort = false;

            // Create the TextBlock
            FrameworkElementFactory btnFactory = new FrameworkElementFactory(typeof(Button));
            btnFactory.SetValue(Button.ContentProperty, _icon);

            btnFactory.SetValue(Button.StyleProperty, (Style)Application.Current.Resources["DataTableButton"]);
            btnFactory.SetValue(Button.BackgroundProperty, _background);
            btnFactory.AddHandler(Button.ClickEvent, _ev);

            spFactory.AppendChild(btnFactory);
            //DataTemplate btnTemplate = new DataTemplate();
            //btnTemplate.VisualTree = btnFactory;

            //// Set the Templates to the Column
            //templateColumn.CellTemplate = btnTemplate;

            return spFactory;
        }
    }

    /// <summary>
    /// Internal class for column with checkbox in datatable
    /// </summary>
    public class DataTableCheckBox
    {
        private RoutedEventHandler _ev;

        public DataTableCheckBox(RoutedEventHandler ev)
        {
            _ev = ev;
        }


        public DataGridTemplateColumn getButton()
        {
            // Create The Column
            DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();

            templateColumn.Header = "";
            templateColumn.Width = (double)60;
            templateColumn.CanUserSort = false;

            FrameworkElementFactory btnFactory = new FrameworkElementFactory(typeof(CheckBox));

            btnFactory.AddHandler(CheckBox.ClickEvent, _ev);

            DataTemplate btnTemplate = new DataTemplate();
            btnTemplate.VisualTree = btnFactory;

            // Set the Templates to the Column
            templateColumn.CellTemplate = btnTemplate;

            return templateColumn;
        }
    }

    /// <summary>
    /// Internal class for column with checkbox in datatable
    /// </summary>
    public class CustomDataGridCheckBoxColumn : DataGridCheckBoxColumn
    {
        private CheckBox checkBox;
        public RoutedEventHandler Click;

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {

            CheckBox checkBox = base.GenerateEditingElement(cell, dataItem) as CheckBox;
            checkBox.Checked += new RoutedEventHandler(HandleClick);
            checkBox.Unchecked += new RoutedEventHandler(HandleClick);
            return checkBox;
        }
        public void HandleClick(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(sender, e);
            }
        }
    }
}
