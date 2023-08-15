﻿namespace Stonksbot.GameModel.CompanyClasses;

internal class Company
{

    public Company(string name, int initialStockCount, int initialPrice)
    {
        Name = name;
        StockCount = initialStockCount;
        Price = initialPrice;
    }

    public string Name { get; }

    public int Price { get; private set; }

    public int StockCount { get; private set; }

    public void BuyStock(int amount)
    {
        if(amount > StockCount)
        {
            throw new ArgumentException();
        }
        StockCount -= amount;
    }

    public void SellStock(int amount)
    {
        if(amount <= 0)
        {
            throw new ArgumentException();
        }
        StockCount += amount;
    }

    public void UpdatePrice(int newPrice)
    {
        if(newPrice < 0)
        {
            throw new ArgumentException();
        }
        Price = newPrice;
    }
}