namespace Aop.InterceptionDemo
{
    public class FederationStarship : IStarship
    {
        private readonly string name;
        private const int WarpSpeedLimit = 10;

        public FederationStarship(string name)
        {
            this.name = name;
        }

        public void GoToWarp(double factor)
        {
            if (factor >= WarpSpeedLimit)
                throw new ImpossibleVelocityException();
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}