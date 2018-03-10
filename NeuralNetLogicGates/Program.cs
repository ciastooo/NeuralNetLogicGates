using System;
using NeuralNetLogicGates.NeuralNetStructure;
using NeuralNetLogicGates.DataModels;

namespace NeuralNetLogicGates
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new NeuralNet(2, 1, 3, 5);
            var andGate = new AndGate();
            test.Propagate(new double[] { 1, 1 });
            Console.WriteLine($"Input data: (1,1) Output data: ({test.OutputLayer.Neurons[0].Value}) ideal (1)");
            test.Propagate(new double[] { 1, 0 });
            Console.WriteLine($"Input data: (1,0) Output data: ({test.OutputLayer.Neurons[0].Value}) ideal (0)");
            test.Propagate(new double[] { 0, 1 });
            Console.WriteLine($"Input data: (0,1) Output data: ({test.OutputLayer.Neurons[0].Value}) ideal (0)");
            test.Propagate(new double[] { 0, 0 });
            Console.WriteLine($"Input data: (0,1) Output data: ({test.OutputLayer.Neurons[0].Value}) ideal (0)");
            Console.WriteLine("Training...");
            test.TrainWithData(andGate, 10000);
            test.Propagate(new double[] { 1, 1 });
            Console.WriteLine($"Input data: (1,1) Output data: ({test.OutputLayer.Neurons[0].Value}) ideal (1)");
            test.Propagate(new double[] { 1, 0 });
            Console.WriteLine($"Input data: (1,0) Output data: ({test.OutputLayer.Neurons[0].Value}) ideal(0)");
            test.Propagate(new double[] { 0, 1 });
            Console.WriteLine($"Input data: (0,1) Output data: ({test.OutputLayer.Neurons[0].Value}) ideal(0)");
            test.Propagate(new double[] { 0, 0 });
            Console.WriteLine($"Input data: (0,0) Output data: ({test.OutputLayer.Neurons[0].Value}) ideal(0)");
        }
    }
}
