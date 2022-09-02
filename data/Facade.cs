using System;
using System.Collections.Generic;
using System.Text;
using CWK2.business;

namespace CWK2.data
{
    class Facade
    {
        //Implement a Facade that hides 5 sub classes from the user of the Facade

        //References to the sub classes
        private Courier co;
        private Parcel pa;
        private Cycle cy;
        private Walk wa;
        private Van va;

        public Facade()
        {
            //create references to the sub classes
            co = new Courier();
            pa = new Parcel();
            cy = new Cycle();
            wa = new Walk();
            va = new Van();
        }

        /*
         * Method1 is a public method of the Facade. When it is called
         * it will call methods within the sub classes.
         */
        public void Method1()
        {
            cy.CycleDisplay();
            wa.WalkDisplay();
            va.VanDisplay();
        }
    }
}
