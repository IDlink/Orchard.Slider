using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Celerik.Slider {
    public class Migrations : DataMigrationImpl {

        public int Create() {
            SchemaBuilder.CreateTable("SliderPartRecord", table => table.ContentPartRecord());

            ContentDefinitionManager.AlterPartDefinition("SliderPart", builder => builder
                .Attachable()
               .WithField("SliderImage", cfg => cfg.OfType("MediaPickerField")
                     .WithDisplayName("Image")
                     .WithSetting("MediaPickerFieldSettings.AllowedExtensions", "gif jpg jpeg png")
                     .WithSetting("MediaPickerFieldSettings.Required", true.ToString()))
                .WithField("SliderTitle", cfg => cfg.OfType("TextField")
                .WithDisplayName("Slider Title")
                .WithSetting("TextFieldSettings.Flavour", "Html"))
                );

            ContentDefinitionManager.AlterTypeDefinition("Slider", builder => builder
               .DisplayedAs("Slider Image")
               .WithPart("TitlePart")
               .WithPart("SliderPart")
               .WithPart("BodyPart")
               .WithPart("CommonPart")
               .WithPart("IdentityPart")
               .Creatable());

            ContentDefinitionManager.AlterPartDefinition("SliderWidgetPart", builder => builder
                .Attachable());

            ContentDefinitionManager.AlterTypeDefinition("SliderWidget", builder => builder
               .DisplayedAs("Slider widget")
               .WithPart("SliderWidgetPart")
               .WithPart("CommonPart")
               .WithPart("WidgetPart")
               .WithSetting("Stereotype", "Widget"));
            return 1;
        }
    }
}