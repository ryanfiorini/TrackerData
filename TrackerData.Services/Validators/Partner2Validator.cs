using TrackerData.Services.Models;

namespace TrackerData.Services.Validators
{
    public class Partner2Validator
    {
        public static bool HasValidDevices(Partner2 trackerData)
        {
            return trackerData.Devices != null;
        }

        public static bool HasValidCompany(Partner2 trackerData)
        {
            return !string.IsNullOrEmpty(trackerData.Company);
        }

    }
}
