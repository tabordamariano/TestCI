using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IHousekeeperRepository
    {
        IQueryable<Housekeeper> GetHousekeepers();
    }

    public class HousekeeperRepository : IHousekeeperRepository
    {

        public HousekeeperRepository()
        {

        }

        public IQueryable<Housekeeper> GetHousekeepers()
        {
            var unitOfWork = new UnitOfWork();
            var housekeepers =
                unitOfWork.Query<Housekeeper>();

            return housekeepers;
        }
    }
}
