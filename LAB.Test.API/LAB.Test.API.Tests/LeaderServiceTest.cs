using LAB.Test.API.Services;
using System;
using Xunit;

namespace LAB.Test.API.Tests
{
    public class LeaderServiceTest
    {
        private ILeaderService _leaderService;
        public LeaderServiceTest()
        {
            _leaderService = new LeaderService();
        }
        [Fact]
        public void CollectionContainsLeader()
        {
            int[] values = new int[] { 1, 1, 1, 1, 50 };
            var result = _leaderService.FindLeaderOfValues(values);

            Assert.Equal(1, result);
        }

        [Fact]
        public void CollectionDoesNotContainsLeader()
        {
            int[] values = new int[] { 2,2,2,2,2,3,4,4,4,6 };
            var result = _leaderService.FindLeaderOfValues(values);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void CollectionWithSingleDigit_SingleDigitIsLeader()
        {
            int[] values = new int[] { 3 };
            var result = _leaderService.FindLeaderOfValues(values);
            Assert.Equal(3, result);
        }
    }
}
