using Stride.Engine;

namespace StrideMountainGoap
{
    class StrideMountainGoapApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
