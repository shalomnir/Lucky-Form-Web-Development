﻿using LuckyForm.DAL;
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
        public static int NumOfBets(string bets)
        {
            return (bets.Split('#')[0].Split(',')).Length;
        }
        public static int NumOfStrongBets(string bets)
        {
            return (bets.Split('#')[0].Split('*')[1].Split(',')).Length;
        }
        public static List<string> GetCombinations(string[] arr, int r)
        {
            
            int n = arr.Length;
            List<string> results = new List<string>();
            generateCombination(Array.ConvertAll(arr, int.Parse), n, r, results);

            return results;
        }
        // Return true if arr2[] is  
        // a subset of arr1[] */ 
        public static bool isSubset(string[] arr1, string[] arr2, int m, int n)
        {
            foreach(string s in arr2)
            {
                if (!arr1.Contains<string>(s))
                    return false;
            }
            return true;
        }
        public static bool cmpArr(string[] arr1, string[] arr2, int len)
        {
            for(int i =0;i<len;i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;                    
        }
        public static bool areEqual(string[] arr1, string[] arr2)
        {
            int n = arr1.Length;
            int m = arr2.Length;

            // If lengths of array are not 
            // equal means array are not equal 
            if (n != m)
                return false;

            // Sort both arrays 
            Array.Sort(arr1);
            Array.Sort(arr2);

            // Linearly compare elements 
            for (int i = 0; i < n; i++)
                if (arr1[i] != arr2[i])
                    return false;
            // If all elements were same. 
            return true;
        }
        public static List<string[]> ListArrFromListString(List<table> tables)
        {
            List<string[]> tbls = new List<string[]>();
            foreach (table t in tables)
            {
                int len = t.regularNums.Count + t.strongNums.Count;
                string[] arr = new string[len];
                for(int i=0;i<len;i++)
                {
                    //TODO
                }
            }
            return tbls;
        }
        public static List<table> ProtocolToClass(string bets, string type)
        {
            List<table> betsTables = new List<table>();
            foreach (string table in FormProtocolHandler.SplitTabels(bets))
            {
                if (table.Length > 0)
                {
                    string strong = "";
                    string reg = table.Split('*')[0];
                    if (type == "1")
                        strong = table.Split('*')[1];
                    table t = new table();
                    foreach (string num in reg.Split(','))
                    {
                        t.regularNums.Add(num);
                    }
                    foreach (string num in strong.Split(','))
                    {
                        t.strongNums.Add(num);
                    }
                    betsTables.Add(t);
                }
            }
            return betsTables;
        }
        public static Double nCk(long n, long k)
        {
            double sum = 0;
            for (long i = 0; i < k; i++)
            {
                sum += Math.Log(n - i, 10);
                sum -= Math.Log(i + 1, 10);
            }
            return Math.Pow(10, sum);
        }
        //return all possible strings of length k that can be formed from a set of n characters
        /* arr[] ---> Input Array 
    data[] ---> Temporary array to 
                store current combination 
    start & end ---> Staring and Ending  
                     indexes in arr[] 
    index ---> Current index in data[] 
    r ---> Size of a combination 
            to be printed */
        static void combinationUtil(int[] arr, int[] data,
                                    int start, int end,
                                    int index, int r, List<string> results)
        {
            // Current combination is  
            // ready to be printed,  
            // print it 
            if (index == r)
            {
                string comb = "";
                for (int j = 0; j < r; j++)
                    comb += data[j] + ",";
                results.Add(comb);
                return;
            }

            // replace index with all 
            // possible elements. The  
            // condition "end-i+1 >=  
            // r-index" makes sure that  
            // including one element 
            // at index will make a  
            // combination with remaining  
            // elements at remaining positions 
            for (int i = start; i <= end &&
                      end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, i + 1,
                                end, index + 1, r, results);
            }
        }

        // The main function that prints 
        // all combinations of size r 
        // in arr[] of size n. This  
        // function mainly uses combinationUtil() 
        static void generateCombination(int[] arr,
                                     int n, int r, List<string> results)
        {
            // A temporary array to store  
            // all combination one by one 
            int[] data = new int[r];

            // Print all combination  
            // using temprary array 'data[]' 
            combinationUtil(arr, data, 0,
                            n - 1, 0, r, results);
        }
    }
}