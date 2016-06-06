using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IRepository
    {
        #region Product
        List<Product> GetPageProducts( int pageNumber, int itemCount, string category, out int totalItems );
        List<string> GetCategories();
        Product GetProductById( int id );
        Product AddProduct( Product product );
        void EditProduct( Product product );
        void RemoveProduct( int id );
        #endregion
        #region User
        List<User> GetUsers();
        User GetUserByLogin( string login );
        User GetUserById( int id );
        void AddUser( User user );
        void RemoveUser( string login );
        User RemoveUserById( int id );
        void EditUser( User user );
        #endregion

        void Save();
    }
}
