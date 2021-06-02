using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAutobuskaStanica.DataModel.Repo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(object id);
        List<TEntity> GetAll();
        bool Insert(TEntity entity);
        bool Delete(object id);
        bool Update(TEntity entityToUpdate);
    }
}
