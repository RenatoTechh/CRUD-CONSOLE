using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_CRUD_CONSOLE
{
    internal class ObjetoDaListaNaoEncontradoException : Exception
    {
        public ObjetoDaListaNaoEncontradoException()
        {
            
        }
        public ObjetoDaListaNaoEncontradoException(string message) : base(message)
        {

        }
    }
}
