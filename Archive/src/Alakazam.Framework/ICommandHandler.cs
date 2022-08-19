using System.Threading;
using System.Threading.Tasks;

namespace Alakazam.Framework
{
    public interface ICommandHandler<TCommand,TResult>
        where TCommand : ICommand
    {
        Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}