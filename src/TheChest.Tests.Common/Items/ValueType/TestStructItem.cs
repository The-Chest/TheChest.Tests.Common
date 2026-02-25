using System;

namespace TheChest.Tests.Common.Items.ValueType
{
    internal readonly struct TestStructItem
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }

        public TestStructItem(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) 
                return false;
            if (!(obj is TestStructItem)) 
                return false;
            
            var item = (TestStructItem)obj;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Description);
        }
    }
}
