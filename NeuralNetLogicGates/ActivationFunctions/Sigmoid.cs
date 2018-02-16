using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetLogicGates.ActivationFunctions
{
    static class Sigmoid
    {
        public static double Count(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public static double Derivative(double x)
        {
            return x * (1 - x);
        }
    }
}
