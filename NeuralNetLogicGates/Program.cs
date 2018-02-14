using System;
using NeuralNetLogicGates.NeuralNetStructure;

namespace NeuralNetLogicGates
{
    class Program
    {
        static void Main(string[] args)
        {
            var testNet = new NeuralNet(2, 2, 1, 2);
            testNet.InputLayer.Neurons[0].Value = 0.05;
            testNet.InputLayer.Neurons[1].Value = 0.1;
            testNet.Layers[1].Neurons[1].Bias= 0.35;
            testNet.Layers[1].Neurons[1].Bias= 0.35;
            testNet.OutputLayer.Neurons[1].Bias= 0.6;
            testNet.OutputLayer.Neurons[2].Bias= 0.6;
            double[] testValues = { 0.05, 0.1};
            testNet.Propagate(testValues);
            Console.WriteLine(testNet.OutputLayer.Neurons[0].Value);
            Console.WriteLine(testNet.OutputLayer.Neurons[1].Value);
            Console.WriteLine("END");
        }
    }
}
