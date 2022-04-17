using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingPractica.Domain.Entities;
using VuelingPractica.Infrastructure.Repositories.Contracts;

namespace VuelingPractica.Infrastructure.Repositories.Implementations
{
    public class TextFileRepository : IFileRepository<Registry>
    {
        public Registry Add(Registry entity)
        {
            throw new NotImplementedException();
        }
    }
}
