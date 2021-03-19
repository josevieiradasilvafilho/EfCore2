using EfCore.Controler;
using EfCore.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace EfCore
{
    class Program
    {
        static void Main(string[] args)
        {


            /*
             * 3)	Monte uma classe C# para cadastrar, atualizar, remover, buscar via identificador e buscar todos, genérica.
             * Update,classe generica
            */

            Pessoa_Crud pessoa1  = new Pessoa_Crud();
            pessoa1.Id_ = Guid.Parse("CB4D6157-947C-429D-BC93-DEA867E5DA58");
            pessoa1.Nome_ = "John Doe45";
            pessoa1.Documento_ = "3333333333333333333333";
            pessoa1.Email_ = "zezinho@gmail.com";
            pessoa1.Telefone_ = "12997411418";

            if (pessoa1.Buscar_Aux())
            {
                pessoa1.Atualizar();
            }
            Console.WriteLine();


            /*
             * Insert, classe genérica
             */
            Pessoa_Crud pessoa2 = new Pessoa_Crud();
            pessoa2.Id_ = Guid.NewGuid();
            pessoa2.Nome_ = "John Doe99";
            pessoa2.Documento_ = "3333333333333333333335";
            pessoa2.Email_ = "zezinho2@gmail.com";
            pessoa2.Telefone_ = "12997411417";
            pessoa2.Cadastrar();
            Console.WriteLine();

            /*
             *busca classe generica 
            */

            Pessoa_Crud pessoa3 = new Pessoa_Crud();
            pessoa3.Id_ = Guid.Parse("CB4D6157-947C-429D-BC93-DEA867E5DA58");
            pessoa3.Buscar();
            Console.WriteLine();

            /*
            * Update,classe generica
           */

            Pessoa_Crud pessoa4 = new Pessoa_Crud();
            pessoa4.Id_ = Guid.Parse("85A2247C-EF2B-4D98-9C90-C9139D035A3A");
            
            if (pessoa4.Buscar_Aux())
                pessoa4.Remover();
            else
                Console.WriteLine("Registro Inexistente!");

            Console.WriteLine();


            /*
            * Classe pesquisa
            */
            Pesquisa pessoa5 = new Pesquisa();
            pessoa5.Pesq_Conta_sem_Filtro();
            Console.WriteLine();

            /*
            *
            */
            Pesq_Conta();
            Console.WriteLine();

            /*
            *
            */
            Pesq_Venda();
            Console.WriteLine();

            /*
            *
            */
            Console.ReadKey();
            

        }


        static void Pesq_Venda()
        {
            /*
             * 1)	Escreva uma consulta em LINQ com base nas informações das tabelas acima. 
             * Buscar todas os produtos que possam ou não terem sido vendidos.
             */
            using (AppDbContext db = new AppDbContext())
            {
                var query = from t1 in db.Produto
                            join t2 in db.VendaProdutoCompetencias on t1.Id equals t2.ProdutoId into t3
                            from t2 in t3.DefaultIfEmpty()
                            select new { Id = t1.Id, Nome = t1.Nome, DtVenda = t2.DataVenda };

                foreach (var item in query)
                {
                    Console.WriteLine("Pesq_Venda():" + "" + item.Id + ";" + item.Nome + ";" + item.DtVenda + " Ok!");                    
                }

            }

        }


        static void Pesq_Conta()
        {
            /*
             * 2)	Monte uma consulta em LINQ com base nas informações das tabelas acima: buscar uma conta onde 
             * o Login seja: “login@sigcorp.com.br” e Senha: “S#1$g55g@g542”
             * 
             */
            using (AppDbContext db = new AppDbContext())
            {
                var query = from t1 in db.Conta
                            join t2 in db.Pessoa on t1.PessoaId equals t2.Id
                            where t2.Email.Contains("login@sigcorp.com.br") & t1.Senha.Contains("S#1$g55g@g542")
                            select new { t1.Id, t1.Login, t1.Senha, t1.IsBloqueado, t1.AlterarSenha, t2.Nome, t2.Documento, t2.Email, t2.Telefone };

                foreach (var item in query)
                {
                    Console.WriteLine("Pesq_Conta():" + ";" + item.Id + ";" + item.Login + ";" + item.Senha + ";" + item.IsBloqueado + ";" + item.AlterarSenha + ";" + item.Nome + ";" + item.Documento + ";" + item.Email + ";" + item.Telefone);                    
                }

            }

        }
       
    }
}
