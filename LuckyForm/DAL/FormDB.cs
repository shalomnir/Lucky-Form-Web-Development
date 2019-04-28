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
            string sql = @"SELECT Forms.FormsID, Forms.FormsNumOfTables, Forms.FormsNumsInTable, Forms.FormsExplain, Forms.FormsName, Forms.TypeID, Forms.FormsPublished, Type.TypeImagePath
                        FROM Type INNER JOIN Forms ON Type.TypeID = Forms.TypeID
                        WHERE (((Forms.TypeID)='" + Type + "'))";           
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
                         dr["TypeImagePath"].ToString(),
                         (bool)dr["FormsPublished"],
                         dr["FormsExplain"].ToString()
                         );
                    
                    allForms.Add(form);
                }
                return allForms;
            }
            return null;
        }
        public Form GetFormById(string id)
        {
            string sql = @"SELECT Forms.FormsID, Forms.FormsNumOfTables, Forms.FormsNumsInTable, Forms.FormsExplain, Forms.FormsName, Forms.TypeID, Forms.FormsPublished, Type.TypeImagePath
                            FROM Type INNER JOIN Forms ON Type.TypeID = Forms.TypeID
                            WHERE (((Forms.FormsID)=" + id + "));";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                Form form = new Form(
                    dt.Rows[0]["FormsID"].ToString(),
                    int.Parse(dt.Rows[0]["FormsNumOfTables"].ToString()),
                    int.Parse(dt.Rows[0]["FormsNumsInTable"].ToString()),
                    dt.Rows[0]["FormsName"].ToString(),
                    dt.Rows[0]["TypeID"].ToString(),
                    dt.Rows[0]["TypeImagePath"].ToString(),                     
                    (bool)dt.Rows[0]["FormsPublished"],
                    dt.Rows[0]["FormsExplain"].ToString()
                    );
                return form;
            }
            return null;
        }
        public void ShowFormByID(string id,bool toShow)
        {
            string sql = @"UPDATE Forms SET FormsPublished = " + toShow + " WHERE FormsID=" + id;
            this.sqlHelper.UpdateData(sql); 
        }
    }
}