namespace FlyPack.Presentation.ViewModels
{
    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; } = true;
    }

}
