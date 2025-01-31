namespace FlyPack.Presentation.ViewModels
{
    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
