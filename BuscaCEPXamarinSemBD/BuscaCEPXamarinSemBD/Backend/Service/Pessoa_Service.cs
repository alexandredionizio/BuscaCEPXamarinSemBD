using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaCEPXamarinSemBD.Backend.Service
{
    public class Pessoa_Service
    {
        //Pessoa_Repository pessoa_Repository = new Pessoa_Repository();

        //public void Criar(Pessoa_Model md)
        //{
        //    if (VerificaSeMaiorDeIdade(md.idade))
        //        pessoa_Repository.Criar(md);
        //    else
        //        throw new Exception("só pde ser salvo pessoas maiores de idade");
        //}

        internal bool VerificaSeMaiorDeIdade(string idade)
        {
            var intIdade = Convert.ToInt32(idade);

            if (intIdade >= 18)
                return true;
            else
                return false;

            /*
			 var intIdade = Convert.ToInt32(idade);
			 var ehMaiorDeIdade = intIdade >= 18
			 return ehMaiorDeIdade;
			 */

            // return Convert.ToInt32(idade) >= 18;
        }
    }
}
