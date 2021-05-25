using PIA_Backend.Database;
using PIA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIA_Backend.Backend
{
    public class ProductService
    {

        NORTHWNDContext DataContext = new NORTHWNDContext();
        public List<ProductModel> GetAllProducts()
        {
            IQueryable<Product> productsQry = GetProductsFromDatabase();

            var products = productsQry.Select(elementFromDB => new ProductModel
            {
                ProductId = elementFromDB.ProductId,
                Discontinued = elementFromDB.Discontinued,
                ProductName = elementFromDB.ProductName,
                UnitPrice = elementFromDB.UnitPrice,
            }).ToList();

            return products;
        }

        private IQueryable<Product> GetProductsFromDatabase()
        {
            return DataContext.Products.AsQueryable();
        }

        public ProductModel GetProductByID(int productID)
        {
            Product product = GetProductFromDatabaseByID(productID);

            var result = new ProductModel();
            result.ProductId = product.ProductId;
            result.ProductName = product.ProductName;
            result.Discontinued = product.Discontinued;
            result.UnitPrice = product.UnitPrice;

            return result;
        }

        private Product GetProductFromDatabaseByID(int productID)
        {
            return GetProductsFromDatabase().Where(w => w.ProductId == productID).FirstOrDefault();
        }

        public void AddNewProduct(ProductModel newProduct)
        {
            var newProductInDatabase = new Product();

            newProductInDatabase.ProductName = newProduct.ProductName;
            newProductInDatabase.Discontinued = newProduct.Discontinued;
            newProductInDatabase.UnitPrice = newProduct.UnitPrice;

            // Este es el equivalente a hacer un INSERT INTO PRODUCTS
            DataContext.Products.Add(newProductInDatabase);
            DataContext.SaveChanges();

        }

        public void DeleteProduct(int id)
        {
            var productToDelete = GetProductFromDatabaseByID(id);
            //REMOVE es el equivalente a DELETE FROM DE SQL
            DataContext.Products.Remove(productToDelete);
            DataContext.SaveChanges();
        }

        public void UpdateProduct(int id, ProductModel modifiedProduct)
        {
            var productForUpdate = GetProductFromDatabaseByID(id);

            productForUpdate.ProductName = modifiedProduct.ProductName;
            productForUpdate.UnitPrice = modifiedProduct.UnitPrice;
            productForUpdate.Discontinued = modifiedProduct.Discontinued;

            DataContext.SaveChanges();

        }
    }
}
