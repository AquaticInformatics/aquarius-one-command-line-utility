using CommandLine;
using ONE;
using System;
using System.Threading.Tasks;


namespace Aquarius.ONE.CLI.Commands
{
    [Verb("users", HelpText = "Retrieve all users.")]
    public class UserCommand: ICommand
    {
        async Task<int> ICommand.Execute(ClientSDK clientSDK)
        {
            CommandHelper.LoadConfig(clientSDK);

            var result = await clientSDK.Core.GetUsersAsync();
            if (result == null)
                return 0;
            foreach (var item in result)
            {
                
                Console.WriteLine($"{item.Id}: {item.FirstName}: {item.LastName}" );
            }
            return 1;
        }
    }
}
