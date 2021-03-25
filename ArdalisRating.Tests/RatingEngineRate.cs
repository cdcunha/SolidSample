using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = Persistence.JsonPolicySerializer.GetJsonStringFromPolicy(policy);
            Persistence.FilePolicySource.SavePolicyToSource(json);

            var engine = new RatingEngine();
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = Persistence.JsonPolicySerializer.GetJsonStringFromPolicy(policy);
            Persistence.FilePolicySource.SavePolicyToSource(json);

            var engine = new RatingEngine();
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0M, result);
        }

        [Fact]
        public void ReturnsDefaultPolicyFromEmptyJsonString()
        {
            var inputJson = "{}";
            var result = Persistence.JsonPolicySerializer.GetPolicyFromJsonString(inputJson);

            var policy = new Policy();

            Assert.True(Equals(result, policy));
        }
    }
}
