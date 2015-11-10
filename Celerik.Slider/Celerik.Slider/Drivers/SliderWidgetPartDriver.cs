using System.Linq;
using Celerik.Slider.Models;
using JetBrains.Annotations;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;
using Orchard.UI.Notify;

namespace Celerik.Slider.Drivers
{
    [UsedImplicitly]

    public class SliderWidgetPartDriver : ContentPartDriver<SliderWidgetPart>
    {
        private readonly INotifier _notifier;
        private readonly IOrchardServices _services;
        private const string TemplateName = "Parts/SliderWidgetPart";

        public Localizer T { get; set; }

        public SliderWidgetPartDriver(INotifier notifier, IOrchardServices services)
        {
            _services = services;
            _notifier = notifier;
            T = NullLocalizer.Instance;
        }

        protected override DriverResult Display(SliderWidgetPart part, string displayType, dynamic shapeHelper)
        {
            var result = _services.ContentManager.Query<SliderPart, SliderPartRecord>().List().ToList();

            return ContentShape("Parts_SliderWidgetPart",
                () => shapeHelper.Parts_SliderWidgetPart(Items: result));
        }

        protected override DriverResult Editor(SliderWidgetPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_SliderWidgetPart",
                    () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(SliderWidgetPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            if (!updater.TryUpdateModel(part, Prefix, null, null))
            {
                _notifier.Error(T("Error during SliderWidgetPart update!"));
            }
            return Editor(part, shapeHelper);
        }

    }
}