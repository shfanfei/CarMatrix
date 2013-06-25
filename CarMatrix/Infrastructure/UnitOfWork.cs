using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CarMatrix.Infrastructure;
using CarMatrixData.Models;
using Moq;
using ModelEntity = CarMatrixData.Models.Models;

namespace CarMatrix.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Record> recordRepository;
        private IRepository<Brands> brandsRepository;
        private IRepository<ModelEntity> modelsRepository;
        private IRepository<BuyYear> buyTimeRepository;

        public UnitOfWork(IRepository<Record> recordRepository,
            IRepository<Brands> brandsRepository,
            IRepository<ModelEntity> modelsRepository,
            IRepository<BuyYear> buyTimeRepository)
        {
            this.recordRepository = recordRepository;
            this.brandsRepository = brandsRepository;
            this.modelsRepository = modelsRepository;
            this.buyTimeRepository = buyTimeRepository;
        }

        public IEnumerable<Record> GetRecords()
        {
            return this.recordRepository.GetEntities;
        }

        public IEnumerable<Brands> GetBrands()
        {
            return this.brandsRepository.GetEntities;
        }

        public IEnumerable<ModelEntity> GetModels()
        {
            return this.modelsRepository.GetEntities;
        }

        public IEnumerable<BuyYear> GetBuyTimes()
        {
            return this.buyTimeRepository.GetEntities;
        }

        public IEnumerable<Record> GetRecordsFilter(params Expression<Func<Record, bool>>[] precidates)
        {
            if (precidates == null)
                throw new ArgumentNullException("precidates");

            IQueryable<Record> results = null;
            int count = precidates.Count();
            if (count > 0)
            {
                Expression<Func<Record, bool>> pre = precidates.ElementAt(0);
                results = this.recordRepository.GetEntities.Where(pre);
                for (int i = 1; i < count; i++)
                {
                    Expression<Func<Record, bool>> p = precidates.ElementAt(i);
                    results = results.Where(p);
                }
            }
            return results;
        }
    }
}