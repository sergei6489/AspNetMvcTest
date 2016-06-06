using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class EFRepository : IRepository
    {
        public EFDbContext context = new EFDbContext();
        public List<Product> GetPageProducts( int pageNumber, int itemCount, string category, out int totalItems )
        {
            totalItems = context.Products.Count();
            List<Product> products;
            if( String.IsNullOrEmpty( category ) )
            {
               products = context.Products.OrderBy(m=>m.Id).Skip( (pageNumber-1) * itemCount ).Take( itemCount ).ToList();
            }
            else
            {
                products = context.Products.Where( n => n.Category == category ).OrderBy( m => m.Id ).Skip( (pageNumber-1) * itemCount ).Take( itemCount ).ToList();
            }
            return products;
        }

        public Product GetProductById( int id )
        {
            return context.Products.FirstOrDefault( n => n.Id == id );
        }

        public Product AddProduct( Product product )
        {
            return context.Products.Add( product );
        }

        public void RemoveProduct( int id )
        {
            var product = context.Products.FirstOrDefault( n => n.Id == id );
            if( product == null )
            {
                throw new Exception( "Указанный товар отсутствует" );
            }
            else
            {
                context.Products.Remove( product );
            }
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByLogin( string userName )
        {
            return context.Users.FirstOrDefault( n => n.UserName == userName );
        }

        public void AddUser( User user )
        {
            context.Users.Add( user );
        }

        public void RemoveUser( string userName )
        {
            var user = context.Users.FirstOrDefault( n => n.UserName == userName );
            if (user!=null)
            {
               context.Users.Remove(user);
            }
            else
            {
                throw new Exception("Пользователь с указанным логином отсутствует");
            }
        }

        public User GetUserById( int id )
        {
           return context.Users.FirstOrDefault( n => n.Id == id );
        }

        public User RemoveUserById( int id )
        {
            var user = context.Users.FirstOrDefault( n => n.Id == id );
            return context.Users.Remove( user );
        }

        public void EditUser( User user )
        {
           var currentUser = context.Users.FirstOrDefault( n => n.Id == user.Id );
           if( currentUser != null )
           {
               currentUser.Name = user.Name;
               currentUser.UserName = user.UserName;
               currentUser.Password = user.Password;
           }
           else
           {
               throw new Exception( "Указанный пользователь отсутствует в системе" );
           }
        }

        public List<string> GetCategories()
        {
            return context.Products.Select( n => n.Category ).Distinct().ToList();
        }

        public void EditProduct( Product product )
        {
            var prod = context.Products.FirstOrDefault( n => n.Id == product.Id );
            if( prod != null )
            {
                if( product.Image != null )
                {
                    prod.Image = product.Image;
                }
                prod.Name = product.Name;
                prod.Price = product.Price;
                prod.Description = product.Description;
            }
            else
            {
                throw new Exception( String.Format( "Указанный продукт отсутствует id={0}",product.Id) );
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
