using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTestingSamples.Models;

namespace MvcTestingSamples.Repositories
{
    public interface ISampleRepository
    {
        void InsertSomething(Something value);
        void UpdateSomething(Something value);
        void DeleteSomething(Something value);

        Something GetSomething(int ID);
        IEnumerable<Something> GetSomethings();
    }
}