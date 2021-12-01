using CommandLine;
using ONE;
using System;
using System.Threading.Tasks;


namespace Aquarius.ONE.CLI.Commands
{
    [Verb("userinfo", HelpText = "Retrieve User Information.")]
    public class UserInfoCommand: ICommand
    {
       
        async Task<int> ICommand.Execute(ClientSDK clientSDK)
        {
            CommandHelper.LoadConfig(clientSDK);

            var result = await clientSDK.Authentication.GetUserInfo();
            if (result == null)
                return 0;
            else
            {
                Console.WriteLine(result);
                return 1;
            }
        }
    }
}
