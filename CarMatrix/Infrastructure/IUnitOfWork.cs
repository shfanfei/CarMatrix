using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarMatrixData.Models;
using ModelEntity = CarMatrixData.Models.Models;

namespace CarMatrix.Infrastructure
{
    public interface IUnitOfWork
    {
        IEnumerable<Record> GetRecords();
        IEnumerable<Brands> GetBrands();
        IEnumerable<ModelEntity> GetModels();
        IEnumerable<BuyTime> GetBuyTimes();
    }
}