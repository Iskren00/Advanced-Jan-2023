using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniKindergarten;

public class Kindergarten
{
    public Kindergarten(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        Registry = new List<Child>();
    }

    public string Name { get; set; }

    public int Capacity { get; set; }

    public List<Child> Registry { get; set; }

    public int ChildrenCount { get { return Registry.Count; } }

    public bool AddChild(Child child)
    {
        if (Registry.Count == Capacity)
        {
            return false;
        }

        Registry.Add(child);

        return true;
    }

    public bool RemoveChild(string childFullName)
    {
        List<Child> coppy = new List<Child>(Registry);

        foreach (var child in Registry)
        {
            if (child.FirstName + " " + child.LastName == childFullName)
            {
                coppy.Remove(child);
            }
        }

        if (coppy.Count != Registry.Count)
        {
            Registry = coppy;
            return true;
        }

        return false;
    }

    public Child GetChild(string childFullName)
    {
        foreach (var child in Registry)
        {
            if (child.FirstName + " " + child.LastName == childFullName)
            {
                return child;
            }
        }

        return null;
    }

    public string RegistryReport()
    {
        Registry = Registry.OrderBy(f => f.FirstName).ToList();
        Registry = Registry.OrderBy(l => l.LastName).ToList();
        Registry = Registry.OrderByDescending(a => a.Age).ToList();

        return $"Registered children in {Name}:{Environment.NewLine}{string.Join(Environment.NewLine, Registry)}";
    }
}
