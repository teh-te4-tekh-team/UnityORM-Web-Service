namespace Orm.Data.Implementations
{
    using System;

    public class UnitOfWorkProvider
    {
        private static readonly Lazy<UnitOfWork> singleton = new Lazy<UnitOfWork>(() => new UnitOfWork());
        
        public static UnitOfWork Instance { get { return singleton.Value; } }
    }
}
