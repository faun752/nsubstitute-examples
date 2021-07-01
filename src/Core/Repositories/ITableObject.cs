using System;

namespace Core.Repositories
{
    public interface ITableObject<T> where T : IEquatable<T>
    {
    }
}
