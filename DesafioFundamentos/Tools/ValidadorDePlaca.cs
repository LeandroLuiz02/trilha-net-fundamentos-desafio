using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Tools
{
	public class ValidadorDePlaca
	{
		public bool Valida(string placa)
		{
			if (ValidadorPlacaNova(placa))
			{
				Console.WriteLine("Novo formato MERCOSUL de placa inserido");
				return true;
			}
			else if (ValidadorPlacaAntiga(placa))
			{
				Console.WriteLine("Antigo formato MERCOSUL de placa inserido");
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool ValidadorPlacaAntiga(string placa)
		{
			if (Regex.IsMatch(placa, @"^[A-Z]{3}-\d{4}$")) return true;
			else return false;
		}

		private bool ValidadorPlacaNova(string placa)
		{
			if (Regex.IsMatch(placa, @"^[A-Z]{3}\d[A-Z]\d{2}$")) return true;
			else return false;
		}
	}
}