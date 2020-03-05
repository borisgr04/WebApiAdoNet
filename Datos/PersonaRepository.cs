using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class PersonaRepository
    {
        SqlConnection _connection;

        List<Persona> personas = new List<Persona>();

        public PersonaRepository(ConnectionManeger connection)
        {
            _connection = connection._conexion;
        }


        public void Guardar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Insert Into Persona (Identificacion,Nombre,Edad, Sexo, Pulsacion) values (@Identificacion,@Nombre,@Edad,@Sexo,@Pulsacion)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                command.Parameters.AddWithValue("@Pulsacion", persona.Pulsacion);
                var Filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Persona persona)
        {

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.ExecuteNonQuery();
            }
        }

        public List<Persona> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }


            }
            return personas;
        }

        public Persona Buscar(string identificacion)
        {

            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                return DataReaderMapToPerson(dataReader);
            }
        }

        private Persona DataReaderMapToPerson(SqlDataReader dataReader)
        {
            Persona persona = new Persona();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombre = (string)dataReader["Nombre"];
            persona.Sexo = (string)dataReader["Sexo"];
            persona.Edad = (int)dataReader["Edad"];
            return persona;
        }

        public int Totalizar()
        {
            return personas.Count();
        }

        public int TotalizarMujeres()
        {
            ConsultarTodos();
            return personas.Where(p => p.Sexo.Equals("F")).Count();
        }

        public int TotalizarHombres()
        {
            ConsultarTodos();
            return personas.Where(p => p.Sexo.Equals("M")).Count();
        }

    }
}
