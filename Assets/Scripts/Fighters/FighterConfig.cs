namespace Fighters
{
    public class FighterConfig : IConfig
    {
        public readonly float MinSpeed = 1f;
        public readonly float MaxSpeed = 2f;
        public readonly float MaxHp = 70f;
        public readonly float MinHp = 130f;
        public readonly float MinDamage = 10;
        public readonly float MaxDamage = 20;
        public readonly float MinAttackRange = 10;
        public readonly float MaxAttackRange = 2;

        public IConfig GetConfig()
        {
            return this;
        }
    }
}