using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMADA_2012.App_Code.SMADA
{
    public class SewerPipe : CircularPipe 
    {
        private float myUpstreamInvertElevation;
        public float upstreamInvertElevation
        {
            get { return myUpstreamInvertElevation; }
            set { myUpstreamInvertElevation = value; }
        }

        private float myDownstreamInvertElevation;
        public float downstreamInvertElevation
        {
            get { return myDownstreamInvertElevation; }
            set { myDownstreamInvertElevation = value; }
        }

        private float myLength;
        public float length
        {
            get { return myLength; }
            set { myLength = value; }
        }


        



    }
}