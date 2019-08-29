using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Sample
{
    public class OdataModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.EntitySet<Person>("Persons");
        }
    }
}
