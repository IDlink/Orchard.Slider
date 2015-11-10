using JetBrains.Annotations;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Celerik.Slider.Models;

namespace Celerik.Slider.Handlers
{
    [UsedImplicitly]
	
    public class SliderWidgetPartHandler : ContentHandler
    {
        public SliderWidgetPartHandler(IRepository<SliderWidgetPartRecord> repository)
        {		
        }
    }
}
