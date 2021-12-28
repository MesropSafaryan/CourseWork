namespace DAL.Interface
{
    public interface ISerializeable<T>
    {
        bool Serialize(T obj);

        T Deserialize();
    }
}
