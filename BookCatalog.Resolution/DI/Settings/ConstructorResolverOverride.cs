using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Builder;
using Unity.Injection;
using Unity.Policy;
using Unity.Resolution;

namespace BookCatalog.Resolution.DI.Settings
{
    class ConstructorResolverOverride : ResolverOverride
    {
        Queue<InjectionParameterValue> _parameterValues;

        public ConstructorResolverOverride(params object[] parameters)
        {
            _parameterValues = new Queue<InjectionParameterValue>();

            foreach (var parameterValue in parameters)
            {
                _parameterValues.Enqueue(InjectionParameterValue.ToParameter(parameterValue));
            }
        }

        public override IResolverPolicy GetResolver(IBuilderContext context, Type dependencyType)
        {
            if (_parameterValues.Count < 1)
                return null;

            var value = _parameterValues.Dequeue();
            return value.GetResolverPolicy(dependencyType);
        }
    }
}
