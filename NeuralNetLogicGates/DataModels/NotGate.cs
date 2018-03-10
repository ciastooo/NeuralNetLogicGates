using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetLogicGates.DataModels
{
    public class NotGate: LogicGate
    {
        public NotGate()
        {
            this.AddLearningData(new double[] { 0 }, new double[] { 1 });
            this.AddLearningData(new double[] { 1 }, new double[] { 0 });
        }
    }
}
