using InsuranceManagementSystem.Interfaces;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Decorators
{
    public abstract class PolicyServiceDecorator : IPolicyService
    {
        protected readonly IPolicyService _policyService;

        protected PolicyServiceDecorator(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        public virtual void ApplyPolicy(Policy policy)
        {
            _policyService.ApplyPolicy(policy);
        }
    }
}