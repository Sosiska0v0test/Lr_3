using System.Text;
using modified_Lr_3.Entity;
using modified_Lr_3.GameAccounts;
using modified_Lr_3.Repository;
using modified_Lr_3.Service;
using modified_Lr_3.Entity.GameEntities;

namespace modified_Lr_3
{
    public abstract class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DbContext dbContext = new DbContext();
            PlayerRepository playerRepository = new PlayerRepository(dbContext.Players);
            GameRepository gameRepository = new GameRepository(dbContext.Games);
            IGameService gameService = new GameService(playerRepository, gameRepository);

            PlayerEntity player1 = new PlayerEntity(new StandardGameAccount("Liza", 466));
            PlayerEntity player2 = new PlayerEntity(new ReducedLossGameAccount("Sofia", 183));

            gameService.CreateAccount(player1);
            gameService.CreateAccount(player2);

            GameEntity standardGame1 = new StandardGameEntity(25, player1.Id);
            gameService.CreateGame(standardGame1);

            GameEntity trainingGame1 = new TrainingGameEntity(player1.Id);
            gameService.CreateGame(trainingGame1);

            GameEntity randomGame1 = new RandomRatingGameEntity(player1.Id);
            gameService.CreateGame(randomGame1);

            GameEntity standardGame2 = new StandardGameEntity(15, player2.Id);
            gameService.CreateGame(standardGame2);

            GameEntity trainingGame2 = new TrainingGameEntity(player2.Id);
            gameService.CreateGame(trainingGame2);

            GameEntity randomGame2 = new RandomRatingGameEntity(player2.Id);
            gameService.CreateGame(randomGame2);


            Console.WriteLine("Список гравців:");
            foreach (var player in gameService.ReadAccounts())
            {
                Console.WriteLine($"{player.Id}. {player.UserName} - Rating: {player.CurrentRating}");
            }

            PrintPlayerGamesInfo(gameService, player1);
            PrintPlayerGamesInfo(gameService, player2);


            Console.WriteLine("\nСписок всіх ігор:");
            foreach (var game in gameService.ReadGames())
            {
                PrintGameInfo(gameService, game);
            }
        }

        private static void PrintPlayerGamesInfo(IGameService gameService, PlayerEntity player)
        {
            Console.WriteLine($"\nСписок ігор для {player.UserName}:");
            foreach (var game in gameService.ReadPlayerGamesByPlayerId(player.Id))
            {
                PrintGameInfo(gameService, game);
            }
        }

        private static void PrintGameInfo(IGameService gameService, GameEntity game)
        {
            var result = gameService.IsPlayerWinner(game.PlayerId, game.Id) ? "Win" : "Lose";
            Console.WriteLine($"Game '{game.Id}' - Result: {result}, Rating Change: {game.ChangeOfRating}, " +
                              $"New Rating: {gameService.GetPlayerRating(game.PlayerId)}, Game Type: " +
                              $"{gameService.GetGameTypeName(game)}");
        }
    }
}