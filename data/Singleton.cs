using System;
using System.Collections.Generic;
using System.Text;
using CWK2.business;
using System.IO;

namespace CWK2.data
{
    class Singleton
    {
        
        //Private property
        private static Singleton instance;

        //Constructor
        private Singleton() { }

        //set the property to public
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        //Method
        public void log(string sender, string msg)
        {
            //Append the sender and the message to the .csv file along with the current date and time
            System.IO.File.AppendAllText("C:\\C#\\log.csv", "Time, " + DateTime.Now  + ", Sender:, " + sender + ", Message:, " + msg +"\n");
            System.IO.File.AppendAllText("C:\\C#\\log.txt", "Time, " + DateTime.Now + ", Sender:, " + sender + ", Message:, " + msg + "\n");
        }

    }
}
