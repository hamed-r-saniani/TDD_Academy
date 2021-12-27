﻿namespace Academy.Domain
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Section(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}