using System;
using System.Collections.Specialized;

namespace Zeus.Util
{
    [Serializable]
    internal class PluginUserConfig
    {
        public string ItemOrder { get; set; }
        public string login { get; set; }
        public StringCollection pluginsActivos { get; set; }
        public StringCollection pluginsVisibles { get; set; }
    }
}