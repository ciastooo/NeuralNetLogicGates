using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetLogicGates.NeuralNetStructure
{
    class Dendrite
    {
        public Neuron PreviousNeuron { get; }
        public Neuron NextNeuron { get; }
        public double Weight { get; set; }
        public double Delta { get; set; }

        public Dendrite(double weight, Neuron previous, Neuron next)
        {
            this.Weight = weight;
            this.PreviousNeuron = previous;
            this.NextNeuron = next;
        }
    }
}
