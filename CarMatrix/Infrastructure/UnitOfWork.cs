using System;
using System.Collections.Generic;
using System.Linq;
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
        private IRepository<BuyTime> buyTimeRepository;

        public UnitOfWork(IRepository<Record> recordRepository, 
            IRepository<Brands> brandsRepository,
            IRepository<ModelEntity> modelsRepository,
            IRepository<BuyTime> buyTimeRepository)
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
            //Mock<Brands> mockBrands = new Mock<Brands>();
            //mockBrands.Setup().Returns
            return this.brandsRepository.GetEntities;
        }

        public IEnumerable<ModelEntity> GetModels()
        {
            return this.modelsRepository.GetEntities;
        }

        public IEnumerable<BuyTime> GetBuyTimes()
        {
            return this.buyTimeRepository.GetEntities;
        }
    }
}