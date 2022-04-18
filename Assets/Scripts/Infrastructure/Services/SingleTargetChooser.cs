using Fighters;
using Teams;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services
{
    public class SingleTargetChooser : ITargetChooser
    {
        private readonly TeamsContainer teamsContainer;

        [Inject]
        public SingleTargetChooser(TeamsContainer teamsContainer)
        {
            this.teamsContainer = teamsContainer;
        }
        public Transform GetTarget(Fighter fighterComp)
        {
            float currentDistance = Mathf.Infinity;
            Transform returnedFighter=null;
            for (int i = 0; i < teamsContainer.allActiveTeams.Count; i++)
            {
                if (i != fighterComp.myTeam.index)
                {
                    for (int j = 0; j < teamsContainer.allActiveTeams[i].myFighters.Count; j++)
                    {
                        float distanceToFighter = Vector3.Distance(fighterComp.transform.position,
                            teamsContainer.allActiveTeams[i].myFighters[j].transform.position);
                        if (distanceToFighter<currentDistance)
                        {
                            currentDistance = distanceToFighter;
                            returnedFighter= teamsContainer.allActiveTeams[i].myFighters[j].transform;
                        }
                    }
                   
                }
            }
            return returnedFighter;
        }
    }
}