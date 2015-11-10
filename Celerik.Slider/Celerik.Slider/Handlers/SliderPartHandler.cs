using JetBrains.Annotations;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Celerik.Slider.Models;

namespace Celerik.Slider.Handlers
{
    [UsedImplicitly]
	
    public class SliderPartHandler : ContentHandler
    {
        public SliderPartHandler(IRepository<SliderPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
			
        }
    }
}
