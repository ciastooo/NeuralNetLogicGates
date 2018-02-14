using System;
using System.Collections.Generic;
using System.Text;
using NeuralNetLogicGates.ActivationFunctions;

namespace NeuralNetLogicGates.NeuralNetStructure
{
    class NeuralNet
    {
        public IList<Layer> Layers { get; }
        public int LayersCount { get { return this.Layers.Count; } }
        public Layer InputLayer
        {
            get
            {
                if (Layers.Count == 0)
                {
                    return null;
                }
                else
                {
                    return Layers[0];
                }
            }
        }
        public Layer OutputLayer
        {
            get
            {
                if (Layers.Count == 0)
                {
                    return null;
                }
                else
                {
                    return Layers[Layers.Count - 1];
                }
            }
        }

        public NeuralNet(int inputNeuronsCount, int outputNeuronsCount, int hiddenLayersCount, int hiddenLayerNeuronsCount)
        {
            this.Layers = new List<Layer>();
            Layer inputLayer = new Layer(inputNeuronsCount);
            this.Layers.Add(inputLayer);
            for (int i = 0; i < hiddenLayersCount; i++)
            {
                Layer hiddenLayer = new Layer(hiddenLayerNeuronsCount, this.Layers[i]);
                this.Layers.Add(hiddenLayer);
            }
            Layer outputLayer = new Layer(outputNeuronsCount, this.Layers[this.Layers.Count - 1]);
            this.Layers.Add(outputLayer);
        }

        public void Propagate(double[] values)
        {
            if (values.Length != this.InputLayer.NeuronsCount)
            {
                throw new Exception("Number of passed values does not match with number of input neurons");
            }
            // passing values to input neurons
            for (int i = 0; i < values.Length; i++)
            {
                this.InputLayer.Neurons[i].Value = values[i];
            }
            // passing values to hdden layers and output layer
            for (int layerIndex = 1; layerIndex < this.LayersCount; layerIndex++)
            {
                Layer currentLayer = this.Layers[layerIndex];
                Layer previousLayer = this.Layers[layerIndex - 1];
                for(int currentLayerNeuronIndex = 0; currentLayerNeuronIndex < currentLayer.NeuronsCount; currentLayerNeuronIndex++)
                {
                    Neuron currentLayerNeuron = currentLayer.Neurons[currentLayerNeuronIndex];
                    currentLayerNeuron.Value = currentLayerNeuron.Bias;
                    for(int previousLayerNeuronIndex = 0; previousLayerNeuronIndex < previousLayer.NeuronsCount; previousLayerNeuronIndex++)
                    {
                        Neuron previousLayerNeuron = previousLayer.Neurons[previousLayerNeuronIndex];
                        currentLayerNeuron.Value += previousLayerNeuron.Value * previousLayerNeuron.NextDendrites[currentLayerNeuronIndex].Weight;
                    }
                    currentLayerNeuron.Value = Sigmoid.Count(currentLayerNeuron.Value);
                }
            }
        }
    }
}
