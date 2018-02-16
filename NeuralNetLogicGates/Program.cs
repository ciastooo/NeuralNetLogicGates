using System;
using NeuralNetLogicGates.NeuralNetStructure;

namespace NeuralNetLogicGates
{
    class Program
    {
        static void Main(string[] args)
        {
            var testNet = new NeuralNet(2, 2, 1, 2);
            testNet.InputLayer.Neurons[0].NextDendrites[0].Weight = 0.15;
            testNet.InputLayer.Neurons[0].NextDendrites[1].Weight = 0.25;
            testNet.InputLayer.Neurons[1].NextDendrites[0].Weight = 0.20;
            testNet.InputLayer.Neurons[1].NextDendrites[1].Weight = 0.30;
            testNet.Layers[1].Neurons[0].Bias= 0.35;
            testNet.Layers[1].Neurons[1].Bias= 0.35;
            testNet.Layers[1].Neurons[0].NextDendrites[0].Weight = 0.40;
            testNet.Layers[1].Neurons[0].NextDendrites[1].Weight = 0.50;
            testNet.Layers[1].Neurons[1].NextDendrites[0].Weight = 0.45;
            testNet.Layers[1].Neurons[1].NextDendrites[1].Weight = 0.55;
            testNet.OutputLayer.Neurons[0].Bias= 0.6;
            testNet.OutputLayer.Neurons[1].Bias= 0.6;
            double[] testValues = { 0.05, 0.1};
            testNet.Propagate(testValues);
            Console.WriteLine(testNet.OutputLayer.Neurons[0].Value);
            Console.WriteLine(testNet.OutputLayer.Neurons[1].Value);
            double[] testTrain = { 0.01, 0.99 };
            testNet.Train(testValues, testTrain);
            Console.WriteLine("END");
        }
    }
}
