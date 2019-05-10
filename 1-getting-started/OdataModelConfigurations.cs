using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyApp
{

    public class OdataModelConfigurations : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.EntitySet<Person>("Persons");
        }
    }
}