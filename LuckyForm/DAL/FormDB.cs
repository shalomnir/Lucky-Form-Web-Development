using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class FormDB
    {
        DataTable dt;
        SqlHelper sqlHelper;

        public FormDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public FormDB(string path)
        {
            this.sqlHelper = new SqlHelper(path);
        }


        public List<Form> GetAllForms(string Type)
        {
            string sql = @"SELECT Forms.FormsID, Forms.FormsNumsInTable, Forms.FormsNumOfTables, Forms.FormsName, Forms.TypeID, Type.TypeImagePath
            FROM Type INNER JOIN Forms ON Type.TypeID = Forms.TypeID
            WHERE (((Forms.TypeID)='" + Type + "'));";           
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                List<Form> allForms = new List<Form>();
                foreach (DataRow dr in this.dt.Rows)
                {
                    Form form = new Form(
                         dr["FormsID"].ToString(),
                         int.Parse(dr["FormsNumOfTables"].ToString()),
                         int.Parse(dr["FormsNumsInTable"].ToString()),
                         dr["FormsName"].ToString(),
                         dr["TypeID"].ToString(),
                         dr["TypeImagePath"].ToString()
                         );
                    
                    allForms.Add(form);
                }
                return allForms;
            }
            return null;
        }
        public Form GetFormById(string id)
        {
            string sql = @"SELECT * FROM Forms WHERE FormsID='" + id + "'";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                Form form = new Form(
                    dt.Rows[0]["FormsID"].ToString(),
                    (int)dt.Rows[0]["FormsNumOfTables"],
                    (int)dt.Rows[0]["FormsNumsInTable"],
                    dt.Rows[0]["FormsName"].ToString(),
                    dt.Rows[0]["TypeID"].ToString(),
                    dt.Rows[0]["TypeImagePath"].ToString()
                    );
                return form;
            }
            return null;
        }

    }
}