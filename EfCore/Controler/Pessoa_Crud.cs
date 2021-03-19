using EfCore.Model;
using System;
using System.Linq;

namespace EfCore.Controler
{
    public class Pessoa_Crud
    {

        public Guid Id_ { get; set; }

        public string Nome_ { get; set; }

        public string Documento_ { get; set; }

        public string Email_ { get; set; }

        public string Telefone_ { get; set; }

        public void Buscar()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var query = from t1 in db.Pessoa
                                where t1.Id.Equals(Id_)
                                select new { t1.Id, t1.Nome, t1.Documento, t1.Email, t1.Telefone };

                    foreach (var item in query)
                    {
                        Console.WriteLine("Buscar():" + item.Id + ";" + item.Nome + ";" + item.Documento + ";" + item.Email + ";" + item.Telefone + ";" + " OK!");
                    }

                }

            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("Buscar(Erro): " + e.Source);

            }
        }
               
        public bool Buscar_Aux()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    //var Pessoas = db.Set<Model.Pessoa>();
                    var registro = db.Pessoa.Find(Id_);
                    if (registro.Id != null)
                    {
                        return true;
                    }
                    else return false;
                }

            }

            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("Buscar_Aux(Erro)", e.Source);
                return false;
            }

        }

        public void Cadastrar()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var Pessoas = db.Set<Model.Pessoa>();

                    Pessoas.Add(new Model.Pessoa { Id = Id_, Nome = Nome_, Documento = Documento_, Email = Email_, Telefone = Telefone_ });

                    db.SaveChanges();

                    Console.WriteLine("Cadastrar(): {0}", "Ok!");

                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("Err: {0}", e.Source);
                throw;
            }

        }

        public void Atualizar()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var Pessoas = db.Set<Model.Pessoa>();

                    Pessoas.Update(new Model.Pessoa { Id = Id_, Nome = Nome_, Documento = Documento_, Email = Email_, Telefone = Telefone_ });

                    db.SaveChanges();

                    Console.WriteLine("Atualizar(): {0}", "Ok!");
                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("Err: {0}", e.Source);
            }

        }

        public void Remover()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var Pessoas = db.Set<Model.Pessoa>();

                    Pessoas.Remove(new Model.Pessoa { Id = Id_});

                    db.SaveChanges();

                    Console.WriteLine("Deletar(): {0}", "Ok!");
                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("Err: {0}", e.Source);
            }

        }


    }
}
