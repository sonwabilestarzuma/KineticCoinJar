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
    public class ResetCoinJarCommandHandler : RequestHandler<ResetCoinJarCommand>
    {
        private readonly ICoinJar _db;

        public ResetCoinJarCommandHandler(ICoinJar db)
        {
            _db = db;
        }

        protected override void Handle(ResetCoinJarCommand coinJarCommand)
        {
            _db.Reset();
        }
    }
}