
using BranchOps.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BranchOps.Api.Data;

public static class SeedData
{
    public static async Task InitializeAsync(
        AppDbContext db)
    {
        // Don't insert demo records twice.
        if (await db.Branches.AnyAsync())
            return;

        // Create three warehouse branches.
        var phoenix = new Branch
        {
            Name = "Phoenix",
            City = "Phoenix, AZ"
        };

        var tucson = new Branch
        {
            Name = "Tucson",
            City = "Tucson, AZ"
        };

        var mesa = new Branch
        {
            Name = "Mesa",
            City = "Mesa, AZ"
        };

        db.Branches.AddRange(
            phoenix, tucson, mesa);

        // Create three products.
        var bolt = new Product
        {
            Sku = "BOLT-M8",
            Name = "M8 Hex Bolt"
        };

        var nut = new Product
        {
            Sku = "NUT-M8",
            Name = "M8 Hex Nut"
        };

        var washer = new Product
        {
            Sku = "WASH-M8",
            Name = "M8 Flat Washer"
        };

        db.Products.AddRange(
            bolt, nut, washer);

        // Save to generate primary-key IDs.
        await db.SaveChangesAsync();

        // Create inventory at each warehouse.
        db.InventoryItems.AddRange(
            new InventoryItem
            {
                BranchId = phoenix.Id,
                ProductId = bolt.Id,
                Quantity = 25,
                ReorderLevel = 50
            },
            new InventoryItem
            {
                BranchId = tucson.Id,
                ProductId = bolt.Id,
                Quantity = 300,
                ReorderLevel = 50
            },
            new InventoryItem
            {
                BranchId = mesa.Id,
                ProductId = bolt.Id,
                Quantity = 140,
                ReorderLevel = 40
            },
            new InventoryItem
            {
                BranchId = phoenix.Id,
                ProductId = nut.Id,
                Quantity = 80,
                ReorderLevel = 40
            },
            new InventoryItem
            {
                BranchId = tucson.Id,
                ProductId = nut.Id,
                Quantity = 90,
                ReorderLevel = 40
            },
            new InventoryItem
            {
                BranchId = mesa.Id,
                ProductId = nut.Id,
                Quantity = 20,
                ReorderLevel = 40
            },
            new InventoryItem
            {
                BranchId = phoenix.Id,
                ProductId = washer.Id,
                Quantity = 120,
                ReorderLevel = 40
            },
            new InventoryItem
            {
                BranchId = tucson.Id,
                ProductId = washer.Id,
                Quantity = 75,
                ReorderLevel = 40
            },
            new InventoryItem
            {
                BranchId = mesa.Id,
                ProductId = washer.Id,
                Quantity = 70,
                ReorderLevel = 40
            }
        );

        await db.SaveChangesAsync();
    }
}
