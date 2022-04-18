using System.Collections.Generic;
using Fighters;
using Zenject;

namespace Teams
{
    public class TeamsContainer
    {
        public List<Team> allActiveTeams = new List<Team>();
        
        public void UpdateTargetChooserForFighters(ITargetChooser targetChooser)
        {
            for (int i = 0; i < allActiveTeams.Count; i++)
            {
                for (int j = 0; j < allActiveTeams[i].myFighters.Count; j++)
                {
                    allActiveTeams[i].myFighters[j].UpdateTargetChooser(targetChooser);
                }
            }
        }
        public void Add(Team newTeam) => allActiveTeams.Add(newTeam);

        public void ClearTeams()
        {
            for (int i = 0; i < allActiveTeams.Count; i++)
            {
                for (int j = 0; j < allActiveTeams[i].myFighters.Count; j++)
                {
                    UnityEngine.Object.Destroy(allActiveTeams[i].myFighters[j].gameObject);
                }
                allActiveTeams[i].myFighters.Clear();
            }
            allActiveTeams.Clear();
        }
    }
}