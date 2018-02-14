using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetLogicGates.NeuralNetStructure
{
    class Layer
    {
        public IList<Neuron> Neurons { get; }
        public int NeuronsCount { get { return this.Neurons.Count; } }
        public Layer(int neuronsCount, Layer previous = null)
        {
            this.Neurons = new List<Neuron>();
            for (int i = 0; i < neuronsCount; i++)
            {
                Neuron addingNeuron = new Neuron(new Random().NextDouble());
                if (previous != null)
                {
                    for (int j = 0; j < previous.Neurons.Count; j++)
                    {
                        Neuron previousNeuron = previous.Neurons[j];
                        previousNeuron.AddNextNeuron(addingNeuron, new Random().NextDouble());
                        addingNeuron.AddPreviousNeuron(previousNeuron, new Random().NextDouble());
                    }
                }
                this.Neurons.Add(addingNeuron);
            }
        }
    }
}
