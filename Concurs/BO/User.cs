﻿namespace Concurs.BO
{
    public class User
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}