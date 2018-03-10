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
            var notGate = new NotGate();
            var orGate = new OrGate();
            test.TrainWithData(orGate, 10000);
        }
    }
}
