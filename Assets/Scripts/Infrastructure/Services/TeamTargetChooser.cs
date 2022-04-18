using System.Collections.Generic;
using Fighters;
using Teams;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services
{
    public class TeamTargetChooser : ITargetChooser
    {
        private readonly TeamsContainer teamsContainer;
        private Dictionary<Team, Transform> targetsForTeams = new Dictionary<Team, Transform>();

        [Inject]
        public TeamTargetChooser(TeamsContainer teamsContainer)
        {
            this.teamsContainer = teamsContainer;
        }
        public Transform GetTarget(Fighter fighterComp)
        {
            Transform returnedFighter=CheckTeamInDictionary(fighterComp);
            if (returnedFighter == null)
            {
                returnedFighter = FindNearestForTeam(fighterComp, returnedFighter);

                targetsForTeams[fighterComp.myTeam] = returnedFighter;
            }
            return returnedFighter;
        }

        private Transform FindNearestForTeam(Fighter fighterComp, Transform returnedFighter)
        {
            float currentDistance = Mathf.Infinity;
            for (int i = 0; i < teamsContainer.allActiveTeams.Count; i++)
            {
                if (i != fighterComp.myTeam.index)
                {
                    for (int j = 0; j < teamsContainer.allActiveTeams[i].myFighters.Count; j++)
                    {
                        float totalDistanceToFighter = 0;
                        for (int k = 0; k < fighterComp.myTeam.myFighters.Count; k++)
                        {
                            float distanceToFighter = Vector3.Distance(fighterComp.transform.position,
                                teamsContainer.allActiveTeams[i].myFighters[j].transform.position);
                            totalDistanceToFighter += distanceToFighter;
                        }

                        if (totalDistanceToFighter < currentDistance)
                        {
                            currentDistance = totalDistanceToFighter;
                            returnedFighter = teamsContainer.allActiveTeams[i].myFighters[j].transform;
                        }
                    }
                }
            }

            return returnedFighter;
        }

        private Transform CheckTeamInDictionary(Fighter fighterComp)
        {
            if (!targetsForTeams.ContainsKey(fighterComp.myTeam))
            {
                targetsForTeams.Add(fighterComp.myTeam, null);
            }

            return targetsForTeams[fighterComp.myTeam];
        }
    }
}