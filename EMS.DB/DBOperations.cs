using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB
{
    public class DBOperations
    {
        public int AddUser(Users user)
        {
            using(EMSEntities dbContext=new EMSEntities())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return user.id;
            }
        }
    }
}
