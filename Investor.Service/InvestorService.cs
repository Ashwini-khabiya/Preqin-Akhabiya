using Investor.Models;
using Investor.Repository;
using Investor.Repository.Interface;
using Investor.Service;
using Investor.Service.Interface;
using SQLitePCL;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Investor.Service
{
    public class InvestorService : IInvestorService
    {
        private readonly IInvestorRepository _investorRepository;
        private readonly ICommitmentsRepository _commitmentRepository;
        public InvestorService(IInvestorRepository investorRepository, ICommitmentsRepository commitmentRepository) {
            _investorRepository = investorRepository;
            _commitmentRepository = commitmentRepository;
        }

        public List<InvestorDto> GetInvestors() {
            var investors = _investorRepository.GetAllInvestors();
            var InvestorDtos = new List<InvestorDto>();

            foreach (var investor in investors)
            {

                var commitments = investor.Commitments;
                var totalCommitmentAmount = commitments.Sum(C => C.Amount);
                var InvestorDto = new InvestorDto {
                    Id = investor.Id,
                    Name = investor.Name,
                    InvestorType = investor.InvestorType,
                    Country = investor.Country,
                    DateAdded = investor.DateAdded,
                    LastUpdated = investor.LastModifiedDate,
                    TotalCommitmentAmount = totalCommitmentAmount,
                };

                InvestorDtos.Add(InvestorDto);
            }

            return InvestorDtos;
        }

        public InvestorDto GetInvestorById(int id) {

            var investor = _investorRepository.GetInvestorById(id);
            if (investor == null) {
                return null;
            }

            var commitments = investor.Commitments;
            var totalCanitrentamount = commitments.Sum(C => C.Amount);
            var InvestonData = new InvestorDto {
                Id = investor.Id,
                Name = investor.Name,
                InvestorType = investor.InvestorType,
                Country = investor.Country,
                DateAdded = investor.DateAdded,
                LastUpdated = investor.LastModifiedDate,
                Commitments = commitments,
                TotalCommitmentAmount = totalCanitrentamount
                
            };
           
            return InvestonData;
        }

    }
}

