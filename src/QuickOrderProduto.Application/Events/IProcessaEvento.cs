namespace QuickOrderProduto.Core.Application.Events
{
    public interface IProcessaEvento
    {
        void Processa(string mensagem);
    }
}
