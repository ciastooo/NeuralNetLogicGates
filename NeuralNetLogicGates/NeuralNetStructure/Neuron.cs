using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetLogicGates.NeuralNetStructure
{
    class Neuron
    {
        public IList<Dendrite> PreviousDendrites { get; }
        public IList<Dendrite> NextDendrites { get; }
        public double Value { get; set; }
        public double Bias { get; set; }

        public Neuron(double bias)
        {
            this.Value = 0;
            this.Bias = bias;
            this.PreviousDendrites = new List<Dendrite>();
            this.NextDendrites = new List<Dendrite>();
        }

        public void AddPreviousNeuron(Neuron previous, double weight)
        {
            Dendrite addingDendrite = new Dendrite(weight, previous, this);
            this.PreviousDendrites.Add(addingDendrite);
        }

        public void AddNextNeuron(Neuron next, double weight)
        {
            Dendrite addingDendrite = new Dendrite(weight, this, next);
            this.NextDendrites.Add(addingDendrite);
        }
    }
}
