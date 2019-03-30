using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class DataDB
    {
        DataTable dt;
        SqlHelper sqlHelper;

        public DataDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public DataDB(string path)
        {
            this.sqlHelper = new SqlHelper(path);
        }
       
    }
}