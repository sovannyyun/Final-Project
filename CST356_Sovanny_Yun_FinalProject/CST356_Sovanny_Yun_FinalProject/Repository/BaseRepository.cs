using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CST356_Sovanny_Yun_FinalProject.Data;
using System.Web.Mvc;
using System.Net;

namespace CST356_Sovanny_Yun_FinalProject.Repository
{
    public abstract class BaseRepository
    {
        internal Data.Entities1 finalProjectDb;

        public BaseRepository(Entities1 cntext)
        {
            finalProjectDb = cntext;
        }


        internal HttpStatusCodeResult SaveChanges()
        {
            var isSaved = finalProjectDb.SaveChanges();

            return isSaved > 0
                ? new HttpStatusCodeResult(HttpStatusCode.OK)
                : new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}