using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityService.Interface;
using DAL.Interface;

namespace EntityService
{
    public class EntityService<T> : IEntityService<T>
    {
        IDataFilling<T> provider;
        public EntityService(IDataFilling<T> provider)
        {
            if (provider == null) { throw new NullReferenceException(); }

            this.provider = provider;
        }


        //Agregation
        public IDataFilling<T> Provider
        {
            get { return provider; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }

                provider = value;
            }
        }


        public bool AddNewData(T obj) { ClearData(); return UpdateData(obj); }
        public void ClearData() { provider.ClearDataFile(); }
        public T GetData() { return provider.Deserialize(); }
        public bool UpdateData(T obj) { return provider.Serialize(obj); }
    }
}
