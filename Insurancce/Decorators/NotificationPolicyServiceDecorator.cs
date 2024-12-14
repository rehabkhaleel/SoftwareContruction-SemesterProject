using InsuranceManagementSystem.Interfaces;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Decorators
{
    public class NotificationPolicyServiceDecorator : PolicyServiceDecorator
    {
        public NotificationPolicyServiceDecorator(IPolicyService policyService)
            : base(policyService) { }

        public override void ApplyPolicy(Policy policy)
        {
            base.ApplyPolicy(policy);
            Console.WriteLine("Notification: Policy applied: " + policy.PolicyName);
        }
    }
}
