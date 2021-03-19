using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EfCore.Model
{
    public class AppDbContext : DbContext
    {

        /*
         * Boletos
         */
        public DbSet<Boleto> Boleto { get; set; }
        public DbSet<Cedente> Cedente { get; set; }

        /*
        *Permissao de Conta 
        */
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<PermissaoConta> PermissaoConta { get; set; }
        
        /*
        * Venda
        */
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Produto> Produto { get; set; }        
        public DbSet<Competencia> Competencia { get; set; }
        public DbSet<VendaProdutoCompetencia> VendaProdutoCompetencias { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Password = 101418JvSf@" +
                                       @"Persist Security Info=True;" +
                                       @"Integrated Security=True;" +
                                       @"User ID=sa;" +
                                       @"Data Source=JOSEVIEIRAS\SQLEXPRESS;" +
                                      @"Initial Catalog=Db_SigCorp;");
            
        }


        

    }
}
