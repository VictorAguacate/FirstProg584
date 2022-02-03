//============================================================================
// SimplePend.cs Defines a class for simulating a Simple Pendulum
//============================================================================
using System;
///
namespace Sim 
{
    public class SimplePend
    {
        private double len = 1.1; // pendulum length
        private double g = 9.81; // gravitational field strength
        int n = 2;               // number of states
        private double[] X;     //array of states
        private double[] f;    //right side of equation evaluation
        //====================================================================
        // Constructor
        //====================================================================
        public SimplePend()
        {
            //Console.WriteLine("Inside Constructor");
            X = new double[n];  //specifiing size of arrays
            f = new double[n];  

            X[0]= 1.0; //inital condition of theta (in radians)
            X[1]= 0.0;
        }

        //====================================================================
        //st perform one integration step via Euler
        //====================================================================
        public void step(double dt)
        {
            rhsFunc(X,f); 
            int i;
            for(i=0; i<n; i++)
            {
                X[i]= X[i] + f[i] * dt;
            }
           // Console.WriteLine($"{f[0].ToString()}  {f[1].ToString()}");
        }

        //====================================================================
        //rhsFunc: function to calculate rhs of  pendulum ODEs
        //====================================================================
        public void rhsFunc(double[] st, double[] ff)
        {
            ff[0] = st[1]; 
            ff[1] = -g/len * Math.Sin(st[0]);
        }


        //====================================================================
        // Getters and setters
        //====================================================================
        public double L
        {
            get {return(len);}

            set 
            {
                if(value> 0.0)
                    len = value;
            }

            
        }
        public double G 
        {
            get {return(g);}

            set 
            {
                if(value>= 0.0)
                    G = value;
            }

        }
        public double theta
        {
            get {return X[0];}

            set {X[0]= value;}
        }

        public double thetaDot
        {
            get {return X[1];}

            set {X[1]= value;}
        }
    }
    
}