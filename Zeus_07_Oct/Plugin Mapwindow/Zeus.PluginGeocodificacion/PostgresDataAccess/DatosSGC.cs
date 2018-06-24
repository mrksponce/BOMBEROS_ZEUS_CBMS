
namespace Zeus.PluginGeocodificacion
{
    public static class DatosSGC
    {
        public static string RedTicURL
        {
            get { return Zeus.PluginGeocodificacion.Properties.Settings.Default.RedTicURL; }
            set { Zeus.PluginGeocodificacion.Properties.Settings.Default.RedTicURL = value; Zeus.PluginGeocodificacion.Properties.Settings.Default.Save(); }
        }
        public static string IdSGC
        {
            get { return Zeus.PluginGeocodificacion.Properties.Settings.Default.IdSGC; }
            set { Zeus.PluginGeocodificacion.Properties.Settings.Default.IdSGC = value; Zeus.PluginGeocodificacion.Properties.Settings.Default.Save(); }
        }
        public static string Host
        {
            get { return Zeus.PluginGeocodificacion.Properties.Settings.Default.Host; }
            set { Zeus.PluginGeocodificacion.Properties.Settings.Default.Host = value; Zeus.PluginGeocodificacion.Properties.Settings.Default.Save(); }
        }
    }
}
