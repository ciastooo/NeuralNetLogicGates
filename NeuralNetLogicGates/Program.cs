using System;
using NeuralNetLogicGates.NeuralNetStructure;

namespace NeuralNetLogicGates
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new NeuralNet(2, 1, 2, 3);
            double[] a = {0, 0};
            double[] aa = {0};
            double[] b = {1, 0};
            double[] bb = {0};
            double[] c = {0, 1};
            double[] cc = {0};
            double[] d = {1, 1};
            double[] dd = {1};
            int j = 0;
            test.Propagate(a);
            Console.WriteLine(test.OutputLayer.Neurons[0].Value);
            test.Propagate(d);
            Console.WriteLine(test.OutputLayer.Neurons[0].Value);
            for(int i = 0; i < 100000; i++) {
                switch(j) {
                case 0:
                        test.Train(a, aa);
                break;
                case 1:
                        test.Train(b, bb);
                break;
                case 2:
                        test.Train(c,cc);
                break;
                case 3:
                default:
                        test.Train(d, dd);
                break;
                }
                j++;
                if(j==4) {
                    j = 0;
                }
            }
            Console.WriteLine("END");
            test.Propagate(a);
            Console.WriteLine(test.OutputLayer.Neurons[0].Value);
            test.Propagate(d);
            Console.WriteLine(test.OutputLayer.Neurons[0].Value);
        }
    }
}
