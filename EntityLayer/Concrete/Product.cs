using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Order> Orders { get; set; }
    }
}

/*
 
int x,-->Field

public int MyProperty { get; set; } --> Property

int y= 5; --> Variable

*/