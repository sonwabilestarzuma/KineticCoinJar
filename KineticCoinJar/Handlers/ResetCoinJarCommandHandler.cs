using KineticCoinJar.DataAccess;
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
        private ApplicationDbContext _dbcontext;

        public ResetCoinJarCommandHandler(ICoinJar coin, ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}