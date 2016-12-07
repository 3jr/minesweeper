using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;
using System.IO;

namespace Minesweeper
{
    class Program
    {
        static void SolveGivenMinesweeper(string initAsText, out KnownMinesweeper minesweeper, out Dictionary<Coord, bool> isMineDict)
        {
            // add a ring of mines as border
            var f = initAsText.Split(new[] { Environment.NewLine, "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var knownNumbers = new Dictionary<Coord, int>();
            isMineDict = new Dictionary<Coord, bool>();

            for (int x = -1; x <= f[0].Length; x++)
            {
                isMineDict.Add(new Coord(x: x, y: -1), true);
            }

            for (int y = 0; y < f.Length; y++)
            {
                isMineDict.Add(new Coord(x: -1, y: y), true);
                if (f[y].Length != f[0].Length) { throw new Exception("Every line in the File must contain the same number of character"); }
                for (int x = 0; x < f[y].Length; x++)
                {
                    bool topBottom = x == 0 || x == f[y].Length;
                    bool rightLeft = y == 0 || y == f.Length;

                    if (char.IsDigit(f[y][x]))
                    {
                        int n = int.Parse(f[y][x].ToString());
                        if (topBottom && rightLeft)
                        {
                            n += 5;
                        }
                        else if (topBottom || rightLeft)
                        {
                            n += 3;
                        }
                        knownNumbers.Add(new Coord(x, y), n);
                        isMineDict.Add(new Coord(x, y), false);
                    }
                    else
                    {
                        if (f[y][x] == '*')
                        {
                            isMineDict.Add(new Coord(x, y), true);
                        }
                    }
                }
                isMineDict.Add(new Coord(x: f[y].Length, y: y), true);
            }

            for (int x = -1; x <= f[0].Length; x++)
                isMineDict.Add(new Coord(x, y: f.Length), true);

            minesweeper = new KnownMinesweeper(knownNumbers);
        }

        static Dictionary<Coord, bool> ParseInitField(string initAsText)
        {
            var f = initAsText.Split(new[] { Environment.NewLine, "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<Coord, bool> isMine = new Dictionary<Coord, bool>();
            for (int y = 0; y < f.Length; y++)
            {
                if (f[y].Length != f[0].Length) { throw new Exception("Every line in the File must contain the same number of character"); }
                for (int x = 0; x < f[y].Length; x++)
                {
                    switch (f[y][x])
                    {
                        case '*':
                            isMine.Add(new Coord(x, y), true);
                            break;
                        case ' ':
                            isMine.Add(new Coord(x, y), false);
                            break;
                    }
                }
            }
            return isMine;
        }
        static int? ParseMaybeIntOption(int? defaultValue, CommandOption option)
        {
            int parseValue = 0;
            if (option.HasValue() && !int.TryParse(option.Value(), out parseValue))
            {
                Console.WriteLine(option.LongName + " must be a integer number");
                System.Environment.Exit(1);
            }
            if (option.HasValue())
            {
                return parseValue;
            }
            else
            {
                return defaultValue;
            }
        }
        static double ParseDoubleOption(double defaultValue, CommandOption option)
        {
            var value = defaultValue;
            if (option.HasValue() && !double.TryParse(option.Value(), out value))
            {
                Console.WriteLine(option.LongName + " must be a decimal number");
                System.Environment.Exit(1);
            }
            return value;
        }
        static void Main(string[] args)
        {
            CommandLineApplication cli =
                new CommandLineApplication(throwOnUnexpectedArg: true);

            cli.Description = "Randomly places mines and solves an ever expanding area";

            Func<bool> coords;
            {
                var opt = cli.Option(
                        "-c",
                        "Show a coordinate system. @ marks the origin.",
                        CommandOptionType.NoValue
                );
                coords = () => opt.HasValue();
            }
            Func<int?> seed;
            {
                var opt = cli.Option(
                        "-s <seed>",
                        "The seed that determines where mines are",
                        CommandOptionType.SingleValue
                );
                seed = () => ParseMaybeIntOption(defaultValue: null, option: opt);
            }
            Func<double> probability;
            {
                var opt = cli.Option(
                    "-p <probability>",
                    "The probability that a given spot is a mine. Default is: 60.0 / (16 * 16)",
                    CommandOptionType.SingleValue
                );
                probability = () => ParseDoubleOption(defaultValue: 60.0 / (16 * 16), option: opt);
            }
            cli.Command("run",
                (target) =>
                {
                    target.Description = "Randomly places mines and solves an ever expanding area";
                    target.HelpOption("-? | -h | --help");
                    target.ShowInHelpText = true;
                    target.OnExecute((Func<int>)(() =>
                    {
                        var minesweeper = new Minesweeper(probability(), seed: seed());
                        var board = new Board(minesweeper);
                        var solver = new Solver(board);
                        board.Print(coords());
                        while (true)
                        {
                            Console.ReadKey();
                            Console.WriteLine("Step {0} --------- Press key to continue ---------", solver.Step);
                            solver.SolveStep();
                            board.Print(coords());
                        }
                    }));
                });
            cli.Command("screensaver",
                (target) =>
                {
                    target.Description = "Like run but solves 40 steps consecutively and restarts";
                    target.HelpOption("-? | -h | --help");
                    target.ShowInHelpText = true;
                    target.OnExecute((Func<int>)(() =>
                    {
                        while (true)
                        {
                            var minesweeper = new Minesweeper(probability(), seed: seed());
                            var board = new Board(minesweeper);
                            var solver = new Solver(board);
                            board.Print(coords());
                            for (int i = 0; i < 40; i++)
                            {
                                Console.WriteLine("Step {0} --------- Press key to continue ---------", solver.Step);
                                solver.SolveStep();
                                board.Print(coords());
                            }
                        }
                    }));
                });
            cli.Command("with-initial",
              (target) =>
              {
                  target.Description = "Like run but has an initial configuration that specifies some mine spots and some non mine spots";
                  target.HelpOption("-? | -h | --help");
                  target.ShowInHelpText = true;
                  CommandArgument initialFile = target.Argument(
                    "file",
                    "A file with an initial configuration. '*' is a known mine ' ' known free spot and everything else might be a mine depending on chance",
                    multipleValues: false
                    );
                  target.OnExecute((Func<int>)(() =>
                  {
                      var isMineDict = ParseInitField(File.ReadAllText(initialFile.Value));
                      var minesweeper = new Minesweeper(probability(), isMineDict, seed());
                      var board = new Board(minesweeper, isMineDict);
                      var solver = new Solver(board, isMineDict.Where(e => !e.Value).Select(e => board[e.Key]).ToList());
                      board.Print(coords());
                      while (true)
                      {
                          Console.ReadKey();
                          Console.WriteLine("Step {0} --------- Press key to continue ---------", solver.Step);
                          solver.SolveStep();
                          board.Print(coords());
                      }
                  }));
              });
            cli.Command("solve",
              (target) =>
              {
                  target.Description = "Solve a given minesweeper and show what you can uncover next";
                  target.HelpOption("-? | -h | --help");
                  target.ShowInHelpText = true;
                  CommandArgument initialFile = target.Argument(
                    "file",
                    "A file with an initial configuration. '*' is a known mine a digit is a known free spot with that number of adjacent mines",
                    multipleValues: false
                    );
                  target.OnExecute((Func<int>)(() =>
                  {
                      KnownMinesweeper minesweeper;
                      Dictionary<Coord, bool> isMineDict;
                      SolveGivenMinesweeper(File.ReadAllText(initialFile.Value), out minesweeper, out isMineDict);
                      var board = new Board(minesweeper, isMineDict);
                      var solver = new Solver(board, isMineDict.Where(e => !e.Value).Select(e => board[e.Key]).ToList());
                      board.Print(coords());
                      solver.SolveStep();
                      Console.WriteLine("\n\nAfter solve step:\n\n");
                      board.Print(coords());
                      Console.WriteLine("\nThese tiles can be uncoved next:");
                      Console.WriteLine(string.Join("\n", minesweeper.SoverTriedToUncover.Select(c => c.ToString()).ToArray()));
                      return 0;
                  }));
              });
            cli.HelpOption("-? | -h | --help");

            cli.OnExecute((Func<int>)(() =>
            {
                cli.ShowHint();
                return 0;
            }));

            //try
            //{
            cli.Execute(args);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}
