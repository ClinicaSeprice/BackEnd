﻿using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IObraSocialService
    {
        Task<bool> RegistrarObraSocialAsync(ObraSocialDTO obraSocialDTO);
        Task<IEnumerable<ObraSocialDTO>> ObtenerObraSocialPorIdAsync(int id);
    }
}
