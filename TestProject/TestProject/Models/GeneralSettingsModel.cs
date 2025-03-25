namespace iAMSWebCore.Models
{
    public class GeneralSettingsModel
    {
        public GeneralSettingsModel()
        {
            SystemSettings = new List<ProfileSettingsModel>();
            AccountSettings = new List<ProfileSettingsModel>();
        }
        public List<ProfileSettingsModel> SystemSettings { get; set; }
        public List<ProfileSettingsModel> AccountSettings { get; set; }
    }

    public class ProfileResetRequest
    {
        public int ClientId { get; set; }
        public int Flag { get; set; }
        public string Tabval { get; set; }
    }
}
