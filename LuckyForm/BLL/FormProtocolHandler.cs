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
        
        public static string CreateProtocolString(string[] numbers, int regInTables = 0, int strongInTables = 0)
        {
            string protocolStr = "";
            
            for (int i = 0; i < numbers.Length;)
            {
                for(int z = 0; z < regInTables; z++)
                {
                    protocolStr += numbers[i+z];
                    if(z < regInTables - 1)
                        protocolStr += ",";        
                }
                if(strongInTables != 0)
                    protocolStr += "*";

                i += regInTables;
                for(int j = 0; j < strongInTables; j++)
                {
                    protocolStr += numbers[i+j];
                    if(j < strongInTables)
                        protocolStr += ",";                   
                }
                protocolStr += "#";
                i += strongInTables;
                
            }
            return protocolStr;

        }
        public static string CreateChanceProtocolString(string[] numbers, int [] CountPerRow)
        {
            string protocolStr = "";
            int index = 0;
            foreach (int cards_count in CountPerRow)
            {
                if (cards_count == 0)
                {
                    protocolStr += "n";
                }
                    
                for(int i = 0;i<cards_count;i++)
                {
                    protocolStr += numbers[index];
                    protocolStr += ",";
                    index++;
                }
                protocolStr += "#";
                
            }
            return protocolStr;
        }
        public static string[] SplitTabels(string bets)
        {
            return bets.Split('#');
        }
    }
}