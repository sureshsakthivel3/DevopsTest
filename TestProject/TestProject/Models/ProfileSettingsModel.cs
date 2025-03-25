using System.ComponentModel.DataAnnotations;

namespace iAMSWebCore.Models
{
    public class ProfileSettingsModel
    {
        public string Name { get; set; }
        public string Value { get; set; }

    }
    public class ProfileSettingsData
    {
        public List<ProfileSettingsModel> ProfileSettingsdata { get; set; }=new List<ProfileSettingsModel>();
        public string EmailId { get; set; }
        public string ID { get; set; }
        public string Mode { get; set; }
    }


        public class LandingPageModel
    {
        public List<LanguageModel> languages { get; set; } = new List<LanguageModel>();
        public List<MenuModel> menuModels { get; set; } = new List<MenuModel>();
    }

    public class LanguageModel
    {
        public int Id { get; set; }
        public string? LanguageName { get; set; }
        public string? ShortName { get; set; }
    }

    public class MenuModel
    {
        public int ApplicationMenuId { get; set; }
        public string? MenuName { get; set; }
        public int ParentId { get; set; }
        public string? PageName { get; set; }
    }
}
