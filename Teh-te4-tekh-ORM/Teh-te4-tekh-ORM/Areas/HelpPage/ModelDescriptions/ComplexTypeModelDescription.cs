namespace Teh_te4_tekh_ORM.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    public class ComplexTypeModelDescription : ModelDescription
    {
        public ComplexTypeModelDescription()
        {
            this.Properties = new Collection<ParameterDescription>();
        }

        public Collection<ParameterDescription> Properties { get; private set; }
    }
}