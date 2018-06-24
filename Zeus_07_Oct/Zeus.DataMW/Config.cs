using Microsoft.Win32;

namespace Zeus.Data
{
	public static class Config
	{
        public static void Load()
        {
            // Attempt to open the keya
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\GEOBit\\ZEUS");

            // If the return value is null, the key doesn't exist
            if (key == null)
            {
                return;
            }

            // Attempt to retrieve the value X; if null is returned, the value
            // doesn't exist in the registry.
            if (key.GetValue("Host") != null)
            {
                Host = (string)key.GetValue("Host");
            }

            if (key.GetValue("Database") != null)
            {
                Database = (string)key.GetValue("Database");
            }
        }

        public static void LoadLocal()
        {
            Host = "localhost";
            Database = "bd_sgc";
        }

        public static string Host
        {
            get 
            { 
                return DataSettings.Default.Host; 
            }
            set 
            { 
                DataSettings.Default.Host = value;
                DataSettings.Default.Save(); 
            }
        }

        public static string Database
        {
            get
            {
                return DataSettings.Default.Database;
            }
            set
            {
                DataSettings.Default.Database = value;
                DataSettings.Default.Save();
            }
        }    
	}
}
