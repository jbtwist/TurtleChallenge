using System.Configuration;
using System.Collections.Specialized;

class Challenge
{
    static string[] ReadInstructionsFile(){
        string[] instructions = Array.Empty<string>();
        if (File.Exists("instructions.txt"))
        {
            string file = File.ReadAllText("instructions.txt");
            instructions = file.Split(" ");
            Console.WriteLine(file);
        } else {
            throw new FileLoadException();
        }
        return instructions;
    }

    static void Main(string[] args)
    {
        NameValueCollection config = ConfigurationManager.AppSettings;

        try
        {        
            string[] instructions = ReadInstructionsFile();   

            // Managing config file
            string height_ = config["height"] ?? throw new FormatException();
            string width_ = config["width"] ?? throw new FormatException();
            string start_ = config["start"] ?? throw new FormatException();
            string dir_ = config["dir"] ?? throw new FormatException();
            string mines_ = config["mines"] ?? throw new FormatException();
            string exit_ = config["exit"] ?? throw new FormatException();       


            int height = int.Parse(height_);
            int width = int.Parse(width_);
            string[] start_array = start_.Split(",");
            string[] mines_array = mines_.Split(",");
            string[] exit_array = exit_.Split(",");


            int[] start = Array.ConvertAll(start_array, int.Parse);
            int[] mines = Array.ConvertAll(mines_array, int.Parse);
            int[] exit = Array.ConvertAll(exit_array, int.Parse);

            if (!Enum.TryParse(dir_, out Direction dir))
            {
                throw new FormatException();
            }

            if (start.Length != 2) throw new FormatException();
            if (exit.Length != 2) throw new FormatException();
            if (mines.Length % 2 != 0) throw new FormatException(); //If mines module is not pair, it means it cannot be an array of positions.

            // Generating instances
            Turtle turtle = new (dir, start[0], start[1]);
            Board board = new (height, width, turtle, mines, exit);

            //Execute the instructions and  handle the gameState
            foreach(string i in instructions){
                switch (i)
                {
                    case "r":
                        turtle.Rotate();
                        break;
                    case "m":
                        board.Move();
                        break;
                }
                switch (turtle.gameState)
                {
                    case GameState.WIN:
                        Console.WriteLine("You found the exit. You win!");
                        return;                        
                    case GameState.LOSE:
                        Console.WriteLine("You found a mine. You lose :(");
                        return;
                    case GameState.ALIVE:
                        break;
                }            
            }
            Console.WriteLine("There are no more movements and you didn't find the exit.");
            return;      
        } catch (FormatException) {
            Console.WriteLine("Error loading settings, check that every key is well formatted.");
        } catch (FileLoadException) {
            Console.WriteLine("There's no instructions file.");
        } catch (OverlapException e) {
            Console.WriteLine(e.Message);
        }
    }
}

