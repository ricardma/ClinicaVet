using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _20170407_ClinicaVet.Models
{
    public class VetsDB : DbContext
    {
        //representar as tabelas a criar na Base de Dados
        public virtual DbSet<Donos> Donos { get; set; }
        public virtual DbSet<Animais> Animais { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }
        public virtual DbSet<Veterinarios> Veterinarios { get; set; }

        //especeficar onde será criada a base de dados, e meter no WEB.CONFIG a localizaçao
        public VetsDB() : base("LocalizacaoDaBD")
        {
            
        }
    }
}