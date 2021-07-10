using BuscaCEPXamarinSemBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuscaCEPXamarinSemBD.Backend.Repository
{
    class Cep_Repository
    {
        public void Create(Cep_Model cep_model)
        {
            // codigo para simular o enumeracao de ids do banco de dados
            cep_model.id = Conexao.Cep.Count();

            Conexao.Cep.Add(cep_model);
        }

        public Cep_Model Read(string filtro)
        {
            // converte para minusculo o dado enviado no filto
            filtro = filtro.ToLower();

            int id = 0;
            bool porId = int.TryParse(filtro, out id);

            var cepmodel = Conexao.Cep
                .Where(
                    cep_db => porId ? cep_db.id == id : false ||
                    cep_db.cep.ToLower().Contains(filtro) ||
                    cep_db.logradouro.ToLower().Contains(filtro) ||
                    cep_db.uf.ToLower().Contains(filtro)
                    )
                .FirstOrDefault();

            return cepmodel;
        }
    }
}
