using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Aula9_AppHotel.Model
{
    public class Hospedagem
    {
        public CategoriaQuarto Quarto { get; set; }
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public int QuantidadeDias { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public double ValorTotal { get; set; }            


        /**
         * Calcula e retorna a diferença em dias da data de um CheckIn e um CheckOut.
         */ 
        public static int CalcularTempoEstadia(DateTime checkin, DateTime checkout)
        {
            int total_dias = checkout.Subtract(checkin).Days;

            if (total_dias <= 0)
                throw new Exception("Saída nao pode ser inferior a entrada.");

            return total_dias;
        }


        /**
         * Calcula o valor da hospedagem de acordo com o quarto escolhido, tipo de hospede,
         * e quantidade de hospedes.
         */ 
        public double CalcularValorEstadia()
        {
            double valor_adultos = (QuantidadeAdultos * Quarto.ValorDiariaAdulto) * QuantidadeDias;

            double valor_criancas = (QuantidadeCriancas * Quarto.ValorDiariaCrianca) * QuantidadeDias;

            double valor_hospedagem = valor_adultos + valor_criancas;

            return valor_hospedagem;
        }

    }
}
