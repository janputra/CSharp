using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOM_NN1_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int[] A1 = {0, 0, 1, 1, 0, 0, 0, 
                            0, 0, 0, 1, 0, 0, 0,
                            0, 0, 0, 1, 0, 0, 0,
                            0, 0, 1, 0, 1, 0, 0,
                            0, 0, 1, 0, 1, 0, 0,
                            0, 1, 1, 1, 1, 1, 0,
                            0, 1, 0, 0, 0, 1, 0,
                            0, 1, 0, 0, 0, 1, 0,
                            1, 1, 1, 0, 1, 1, 1};

        private int[] B1 = {1, 1, 1, 1, 1, 1, 0, 
                            0, 1, 0, 0, 0, 0, 1,
                            0, 1, 0, 0, 0, 0, 1,
                            0, 1, 0, 0, 0, 0, 1,
                            0, 1, 1, 1, 1, 1, 0,
                            0, 1, 0, 0, 0, 0, 1,
                            0, 1, 0, 0, 0, 0, 1,
                            0, 1, 0, 0, 0, 0, 1,
                            1, 1, 1, 1, 1, 1, 0};

        private int[] C1 = {0, 0, 1, 1, 1, 1, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 0, 1, 1, 1, 1, 0};

        private int[] D1 = {1, 1, 1, 1, 1, 0, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 1, 0, 
                            1, 1, 1, 1, 1, 0, 0};

        private int[] E1 = {1, 1, 1, 1, 1, 1, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 0, 0, 
                            0, 1, 0, 1, 0, 0, 0, 
                            0, 1, 1, 1, 0, 0, 0, 
                            0, 1, 0, 1, 0, 0, 0, 
                            0, 1, 0, 0, 0, 0, 0, 
                            0, 1, 0, 0, 0, 0, 1, 
                            1, 1, 1, 1, 1, 1, 1};

        private int[] J1 = {0, 0, 0, 1, 1, 1, 1,
                            0, 0, 0, 0, 0, 1, 0,
                            0, 0, 0, 0, 0, 1, 0,
                            0, 0, 0, 0, 0, 1, 0,
                            0, 0, 0, 0, 0, 1, 0,
                            0, 0, 0, 0, 0, 1, 0,
                            0, 1, 0, 0, 0, 1, 0,
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 0, 1, 1, 1, 0, 0};

        private int[] K1 = {1, 1, 1, 0, 0, 1, 1, 
                            0, 1, 0, 0, 1, 0, 0, 
                            0, 1, 0, 1, 0, 0, 0, 
                            0, 1, 1, 0, 0, 0, 0, 
                            0, 1, 1, 0, 0, 0, 0, 
                            0, 1, 0, 1, 0, 0, 0, 
                            0, 1, 0, 0, 1, 0, 0,
                            0, 1, 0, 0, 0, 1, 0, 
                            1, 1, 1, 0, 0, 1, 1};


        private int[] A2 = {0, 0, 0, 1, 0, 0, 0, 
                            0, 0, 0, 1, 0, 0, 0, 
                            0, 0, 0, 1, 0, 0, 0, 
                            0, 0, 1, 0, 1, 0, 0, 
                            0, 0, 1, 0, 1, 0, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 1, 1, 1, 1, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 0, 1, 0};

        private int[] B2 = {1, 1, 1, 1, 1, 1, 0, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 1, 1, 1, 1, 1, 0, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 1, 1, 1, 1, 1, 0};

        private int[] C2 = {0, 0, 1, 1, 1, 0, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 0, 1, 1, 1, 0, 0};

        private int[] D2 = {1, 1, 1, 1, 1, 0, 0, 
                            1, 0, 0, 0, 0, 1, 0, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 1, 0, 
                            1, 1, 1, 1, 1, 0, 0};

        private int[] E2 = {1, 1, 1, 1, 1, 1, 1, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 1, 1, 1, 1, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 1, 1, 1, 1, 1, 1};

        private int[] J2 = {0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 0, 1, 1, 1, 0, 0};

        private int[] K2 = {1, 0, 0, 0, 0, 1, 0, 
                            1, 0, 0, 0, 1, 0, 0, 
                            1, 0, 0, 1, 0, 0, 0, 
                            1, 0, 1, 0, 0, 0, 0, 
                            1, 1, 0, 0, 0, 0, 0, 
                            1, 0, 1, 0, 0, 0, 0, 
                            1, 0, 0, 1, 0, 0, 0, 
                            1, 0, 0, 0, 1, 0, 0, 
                            1, 0, 0, 0, 0, 1, 0};

        private int[] A3 = {0, 0, 0, 1, 0, 0, 0, 
                            0, 0, 0, 1, 0, 0, 0, 
                            0, 0, 1, 0, 1, 0, 0, 
                            0, 0, 1, 0, 1, 0, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 1, 1, 1, 1, 0, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 1, 0, 0, 0, 1, 1};

        private int[] B3 = {1, 1, 1, 1, 1, 1, 0, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 1, 1, 1, 1, 0, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            1, 1, 1, 1, 1, 1, 0};

        private int[] C3 = {0, 0, 1, 1, 1, 0, 1, 
                            0, 1, 0, 0, 0, 1, 1, 
                            1, 0, 0, 0, 0, 0, 1, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 0, 
                            1, 0, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 0, 1, 1, 1, 0, 0};

        private int[] D3 = {1, 1, 1, 1, 0, 0, 0, 
                            0, 1, 0, 0, 1, 0, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 1, 0, 0, 
                            1, 1, 1, 1, 0, 0, 0};

        private int[] E3 = {1, 1, 1, 1, 1, 1, 1, 
                            0, 1, 0, 0, 0, 0, 1, 
                            0, 1, 0, 0, 1, 0, 0, 
                            0, 1, 1, 1, 1, 0, 0, 
                            0, 1, 0, 0, 1, 0, 0, 
                            0, 1, 0, 0, 0, 0, 0, 
                            0, 1, 0, 0, 0, 0, 0, 
                            0, 1, 0, 0, 0, 0, 1, 
                            1, 1, 1, 1, 1, 1, 1};

        private int[] J3 = {0, 0, 0, 0, 1, 1, 1, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 0, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 0, 1, 1, 1, 0, 0};

        private int[] K3 = {1, 1, 1, 0, 0, 1, 1, 
                            0, 1, 0, 0, 0, 1, 0, 
                            0, 1, 0, 0, 1, 0, 0, 
                            0, 1, 0, 1, 0, 0, 0, 
                            0, 1, 1, 0, 0, 0, 0, 
                            0, 1, 0, 1, 0, 0, 0, 
                            0, 1, 0, 0, 1, 0, 0, 
                            0, 1, 0, 0, 0, 1, 0, 
                            1, 1, 1, 0, 0, 1, 1};

        private const int MAX_CLUSTERS = 25;
        private const int VEC_LEN = 63;
        private const int VEC_XLEN = 5;
        private const int VEC_YLEN = 5;
        private const double DECAY_RATE = 0.96;//About 100 iteration
        private const double MIN_ALPHA = 0.01;
        private const double RADIUS_REDUCTION_POINT = 0.023; //Last 20% of iteration
        private double Alpha = 0.6;
       
        private double[] D = new double[MAX_CLUSTERS]; //networks nodes

        //weight matrix with randomly chosen values between 0.0 and 1.0
        private double[,] w = new double[MAX_CLUSTERS, VEC_LEN]; // 25 x 63

        private const int IN_PATERN = 21;
        private int[][] Pattern = new int[IN_PATERN][];
        string[] names = { "A1", "B1", "C1", "D1", "E1", "J1", "K1", "A2", "B2", "C2", "D2", "E2", "J2", "K2", "A3", "B3", "C3", "D3", "E3", "J3", "K3" };

        ListBox[] Cluster = new ListBox[25];

        string con_sign(int sign)
        {
            string print;
            if (sign == 1)
            {
                print = "[]";
            }
            else
            {
                print = " ";
            }
            return print;
        }

        int Minimum(double[] NodeArray)
        {
            int i, Winner;
            bool FoundNewWinner;
            bool Done = false;

            Winner = 0;
            do
            {
                FoundNewWinner = false;
                for (i = 0; i < MAX_CLUSTERS; i++)
                {
                    if (i != Winner) //Avoid self-comparison 
                    {
                        if (NodeArray[i] < NodeArray[Winner])
                        {
                            Winner = i;
                            FoundNewWinner = true;

                        }
                    }

                }
                if (FoundNewWinner == false)
                {
                    Done = true;
                }

            }
            while (Done==false);
            return Winner;
        }

        void ClearArray(double[] NodeArray)
        { 
            int i;
            for (i = 0; i < MAX_CLUSTERS; i++) 
            {
                D[i] = 0.0;
            }
        
        }

        void ComputeInput(int[] VectorArray) 
        {
            int i, j;
            ClearArray(D);
            for (i = 0; i < MAX_CLUSTERS; i++) 
            {
                for (j = 0; j < VEC_LEN; j++) 
                {
                   
                    D[i] += (w[i, j] - VectorArray[j]) * (w[i, j] - VectorArray[j]);
                
                }
            }
        }

        void Initialize() 
        {
            int i, j;
            Random rnd = new Random();
               
            //insert pattern arrays into Pattern() to make an array of arrays
            Pattern[0] = A1;
            Pattern[1] = B1;
            Pattern[2] = C1;
            Pattern[3] = D1;
            Pattern[4] = E1;
            Pattern[5] = J1;
            Pattern[6] = K1;
            Pattern[7] = A2;
            Pattern[8] = B2;
            Pattern[9] = C2;
            Pattern[10] = D2;
            Pattern[11] = E2;
            Pattern[12] = J2;
            Pattern[13] = K2;
            Pattern[14] = A3;
            Pattern[15] = B3;
            Pattern[16] = C3;
            Pattern[17] = D3;
            Pattern[18] = E3;
            Pattern[19] = J3;
            Pattern[20] = K3;

            //Initialize weights to random values between 0.0 and 1.0
            for (i = 0; i < MAX_CLUSTERS; i++)
            {
                for (j = 0; j < VEC_LEN; j++)
                {
                   w[i, j] = rnd.NextDouble();
                }
            }

        }

        void UpdateWeights(int[]wArray,int Dmin) 
        {
            int i, y, DIndex, PointA=0, PointB=0;
            bool Done = false;
            for (i = 0; i < VEC_LEN; i++) 
            {
                //only include neighbors before radius reduction point is reached 
                if (Alpha > RADIUS_REDUCTION_POINT) 
                {
                    y = 1;
                    do
                    {
                        if (y == 1) 
                        {                                       //top row of 3
                            if (Dmin > VEC_XLEN - 1)
                            {
                                PointA = Dmin - VEC_XLEN - 1;
                                PointB = Dmin - VEC_XLEN + 1;
                            }
                            else 
                            {
                                y = 2;
                            }
                        }
                        else if (y == 2)                            //middle row of 3
                        {
                            PointA = Dmin - 1;
                            //Dmin is like an anchor position right between these two
                            PointB = Dmin + 1;
                        
                        }
                        else if (y == 3)                          //bottom row of 3
                        {
                            if (Dmin < (VEC_XLEN * (VEC_YLEN - 1)))
                            {
                                PointA = Dmin + VEC_XLEN - 1;
                                PointB = Dmin + VEC_XLEN + 1;
                            }
                            else { Done = true; }
                        }

                      
                        if (Done == false) 
                        {
                            for (DIndex = PointA; DIndex <= PointB;DIndex++ )
                            {
                                //check if anchor is at left side
                                if (Dmin % VEC_XLEN == 0)
                                {
                                 
                                    //check if anchor is at top
                                    if (DIndex > PointA) 
                                    {
                                    w[DIndex,i] = w[DIndex,i]+(Alpha*(wArray[i]-w[DIndex,i]));
                                    }
                                  

                                
                                }
                                //check if anchor is at right side
                                else if ((Dmin + 1) % VEC_XLEN == 0)
                                {  
                                 
                                    //check if anchor is at top
                                    if (DIndex < PointB)
                                    {
                                        w[DIndex, i] = w[DIndex, i] + (Alpha *(wArray[i] - w[DIndex, i]));
                                    }
                                   
                                }
                                //otherwise, anchor is at neither side
                                else
                                {
                                    
                                    w[DIndex, i] = w[DIndex, i] + (Alpha * (wArray[i] - w[DIndex, i]));
                                    
                                }
                            }
                        
                        }
                        if (y == 3) 
                        {
                            Done = true;
                        }
                        y++;
                    }
                    while(Done==false);
                    
                }
                else if (Alpha < RADIUS_REDUCTION_POINT)
                {
                    //update only the winner
                    w[Dmin, i] = w[Dmin, i] + (Alpha * (wArray[i] - w[Dmin, i]));
                }
            }
        
        }

        void Training()
        {
            int Iterations = 0;
            bool ReductionFlag = false;
            int Reductionpoint = 0;
            int VecNum, Dmin;
            do
            {
            Iterations++;
            for (VecNum = 0; VecNum < IN_PATERN; VecNum++) 
                {   
                   //Compute inputs for all nodes 
                    ComputeInput(Pattern[VecNum]);
                    
                   //see which one is smaller
                    Dmin = Minimum(D);

                 
        //update the weights on the winning unit
                    UpdateWeights(Pattern[VecNum], Dmin);
                }
                //Reduce the learning rate
                 Alpha = DECAY_RATE * Alpha;

                //Reduce radius at specified point
                 if (Alpha < RADIUS_REDUCTION_POINT) 
                 {
                     if (ReductionFlag == false) 
                     {
                         ReductionFlag = true;
                         Reductionpoint = Iterations;
                     }
                 }
            }
            while (Alpha>MIN_ALPHA);
            listBox1.Items.Add("Iterations: " +Iterations.ToString()+'\n');
            listBox1.Items.Add("Neighborhood radius reduced after " + Reductionpoint.ToString()+" iterations."+'\n');
        }
        void PrintResults() 
        {
            int i,j=0, VecNum, Dmin;
            int[] temp=new int[25];
            //print clusters created
            listBox1.Items.Add("Clusters for training input:" + '\n');
            for (VecNum = 0; VecNum < IN_PATERN; VecNum++)
            {
                //compute input
                ComputeInput(Pattern[VecNum]);
                //see which is smaller
                Dmin = Minimum(D);
                temp[VecNum] = Dmin;
                listBox1.Items.Add('\n' + "Vector (Pattern " + VecNum.ToString()+","+names[VecNum]+" ) fits into category "+Dmin.ToString()+'\n');
                Cluster[Dmin].Items.Add(names[VecNum] + '\n');
            }
            listBox2.Items.Add("---------------------------  A1 = " + temp[0].ToString());
            listBox3.Items.Add("---------------------------  A2 = " + temp[7].ToString());
            listBox4.Items.Add("---------------------------  A3 = " + temp[14].ToString());
            for (i = 0; i <= 8; i++) 
            {
                listBox2.Items.Add(con_sign(A1[j]) + " " + con_sign(A1[j + 1]) + " " + con_sign(A1[j + 2]) + " " + con_sign(A1[j + 3]) + " " + con_sign(A1[j + 4]) + " " + con_sign(A1[j + 5]) + " " + con_sign(A1[j + 6]));
                listBox3.Items.Add(con_sign(A2[j]) + " " + con_sign(A2[j + 1]) + " " + con_sign(A2[j + 2]) + " " + con_sign(A2[j + 3]) + " " + con_sign(A2[j + 4]) + " " + con_sign(A2[j + 5]) + " " + con_sign(A2[j + 6]));
                listBox4.Items.Add(con_sign(A3[j]) + " " + con_sign(A3[j + 1]) + " " + con_sign(A3[j + 2]) + " " + con_sign(A3[j + 3]) + " " + con_sign(A3[j + 4]) + " " + con_sign(A3[j + 5]) + " " + con_sign(A3[j + 6]));
                j = j + 7;
            }
            j = 0;
            listBox2.Items.Add("---------------------------  B1 = " + temp[1].ToString());
            listBox3.Items.Add("---------------------------  B2 = " + temp[8].ToString());
            listBox4.Items.Add("---------------------------  B3 = " + temp[15].ToString());
            for (i = 0; i <= 8; i++)
            {
                listBox2.Items.Add(con_sign(B1[j]) + " " + con_sign(B1[j + 1]) + " " + con_sign(B1[j + 2]) + " " + con_sign(B1[j + 3]) + " " + con_sign(B1[j + 4]) + " " + con_sign(B1[j + 5]) + " " + con_sign(B1[j + 6]));
                listBox3.Items.Add(con_sign(B2[j]) + " " + con_sign(B2[j + 1]) + " " + con_sign(B2[j + 2]) + " " + con_sign(B2[j + 3]) + " " + con_sign(B2[j + 4]) + " " + con_sign(B2[j + 5]) + " " + con_sign(B2[j + 6]));
                listBox4.Items.Add(con_sign(B3[j]) + " " + con_sign(B3[j + 1]) + " " + con_sign(B3[j + 2]) + " " + con_sign(B3[j + 3]) + " " + con_sign(B3[j + 4]) + " " + con_sign(B3[j + 5]) + " " + con_sign(B3[j + 6]));
                j = j + 7;
            }
            j = 0;
            listBox2.Items.Add("---------------------------  C1 = " + temp[2].ToString());
            listBox3.Items.Add("---------------------------  C2 = " + temp[9].ToString());
            listBox4.Items.Add("---------------------------  C3 = " + temp[16].ToString());
            for (i = 0; i <= 8; i++)
            {
                listBox2.Items.Add(con_sign(C1[j]) + " " + con_sign(C1[j + 1]) + " " + con_sign(C1[j + 2]) + " " + con_sign(C1[j + 3]) + " " + con_sign(C1[j + 4]) + " " + con_sign(C1[j + 5]) + " " + con_sign(C1[j + 6]));
                listBox3.Items.Add(con_sign(C2[j]) + " " + con_sign(C2[j + 1]) + " " + con_sign(C2[j + 2]) + " " + con_sign(C2[j + 3]) + " " + con_sign(C2[j + 4]) + " " + con_sign(C2[j + 5]) + " " + con_sign(C2[j + 6]));
                listBox4.Items.Add(con_sign(C3[j]) + " " + con_sign(C3[j + 1]) + " " + con_sign(C3[j + 2]) + " " + con_sign(C3[j + 3]) + " " + con_sign(C3[j + 4]) + " " + con_sign(C3[j + 5]) + " " + con_sign(C3[j + 6]));
                j = j + 7;
            }
            j = 0;
            listBox2.Items.Add("---------------------------  D1 = " + temp[3].ToString());
            listBox3.Items.Add("---------------------------  D2 = " + temp[10].ToString());
            listBox4.Items.Add("---------------------------  D3 = " + temp[17].ToString());
            for (i =
                0; i <= 8; i++)
            {
                listBox2.Items.Add(con_sign(D1[j]) + " " + con_sign(D1[j + 1]) + " " + con_sign(D1[j + 2]) + " " + con_sign(D1[j + 3]) + " " + con_sign(D1[j + 4]) + " " + con_sign(D1[j + 5]) + " " + con_sign(D1[j + 6]));
                listBox3.Items.Add(con_sign(D2[j]) + " " + con_sign(D2[j + 1]) + " " + con_sign(D2[j + 2]) + " " + con_sign(D2[j + 3]) + " " + con_sign(D2[j + 4]) + " " + con_sign(D2[j + 5]) + " " + con_sign(D2[j + 6]));
                listBox4.Items.Add(con_sign(D3[j]) + " " + con_sign(D3[j + 1]) + " " + con_sign(D3[j + 2]) + " " + con_sign(D3[j + 3]) + " " + con_sign(D3[j + 4]) + " " + con_sign(D3[j + 5]) + " " + con_sign(D3[j + 6]));
                j = j + 7;
            }
            j = 0;
            listBox2.Items.Add("---------------------------  E1 = " + temp[4].ToString());
            listBox3.Items.Add("---------------------------  E2 = " + temp[11].ToString());
            listBox4.Items.Add("---------------------------  E3 = " + temp[18].ToString());
            for (i = 0; i <= 8; i++)
            {
                listBox2.Items.Add(con_sign(E1[j]) + " " + con_sign(E1[j + 1]) + " " + con_sign(E1[j + 2]) + " " + con_sign(E1[j + 3]) + " " + con_sign(E1[j + 4]) + " " + con_sign(E1[j + 5]) + " " + con_sign(E1[j + 6]));
                listBox3.Items.Add(con_sign(E2[j]) + " " + con_sign(E2[j + 1]) + " " + con_sign(E2[j + 2]) + " " + con_sign(E2[j + 3]) + " " + con_sign(E2[j + 4]) + " " + con_sign(E2[j + 5]) + " " + con_sign(E2[j + 6]));
                listBox4.Items.Add(con_sign(E3[j]) + " " + con_sign(E3[j + 1]) + " " + con_sign(E3[j + 2]) + " " + con_sign(E3[j + 3]) + " " + con_sign(E3[j + 4]) + " " + con_sign(E3[j + 5]) + " " + con_sign(E3[j + 6]));
                j = j + 7;
            }
            j = 0;
            listBox2.Items.Add("---------------------------  J1 = " + temp[5].ToString());
            listBox3.Items.Add("---------------------------  J2 = " + temp[12].ToString());
            listBox4.Items.Add("---------------------------  J3 = " + temp[19].ToString());
            for (i = 0; i <= 8; i++)
            {
                listBox2.Items.Add(con_sign(J1[j]) + " " + con_sign(J1[j + 1]) + " " + con_sign(J1[j + 2]) + " " + con_sign(J1[j + 3]) + " " + con_sign(J1[j + 4]) + " " + con_sign(J1[j + 5]) + " " + con_sign(J1[j + 6]));
                listBox3.Items.Add(con_sign(J2[j]) + " " + con_sign(J2[j + 1]) + " " + con_sign(J2[j + 2]) + " " + con_sign(J2[j + 3]) + " " + con_sign(J2[j + 4]) + " " + con_sign(J2[j + 5]) + " " + con_sign(J2[j + 6]));
                listBox4.Items.Add(con_sign(J3[j]) + " " + con_sign(J3[j + 1]) + " " + con_sign(J3[j + 2]) + " " + con_sign(J3[j + 3]) + " " + con_sign(J3[j + 4]) + " " + con_sign(J3[j + 5]) + " " + con_sign(J3[j + 6]));
                j = j + 7;
            }
            j = 0;
            listBox2.Items.Add("---------------------------  K1 = " + temp[6].ToString());
            listBox3.Items.Add("---------------------------  K2 = " + temp[13].ToString());
            listBox4.Items.Add("---------------------------  K3 = " + temp[20].ToString());
            for (i = 0; i <= 8; i++)
            {
                listBox2.Items.Add(con_sign(K1[j]) + " " + con_sign(K1[j + 1]) + " " + con_sign(K1[j + 2]) + " " + con_sign(K1[j + 3]) + " " + con_sign(K1[j + 4]) + " " + con_sign(K1[j + 5]) + " " + con_sign(K1[j + 6]));
                listBox3.Items.Add(con_sign(K2[j]) + " " + con_sign(K2[j + 1]) + " " + con_sign(K2[j + 2]) + " " + con_sign(K2[j + 3]) + " " + con_sign(K2[j + 4]) + " " + con_sign(K2[j + 5]) + " " + con_sign(K2[j + 6]));
                listBox4.Items.Add(con_sign(K3[j]) + " " + con_sign(K3[j + 1]) + " " + con_sign(K3[j + 2]) + " " + con_sign(K3[j + 3]) + " " + con_sign(K3[j + 4]) + " " + con_sign(K3[j + 5]) + " " + con_sign(K3[j + 6]));
                j = j + 7;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            Initialize();
            Training();
            PrintResults();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cluster[0] = listBox5;
            Cluster[1] = listBox6;
            Cluster[2] = listBox7;
            Cluster[3] = listBox8;
            Cluster[4] = listBox9;

            Cluster[5] = listBox14;
            Cluster[6] = listBox13;
            Cluster[7] = listBox12;
            Cluster[8] = listBox11;
            Cluster[9] = listBox10;


            Cluster[10] = listBox19;
            Cluster[11] = listBox18;
            Cluster[12] = listBox17;
            Cluster[13] = listBox16;
            Cluster[14] = listBox15;

            Cluster[15] = listBox24;
            Cluster[16] = listBox23;
            Cluster[17] = listBox22;
            Cluster[18] = listBox21;
            Cluster[19] = listBox20;


            Cluster[20] = listBox29;
            Cluster[21] = listBox28;
            Cluster[22] = listBox27;
            Cluster[23] = listBox26;
            Cluster[24] = listBox25;
            
            
        }

    

       

        

    }
}
