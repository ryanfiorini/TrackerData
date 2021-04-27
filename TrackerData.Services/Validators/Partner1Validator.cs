using TrackerData.Services.Models;

namespace TrackerData.Services.Validators
{
    public class Partner1Validator
    {
        public static bool HasValidTrackers(Partner1 trackerData)
        {
            return trackerData.Trackers != null;
        }

        public static bool HasValidPartnerName(Partner1 trackerData)
        {
            return !string.IsNullOrEmpty(trackerData.PartnerName);
        }

    }
}
