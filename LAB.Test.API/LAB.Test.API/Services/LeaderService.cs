using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB.Test.API.Services
{
    public class LeaderService : ILeaderService
    {
        public LeaderService()
        {

        }
        public int FindLeaderOfValues(int[] values)
        {
            const int noLeader = -1;
            if (values.Length == 0)
                return noLeader;

            var halfOfTotal = Math.Ceiling((decimal)(values.Length/2));

            var groupByValues = values.GroupBy(i => i);
            var mostOccuringValue = groupByValues.OrderByDescending(g => g.Count()).First();
            if (mostOccuringValue.Count() > halfOfTotal)
                return mostOccuringValue.Key;
            else
                return noLeader;
        }
    }
}
