using System;
using System.Collections.Generic;
using BookWorm_C_.Entities;
namespace BookWorm_C_.Services // Update the namespace to match your entity's namespace
{
    public interface IBeneficiaryRepository
    {
        IEnumerable<Beneficiary> GetAllBeneficiaries();
        Beneficiary GetBeneficiaryById(long beneficiaryId);
        void AddBeneficiary(Beneficiary beneficiary);
        void UpdateBeneficiary(Beneficiary beneficiary);
        void DeleteBeneficiary(long beneficiaryId);

    }
}
