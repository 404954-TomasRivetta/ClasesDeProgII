﻿using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.Interfaz
{
    public interface IRecetaDAO
    {
        List<Ingrediente> TraerIngredientes();

        int TraerProximoIdReceta();

        bool CrearReceta(Receta oReceta);
    }
}