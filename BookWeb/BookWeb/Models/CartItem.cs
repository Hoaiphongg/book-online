using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWeb.Models
{
    [Serializable]
    public class CartItem
    {
        public Book book { get; set; }
        public int quantity { get; set; }
    }
}