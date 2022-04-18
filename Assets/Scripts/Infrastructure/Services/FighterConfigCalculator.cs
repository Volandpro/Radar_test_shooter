using Fighters;
using Teams;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services
{
    public class FighterConfigCalculator : IConfigCalculator
    {
        private readonly FighterConfig fighterConfig;
        private readonly FighterShapesConfig fighterShapesConfig;
        private readonly TeamsConfig teamsConfig;

        [Inject]
        public FighterConfigCalculator(FighterConfig fighterConfig, TeamsConfig teamsConfig,FighterShapesConfig fighterShapesConfig)
        {
            this.fighterConfig = fighterConfig;
            this.fighterShapesConfig = fighterShapesConfig;
            this.teamsConfig = teamsConfig;
        }

        public float CalculateMoveSpeed() => 
            Random.Range(fighterConfig.MinSpeed, fighterConfig.MaxSpeed);

        public Color GetColor(Team teamToColor) => 
            teamsConfig.teamsColor[teamToColor.index];

        public float CalculateHp() => 
            Random.Range(fighterConfig.MinHp, fighterConfig.MaxHp);

        public float CalculateDamage() => 
            Random.Range(fighterConfig.MinDamage, fighterConfig.MaxDamage);

        public float CalculateAttackRange() => 
            Random.Range(fighterConfig.MinAttackRange, fighterConfig.MaxAttackRange);

        public Sprite GetSprite()
        {
            return fighterShapesConfig.allShapes[Random.Range(0, fighterShapesConfig.allShapes.Length)];
        }
    }
}