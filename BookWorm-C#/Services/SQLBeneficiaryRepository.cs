using System;
using System.Collections.Generic;
using System.Linq;
using BookWorm_C_.Entities;
using BookWorm_C_.Services;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_C_.Services
{
    public class SQLBeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly BookWormContext _dbContext;

        public SQLBeneficiaryRepository(BookWormContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Beneficiary> GetAllBeneficiaries()
        {
            return _dbContext.Beneficiarys.Include(b => b.ProductBenMasters)
                .Include(b => b.RoyaltyCalculations)
                .ToList();
        }

        public Beneficiary GetBeneficiaryById(long beneficiaryId)
        {
            return _dbContext.Beneficiarys
                .Include(b => b.ProductBenMasters)
                .Include(b => b.RoyaltyCalculations)
                .FirstOrDefault(b => b.BeneficiaryId == beneficiaryId);
        }

        public void AddBeneficiary(Beneficiary beneficiary)
        {
            _dbContext.Beneficiarys.Add(beneficiary);
            _dbContext.SaveChanges();
        }

        public void UpdateBeneficiary(Beneficiary beneficiary)
        {
            _dbContext.Beneficiarys.Update(beneficiary);
            _dbContext.SaveChanges();
        }

        public void DeleteBeneficiary(long beneficiaryId)
        {
            var beneficiary = _dbContext.Beneficiarys.Find(beneficiaryId);
            if (beneficiary != null)
            {
                _dbContext.Beneficiarys.Remove(beneficiary);
                _dbContext.SaveChanges();
            }
        }
    }
}
