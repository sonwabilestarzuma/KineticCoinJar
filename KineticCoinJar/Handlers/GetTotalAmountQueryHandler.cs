using KineticCoinJar.IRepositories;
using KineticCoinJar.Messages;
using KineticCoinJar.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.Handlers
{
    public class GetTotalAmountQueryHandler : RequestHandler<GetTotalAmountQuery, GetTotalAmountQueryResponse>
    {
        private readonly ICoinJar _db;

        public GetTotalAmountQueryHandler(ICoinJar db)
        {
            _db = db;
        }

        protected override GetTotalAmountQueryResponse Handle(GetTotalAmountQuery query)
        {
            return new GetTotalAmountQueryResponse { TotalAmount = _db.GetTotalAmount() };
        }
    }
}