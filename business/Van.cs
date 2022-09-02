using System;
using System.Collections.Generic;
using System.Text;
using CWK2.data;

namespace CWK2.business
{
    class Van : Courier
    {
        //create a variable that will not change the number set
        private static int pq = 100;

        //create a list of areas to store in the van class
        List<string> vanArea = new List<string>();

        public string area3 { set; get; }

        //set the property van to public
        public static int parcelQuantity
        {
            get { return pq; }
        }

        public void Area(string theArea)
        {
            vanArea.Add(theArea);
        }


        public void VanDisplay()
        {
            Van area = new Van();
            area.area3 = "EH1";
            area.area3 = "EH2";
            area.area3 = "EH3";
            area.area3 = "EH4";
            area.area3 = "EH5";
            area.area3 = "EH6";
            area.area3 = "EH7";
            area.area3 = "EH8";
            area.area3 = "EH9";
            area.area3 = "EH10";
            area.area3 = "EH11";
            area.area3 = "EH12";
            area.area3 = "EH13";
            area.area3 = "EH14";
            area.area3 = "EH15";
            area.area3 = "EH16";
            area.area3 = "EH17";
            area.area3 = "EH18";
            area.area3 = "EH19";
            area.area3 = "EH20";
            area.area3 = "EH21";
            area.area3 = "EH22";

            vanArea.Add(area3);

            foreach (string a in vanArea)
            {
                Console.WriteLine(a);
            }
        }
    }
}
