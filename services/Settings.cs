using System.IO;

namespace Gurdian_Picture_Tool
{
    internal class Settings
    {
        private static Settings instance = null;
        private static readonly object padlock = new object();
        public string  SfFormKey { get; set; }
        public string r { get; set; }
        public string g { get; set; }
        public string b { get; set; }
        public int pngQualityInKB { get; set; }
        public string jpgQuality { get; set; }
        public string format { get; set; }
        public string savePath { get; set; }
        public string server_ip { get; set; }
        public string server_port { get; set; }
        public string announcement { get; set; }
        public string patch { get; set; }
        public string js { get; set; }   
        public bool first { get; set; }
        public static Settings Instance
        { 
            get {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Settings();
                        instance.SfFormKey = "NTQyNjM3QDMxMzkyZTMzMmUzMEM3L1FZWW1rZ2NPdy9hNlNuWUFmZFNiV1hSRXZEZjlCUFkycWVqdkMwMkk9;NTQyNjM4QDMxMzkyZTMzMmUzMG9NZi9XYWVvd052WW1uMFFjWkNXR3paZ2pXUnl3NlVwZUhHQzJRc0VzbkE9;NTQyNjM5QDMxMzkyZTMzMmUzMG5aWFhsV25YS0ZpVnJYeUFQZUZKMmEvN2lvUkQvQ1YyVGZ0WEl4SHd6QWc9;NTQyNjQwQDMxMzkyZTMzMmUzMGpPUExNOGlXVjJuYzhyNGUzME5sQ3R0VHFZa2k5RjNBeXRGZjV3MG1QZnc9;NTQyNjQxQDMxMzkyZTMzMmUzME1Xd3lMTWQ2VERibHNDRXdMa2VXQ0N5bTBxK2h6R2k0NFNwZ0twaHRNQ3c9;NTQyNjQyQDMxMzkyZTMzMmUzMEorMDlOdzkxRHBrN0lEaXlmTXp4bjl1elhDUzkydWIyejgxSTJFRzNtZzg9;NTQyNjQzQDMxMzkyZTMzMmUzMGZXOVFwSnR0VGpuVzFEWTNxM0hRVmh6YWYyb3p3MFdiZng2S1lRZ1hyY289;NTQyNjQ0QDMxMzkyZTMzMmUzMGpLS0FuZEEwUUpiOEpqTEtIcUVBVmtqM08rVU80Zng5N2dtNk5UTXNNUjQ9;NTQyNjQ1QDMxMzkyZTMzMmUzME5DdFBocFU2NUw0WXJDenFSMGR1elhSaHZWRWdSK3RuZFh1VFVkTEJkTkk9;NTQyNjQ2QDMxMzkyZTMzMmUzMFFBT0tXVmRJNDBwYmRTQ3dwSVErcUZvQWZsQ01NRTFDKzYxU0dUVmVJOXc9;NTQyNjQ3QDMxMzkyZTMzMmUzMEh6aGFBVGZuTlh2TkNXTEZxSGNJRFczeE1sZmZyRE9LcldwU0p2aHF6WGs9";
                        instance.r = "255";
                        instance.g = "255";
                        instance.b = "255";
                        instance.pngQualityInKB = 250;
                        instance.jpgQuality = "80";
                        instance.format = "jpg";
                        instance.savePath = "";
                        instance.server_ip = "10.100.102.23";
                        instance.server_port = "41181";
                        instance.announcement = "";
                        instance.patch = "";
                        instance.js = "";
                        instance.first = true;
                    }
                    return instance;
                }
            } }
        
        public static void Update()
        {
            File.WriteAllText("./Settings.xD", instance.SfFormKey + "," + instance.r + "," + instance.g + "," + instance.b + "," + 
                instance.pngQualityInKB + "," + instance.jpgQuality + "," + instance.format + "," + instance.savePath + "," + instance.server_ip + "," + instance.server_port + "," +
                instance.announcement + "," + instance.patch + "," + instance.js + "," + instance.first); 
        }

        public static void Sync() 
        {
            if (File.Exists("./Settings.xD") && instance != null)
            {
                var raw = File.ReadAllText("./Settings.xD").Split(',');
                if(raw.Length == 14)
                {
                    instance.SfFormKey = raw[0];
                    instance.r = raw[1];
                    instance.g = raw[2];
                    instance.b = raw[3];
                    instance.pngQualityInKB = int.Parse(raw[4]);
                    instance.jpgQuality = raw[5];
                    instance.format = raw[6];
                    instance.savePath = raw[7];
                    instance.server_ip = raw[8];
                    instance.server_port = raw[9];
                    instance.announcement = raw[10];
                    instance.patch = raw[11];
                    instance.js = raw[12];
                    instance.first = raw[13].ToLower().Equals("true");
                }
            }
        }

    }
}
