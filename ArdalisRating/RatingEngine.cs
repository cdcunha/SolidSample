using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        //public Logging.ConsoleLogger Logger { get; set; } = new Logging.ConsoleLogger();
        //public Persistence.FilePolicySource PolicySource { get; set; } = new Persistence.FilePolicySource();

        public decimal Rating { get; set; }
        public void Rate()
        {
            Logging.ConsoleLogger.Log("Starting rate.");

            Logging.ConsoleLogger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = Persistence.FilePolicySource.GetPolicyFromSource();

            var policy = Persistence.JsonPolicySerializer.GetPolicyFromJsonString(policyJson);

            if (policy == null)
            {
                throw new NullReferenceException($"The policy is null, verify the policy's file source: {Persistence.FilePolicySource.FileName}");
            }

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    Logging.ConsoleLogger.Log("Rating AUTO policy...");
                    Logging.ConsoleLogger.Log("Validating policy.");
                    if (string.IsNullOrEmpty(policy.Make))
                    {
                        Logging.ConsoleLogger.Log("Auto policy must specify Make");
                        return;
                    }
                    if (policy.Make == "BMW")
                    {
                        if (policy.Deductible < 500)
                        {
                            Rating = 1000m;
                        }
                        Rating = 900m;
                    }
                    break;

                case PolicyType.Land:
                    Logging.ConsoleLogger.Log("Rating LAND policy...");
                    Logging.ConsoleLogger.Log("Validating policy.");
                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        Logging.ConsoleLogger.Log("Land policy must specify Bond Amount and Valuation.");
                        return;
                    }
                    if (policy.BondAmount < 0.8m * policy.Valuation)
                    {
                        Logging.ConsoleLogger.Log("Insufficient bond amount.");
                        return;
                    }
                    Rating = policy.BondAmount.GetValueOrDefault() * 0.05m;
                    break;

                case PolicyType.Life:
                    Logging.ConsoleLogger.Log("Rating LIFE policy...");
                    Logging.ConsoleLogger.Log("Validating policy.");
                    if (policy.DateOfBirth == DateTime.MinValue)
                    {
                        Logging.ConsoleLogger.Log("Life policy must include Date of Birth.");
                        return;
                    }
                    if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                    {
                        Logging.ConsoleLogger.Log("Centenarians are not eligible for coverage.");
                        return;
                    }
                    if (policy.Amount == 0)
                    {
                        Logging.ConsoleLogger.Log("Life policy must include an Amount.");
                        return;
                    }
                    int age = DateTime.Today.Year - policy.DateOfBirth.GetValueOrDefault().Year;
                    if (policy.DateOfBirth.GetValueOrDefault().Month == DateTime.Today.Month &&
                        DateTime.Today.Day < policy.DateOfBirth.GetValueOrDefault().Day ||
                        DateTime.Today.Month < policy.DateOfBirth.GetValueOrDefault().Month)
                    {
                        age--;
                    }
                    decimal baseRate = policy.Amount.GetValueOrDefault() * age / 200;
                    if (policy.IsSmoker.GetValueOrDefault())
                    {
                        Rating = baseRate * 2;
                        break;
                    }
                    Rating = baseRate;
                    break;

                default:
                    Logging.ConsoleLogger.Log("Unknown policy type");
                    break;
            }

            Logging.ConsoleLogger.Log("Rating completed.");
        }
    }
}
