﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class NegocioPaciente
    {
        public List<Paciente> ListaPaciente()
        {
            List<Paciente> ListaPaciente = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("select u.DNI, Nombre, Apellido, Domicilio, FechaNacimiento, Genero, Estado, CodigoPaciente from persona as p inner join Paciente as u on u.DNI=p.DNI");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {
                     Paciente aux = new Paciente();
                    aux.Estado = (bool)datos.Lector["ESTADO"];
                    if (aux.Estado == true)
                    {
                        aux.DNI = datos.Lector.GetInt64(0);
                        aux.Nombre = datos.Lector.GetString(1);
                        aux.Apellido = datos.Lector.GetString(2);
                        aux.Domicilio = datos.Lector.GetString(3);
                        aux.FechaNacimiento = datos.Lector.GetDateTime(4);
                        aux.Genero = datos.Lector.GetString(5);
                        aux.Estado = datos.Lector.GetBoolean(6);

                        aux.CodigoPaciente= datos.Lector.GetString(7);

                        ListaPaciente.Add(aux);
                    }




                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaPaciente;
        }


        public List<Paciente> ListaPaciente2()  // Tiene la lista de todos los pacientes
        {
            List<Paciente> ListaPaciente2 = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("select u.DNI, Nombre, Apellido, Domicilio, FechaNacimiento, Genero, Estado, CodigoPaciente from persona as p inner join Paciente as u on u.DNI=p.DNI");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();
  
                        aux.DNI = datos.Lector.GetInt64(0);
                        aux.Nombre = datos.Lector.GetString(1);
                        aux.Apellido = datos.Lector.GetString(2);
                        aux.Domicilio = datos.Lector.GetString(3);
                        aux.FechaNacimiento = datos.Lector.GetDateTime(4);
                        aux.Genero = datos.Lector.GetString(5);
                        aux.Estado = datos.Lector.GetBoolean(6);

                        aux.CodigoPaciente = datos.Lector.GetString(7);

                    ListaPaciente2.Add(aux);
                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaPaciente2;
        }

        public void AgregarPersona(Persona nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("insert into Persona (DNI,Nombre,Apellido,Domicilio,FechaNacimiento,Genero,Estado) values (@DNI,@Nombre,@Apellido,@Domicilio,@FechaNacimiento,@Genero,@Estado);");
            datos.AgregarParametro("@DNI", nuevo.DNI);
            datos.AgregarParametro("@Nombre", nuevo.Nombre);
            datos.AgregarParametro("@Apellido", nuevo.Apellido);
            datos.AgregarParametro("@Domicilio", nuevo.Domicilio);
            datos.AgregarParametro("@FechaNacimiento", nuevo.FechaNacimiento);
            datos.AgregarParametro("@Genero", nuevo.Genero);
            datos.AgregarParametro("@Estado", nuevo.Estado);
            datos.EjecutarConsulta();

        }

        public void AgregarPaciente(Paciente nuevo, Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("insert into Paciente(CodigoPaciente ,DNI ,FechaInscripcion , Email) values (@CodigoPaciente, @DNI, @FechaInscripcion, @Email );");
            datos.AgregarParametro("@CodigoPaciente", nuevo.CodigoPaciente);
            datos.AgregarParametro("@FechaInscripcion", nuevo.FechaInscripcion);
            datos.AgregarParametro("@Email", nuevo.Email);
            datos.AgregarParametro("@DNI", persona.DNI);
            datos.EjecutarConsulta();
        }
         public void ModificarMedicoPersona(Medico nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("update persona set DNI=@DNI, Nombre=@Nombre, Apellido=@Apellido, Domicilio=@Domicilio where DNI = @DNI");
            datos.AgregarParametro("@DNI", nuevo.DNI);
            datos.AgregarParametro("@Nombre", nuevo.Nombre);
            datos.AgregarParametro("@Apellido", nuevo.Apellido);
            datos.AgregarParametro("@Domicilio", nuevo.Domicilio);
            datos.EjecutarConsulta();
        }


        public bool  ModificarPaciente(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("update persona set DNI=@DNI, Nombre=@Nombre, Apellido=@Apellido, Domicilio=@Domicilio, FechaNacimiento=@FechaNacimiento where DNI = @DNI");
            datos.AgregarParametro("@DNI", nuevo.DNI);
            datos.AgregarParametro("@Nombre", nuevo.Nombre);
            datos.AgregarParametro("@Apellido", nuevo.Apellido);
            datos.AgregarParametro("@Domicilio", nuevo.Domicilio);
            datos.AgregarParametro("@FechaNacimiento", nuevo.FechaNacimiento);
            datos.EjecutarConsulta();
            return true;
        }

        public void BajaPaciente(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("update persona set estado = 0 where DNI = @DNI");
            datos.AgregarParametro("@DNI", nuevo.DNI);
            datos.EjecutarConsulta();
        }

        public void RecuperarPaciente(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("update persona set estado = 1 where DNI = @DNI");
            datos.AgregarParametro("@DNI", nuevo.DNI);
            datos.EjecutarConsulta();
        }

        public void AgregarSeguridad(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("insert into Seguridad (Contraseña, UltimaConexion) values (@Pass, @UltConexion)");
            datos.AgregarParametro("@Pass", nuevo.Seguridad.Contraseña);
            datos.AgregarParametro("@UltConexion", nuevo.Seguridad.UltimaConexion);
            datos.EjecutarConsulta();
        }

    }
}
