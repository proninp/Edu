using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Department
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public ObservableCollection<Employee> EmplList = new ObservableCollection<Employee>();
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
            Description = name;
            //EmplList = list;
        }
    }
}
