using InsuranceManagementSystem.Interfaces;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Servies
{

    public class PolicyService : IPolicyService
    {
        public void ApplyPolicy(Policy policy)
        {
            // Basic policy application logic
            Console.WriteLine("Applying policy: " + policy.PolicyName);
        }
    }
}
