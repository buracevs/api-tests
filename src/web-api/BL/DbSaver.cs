using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Controllers;

namespace web_api.BL
{
    public interface IDbSaver
    {
        public int SaveOne(TestObjectToSave tst);
        public int SaveTwo();
    }
    public class DbSaver : IDbSaver
    {
        public int SaveOne(TestObjectToSave tst)
        {
            //return 0 saved 1 not saved
            return 1;
        }

        public int SaveTwo()
        {
            //return 0 saved 1 not saved
            return 1;
        }
    }
}
