using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace EElections.Helpers
{
    public static class RegistryUtils
    {
        public static readonly ICollection<string> LicenseStore = new List<string>
        {
            "A4C138B3-01A7-4D2B-AEB5-90E1567D011F",
            "7FAAEBA5-2AC9-4EEC-BB1E-46D68F71113C",
            "DCD724B6-AFD4-4AFB-B8E2-D2CF356017E6",
            "1DF8E83A-912A-4BFB-97F9-14A7A8CB7A71",
            "53A7CEAB-88FB-4562-BAB9-198A4E11377C",
            "BA8BC23F-200D-4A9C-9265-4456B8B386A9",
            "01ECC5B6-D14C-49D2-961D-B44807D40B8D",
            "0E7226DB-2AB5-4C09-8BA9-5AE6E33E7115",
            "0D823583-D079-4A6D-B251-0349464BC17D",
            "BA6421F9-E8A4-4600-9EF6-59ED3D5253C8",
            "CFDC0FD6-F49A-49E8-80E4-DCAB23C00973",
            "1C29566B-FCD7-48D7-B4CC-D288FD1E369A",
            "7FE8B60F-ACA9-4575-AB49-E371D8CA8AC1",
            "2484B56E-879F-42F5-A807-E5E0E54DB139",
        };

        private const string TrialMode = "TrialMode";
        private const string ActivationKey = "ActivationKey";
        private const string TrialStart = "TrialStart";

        public static void StoreLicenseKey(string license)
        {
            using (RegistryKey softRegKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\VoteManager", true))
            {
                softRegKey.SetValue("activationkey", license, RegistryValueKind.String);
                softRegKey.Flush();
            }
        }

        public static bool IsLicensed()
        {
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\VoteManager", true))
            {
                if (regKey == null)
                {
                    return false;
                }


                // check if trial mode is activated
                if (Convert.ToBoolean(regKey.GetValue(TrialMode, false)))
                {
                    long fileTime = Convert.ToInt64(regKey.GetValue(TrialStart));
                    if (fileTime == 0L)
                    {
                        return false;
                    }
                    // expired!
                    if ((DateTime.FromFileTimeUtc(fileTime) - DateTime.UtcNow).TotalMilliseconds < 0)
                    {
                        return false;
                    }
                }

                string licenseKey = (string)regKey.GetValue(ActivationKey);
                if (string.IsNullOrEmpty(licenseKey))
                {
                    return false;
                }

                if (LicenseStore.Contains(licenseKey) == false)
                {
                    return false;
                }

                return true;
            }
        }

        public static bool ActivateTrial()
        {
            RegistryKey regKey = null;
            try
            {
                regKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\VoteManager", true);
                if (regKey == null)
                {
                    return false;
                }

                // trial already started
                if (regKey.GetValue(TrialStart) != null)
                {
                    return false;
                }

                // trial duration 24hrs
                DateTime trialEndDate = DateTime.UtcNow; // + TimeSpan.FromDays(3);

                regKey.SetValue(TrialMode, true);
                regKey.SetValue(TrialStart, trialEndDate.ToFileTimeUtc());
            }
            catch
            {
                return false;
            }
            finally
            {
                if (regKey != null)
                {
                    regKey.Flush();
                    //regKey.Close();
                    regKey.Dispose();
                }
            }
            return true;
        }

        public static bool IsTrialModeExpired()
        {
            using (var regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\VoteManager", true))
            {
                if (regKey == null)
                {
                    return false;
                }

                // trial not set!
                var value = regKey.GetValue(TrialStart);
                if (value == null)
                {
                    return false;
                }
                //long fileTime = Convert.ToInt64(regKey.GetValue(TrialStart, false, RegistryValueOptions.None));

                long fileTime = Convert.ToInt64(value);
                if ((DateTime.FromFileTimeUtc(fileTime) - DateTime.UtcNow).TotalMilliseconds < 0)
                {
                    return true; // TrialMode expired!
                }

                return false;
            }
        }
    }
}
