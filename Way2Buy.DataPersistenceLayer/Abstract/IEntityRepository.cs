using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Way2Buy.DataPersistenceLayer.Abstract
{
    public interface IEntityRepository<T>
    {
        IEnumerable<T> Entities { get; }

        void Save(T entity);

        T DeleteEntityId(int entityId);

        T GetEntityId(int entityId);
    }
}
