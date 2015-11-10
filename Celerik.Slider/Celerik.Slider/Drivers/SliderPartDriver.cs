using JetBrains.Annotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;
using Orchard.UI.Notify;
using Celerik.Slider.Models;

namespace Celerik.Slider.Drivers
{
    [UsedImplicitly]
	
    public class SliderPartDriver : ContentPartDriver<SliderPart>
    {
        private readonly INotifier _notifier;
        private const string TemplateName = "Parts/SliderPart";

        public Localizer T { get; set; }

        public SliderPartDriver(INotifier notifier)
        {
            _notifier = notifier;
            T = NullLocalizer.Instance;
        }

        protected override DriverResult Display(SliderPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_SliderPart",
                () => shapeHelper.Parts_SliderPart(ContentItem: part.ContentItem));
        }

        protected override DriverResult Editor(SliderPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_SliderPart",
                    () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(SliderPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            if (updater.TryUpdateModel(part, Prefix, null, null))
            {
                _notifier.Information(T("SliderPart edited successfully"));
            }
            else
            {
                _notifier.Error(T("Error during SliderPart update!"));
            }
            return Editor(part, shapeHelper);
        }

    }
}