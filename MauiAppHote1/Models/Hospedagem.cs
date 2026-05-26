namespace MauiAppHote1.Models
{
    class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QtnAdultos { get; set; }
        public int QtnCriancas { get; set; }
        public DateTime DatacheckIn { get; set; }
        public DateTime DatacheckOut { get; set; }
        public int Estadia
        {
            get => DatacheckOut.Subtract(DatacheckIn).Days;
        }

        public double ValorTotal
        {
            get
            {
                double valor_adultos = QtnAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criancas = QtnCriancas * QuartoSelecionado.ValorDiariaCrianca;

                double total = (valor_adultos + valor_criancas) * Estadia;

                return total;
            }
        }
    }
}
