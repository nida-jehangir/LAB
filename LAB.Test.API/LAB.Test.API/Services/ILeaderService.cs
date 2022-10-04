using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB.Test.API.Services
{
    public interface ILeaderService
    {
        public int FindLeaderOfValues(int[] values);
    }
}
