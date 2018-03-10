using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetLogicGates.DataModels
{
    public abstract class LogicGate
    {
        public List<List<List<double>>> learningData = null;

        public LogicGate()
        {
            this.learningData = new List<List<List<double>>>();
        }

        public void AddLearningData(double[] input, double[] output)
        {
            var newData = new List<List<double>>();
            var inputData = new List<double>(input);
            var outputData = new List<double>(output);
            newData.Add(inputData);
            newData.Add(outputData);
            this.learningData.Add(newData);
        }
    }
}
