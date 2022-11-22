using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialCSharp
{
    public interface IAnimales
    {
        void multiCelulares();

        void sangreCaliente();
    }

    public interface IAnimal : IAnimales
    {
        void correr();
        void viviparo();
    }

    public interface IPajaro : IAnimales
    {
        void volar();
        void oviparo();
    }
}
