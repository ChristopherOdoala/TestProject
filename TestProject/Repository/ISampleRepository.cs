using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Model;

namespace TestProject.Repository
{
    public interface ISampleRepository
    {
        bool SaveAll();

        //Get all Data from sample table
        IQueryable<SampleModel> GetAllSampleData();
        SampleModel GetSampleData(int id);

        //Inserts
        bool Insert(SampleModel model);

        //Update
        bool Update(SampleModel model);

        //Delete
        bool DeleteSampleData(int id);
    }
}
