using Entities;
using Entities.DTOs;
using Entities.RepositoryInterfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{

    public class ProductsRepository : IProductsRepository
    {
        private readonly DatabaseContext _context;
        public ProductsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<ShowProducts>> GetAllProducts()
        {
            var AllProducts = (await _context.Products.Include(p => p.Specials).Include(p => p.Extras).ThenInclude(p => p.ExtraValues).Include(p => p.Picture).Include(p => p.Comments).ToListAsync()).ToList();

            var ProductsList = new List<ShowProducts>();

            foreach (var Product in AllProducts)
            {
                var ExtraList = new List<object>();
                var SpecialsList = new List<object>();
                var CommentsList = new List<object>();
                if (Product.Extras != null)
                {
                    foreach (var Extra in Product.Extras)
                    {
                        var ExtraValuesList = new List<ShowExtraValues>();
                        foreach (var ExtraValues in Extra.ExtraValues)
                        {
                            ExtraValuesList.Add(new ShowExtraValues() { Id = ExtraValues.Id, Value = ExtraValues.Value, PossibleExtraId = ExtraValues.PossibleExtraId });
                        }
                        ExtraList.Add(new ShowExtra() { Id = Extra.Id, Count = Extra.Count, Price = Extra.Price, ExtraValues = ExtraValuesList });
                    }
                }
                else
                {
                    ExtraList.Add(new ShowExtra() { Price = 0 });
                }

                if (Product.Specials != null)
                {
                    foreach (var Special in Product.Specials)
                    {
                        SpecialsList.Add(new ShowSpecial() { Id = Special.Id, Name = Special.Name, Price = Special.Price });
                    }
                }
                else
                {
                    SpecialsList.Add(new ShowSpecial() { Name = "", Price = 0 });
                }

                if (Product.Comments != null)
                {
                    foreach (var Comment in Product.Comments)
                    {
                        CommentsList.Add(new ShowComments() { Id = Comment.Id, Name = Comment.Name, CommentText = Comment.CommentText });
                    }
                }
                else
                {
                    CommentsList.Add(new ShowComments() { Name = "", CommentText = "" });
                }

                ProductsList.Add(new ShowProducts()
                {
                    Id = Product.Id,
                    Name = Product.Name,
                    Picture = new ShowPicture() { Id = Product.Picture.Id, ImagePath = Product.Picture.ImagePath },
                    Comments = CommentsList,
                    Extras = ExtraList,
                    Specials = SpecialsList
                });
            }

            return ProductsList;
        }

        public async Task<ShowProducts> GetAndShowProduct(int id)
        {
            var Product = await _context.Products.Include(p => p.Specials).Include(p => p.Extras).ThenInclude(p => p.ExtraValues).Include(p => p.Picture).Include(p => p.Comments).FirstOrDefaultAsync(m => m.Id == id);

            var ExtraList = new List<object>();
            var SpecialsList = new List<object>();
            var CommentsList = new List<object>();
            if (Product.Extras != null)
            {
                foreach (var Extra in Product.Extras)
                {
                    var ExtraValuesList = new List<ShowExtraValues>();
                    foreach (var ExtraValues in Extra.ExtraValues)
                    {
                        ExtraValuesList.Add(new ShowExtraValues() { Id = ExtraValues.Id, Value = ExtraValues.Value, PossibleExtraId = ExtraValues.PossibleExtraId });
                    }
                    ExtraList.Add(new ShowExtra() { Id = Extra.Id, Count = Extra.Count, Price = Extra.Price, ExtraValues = ExtraValuesList });
                }
            }
            else
            {
                ExtraList.Add(new ShowExtra() { Price = 0 });
            }

            if (Product.Specials != null)
            {
                foreach (var Special in Product.Specials)
                {
                    SpecialsList.Add(new ShowSpecial() { Id = Special.Id, Name = Special.Name, Price = Special.Price });
                }
            }
            else
            {
                SpecialsList.Add(new ShowSpecial() { Name = "", Price = 0 });
            }

            if (Product.Comments != null)
            {
                foreach (var Comment in Product.Comments)
                {
                    CommentsList.Add(new ShowComments() { Id = Comment.Id, Name = Comment.Name, CommentText = Comment.CommentText });
                }
            }
            else
            {
                CommentsList.Add(new ShowComments() { Name = "", CommentText = "" });
            }

            var Output = (new ShowProducts()
            {
                Id = Product.Id,
                Name = Product.Name,
                Picture = new ShowPicture() { Id = Product.Picture.Id, ImagePath = Product.Picture.ImagePath },
                Comments = CommentsList,
                Extras = ExtraList,
                Specials = SpecialsList
            });

            return (Output);
        }

        public async Task AddProduct(CreateProductDTO product)
        {
            double FinalSpecialprices = 0;
            var SpecialsList = new List<Special>();
            foreach (var Specials in product.Specials)
            {
                var ChoosenSpecial = await _context.Specials.FirstOrDefaultAsync(p => p.Id == Specials.SpecialItemId);
                FinalSpecialprices += ChoosenSpecial.Price;
                SpecialsList.Add(ChoosenSpecial);
            }


            var extraList = new List<Extra>();
            foreach (var Extras in product.Extra)
            {
                var thisExtraValues = new List<ExtraValues>();
                foreach (var thisExtraValue in Extras.ExtraValues)
                {
                    thisExtraValues.Add(new ExtraValues() { PossibleExtraId = thisExtraValue.PossibleExtrasId, Value = thisExtraValue.PossibleExtrasValue });
                }
                extraList.Add(new Extra() { Price = Extras.Price + FinalSpecialprices, Count = Extras.Count, ExtraValues = thisExtraValues });
            }


            var ProductPic = await _context.Pics.FirstOrDefaultAsync(p => p.Id == product.PictureId);

            await _context.Products.AddAsync(new Product
            {
                Name = product.Name,
                Extras = extraList,
                Picture = ProductPic,
                Specials = SpecialsList,
            });



            await _context.SaveChangesAsync();
        }

        public async Task EdiProduct(int Id, CreateProductDTO product, Product existingProduct)
        {
            double FinalSpecialprices = 0;

            var SpecialsList = new List<Special>();
            foreach (var Specials in product.Specials)
            {
                var ChoosenSpecial = await _context.Specials.FirstOrDefaultAsync(p => p.Id == Specials.SpecialItemId);
                if (ChoosenSpecial != null)
                {
                    FinalSpecialprices += ChoosenSpecial.Price;
                    SpecialsList.Add(ChoosenSpecial);
                }

            }

            var extraList = new List<Extra>();
            foreach (var Extras in product.Extra)
            {
                var thisExtraValues = new List<ExtraValues>();
                foreach (var thisExtraValue in Extras.ExtraValues)
                {
                    thisExtraValues.Add(new ExtraValues() { PossibleExtraId = thisExtraValue.PossibleExtrasId, Value = thisExtraValue.PossibleExtrasValue });
                }
                extraList.Add(new Extra() { Price = Extras.Price + FinalSpecialprices, Count = Extras.Count, ExtraValues = thisExtraValues });
            }


            var ProductPic = await _context.Pics.FirstOrDefaultAsync(p => p.Id == product.PictureId);


            existingProduct.Name = product.Name;
            existingProduct.Extras = extraList;
            existingProduct.Picture = ProductPic;
            existingProduct.Specials = SpecialsList;
            _context.Products.Update(existingProduct);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task AddExtras(int id, Product ExistingProduct, UpdateExtrasList updateExtrasList)
        {
            double FinalSpecialprices = 0;

            var SpecialsList = new List<Special>();
            foreach (var Specials in ExistingProduct.Specials)
            {
                var ChoosenSpecial = await _context.Specials.FirstOrDefaultAsync(p => p.Id == Specials.Id);
                FinalSpecialprices += ChoosenSpecial.Price;
                SpecialsList.Add(ChoosenSpecial);
            }


            var extraList = ExistingProduct.Extras;
            foreach (var Extras in updateExtrasList.Extra)
            {
                var thisExtraValues = new List<ExtraValues>();
                foreach (var thisExtraValue in Extras.ExtraValues)
                {
                    thisExtraValues.Add(new ExtraValues() { PossibleExtraId = thisExtraValue.PossibleExtrasId, Value = thisExtraValue.PossibleExtrasValue });
                }
                extraList.Add(new Extra() { Price = Extras.Price + FinalSpecialprices, Count = Extras.Count, ExtraValues = thisExtraValues });
            }


            var ProductPic = await _context.Pics.FirstOrDefaultAsync(p => p.Id == ExistingProduct.Picture.Id);

            _context.Products.Update(new Product
            {
                Name = ExistingProduct.Name,
                Extras = extraList,
                Picture = ProductPic,
                Specials = SpecialsList,
            });

            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var Product = await _context.Products.Include(p => p.Specials).Include(p => p.Extras).ThenInclude(p => p.ExtraValues).Include(p => p.Picture).FirstOrDefaultAsync(m => m.Id == id);
            return Product;
        }
    }
}
