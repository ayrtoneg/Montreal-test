using Montreal.Domain.Core.Commands;
using Montreal.Domain.Core.Events;
using System.Threading.Tasks;

namespace Montreal.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
