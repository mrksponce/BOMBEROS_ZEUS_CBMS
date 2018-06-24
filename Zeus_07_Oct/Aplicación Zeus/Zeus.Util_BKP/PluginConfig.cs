using System;
using System.Collections;

namespace Zeus.Util
{
    [Serializable]
    internal class PluginConfig
    {
        private readonly ArrayList usuarios;

        public PluginConfig()
        {
            usuarios = new ArrayList();
        }

        public PluginUserConfig Get(string usuario)
        {
            return getUsuario(usuario);
        }

        public void Set(string usuario, PluginUserConfig data)
        {
            PluginUserConfig u = getUsuario(usuario);
            if (u != null)
            {
                u.login = data.login;
                u.pluginsActivos = data.pluginsActivos;
                u.pluginsVisibles = data.pluginsVisibles;
                u.ItemOrder = data.ItemOrder;
            }
            else
            {
                usuarios.Add(data);
            }
        }

        public void Delete(string usuario)
        {
            PluginUserConfig u = getUsuario(usuario);
            if (u != null)
            {
                usuarios.Remove(u);
            }
        }

        private PluginUserConfig getUsuario(string usuario)
        {
            foreach (PluginUserConfig u in usuarios)
            {
                if (u.login == usuario)
                {
                    return u;
                }
            }
            return null;
        }
    }
}