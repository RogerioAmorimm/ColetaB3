using System;
using System.Collections.Generic;
using System.Text;

namespace ColetaB3.Interfaces
{
    public interface IDocument
    {
        string GetHost();
        int GetPort();
        string GetTo();
        string GetFrom();

        bool IsValid();

    }
}
