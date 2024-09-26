using Counter.Core.Modelos;
using Counter.DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Interfaces
{
    public interface ICounterService
    {

        Task<BaseResult> IngresarEquipo(EquiposInput entrada);
        Task<EquiposResult> ConsultarEquipo(string nombreDeEquipo);

        Task<BaseResult> IngresarJugador(JugadoresInput EntradaJugador);


        Task<BaseResult> IngresarArma(ArmasInput EntradaArma);
        Task<BaseResult> IngresarPais(PaisInput EntradaPais);
        Task<JugadoresPyA> ConsultarJugadorPyA(string NombreJugador);

        Task<Killer> Jugadorkiller();

        /* Task<JugadoresResult> Partidas(string Patridasganadas);

         /*Task<BaseResult> IngresarPais(PaisInput EntradaPais);
         Task<BaseResult> ConsultarPais(string NombrePais);

         Task<BaseResult> IngresarArmas(ArmasInput EntradaDeArma);
         Task<BaseResult> ConsultarArmas(string NombreArmas);*/
    }
}
