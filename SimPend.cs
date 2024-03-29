//============================================================================
// SimplePend.cs Defines a class for simulating a Simple Pendulum
//============================================================================
using System;
////////
namespace Sim 
{
    public class SimplePend
    {
        private double len = 1.1; // pendulum length
        private double g = 9.81; // gravitational field strength
        int n = 2;               // number of states
        private double[] X;     //array of states
        private double[] f;    //right side of equation evaluation
        private double k1; //Ks for rk4 method
        private double k2;
        private double k3;
        private double k4;
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
            rhsFunc(X,f,dt); 
            int i;
            //Console.WriteLine($"{X[0].ToString()}");
            for(i=0; i<n; i++)
            {
                X[i]= X[i] + f[i] * dt;
            }
           // Console.WriteLine($"{f[0].ToString()}  {f[1].ToString()}");
        }

        //====================================================================
        //rhsFunc: function to calculate rhs of  pendulum ODEs
        //====================================================================
        public void rhsFunc(double[] st, double[] ff,double h)
        {
            double[] ts;
            ts= new double[n];
            ts[0]= st[1]; 
            ts[1]= st[0];
            int v= 0;
            int w= 1;
                k1= ts[v]; //k calculations
                double k11= (-g/len) * Math.Sin(ts[w]);
                k2= ts[v]+ (.5*k11*h);
                double k22= (-g/len) * Math.Sin(ts[w]+(.5*k1*h));
                k3= ts[v]+ (.5*k22*h);
                double k33= (-g/len) * Math.Sin(ts[w]+ (.5*k2*h));
                k4= ts[v]+ (k33*h);
                double k44 = (-g/len) * Math.Sin(ts[w]+ (k3*h));
                ff[v]=  (1.0/6.0)*(k1+(2*k2)+(2*k3)+k4);
                ff[w]=  (1.0/6.0)*(k11+(2*k22)+(2*k33)+k44);


            
            
            
            //ff[0] = st[1]; 
            //ff[1] = -g/len * Math.Sin(st[0]);
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