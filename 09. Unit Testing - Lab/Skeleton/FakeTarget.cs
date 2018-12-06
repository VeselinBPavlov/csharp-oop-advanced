namespace Skeleton
{
    using Skeleton.Contracts;

    public class FakeTarget : ITarget
    {
        public int Health { get; private set; } = 0;

        public int GiveExperience()
        {
            return 10;
        }

        public bool IsDead() => this.Health <= 0;

        public void TakeAttack(int attackPoints)
        {
            this.Health -= attackPoints;
        }
    }
}
