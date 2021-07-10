using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaCEPXamarinSemBD.Model
{
    public class Pessoa_Model
    {
		private long _cpf;
		public string Cpf
		{
			get => FormataComPontos(_cpf);
			set => _cpf = TiraPonto(value);
		}

		public string Nome { get; set; }

		private string FormataComPontos(long cpf)
		{
			string retorno = null;
			string strCpf = cpf.ToString();
			retorno = $"{strCpf.Substring(0, 3)}." +
				$"{strCpf.Substring(3, 3)}." +
				$"{strCpf.Substring(6, 3)}-" +
				$"{strCpf.Substring(9, 2)}";
			return retorno;
		}
		private long TiraPonto(string cpf)
		{
			var cpfSemPonto = cpf.Replace(".", "");
			var cpfSemTraco = cpfSemPonto.Replace("-", "");
			var cpfInt = Convert.ToInt64(cpfSemTraco);

			return cpfInt;
		}
	}
}
