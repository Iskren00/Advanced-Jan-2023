using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoeStore;

public class ShoeStore
{
    public ShoeStore(string name, int storageCapacity)
    {
        Name = name;
        StorageCapacity = storageCapacity;
        Shoes = new List<Shoe>();
    }

    public string Name { get; set; }

    public int StorageCapacity { get; set; }

    public List<Shoe> Shoes { get; set; }

    public int Count { get { return Shoes.Count; } }

    public string AddShoe(Shoe shoe)
    {
        if (Shoes.Count == StorageCapacity)
        {
            return "No more space in the storage room.";
        }

        Shoes.Add(shoe);

        return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
    }

    public int RemoveShoes(string material)
    {
        int count = 0;

        List<Shoe> coppy = new List<Shoe>(Shoes);

        foreach (var shoe in Shoes)
        {
            if (shoe.Material == material)
            {
                count++;

                coppy.Remove(shoe);
            }
        }

        Shoes = coppy;

        return count;
    }

    public List<Shoe> GetShoesByType(string type)
    {
        List<Shoe> shoesEqualType = new();

        foreach (var shoe in Shoes)
        {
            if (shoe.Type == type.ToLower())
            {
                shoesEqualType.Add(shoe);
            }
        }

        return shoesEqualType;
    }

    public Shoe GetShoeBySize(double size)
    {
        foreach (var shoe in Shoes)
        {
            if (shoe.Size == size)
            {
                return shoe;
            }
        }

        return null;
    }

    public string StockList(double size, string type)
    {
        List<Shoe> stockList = new();

        foreach (var shoe in Shoes)
        {
            if (shoe.Size == size && shoe.Type == type)
            {
                stockList.Add(shoe);
            }
        }

        if (!stockList.Any())
        {
            return "No matches found!";
        }

        return $"Stock list for size {size} - {type} shoes:{Environment.NewLine}{string.Join(Environment.NewLine, stockList)}";
    }
}
