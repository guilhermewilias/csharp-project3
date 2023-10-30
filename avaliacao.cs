using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.modelos;
internal class avaliacao //internal = também relacionado a visibilidade de classes -> Apenas o projeto vai conseguir enxergar.
{
    public avaliacao(int nota)
    {
        Nota = nota;
    }

    public int Nota { get; }
}
