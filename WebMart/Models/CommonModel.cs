using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMart.Models
{
    public class CommonModel
    {
        public CardCompanyEn CardCompany { get; set; }
        public CardTypeEn CardType { get; set; }
    }
    public enum CardCompanyEn
    {
        Visa,
        Master
    }
    public enum CardTypeEn
    {
        Credit,
        Debit
    }
}