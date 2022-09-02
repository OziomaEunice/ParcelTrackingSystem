using System;
using System.Collections.Generic;
using System.Text;
using CWK2.data;


namespace CWK2.business
{
    class Cycle : Courier
    {
        //create a variable that will not change the number set
        private static int pq = 10;

        //create a list of areas to store in the cycle class
        List<string> cycleArea = new List<string>();

        public string area1 { set; get; }
       
        //set the property cycle to public
        public static int parcelQuantity
        {
            get { return pq; }
        }

        public void Area(string theArea)
        {
            cycleArea.Add(theArea);
        }

        public void CycleDisplay()
        {
            Cycle area = new Cycle();
            area.area1 = "EH5";
            
            cycleArea.Add(area1);

            foreach(string a in cycleArea)
            {
                Console.WriteLine(a);
            }
        }
    }
}
