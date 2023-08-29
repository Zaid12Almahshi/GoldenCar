using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositoy.Repositories
{
    public interface IReopsitory<T>
    {
        Task<List<T>> ListData(string SpName,object Params);

        Task ExecCommand(string SpName,object Params);

        Task<T> FindExecCommand(string SpName,object Params);
    }
}
