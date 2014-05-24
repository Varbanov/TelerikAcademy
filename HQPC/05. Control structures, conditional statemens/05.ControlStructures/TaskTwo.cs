using System;

public class TaskTwo
{
    private Potato potato = new Potato();

    public void TaskTwoMethod(Potato potato)
    {
        if (potato == null)
        {
            throw new ArgumentException("The potato to cook is null");
        }
        else if (!potato.IsPeeled)
        {
            throw new ArgumentException("The potato is not peeled!");
        }
        else if (potato.IsRotten)
        {
            throw new ArgumentException("The potato is rotten!");
        }

        this.Cook(potato);
    }

    public void Cook(Vegetable vegetable)
    {
        // cooking logic here
    }
}