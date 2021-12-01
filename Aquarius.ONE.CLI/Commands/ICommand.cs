using ONE;
using System.Threading.Tasks;

namespace Aquarius.ONE.CLI.Commands
{
    public interface ICommand
    {
        Task<int> Execute(ClientSDK clientSDK);
    }
}
