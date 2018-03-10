using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetLogicGates.DataModels
{
    public class OrGate: LogicGate
    {
        public OrGate(): base()
        {
            this.AddLearningData(new double[] { 0, 0 }, new double[] { 0 });
            this.AddLearningData(new double[] { 1, 0 }, new double[] { 1 });
            this.AddLearningData(new double[] { 0, 1 }, new double[] { 1 });
            this.AddLearningData(new double[] { 1, 1 }, new double[] { 1 });
        }
    }
}
