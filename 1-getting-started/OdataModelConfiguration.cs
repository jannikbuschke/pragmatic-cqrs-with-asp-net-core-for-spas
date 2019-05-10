using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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