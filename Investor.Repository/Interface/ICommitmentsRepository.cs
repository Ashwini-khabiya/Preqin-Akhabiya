using Investor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository.Interface
{
    public interface ICommitmentsRepository
    {
        public List<Commitment> GetCommitmentsById(int id);
    }
}
