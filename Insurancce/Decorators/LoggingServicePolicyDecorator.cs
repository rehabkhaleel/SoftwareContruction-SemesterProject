using InsuranceManagementSystem.Interfaces;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Decorators
{
    public class LoggingPolicyServiceDecorator : PolicyServiceDecorator
    {
        public LoggingPolicyServiceDecorator(IPolicyService policyService)
            : base(policyService) { }

        public override void ApplyPolicy(Policy policy)
        {
            Console.WriteLine("Logging: Applying policy: " + policy.PolicyName);
            base.ApplyPolicy(policy);
        }
    }
}
