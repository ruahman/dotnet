using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialCSharp
{
    public class ListaElementos<T>
    {
        List<T> elementos;

        public ListaElementos()
        {
            elementos = new List<T>();
        }

        public void Agregar(T nuevoElemento)
        {
            elementos.Add(nuevoElemento);
        }

        public void Eliminar(T elemento)
        {
            elementos.Remove(elemento);
        }

        public void Listar()
        {
            foreach (var elemento in elementos)
            {
                Console.WriteLine(elemento);
            }
        }
    }
}
