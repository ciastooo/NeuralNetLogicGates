using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetLogicGates.NeuralNetStructure
{
    class Dendrite
    {
        private Neuron PreviousNeuron { get; }
        private Neuron NextNeuron { get; }
        public double Weight { get; set; }

        public Dendrite(double weight, Neuron previous, Neuron next)
        {
            this.Weight = weight;
            this.PreviousNeuron = previous;
            this.NextNeuron = next;
        }
    }
}
