﻿using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class PlayCardDB
    {
        DataTable dt;
        SqlHelper sqlHelper;
        public PlayCardDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public PlayCardDB(string path)
        {
            this.sqlHelper = new SqlHelper(path);
        }
        public Dictionary<string, List<PlayCard>> GetAllPlayCards()
        {
            Dictionary<string, List<PlayCard>> playCards = new Dictionary<string, List<PlayCard>>();
            playCards.Add("clubs", GetPlayCardsByType("clubs"));
            playCards.Add("hearts", GetPlayCardsByType("hearts"));
            playCards.Add("diamonds", GetPlayCardsByType("diamonds"));
            playCards.Add("spades", GetPlayCardsByType("spades"));
            return playCards;
        }
        public List<PlayCard> GetPlayCardsByType(string Type)
        {
            string sql = @"SELECT * FROM PlayCards WHERE PlayCardsType='" + Type + "'";
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                List<PlayCard> allPlayCards = new List<PlayCard>();
                foreach (DataRow dr in this.dt.Rows)
                {
                    PlayCard playCard = new PlayCard();
                    playCard.ID = dr["PlayCardsID"].ToString();
                    playCard.Number = dr["PlayCardsNumber"].ToString();
                    playCard.Type = dr["PlayCardsType"].ToString();                   
                    playCard.Img = dr["PlayCardsImg"].ToString();

                    allPlayCards.Add(playCard);
                }
                return allPlayCards;
            }
            return null;
        }
    }
}