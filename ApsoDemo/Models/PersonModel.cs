using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ApsoDemo.Models
{
    // [AddINotifyPropertyChangedInterface]
    public class PersonModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #region Attrs
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
        #endregion

        public PersonModel(int id, string name, int age, bool active)
        {
            ID = id;
            Name = name;
            Age = age;
            Active = active;
        }
    }

    public class PersonCollection: ObservableCollection<PersonModel> { }
}
