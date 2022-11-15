using System;
namespace BackEnd
{
    public struct Identity
    {
        public string Name { get; set; }
        public string StoreFile { get; set; }
        public bool Permission { get; set; }
        public short Id { get; set; }

        public Identity(short id, string name, string storefile, bool permission)
        {
            Id = id;
            Name = name;
            StoreFile = storefile;
            Permission = permission;
        }
    }
}

