using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetLogicGates.NeuralNet
{
    class NeuralNet
    {
        public IList<Layer> Layers { get; }
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
                    return Layers[Layers.Count-1];
                }
            }
        }

        public NeuralNet(int inputNeuronsCount, int outputNeuronsCount, int hiddenLayersCount, int hiddenLayerNeuronsCount)
        {
            this.Layers = new List<Layer>();
            Layer inputLayer = new Layer(inputNeuronsCount);
            this.Layers.Add(inputLayer);
            for(int i = 0; i < hiddenLayersCount; i++)
            {
                Layer hiddenLayer = new Layer(hiddenLayerNeuronsCount, this.Layers[i]);
                this.Layers.Add(hiddenLayer);
            }
            Layer outputLayer = new Layer(outputNeuronsCount, this.Layers[this.Layers.Count]);
        }
    }
}
