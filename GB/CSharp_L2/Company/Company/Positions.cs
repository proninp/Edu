using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public Position(int id, string name, int departmentId)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
        }
    }
}
