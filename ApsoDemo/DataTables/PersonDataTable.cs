using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApsoDemo.Models;
using Apso.Control.DataTable;
using System.Collections.ObjectModel;

namespace ApsoDemo.DataTables
{
    public class PersonDataTable : DataTable<PersonModel>
    {
        public PersonDataTable()
        {
            _columns = new List<DataTableColumn>()
            {
                new DataTableColumn("ID", "ID", 50),
                new DataTableColumn("Name", "Nombre", 150),
                new DataTableColumn("Age", "Edad", 50),
                new DataTableColumn("Active", "-", 50)
            };

            init(true);

            source = new PersonCollection()
            {
                new PersonModel(1, "Luis Carlos", 31, true),
                new PersonModel(2, "Juan Ramiro", 28, true),
                new PersonModel(3, "Omarcinho de Jesús", 35, false)
            };
        }

        public void getList()
        {
            source = null;
            source = new PersonCollection();
            source.Add(new PersonModel(1, "Luis Carlos", 31, true));
            source.Add(new PersonModel(2, "Juan Ramiro", 28, true));
            source.Add(new PersonModel(3, "Omarcinho de Jesús", 35, false));
        }
    }
}
