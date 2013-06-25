using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        IEnumerable<BuyYear> GetBuyTimes();
        IEnumerable<Record> GetRecordsFilter(params Expression<Func<Record, bool>>[] precidates);
    }
}