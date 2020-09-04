namespace lyssamarket.Models
{
    public class Promotion
    {
        public int Id {get;set;}
        public string name{get;set;} 
        public Product Product{get;set;}
        public float Percentage{get;set;} 
        public bool Status{get;set;}
    }
}