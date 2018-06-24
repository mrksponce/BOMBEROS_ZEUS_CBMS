using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Zeus.Interfaces;

namespace Zeus.Util
{
    public class PluginsManager
    {
        private readonly IZeusWin _parent;
        private readonly List<PluginStatus> plugins;
        private StringCollection _pluginsActivos;

        /// <summary>
        /// inicia la clase, cargando los plugins de la sesión previa
        /// </summary>
        public PluginsManager(IZeusWin parent)
        {
            plugins = new List<PluginStatus>();
            _pluginsActivos = new StringCollection();
            PluginsVisibles = new StringCollection();
            _parent = parent;
        }

        public StringCollection PluginsVisibles { get; set; }

        public StringCollection PluginsActivos
        {
            get { return _pluginsActivos; }
            set { if (value != null) _pluginsActivos = value; }
        }

        public void CargarPlugins(string folder)
        {
            try
            {
                string[] files = Directory.GetFiles(folder, "*.dll");
                foreach (string file in files)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(file);
                        foreach (Type type in assembly.GetTypes())
                        {
                            if (!type.IsClass || type.IsNotPublic) continue;
                            Type[] interfaces = type.GetInterfaces();
                            if (((IList) interfaces).Contains(typeof (IPlugin)))
                            {
                                PluginStatus pl;
                                object obj = Activator.CreateInstance(type);
                                var t = (IPlugin) obj;
                                // agregar
                                if (_pluginsActivos.Contains(file))
                                {
                                    t.Initialize(_parent);
                                    pl = new PluginStatus(t, file, true);
                                    //visible?
                                    t.GetButton().Visible = PluginsVisibles.Contains(file);
                                }
                                else
                                {
                                    pl = new PluginStatus(t, file, false);
                                }
                                plugins.Add(pl);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Log.ShowAndLog(
                            new Exception("El Plugin " + file + " Ha reportado el siguiente error:\n" + e.Message));
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                return;
            }
            catch (Exception ex)
            {
                // error cargando plugins
                Log.ShowAndLog(ex);
            }
        }

        public string CargarConfig(byte[] stream, string usuario)
        {
            var ms = new MemoryStream();
            //FileStream fs = new FileStream("a.txt", FileMode.Create);
            var sf = new BinaryFormatter();
            string itemOrder = "";

            ms.Write(stream, 0, stream.Length);
            ms.Seek(0, SeekOrigin.Begin);
            var p = (PluginConfig) sf.Deserialize(ms);
            PluginUserConfig u = p.Get(usuario);
            if (u != null)
            {
                _pluginsActivos = u.pluginsActivos;
                PluginsVisibles = u.pluginsVisibles;
                itemOrder = u.ItemOrder;
            }
            return itemOrder;
        }

        public byte[] GuardarConfig(byte[] stream, string usuario, string itemOrder)
        {
            var ms = new MemoryStream();
            var sf = new BinaryFormatter();
            PluginConfig p;
            if (stream != null)
            {
                ms.Write(stream, 0, stream.Length);
                ms.Seek(0, SeekOrigin.Begin);
                p = (PluginConfig) sf.Deserialize(ms);
            }
            else
            {
                p = new PluginConfig();
            }
            PluginUserConfig u = p.Get(usuario);
            if (u != null)
            {
                u.pluginsActivos = _pluginsActivos;
                u.pluginsVisibles = PluginsVisibles;
                u.ItemOrder = itemOrder;
            }
            else
            {
                u = new PluginUserConfig
                        {
                            login = usuario,
                            pluginsActivos = _pluginsActivos,
                            pluginsVisibles = PluginsVisibles,
                            ItemOrder = itemOrder
                        };
                p.Set(usuario, u);
            }

            ms = new MemoryStream();
            sf.Serialize(ms, p);
            return ms.ToArray();
        }

        public void ActivarPlugin(string arch)
        {
            PluginStatus p = getPlugin(arch);
            if (p != null)
            {
                p.Plugin.Initialize(_parent);
                p.Activado = true;
            }
        }

        public void DesactivarPlugin(string arch)
        {
            PluginStatus p = getPlugin(arch);
            if (p != null)
            {
                p.Plugin.Terminate();
                p.Activado = false;
            }
        }

        public void MostrarPlugin(String arch, bool ver)
        {
            PluginStatus p = getPlugin(arch);
            if (p != null && p.Activado)
            {
                if (ver)
                {
                    PluginsVisibles.Add(arch);
                    p.Plugin.GetButton().Visible = true;
                }
                else
                {
                    PluginsVisibles.Remove(arch);
                    p.Plugin.GetButton().Visible = false;
                }
            }
        }

        private PluginStatus getPlugin(string arch)
        {
            foreach (PluginStatus p in plugins)
            {
                if (p.Archivo == arch)
                {
                    return p;
                }
            }
            return null;
        }

        public PluginStatus[] GetPlugins()
        {
            return plugins.ToArray();
        }

        public void DescargarPlugins()
        {
            foreach (PluginStatus p in plugins)
            {
                if (p.Activado)
                {
                    p.Plugin.Terminate();
                }
            }
            plugins.Clear();
            PluginsActivos.Clear();
            PluginsVisibles.Clear();
        }
    }
}