using APINasa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APINasa.DataAccess
{
    public interface IMeteoritoService
    {
        List<Meteorito> Obtenertop3(int dias);
        List<Meteorito> Insertar3Meteoritos(int dias);
    }
}