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
        public static string[] GetCombinations(string[] arr, int r)
        {
            
            int n = arr.Length;
            printCombination(arr, n, r);
        }
        //Print all possible strings of length k that can be formed from a set of n characters
        static string[] combinationUtil(string[] arr, string[] data, int start, int end, int index, int r)
        {
            
            if (index == r)
            {
                for (int j = 0; j < r; j++)
                    Console.Write(data[j] + " ");
                Console.WriteLine("");
                return;
            }

            
            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                return combinationUtil(arr, data, i + 1, end, index + 1, r);
            }
        }

        
        static string[] printCombination(string[] arr,int n, int r)
        {
            string[] data = new string[r];
            return combinationUtil(arr, data, 0, n - 1, 0, r);
        }
    }
}