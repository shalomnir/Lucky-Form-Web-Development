﻿using LuckyForm.Models;
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


        public List<Form> GetAllForms()
        {
            string sql = @"SELECT * FROM Forms ";
            
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                List<Form> allForms = new List<Form>();
                foreach (DataRow dr in this.dt.Rows)
                {
                    Form form = new Form();
                    form.ID = dr["FormsID"].ToString();
                    form.Name = dr["FormsName"].ToString();
                    form.NumOfTables = int.Parse(dr["FormsNumOfTables"].ToString());
                    form.NumsInTables = int.Parse(dr["FormsNumsInTable"].ToString());
                    allForms.Add(form);
                }
                return allForms;
            }
            return null;
        }

    }
}