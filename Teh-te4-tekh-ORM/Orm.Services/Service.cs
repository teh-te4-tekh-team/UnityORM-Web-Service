namespace Orm.Services
{
    using Data.Interfaces;

    public abstract class Service
    {
        protected Service(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        protected IUnitOfWork Unit { get; set; }
    }
}