namespace Cars.Contracts
{
    using Cars.Models;
    using System.Collections.Generic;

    public interface ICarsRepository
    {
        int TotalCars{get;}

        void Add(Car car); //mocked

        void Remove(Car car);

        Car GetById(int id); //mocked

        ICollection<Car> All(); //mocked

        ICollection<Car> SortedByMake();

        ICollection<Car> SortedByYear();

        ICollection<Car> Search(string condition); //mocked
    }
}
