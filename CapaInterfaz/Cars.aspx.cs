﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaTD.EN;
using LibreriaTD.CAD;
using System.Data;

namespace CapaInterfaz
{
    public partial class Cars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string matricula = Request.QueryString["matricula"];
            CocheEN car = new CocheEN();

            CocheEN Coche = car.SacarCar(matricula);

            DataTable tabla = new DataTable();

            tabla.Columns.Add("Matricula");
            tabla.Columns.Add("Marca");
            tabla.Columns.Add("Modelo");
            tabla.Columns.Add("Precio");
            tabla.Columns.Add("Puertas");
            tabla.Columns.Add("Motor");
            tabla.Columns.Add("Km");
            tabla.Columns.Add("Anyo");
            tabla.Columns.Add("Tipo");
            tabla.Columns.Add("Plazas");
            tabla.Columns.Add("Cambio");
            tabla.Columns.Add("Color");
            tabla.Columns.Add("Imagen");

           
                DataRow row = tabla.NewRow();
                row["Matricula"] = Coche.Matricula;
                row["Marca"] = Coche.Marca;
                row["Modelo"] = Coche.Modelo;
                row["Precio"] = Coche.Precio;
                row["Puertas"] = Coche.Puertas;
                row["Motor"] = Coche.Motor;
                row["Km"] = Coche.Km;
                row["Anyo"] = Coche.Anyo;
                row["Tipo"] = Coche.Tipo;
                row["Plazas"] = Coche.Plazas;
                row["Cambio"] = Coche.Cambio;
                row["Color"] = Coche.Color;
                row["Imagen"] = Coche.Imagen;
                tabla.Rows.Add(row);
            
            
            ListProducts.DataSource = tabla;
            ListProducts.DataBind();
        }
        
    }
}