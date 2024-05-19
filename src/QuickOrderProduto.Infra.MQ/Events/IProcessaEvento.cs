namespace QuickOrderProduto.Infra.MQ.Events
{
    public interface IProcessaEvento
    {
        void Processa(string mensagem);
    }
}
