﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class NegocioMedico
    {
        public List<Medico> ListaMedicos()
        {
            List<Medico> ListaMedicos = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("select m.DNI, Nombre, Apellido, Domicilio, FechaNacimiento, Genero, Estado, LegajoMedico from persona as p inner join Medico as m on m.DNI=p.DNI");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {
                    Medico aux = new Medico(); 
                    aux.DNI = datos.Lector.GetInt64(0);
                    aux.Nombre = datos.Lector.GetString(1);
                    aux.Apellido = datos.Lector.GetString(2);
                    aux.Domicilio = datos.Lector.GetString(3);
                    aux.FechaNacimiento = datos.Lector.GetDateTime(4);
                    aux.Genero = datos.Lector.GetString(5);
                    aux.Estado = datos.Lector.GetBoolean(6);
                    aux.LegajoMedico = datos.Lector.GetString(7);
                    ListaMedicos.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaMedicos;
        }

        public List<Medico> BuscaMedicos(Especialidad filtrado)
        {
            List<Medico> BuscaMedicos = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.AgregarParametro("@IdEspecialidad", filtrado.IdEspecialidad);
                datos.SetearQuery("select m.DNI, p.Nombre, Apellido, Domicilio, FechaNacimiento, Genero, Estado, LegajoMedico from persona as p inner join Medico as m on m.DNI = p.DNI where Especialidad = @IdEspecialidad");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.DNI = datos.Lector.GetInt64(0);
                    aux.Nombre = datos.Lector.GetString(1);
                    aux.Apellido = datos.Lector.GetString(2);
                    aux.Domicilio = datos.Lector.GetString(3);
                    aux.FechaNacimiento = datos.Lector.GetDateTime(4);
                    aux.Genero = datos.Lector.GetString(5);
                    aux.Estado = datos.Lector.GetBoolean(6);
                    aux.LegajoMedico = datos.Lector.GetString(7);
                    BuscaMedicos.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return BuscaMedicos;
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

        public void AgregarMedico(Medico nuevo, Persona Persona, Especialidad idEsp)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("insert into Medico (LegajoMedico,DNI,FechaIngreso,Especialidad) values (@LegajoMedico, @DNI, @FechaIngreso, @Especialidad);");
            datos.AgregarParametro("@LegajoMedico", nuevo.LegajoMedico);
            datos.AgregarParametro("@DNI", Persona.DNI);
            datos.AgregarParametro("@FechaIngreso", nuevo.FechaIngreso);
            datos.AgregarParametro("@Especialidad", idEsp.IdEspecialidad);
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

        public void ModificarMedico(Medico nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("update Medico set Especialidad=@Especialidad where DNI = @DNI");
            datos.AgregarParametro("@DNI", nuevo.DNI);
            datos.AgregarParametro("@Especialidad", nuevo.Especialidad.IdEspecialidad);
            datos.EjecutarConsulta();
        }
        public void BajaMedico(Medico nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("update persona set estado = 0 where DNI = @DNI");
            datos.AgregarParametro("@DNI", nuevo.DNI);
            datos.EjecutarConsulta();
        }
    }
}
