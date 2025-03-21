﻿using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerCity { get; set; }
        public List<Order> Orders { get; set; }
        public bool CustomerStatus { get; set; }
    }
}

/*
 
int x,-->Field

public int MyProperty { get; set; } --> Property

int y= 5; --> Variable

*/