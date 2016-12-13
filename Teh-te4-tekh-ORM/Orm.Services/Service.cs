namespace Orm.Services
{
    using Data.Interfaces;

    /// <summary>
    /// Main class providing service functionallity based on a given <see cref="IUnitOfWork"/>.
    /// </summary>
    public abstract class Service
    {
        protected Service(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        protected IUnitOfWork Unit { get; set; }
    }
}