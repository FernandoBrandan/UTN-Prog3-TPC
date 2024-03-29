﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioUsuario
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> ListarUsuarios = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("select u.DNI, Nombre, Apellido, Domicilio, FechaNacimiento, Genero, Estado, LegajoUsuario from persona as p inner join Usuario as u on u.DNI=p.DNI");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {

                    Usuario aux = new Usuario();
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
                        aux.LegajoUsuario = datos.Lector.GetString(7);
                        ListarUsuarios.Add(aux);
                    }
                 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListarUsuarios;
        }

        public List<Usuario> ListaUsuarios2()
        {
            List<Usuario> ListarUsuarios2 = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("select u.DNI, Nombre, Apellido, Domicilio, FechaNacimiento, Genero, Estado, LegajoUsuario from persona as p inner join Usuario as u on u.DNI=p.DNI");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {

                    Usuario aux = new Usuario();
                    aux.Estado = (bool)datos.Lector["ESTADO"];
                        aux.DNI = datos.Lector.GetInt64(0);
                        aux.Nombre = datos.Lector.GetString(1);
                        aux.Apellido = datos.Lector.GetString(2);
                        aux.Domicilio = datos.Lector.GetString(3);
                        aux.FechaNacimiento = datos.Lector.GetDateTime(4);
                        aux.Genero = datos.Lector.GetString(5);
                        aux.Estado = datos.Lector.GetBoolean(6);
                        aux.LegajoUsuario = datos.Lector.GetString(7);
                        ListarUsuarios2.Add(aux);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListarUsuarios2;
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
         
        public void AgregarSeguridad(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("insert into Seguridad (Contraseña, UltimaConexion) values (@Pass, @UltConexion)");
            datos.AgregarParametro("@Pass", nuevo.Seguridad.Contraseña);
            datos.AgregarParametro("@UltConexion", nuevo.Seguridad.UltimaConexion); 
            datos.EjecutarConsulta();
        } 

        public void AgregarUsuario(Usuario nuevo, Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("insert into Usuario (LegajoUsuario, DNI, FechaIngreso, Seguridad, Perfil) values (@LegajoUsuario, @DNI, @FechaIngreso, (select MAX(IdSeguridad) from Seguridad) , @Perfil);");
            datos.AgregarParametro("@LegajoUsuario", nuevo.LegajoUsuario);
            datos.AgregarParametro("@FechaIngreso", nuevo.FechaIngreso);
            datos.AgregarParametro("@DNI", persona.DNI); 
            datos.AgregarParametro("@Perfil", nuevo.Perfil.IdPerfil);
            datos.EjecutarConsulta();
        }

        public bool ModificarUsuario(Usuario nuevo)
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
        public void BajaUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("update persona set estado = 0 where DNI = @DNI");
            datos.AgregarParametro("@DNI", nuevo.DNI);
            datos.EjecutarConsulta();
        }

        public void RecuperarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.SetearQuery("update persona set estado = 1 where DNI = @DNI");
            datos.AgregarParametro("@DNI", nuevo.DNI);
            datos.EjecutarConsulta();
        }
    }
}
