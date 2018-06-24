using System;
using System.Windows.Forms;
using Zeus.Data;

namespace Zeus.Interfaces
{
    public interface IZeusWin
    {
        string Usuario { get; }
        TipoOperadora TipoOperadora { get; }
        int IdOperadora { get; }
        int IdAval { get; }
        int IdExpediente { get; }
        PointD LastGeo { get; }
        void AgregarMenu(ToolStripMenuItem item);
        void AgregarBoton(ToolStripItem button);
        void AgregarSeparador(string nombre);
        void AgregarConfig(ToolStripMenuItem item);
        void EliminarMenu(ToolStripMenuItem item);
        void EliminarBoton(ToolStripItem button);
        void EliminarSeparador(string nombre);
        void EliminarConfig(ToolStripMenuItem item);
        void BarraEstado(string msj);
        void Ocupado(bool estado);
        void Actualizar();
        void AddActualizarHandler(EventHandler handler);
        IPlugin GetPluginActivo(string nombre);
    }

    public enum TipoOperadora
    {
        Operadora,
        Administrador
    }
}