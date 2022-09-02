using System;
using System.Collections.Generic;
using System.Text;
using CWK2.data;

namespace CWK2.business
{
    class Walk : Courier 
    {
        //create a variable that will not change the number set
        private static int pq = 5;

        //create a list of areas to store in the walk class
        List<string> walkArea = new List<string>();

        public string area2 { set; get; }

        //set the property walk to public
        public static int parcelQuantity
        {
            get { return pq; }
        }

        public void Area(string theArea)
        {
            walkArea.Add(theArea);
        }


        public void WalkDisplay()
        {
            Walk area = new Walk();
            area.area2 = "EH1";
            
            walkArea.Add(area2);

            foreach (string a in walkArea)
            {
                Console.WriteLine(a);
            }
        }
    }
}
