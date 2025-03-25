using iAMSWebCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace iAMSWebCore.Controllers
{
    public class GeneralSettingsController : BaseController
    {
        public GeneralSettingsController(IConfiguration configuration) : base(configuration)
        {

        }
        public IActionResult GeneralSettings()
        {
            List<ProfileSettingsModel> profileSettings = new List<ProfileSettingsModel>();
            ProfileResetRequest resetRequest = new ProfileResetRequest();
            resetRequest.ClientId = 1;
            resetRequest.Flag = 0;
            resetRequest.Tabval = "system";
            var result = PostResult("ProfileSettings/ProfileReset", resetRequest);
            profileSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProfileSettingsModel>>(result);
            return View(profileSettings);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public List<ProfileSettingsModel> GeneralSettings(int flag, string tabname)
        {
            List<ProfileSettingsModel> profileSettings = new List<ProfileSettingsModel>();
            ProfileResetRequest resetRequest = new ProfileResetRequest();
            resetRequest.ClientId = 1;
            resetRequest.Flag = flag;
            resetRequest.Tabval = tabname;
            var result = PostResult("ProfileSettings/ProfileReset", resetRequest);
            profileSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProfileSettingsModel>>(result);
            return profileSettings;
        }

        public LandingPageModel LoadLanguage()
        {
            LandingPageModel model = new LandingPageModel();
            string actionname = "ProfileSettings/GetddlLandingPage?ONG=1";
            var result = GetResult(actionname);
            model.languages = Json2List<LanguageModel>(result, "languageModels");
            model.menuModels = Json2List<MenuModel>(result, "menuModels");
            //var LangList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LanguageModel>>(result);
            return model;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult UpdateProfile(string profileSettingsdata)
        {
            string actionname = "ProfileSettings/ProfileUpdate?ProfileSettingsstring=" + profileSettingsdata;
            var result = GetResult(actionname);
            //var result = PostResult("ProfileSettings/ProfileUpdate", profileSettingsdata);
            return Json(result);
        }
    }
}
