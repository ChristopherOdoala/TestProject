using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Context;
using TestProject.Model;

namespace TestProject.Repository
{
    public class SampleRepository : ISampleRepository
    {
        private SampleDbContext _ctx;
        public SampleRepository(SampleDbContext ctx)
        {
            this._ctx = ctx;
        }
        public bool DeleteSampleData(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SampleModel> GetAllSampleData()
        {
            return _ctx.Samples;
        }

        public SampleModel GetSampleData(int id)
        {
            return GetAllSampleData().Where(s => s.id == id).FirstOrDefault();
        }

        public bool Insert(SampleModel model)
        {
            try
            {
                _ctx.Samples.Add(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveAll()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(SampleModel model)
        {
            try
            {
                _ctx.Update(model);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
