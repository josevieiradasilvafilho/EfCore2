using EfCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCore.Controler
{
    public class Pesquisa
    {
        /*
         * 4)	Monte uma classe C# para buscar todas as pessoas que não possuam uma conta.
         */

        public void Pesq_Conta_sem_Filtro()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = from t1 in db.Pessoa
                            join t2 in db.Conta on t1.Id equals t2.PessoaId
                            select new { Id = t1.Id, Nome = t1.Nome, Login = t2.Login };

                foreach (var item in query)
                {
                    Console.WriteLine("Pesq_Conta_sem_Filtro(): " + ";" + item.Id + ";" + item.Nome + ";" + item.Login + "Ok!");
                }

            }

        }
    }

}
