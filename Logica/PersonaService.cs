using Datos;
using Entity;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class PersonaService
    {
        private ConnectionManeger conexion;
        private PersonaRepository repositorio;
        public PersonaService(string connectionString)
        {
            conexion = new ConnectionManeger(connectionString);
            repositorio = new PersonaRepository(conexion);
        }
        public string Guardar(Persona persona)
        {
            try
            {
                conexion.Open();
                repositorio.Guardar(persona);
                conexion.Close();
                return ($"Los Datos de la Persona [ {persona.Nombre} ] se han guardado Satisfactoriamente");
            }
            catch (Exception e)
            {
                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public string Eliminar(Persona persona)
        {
            try
            {
                conexion.Open();
                if (repositorio.Buscar(persona.Identificacion) == null)
                {
                    repositorio.Guardar(persona);
                    conexion.Close();
                    return ($"Los Datos de la {persona.Nombre} se han guardado Satisfactoriamente");
                }
                else
                {
                    return ($"Lo sentimos, {persona.Nombre} ya se encuentra registrada");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }
            finally { conexion.Close(); }

        }
        public Persona BuscarxId(string identificacion)
        {
            conexion.Open();
            Persona persona = repositorio.Buscar(identificacion);
            conexion.Close();
            return persona;
        }
        public List<Persona> Consultar()
        {
            conexion.Open();
            List<Persona> personas = repositorio.ConsultarTodos();
            conexion.Close();
            return personas;
        }

        public Int64 Totalizar()
        {
            return repositorio.Totalizar();
        }

        public Int64 TotalizarMujeres()
        {
            return repositorio.TotalizarMujeres();
        }

        public Int64 TotalizarHombres()
        {
            return repositorio.TotalizarHombres();
        }
    }
}
