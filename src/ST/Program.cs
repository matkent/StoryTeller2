﻿using System;
using FubuCore.CommandLine;
using StoryTeller.CommandLine;

namespace ST
{
    internal class Program
    {
        private static bool success;

        public static int Main(string[] args)
        {
            try
            {
                var factory = new CommandFactory();
                factory.RegisterCommands(typeof (RunCommand).Assembly);

                var executor = new CommandExecutor(factory);
                success = executor.Execute(args);
            }
            catch (CommandFailureException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: " + e.Message);
                Console.ResetColor();
                return 1;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: " + ex);
                Console.ResetColor();
                return 1;
            }
            return success ? 0 : 1;
        }
    }
}