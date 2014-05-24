using System;

public class Chef
{
    public void Cook()
    {
        Potato potato = this.GetPotato();
        this.Peel(potato);
        this.Cut(potato);

        Carrot carrot = this.GetCarrot();
        this.Peel(carrot);
        this.Cut(carrot);

        Bowl bowl = this.GetBowl();
        bowl.Add(carrot);
        bowl.Add(potato);
    }

    private Bowl GetBowl()
    {
        Bowl bowl = new Bowl();
        return bowl;
    }

    private Carrot GetCarrot()
    {
        Carrot carrot = new Carrot();
        return carrot;
    }

    private Potato GetPotato()
    {
        Potato potato = new Potato();
        return potato;
    }

    private void Cut(Vegetable vegetable)
    {
        // the cutting logic here
        throw new NotImplementedException();
    }

    private void Peel(Vegetable vegetable)
    {
        // the peeling logic here
        throw new NotImplementedException();
    }
}