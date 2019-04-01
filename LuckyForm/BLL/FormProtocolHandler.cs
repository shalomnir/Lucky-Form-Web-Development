using LuckyForm.DAL;
using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.BLL
{
    public class FormProtocolHandler
    {
        
        public static string CreateProtocolString(string[] numbers, int regInTables, int strongInTables)
        {
            string protocolStr = "";
            
            for (int i = 0; i < numbers.Length;)
            {
                for(int z = 0; z < regInTables; z++)
                {
                    protocolStr += numbers[i+z];
                    if(z < regInTables - 1)
                        protocolStr += ",";
                    else
                        protocolStr += "*";
                }              
                i += regInTables;
                for(int j = 0; j < strongInTables; j++)
                {
                    protocolStr += numbers[i+j];
                    if(j < strongInTables)
                        protocolStr += ",";
                    else
                        protocolStr += "#";
                }
                i += strongInTables;
                
            }
            return protocolStr;

        }
    }
}