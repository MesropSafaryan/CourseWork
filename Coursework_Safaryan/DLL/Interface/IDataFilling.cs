namespace DAL.Interface
{
    public interface IDataFilling<T> : ISerializeable<T>
    {
        string Path { get; set; }

        void ClearDataFile();

        bool IsHere();

        bool IsHereOrCreate();
    }
}
