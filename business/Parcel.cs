using System;
using System.Collections.Generic;
using System.Text;
using CWK2.data;

namespace CWK2.business
{
    class Parcel
    {
        /*Parcel is responsible for allocating parcels to couriers for deliveries.*/


        //properties:
        private string area, delivery, addressee;
        private Dictionary<string, int> parcelList = new Dictionary<string, int>();
        //add parcel
        //add a pair (parcelList, uniqueID == to parcel object)
        //remove the parcel from ID
        //check the size of parcel list if it exists or not the max capacity


        //Constructor
        public Parcel()
        {

        }

        private void add(string parcels, int p)
        {
            parcelList.Add(parcels, p);
        }


        //set the property delivery to public
        public string Area
        {
            get { return area; }
            set { area = value; }
        }


        //set the property delivery to public
        public string deliveryID
        {
            get { return delivery; }
            set { delivery = value; }
        }


        //set the property addresse to public
        public string Addressee
        {
            get { return addressee; }
            set { addressee = value; }
        }
    }
}