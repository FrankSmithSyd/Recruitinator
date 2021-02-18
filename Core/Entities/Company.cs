﻿using System;

 namespace Core.Entities
{
    public class Company
    {
        public Guid Id { get; }
        public string Name { get; }

        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}