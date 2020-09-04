using System;

namespace lyssamarket.Models
{
    public class Sale
    {
        public int Id{get;set;}
        public DateTime Date{get;set;}
        public float Total{get;set;}
        public float ValuePaid{get;set;}
        public float Change{get;set;}

    }
}