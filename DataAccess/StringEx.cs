using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public static class StringEx
    {
        public static ObjectId ToObjectId(this string id)
        {
            return new ObjectId(id);
        }
    }
}
