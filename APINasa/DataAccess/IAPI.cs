using APINasa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APINasa.DataAccess
{
    public interface IAPI
    {
        Task<List<Meteorito>> Obtenertop3(int dias);
    }
}