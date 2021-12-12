using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTask
{
    class Property
    {
        private long id;
        private string name;
        private string type;
        private string location;
        private double size;
        private List<byte[]> images;
        private DateTime modificationDate;

        public Property(long id, string name, string type, string location, double size, List<byte[]> images, DateTime modificationDate)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.location = location;
            this.size = size;
            this.images = images;
            this.modificationDate = modificationDate;
        }

        public string Name { get => name; }
        public string Type { get => type; set => type = value; }
        public string Location { get => location; set => location = value; }
        public double Size { get => size; set => size = value; }
        public List<byte[]> Images { get => images; set => images = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
    }
}
