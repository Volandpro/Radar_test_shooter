using System.Collections.Generic;
using UnityEngine;

namespace Fighters
{
    public class TeamsConfig : IConfig
    {
        public Dictionary<int, Color> teamsColor = new Dictionary<int, Color>()
        {
            [0] = Color.red,
            [1] = Color.blue
        };
        
        public IConfig GetConfig()
        {
            return this;
        }
    }
}