using Demos.Common.Data;
using Demos.Common._Mock;

namespace Demos.Domains.Foos
{
    public class FooService : BaseMockObject, IFooService
    {
        private readonly ISimpleRepository _simpleRepository;

        public FooService(ISimpleRepository simpleRepository)
        {
            _simpleRepository = simpleRepository;
        }

        public string GetFooInfo()
        {
            return "From Foo Service";
        }
    }
}
