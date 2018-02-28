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
        public double TrainingRate = 0.5;

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
                for (int currentLayerNeuronIndex = 0; currentLayerNeuronIndex < currentLayer.NeuronsCount; currentLayerNeuronIndex++)
                {
                    Neuron currentLayerNeuron = currentLayer.Neurons[currentLayerNeuronIndex];
                    currentLayerNeuron.Value = currentLayerNeuron.Bias;
                    for (int previousLayerNeuronIndex = 0; previousLayerNeuronIndex < previousLayer.NeuronsCount; previousLayerNeuronIndex++)
                    {
                        Neuron previousLayerNeuron = previousLayer.Neurons[previousLayerNeuronIndex];
                        currentLayerNeuron.Value += previousLayerNeuron.Value * previousLayerNeuron.NextDendrites[currentLayerNeuronIndex].Weight;
                    }
                    currentLayerNeuron.Value = Sigmoid.Count(currentLayerNeuron.Value);
                }
            }
        }

        public void Train(double[] input, double[] output)
        {
            if (output.Length != this.OutputLayer.NeuronsCount)
            {
                throw new Exception("Number of passed output values does not match with number of output neurons");
            }
            this.Propagate(input);
            // calculating delta for weights that are before output neurons
            for(int neuronIndex = 0; neuronIndex < this.OutputLayer.NeuronsCount; neuronIndex++)
            {
                Neuron outputNeuron = this.OutputLayer.Neurons[neuronIndex];
                outputNeuron.Delta = (outputNeuron.Value - output[neuronIndex]) * ActivationFunctions.Sigmoid.Derivative(outputNeuron.Value);
                foreach(Dendrite dendrite in outputNeuron.PreviousDendrites)
                {
                    dendrite.Delta = outputNeuron.Delta * dendrite.PreviousNeuron.Value;
                }
            }
            // calculating delta for the rest of weights
            for(int layerIndex = this.LayersCount-2; layerIndex > 0; layerIndex--)
            {
                Layer currentLayer = this.Layers[layerIndex];
                for(int neuronIndex = 0; neuronIndex < currentLayer.NeuronsCount; neuronIndex++)
                {
                    Neuron currentNeuron = currentLayer.Neurons[neuronIndex];
                    currentNeuron.Delta = 0;
                    foreach(Dendrite dendrite in currentNeuron.NextDendrites)
                    {
                        currentNeuron.Delta += dendrite.NextNeuron.Delta * dendrite.Weight;
                    }
                    currentNeuron.Delta *= ActivationFunctions.Sigmoid.Derivative(currentNeuron.Value);
                    foreach(Dendrite dendrite in currentNeuron.PreviousDendrites)
                    {
                        dendrite.Delta = currentNeuron.Delta * dendrite.PreviousNeuron.Value;
                    }
                }
            }
            // updating weights
            foreach(Layer layer in this.Layers)
            {
                foreach(Neuron neuron in layer.Neurons)
                {
                    foreach(Dendrite dendrite in neuron.NextDendrites)
                    {
                        dendrite.Weight -= dendrite.Delta*this.TrainingRate;
                    }
                }
            }
        }
    }
}
