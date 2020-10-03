using System;
using System.Collections.Generic;
using System.Text;

namespace Elements_of_higher_mathematics.SystemOfEquations
{
    class СSystemOfEquations
    {
        // Система Уравнений.
        public Equations[] SystemOfEquations { get; private set; }

        #region Конструкторы

        public СSystemOfEquations(Equations[] equations)
        {
            SystemOfEquations = equations;
        }

        public СSystemOfEquations(Equations equations1, Equations equations2)
        {
            SystemOfEquations = new Equations[2];

            SystemOfEquations[0] = equations1;
            SystemOfEquations[1] = equations2;
        }

        public СSystemOfEquations(Equations equations1, Equations equations2, Equations equations3)
        {
            SystemOfEquations = new Equations[2];

            SystemOfEquations[0] = equations1;
            SystemOfEquations[1] = equations2;
            SystemOfEquations[2] = equations3;
        }

        #endregion

    }
}
