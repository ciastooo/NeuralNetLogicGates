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
            test.TrainWithData(andGate, 10000);
        }
    }
}
