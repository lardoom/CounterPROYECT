using Counter.Core.Modelos;
using Counter.Core.Modelos.Armas;
using Counter.Core.Modelos.Equipos;
using Counter.Core.Modelos.Jugadores;
using Counter.Core.Modelos.Pais;
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
        //Equipo
        Task<BaseResult> IngresarEquipo(EquiposInput entrada);
        Task<EquiposResult> ConsultarEquipo(string nombreDeEquipo);
        //Jugador
        Task<BaseResult> IngresarJugador(JugadoresInput EntradaJugador);
        //Arma
        Task<BaseResult> IngresarArma(ArmasInput EntradaArma);
        Task<BaseResult> IngresarArmasBulk(List<ArmasInput> bulk);
        //Pais
        Task<BaseResult> IngresarPais(PaisInput EntradaPais);

        //Special
        Task<JugadoresRondasGanadasResult> MayorRondasGanadas(int rondasGanadas);
        Task<PromedioRondasGanadasPorEquipoResult> PromedioRondasGanadasPorEquipo();
        Task<JugadorMayorKillsResult> JugadorConMasKills();
        Task<MapaFavYPrecTiroJugadoresResult> MapaFavYPrecTiro(string nombreMapa, decimal precisionTiro);
    }
}
