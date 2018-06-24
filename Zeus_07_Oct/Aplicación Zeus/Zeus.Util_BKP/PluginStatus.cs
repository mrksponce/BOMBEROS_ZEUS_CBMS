using Zeus.Interfaces;

namespace Zeus.Util
{
    public class PluginStatus
    {
        public PluginStatus(IPlugin p, string arch, bool activado)
        {
            Plugin = p;
            Archivo = arch;
            Activado = activado;
        }

        public IPlugin Plugin { get; set; }

        public string Archivo { get; set; }

        public bool Activado { get; set; }
    }
}