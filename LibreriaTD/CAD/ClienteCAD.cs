﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibreriaTD.EN;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace LibreriaTD.CAD
{
    class ClienteCAD
    {
        private string conexion;
        public ClienteCAD()
        {
             conexion = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\TrueDriveBD.mdf';Integrated Security=True";
        }

        public bool InsertarCliente(ClienteEN newCliente)
        {
            bool insert = false;
            string comando = "Insert into Cliente (nif,nombre,apellidos,email,direccion,ciudad,pais,telefono,interesadoEn,codigopostal,fechaNacimiento,usuario,contraseña,provincia) values ('"+ newCliente.nifCliente+"','"+newCliente.nombreCliente+"','"+newCliente.apellidosCliente+ "','" + newCliente.emailCliente + "','" + newCliente.direccionCliente+"','"+newCliente.ciudadCliente+"','"+newCliente.paisCliente+"','"+newCliente.telefonoCliente+"','"+newCliente.interesadoEnCliente+"','"+newCliente.codpCliente+"','"+newCliente.anyoNacimientoCliente+"','"+newCliente.usuCliente+"','"+newCliente.passCliente+"','"+newCliente.provCliente+"')";
           
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand(comando, con);
            

            if (cmd.ExecuteNonQuery() == 1)
                insert = true;
            else
                insert = false;
            
            con.Close();
            return insert;
           
        }

        public bool BorrarCliente(string dni)
        {
            bool delete = false;
            string comando = "DELETE from Cliente WHERE nif ='" + dni + "'";

            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand(comando, con);
            

            if (cmd.ExecuteNonQuery() == 1)
                delete = true;
            else
                delete = false;

            con.Close();
            return delete;
        }

        public bool ModCliente(ClienteEN c)
        {
            bool isModify = false;
            string comando = "UPDATE Cliente SET nombre='"+c.nombreCliente+"',apellidos='"+c.apellidosCliente+"',email='"+c.emailCliente+"',direccion='"+c.direccionCliente+"',ciudad='"+c.ciudadCliente+"',pais='"+c.paisCliente+"',telefono='"+c.telefonoCliente+"',interesadoEn='"+c.interesadoEnCliente+"',codigopostal="+c.codpCliente+",fechaNacimiento='"+c.anyoNacimientoCliente+"',usuario='"+c.usuCliente+"',contraseña='"+c.passCliente+"',provincia='"+c.provCliente+"' WHERE nif='"+c.nifCliente+"'";
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(comando, con);
                cmd.ExecuteNonQuery();
                isModify = true;
            }
            catch (Exception e)
            { }


            con.Close();
            return isModify;
        }

        public bool ConsultarUsuario(string usuario, string pass)
        {
            bool consult = false;
            string comando = "SELECT usuario,contraseña FROM Cliente WHERE usuario ='"+usuario+"' AND contraseña ='"+pass+"'" ;
            SqlConnection con = new SqlConnection(conexion);
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(comando, con);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read() == true)
                    consult = true;
                else
                    consult = false;
                
            }
            catch (Exception e)
            {
                consult = false;
            }     

            con.Close();
            return consult;
        }

        public ClienteEN sacarCliente(string usuario)
        {
            ClienteEN cliente = new ClienteEN();
            string comando = "SELECT * FROM Cliente WHERE usuario='" + usuario + "'";
            SqlConnection con = new SqlConnection(conexion);
            try
            {
                con.Open();
                SqlCommand c = new SqlCommand(comando, con);
                SqlDataReader dr = c.ExecuteReader();
                dr.Read();
                cliente = new ClienteEN((string)dr[0],(string)dr[1],(string)dr[2],(string)dr[3],(string)dr[4],
                        (string)dr[5],(string)dr[6],(string)dr[7],(string)dr[8],(int)dr[9],(string)dr[10],
                        (string)dr[11],(string)dr[12],(string)dr[13]);
               
                dr.Close();
            }
            catch (Exception e)
            {

            }
            con.Close();
            return cliente;
        }
    }
}
