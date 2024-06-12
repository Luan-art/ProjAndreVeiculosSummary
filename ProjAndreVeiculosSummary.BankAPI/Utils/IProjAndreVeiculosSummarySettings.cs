namespace ProjAndreVeiculosSummary.BankAPI.Utils
{
    public interface IProjAndreVeiculosSummarySettings
    {
        public string BankCollectionNome { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
