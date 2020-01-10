using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DATA.Infrastructure;
using DOMAIN;
using SERVICEPATERN;

namespace SERVICE
{
    class MandateService : Service<mandate>
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public MandateService() : base(uow)
        {

        }
    }
}
