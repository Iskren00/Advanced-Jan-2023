namespace DefiningClasses;

public class Car
{      
    public string Model { get; set; }

    public Engine Engine { get; set; }

    public Cargo Cargo { get; set; }

    public Tire[] Tires { get; set; }

    public Car(string model, int engineSpeed, int enginePower, int cargoWeigt, string cargoType,
        double tier1Pressur, int tier1Age, double tier2Pressur, int tier2Age,
        double tier3Pressur, int tier3Age, double tier4Pressur, int tier4Age)
    {
        Model = model;
        Engine = new Engine(engineSpeed, enginePower);
        Cargo = new Cargo(cargoWeigt, cargoType);
        Tires = new Tire[4];
        Tires[0] = new Tire(tier1Pressur, tier1Age);
        Tires[1] = new Tire(tier2Pressur, tier2Age);
        Tires[2] = new Tire(tier3Pressur, tier3Age);
        Tires[3] = new Tire(tier4Pressur, tier4Age);

    }

}
