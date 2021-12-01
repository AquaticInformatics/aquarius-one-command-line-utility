using CommandLine;
using ONE;
using System;
using System.Threading.Tasks;


namespace Aquarius.ONE.CLI.Commands
{
    [Verb("translation", HelpText = "Retrieves translations.")]
    public class TranslationCommand: ICommand
    {
        [Option('c', "culture", Required = false, HelpText = "Culture Code sutch as en for English")]
        public string Culture { get; set; }
        [Option('m', "modules", Required = false, HelpText = "Translation modules (Comma Delimites) such as FOUNDATION_LIBRARY, MOBILE_RIO")]
        public string Modules { get; set; }
        async Task<int> ICommand.Execute(ClientSDK clientSDK)
        {
            CommandHelper.LoadConfig(clientSDK);
            if (string.IsNullOrEmpty(Culture))
                Culture = "en";
            if (string.IsNullOrEmpty(Modules))
                Modules = "FOUNDATION_LIBRARY";
            var result = await clientSDK.Library.Geti18nKeysAsync(Culture, Modules);
            if (result == null)
                return 0;
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Type}: {item.Value}" );
            }
            return 1;
        }
    }
}
