
namespace EntityService.Interface
{
    public interface IEntityService<T>
    {
        bool AddNewData(T obj);
        bool UpdateData(T obj);
        T GetData();
        void ClearData();
    }
}
