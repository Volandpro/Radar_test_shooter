using System;
using System.Collections.Generic;
using Fighters;

namespace Teams
{
    public class Team
    {
        public List<Fighter> myFighters = new List<Fighter>();
        public Action<Team> OnRemoveFighter;
        public int index;

        public Team(int index) => 
            this.index = index;

        public void AddFighter(Fighter newFighter) => myFighters.Add(newFighter);

        public void RemoveFighter(Fighter fighter)
        {
            myFighters.Remove(fighter);
            OnRemoveFighter?.Invoke(this);
        }
    }
}