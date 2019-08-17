using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDesk.Options;

namespace MDSManager2012.Console
{
    class Program
    {
        static int verbosity ;
        static bool list;

        static void Main(string[] args)
        {
            bool show_help = false;
            List<string> names = new List<string>();
            int repeat = 1;

            var p = new OptionSet() {
            { "l|list=", "the {NAME} of someone to greet.", (bool v) => list = v },
            { "m|model=", "list Models\n", (int v) => repeat = v },
            { "v", "increase debug message verbosity",
              v => { if (v != null) ++verbosity; } },
            { "h|help",  "show this message and exit", v => show_help = v != null },
        };

            List<string> prms;
            try
            {
                prms = p.Parse(args);
            }
            catch (OptionException e)
            {
                System.Console.WriteLine("greet: ");
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try 'greet --help' for more information.");
                return;
            }

            if (show_help)
            {
                ShowHelp(p);
                return;
            }

            string message;
            if (prms.Count > 0)
            {
                message = string.Join(" ", prms.ToArray());
                Debug("Using new message: {0}", message);
                System.Console.ReadLine();
            }
            else
            {
                ShowHelp(p);             
                System.Console.ReadLine();
            }

            if (list)
            {

            }
        }

        static void ShowHelp(OptionSet p)
        {
            System.Console.WriteLine("Usage: greet [OPTIONS]+ message");
            System.Console.WriteLine("Greet a list of individuals with an optional message.");
            System.Console.WriteLine("If no message is specified, a generic greeting is used.");
            System.Console.WriteLine();
            System.Console.WriteLine("Options:");
            p.WriteOptionDescriptions(System.Console.Out);
        }

        static void Debug(string format, params object[] args)
        {
            if (verbosity > 0)
            {
                System.Console.Write("# ");
                System.Console.WriteLine(format, args);
            }
        }

    }
}
