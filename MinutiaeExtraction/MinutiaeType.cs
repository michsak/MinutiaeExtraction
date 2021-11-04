using System;
using System.Collections.Generic;
using System.Text;

namespace MinutiaeExtraction
{
    public enum MinutiaeType
    {
        SINGLE_POINT, // pojedynczy punkt
        EDGE_END, // koniec krawedzi
        EDGE_CONTINUATION, // kontynuacja krawedzi
        FORK, // rozwidlenie
        CROSSING // skrzyzowanie
    }
}
