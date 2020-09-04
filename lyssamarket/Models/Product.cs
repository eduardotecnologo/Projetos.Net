namespace lyssamarket.Models
{
    public class Product
    {
        public int Id {get;set;}
        public string name {get;set;} 
        public Category Category {get;set;} 
        public Provider Provider {get;set;}
        public float CostPrice {get;set;}
        public float SaleCost{get;set;}
        public int Measurement{get;set;}
        public bool Status{get;set;}
    }
}