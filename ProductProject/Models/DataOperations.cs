using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProject.Models
{
    public static class DataOperations
    {
        #region Product
        //adding
        public static void AddProduct(string name, double price)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                bool isExist = applicationContext.Products.Any(p => p.Name == name && p.Price == price);
                if(name != null && price != 0 && !isExist)
                {
                    Product product = new Product()
                    {
                        Name = name,
                        Price = price
                    };
                    applicationContext.Add(product);
                    applicationContext.SaveChanges();
                }
            }
        }

        //deleting
        public static void DeleteProduct(Product product)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                applicationContext.Products.Remove(product);
                applicationContext.SaveChanges();
            }
        }

        //editing
        public static void EditProduct(Product product, string name, double price)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                Product productForChanging = applicationContext.Products.FirstOrDefault(p => p.Id == product.Id);
                if(productForChanging != null)
                {
                    productForChanging.Name = name;
                    productForChanging.Price = price;
                    applicationContext.SaveChanges();
                }
            }
        }

        //all
        public static List<Product> AllProducts()
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                return applicationContext.Products.ToList();
            }
        }
        #endregion

        #region Link
        //adding
        public static void AddLink(Product upProduct, Product product, int count)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                if(upProduct != null && upProduct.Id != product.Id)
                {
                    bool isExist = applicationContext.Links.Any(l => l.UpProduct == upProduct.Id && l.ProductId == product.Id && l.Count == count);
                    if (product != null && count != 0 && !isExist && product.Id != upProduct.Id)
                    {
                        Link link = new Link()
                        {
                            UpProduct = upProduct.Id,
                            ProductId = product.Id,
                            Count = count
                        };
                        applicationContext.Add(link);
                        applicationContext.SaveChanges();
                    }
                }else if(upProduct.Id == product.Id)
                {
                    bool isExist = applicationContext.Links.Any(l => l.ProductId == product.Id && l.Count == count);
                    if (product != null && !isExist)
                    {
                        Link link = new Link()
                        {
                            UpProduct = 0,
                            ProductId = product.Id,
                            Count = 1
                        };
                        applicationContext.Add(link);
                        applicationContext.SaveChanges();
                    }
                }
                else if(upProduct == null)
                {
                    bool isExist = applicationContext.Links.Any(l => l.ProductId == product.Id && l.Count == count);
                    if (product != null && !isExist)
                    {
                        Link link = new Link()
                        {
                            UpProduct = 0,
                            ProductId = product.Id,
                            Count = 1
                        };
                        applicationContext.Add(link);
                        applicationContext.SaveChanges();
                    }
                }
            }
        }

        //deleting
        public static void DeleteLink(Link link)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                applicationContext.Links.Remove(link);
                applicationContext.SaveChanges();
            }
        }

        //editing
        public static void EditLink(Link link, Product upProduct, Product product, int count)
        {
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                Link linkForChanging = applicationContext.Links.FirstOrDefault(l => l.Id == link.Id);
                if(linkForChanging != null && upProduct.Id != product.Id)
                {
                    linkForChanging.UpProduct = upProduct.Id;
                    linkForChanging.ProductId = product.Id;
                    linkForChanging.Count = count;
                    applicationContext.SaveChanges();
                }else if (linkForChanging != null && upProduct.Id == product.Id)
                {
                    linkForChanging.UpProduct = 0;
                    linkForChanging.ProductId = product.Id;
                    linkForChanging.Count = 1;
                    applicationContext.SaveChanges();
                }else if(linkForChanging != null && upProduct == null)
                {
                    linkForChanging.UpProduct = 0;
                    linkForChanging.ProductId = product.Id;
                    linkForChanging.Count = 1;
                    applicationContext.SaveChanges();
                }
            }
        }

        //all
        public static List<Link> AllLinks()
        {
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                return applicationContext.Links.ToList();
            }
        }

        public static List<Product> RemoveProductFromList(Product product)
        {
            List<Product> products = new List<Product>();
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                products = applicationContext.Products.ToList();
                bool isExist = applicationContext.Products.Any(p => p.Id == product.Id);
                if (isExist)
                {
                    products.Remove(product);
                }
                return products;
            }
        }

        #endregion

        public static Product GetNameByID(int Id)
        {
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                var product = applicationContext.Products.FirstOrDefault(p => p.Id == Id);
                return product;
            }
        }
    }
}
