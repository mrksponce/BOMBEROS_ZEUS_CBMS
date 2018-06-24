Project File Overview:

  MapWindow2003.sln

    This is the project that we all know and love, the one you're
    probably used to. This is the Visual Studio 2003 project file 
    including MapWindow and associated plugins.

  MapWindow2005.sln

    This is the Visual Studio 2005 project file including
    only the MapWindow application and MapWinInterfaces.dll,
    basically the "core mapwindow".

  MWPlugins2005.sln

    This is the Visual Studio 2005 project file including
    all of the associated MapWindow plugins that ship with
    the "base" MapWindow project and installation. This includes
    things like feature identifier, gistools, etc.

Binaries:

  The Bin subdirectory contains a recent build. All binaries
  committed here should be built with Visual Studio 2005. If you
  only have VS2003, feel free to commit code - but please don't
  commit your binaries. Let someone with VS2005 build the binaries.
  We at ISU build often enough that, if you commit only code, it
  will appear in the binaries very soon after anyway.

New and Shiny VS2005 Features:

  We want to keep MapWindow compatible with Visual Studio 2003
  so that everybody doesn't need to ugprade unless they want to.
  Please don't commit any code using Dot Net 2.0-only features.
  This may change in the future, but this is the current plan.

Thank you!

Any questions/comments? Use the MapWindow forum: http://forum.mapwindow.org