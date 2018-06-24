Project File Overview:

  MapWindow.sln

    This is the Visual Studio 2005 project file including
    only the MapWindow application only, the "core mapwindow".

  MWPluginsCS.sln

    This is the Visual Studio 2005 project file including
    all of the associated MapWindow plugins that ship with
    the "base" MapWindow project and installation. This includes
    things like feature identifier, gistools, etc. The C# plugins
    are separated out into this project file.

  MWPluginsVB.sln

    This is the Visual Studio 2005 project file including
    all of the associated MapWindow plugins that ship with
    the "base" MapWindow project and installation. This includes
    things like feature identifier, gistools, etc. The VB.Net plugins
    are separated out into this project file.

Binaries:

  The Bin subdirectory contains a release-mode build. All binaries
  committed here should be built with Visual Studio 2005. With version
  4.3 and up, MapWindow is no longer supported from Visual Studio 2003.

  The one exception to this rule is MapWinInterfaces.dll, see below.

  If you don't have it already, you may need the .NET 2.0 framework:
  http://www.mapwindow.org/download/20-dotnetfx.exe

MapWinInterfaces.dll:

  For maximum compatibility, this project and it's binary will
  remain compiled with VS2003. This way, plug-ins may still be
  written with VS2003 even though MapWindow is built with 2005.

Thank you!

Any questions/comments? Use the MapWindow forum: http://forum.mapwindow.org

Mailing lists are available at:
http://lists.mapwindow.org