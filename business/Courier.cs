using System;
using System.Collections.Generic;
using System.Text;
using CWK2.data;

namespace CWK2.business
{
    class Courier
    {
        /*Courier class will allocate 3 types of couriers*/

        //List of areas 
        private string nameCourier;

        //Constructor
        public Courier()
        {

        }

        //set the property cycle to public
        public string name
        {
            get { return nameCourier; }
            set { nameCourier = value; }
        }
    }
}