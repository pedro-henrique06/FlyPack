using FlyPack.Domain.Entities;

namespace FlyPack.Application.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
