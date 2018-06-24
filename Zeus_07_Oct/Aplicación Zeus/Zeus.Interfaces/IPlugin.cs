using System.Windows.Forms;

namespace Zeus.Interfaces
{
    public interface IPlugin
    {
        /// <summary>
        /// Author of the plugin.
        /// </summary>
        string Autor { get; }

        /// <summary>
        /// Short description of the plugin.
        /// </summary>
        string Descripcion { get; }

        /// <summary>
        /// Name of the plugin.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Build date.
        /// </summary>
        string BuildDate { get; }

        /// <summary>
        /// Plugin version.
        /// </summary>
        string Version { get; }

        string Licencia { get; }


        /// <summary>
        /// This method is called by the MapWindow when the plugin is loaded.
        /// </summary>
        /// <param name="MapWin">The <c>IMapWin</c> interface to use when interacting with the MapWindow.</param>
        void Initialize(IZeusWin Isg);

        /// <summary>
        /// This method is called by the MapWindow when the plugin is unloaded.
        /// </summary>
        void Terminate();

        ToolStripItem GetButton();
    }
}