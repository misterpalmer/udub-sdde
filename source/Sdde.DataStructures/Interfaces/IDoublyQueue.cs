using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdde.Interfaces;


public interface IDoublyQueue<T> : IQueue<T>
{
    T PeekLast();
    T DequeueLast();
}
