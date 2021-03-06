//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Open Source. 
//
//The Initial Developer of this version of the Original Code is Daniel P. Ames using portions created by 
//Utah State University and the Idaho National Engineering and Environmental Lab that were released as 
//public domain in March 2004.  
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
//1/25/2005 Added additional interface elements needed to support 3.1 plug-ins (dpa)
//7/11/2005 cdm - added some custom window title properties.
//05/15/2007 Tom Shanley (tws) added SaveShapeSettings property to control save of shape-level formatting
//08/28/2008 Jiri Kadlec (jk) added nautical miles, acres and hectares to the UnitOfMeasure enumeration
//********************************************************************************************************

using System;
//using LegendControl;

namespace MapWindow
{
	namespace Interfaces
	{
		/// <summary>
		/// A function that is called upon close of a panel. The
		/// name (caption) of the closed panel is passed into the
		/// OnPanelClose function.
		/// </summary>
		public delegate void OnPanelClose(string Caption);

		/// <summary>
		/// Button constants for vb6 compatibility.
		/// </summary>
		public enum vb6Buttons
		{
			/// <summary>Left mouse button</summary>
			Left = 1,
			/// <summary>Right mouse button</summary>
			Right = 2,
			/// <summary>Middle mouse button.</summary>
			Middle = 3
		}
		

		/// <summary>
		/// Enumeration of supported layer types.
		/// </summary>
		public enum eLayerType
		{
			/// <summary>Invalid layer type</summary>
			Invalid = -1,
			/// <summary>Image layer</summary>
			Image = 0,
			/// <summary>Point shapefile layer</summary>
			PointShapefile = 1,
			/// <summary>Line shapefile layer</summary>
			LineShapefile = 2,
			/// <summary>Polygon shapefile layer</summary>
			PolygonShapefile = 3,
			/// <summary>Grid layer</summary>
			Grid = 4
		}

		/// <summary>
		/// Enumeration of possible preview map update types.
		/// </summary>
		public enum ePreviewUpdateExtents
		{
			/// <summary>
			/// Update using full exents.
			/// </summary>
			FullExtents = 0,
			/// <summary>
			/// Update using current map view.
			/// </summary>
			CurrentMapView = 1
		}
	
		/// <summary>
		/// Location of a click event within the legend.
		/// </summary>
		public enum ClickLocation
		{
			/// <summary>The user clicked outside of any group or layer.</summary>
			None = 0,
			/// <summary>The user clicked on a layer.</summary>
			Layer = 1,
			/// <summary>The user clicked on a group.</summary>
			Group = 2
		}
	
		/// <summary>
		/// Supported units of measure when requesting a Scalebar
		/// </summary>
		public enum UnitOfMeasure
		{
			/// <summary>The units are in decimal degrees.</summary>
			DecimalDegrees,
			/// <summary>The units are in millimeters.</summary>
			Millimeters,
			/// <summary>The units are in centimeters.</summary>
			Centimeters,
			/// <summary>The units are in inches.</summary>
			Inches,
			/// <summary>The units are in feet.</summary>
			Feet,
			/// <summary>The units are in Yards.</summary>
			Yards,
			/// <summary>The units are in meters.</summary>
			Meters,
			/// <summary>The units are in miles.</summary>
			Miles,
			/// <summary>The units are in kilometers.</summary>
			Kilometers,
            /// <summary>The units are in nautical miles.</summary>
            NauticalMiles,
            /// <summary>The units are in acres.</summary>
            Acres,
            /// <summary>The units are in hectares.</summary>
            Hectares,
            /// <summary>The units are unknown.</summary>
            Unknown
		}

		/// <summary>
		/// Alignment of text
		/// </summary>
		public enum eAlignment
		{
			/// <summary>Left align.</summary>
			Left = 0,
			/// <summary>Right align.</summary>
			Right = 1,
			/// <summary>Center align.</summary>
			Center = 2
		}

		/// <summary>
		/// Docking styles for MapWindow UIPanels
		/// </summary>
		public enum MapWindowDockStyle
		{
			/// <summary>Floating</summary>
			None = -1,
			/// <summary>Dock Left</summary>
			Left = 0,
			/// <summary>Dock Right</summary>
			Right = 1,
			/// <summary>Dock Top</summary>
			Top = 2,
			/// <summary>Dock Bottom</summary>
			Bottom = 3,
			/// <summary>Dock Left Autohidden</summary>
			LeftAutoHide = 4,
			/// <summary>Dock Right Autohidden</summary>
			RightAutoHide = 5,
			/// <summary>Dock Top Autohidden</summary>
			TopAutoHide = 6,
			/// <summary>Dock Bottom Autohidden</summary>
			BottomAutoHide = 7
		}

		/// <summary>
		/// Object given back when a ComboBox is added to the Toolbar. 
		/// </summary>
		public interface ComboBoxItem
		{
			/// <summary>
			/// Gets/Sets the cursor
			/// </summary>
			System.Windows.Forms.Cursor Cursor{get;set;}
			/// <summary>
			/// Gets/Sets the description for the control (used when the user customizes the Toolbar)
			/// </summary>
			string Description{get;set;}
			/// <summary>
			/// Gets/Sets the style of the combo box
			/// </summary>
			System.Windows.Forms.ComboBoxStyle DropDownStyle{get;set;}
			/// <summary>
			/// Gets/Sets the enabled state of the ComboBoxItem
			/// </summary>
			bool Enabled{get;set;}

			/// <summary>
			/// Returns a collection of items
			/// </summary>
			System.Windows.Forms.ComboBox.ObjectCollection Items();

			/// <summary>
			/// Gets the name of the ComboBoxItem object
			/// </summary>
			string Name{get;}

			/// <summary>
			/// Gets/Sets the zero based index of the selected item
			/// </summary>
			int SelectedIndex{get;set;}

			/// <summary>
			/// Gets/Sets the selected object
			/// </summary>
			object SelectedItem{get;set;}

			/// <summary>
			/// Gets/Sets the selected item text
			/// </summary>
			string SelectedText{get;set;}
			/// <summary>
			/// Gets/Sets the length of the highlighted text
			/// </summary>
			int SelectionLength{get;set;}
			/// <summary>
			/// Gets/Sets the start index of the highlighted text
			/// </summary>
			int SelectionStart{get;set;}

			/// <summary>
			/// Gets/Sets the text for this object
			/// </summary>
			string Text{get;set;}

			/// <summary>
			/// Gets/Sets the tooltip text for the control
			/// </summary>
			string Tooltip{get;set;}

			/// <summary>
			/// Gets/Sets the width of the control
			/// </summary>
			int Width{get;set;}
		}
	
		/// <summary>
		/// Object given back when a button is added to a Toolbar.  This 
		/// object can then be used to manipulate (change properties) for the button.
		/// </summary>
		public interface ToolbarButton
		{
			/// <summary>
			/// Gets/Sets the pressed state of the ToolbarButton
			/// </summary>
			bool Pressed{get;set;}

			/// <summary>
			/// Gets/Sets the Text/Caption of the ToolbarButton
			/// </summary>
			string Text{get;set;}

			/// <summary>
			/// Gets/Sets the picture for the ToolbarButton
			/// </summary>
			object Picture{get;set;}

			/// <summary>
			/// Gets/Sets the Category for this ToolbarButton item (used when user is customizing the Toolbar)
			/// </summary>
			string Category{get;set;}

			/// <summary>
			/// Gets/Sets the tooltip text for the control
			/// </summary>
			string Tooltip{get;set;}

			/// <summary>
			/// Gets/Sets a flag indicating that this item starts a new group by drawing a seperator line if necessary
			/// </summary>
			bool BeginsGroup{get;set;}

			/// <summary>
			/// Gets/Sets the Cursor for this control
			/// </summary>
			System.Windows.Forms.Cursor Cursor{get;set;}
			/// <summary>
			/// Gets/Sets the description for the control (used when the user customizes the Toolbar)
			/// </summary>
			string Description{get;set;}
			/// <summary>
			/// Gets/Sets a flag marking whether or not this ToolbarButton is displayed
			/// </summary>
			bool Displayed{get;set;}
			/// <summary>
			/// Gets/Sets the enabled state
			/// </summary>
			bool Enabled{get;set;}
			/// <summary>
			/// Gets the name of the ToolbarButton item
			/// </summary>
			string Name{get;}
			/// <summary>
			/// Gets/Sets the visibility of the ToolbarButton
			/// </summary>
			bool Visible{get;set;}
			/// <summary>
			/// Gets the number of subitems
			/// </summary>
			int NumSubItems{get;}
			/// <summary>
			/// Returns the Subitem with the specified zero-based index (null if out of range)
			/// </summary>
			ToolbarButton SubItem(int Index);
			/// <summary>
			/// returns the Subitem with the specified name (null if it doesn't exist)
			/// </summary>
			ToolbarButton SubItem(string Name);
		}

		/// <summary>
		/// Used to add/remove Toolbars, buttons, combo boxes, etc. to/from the application
		/// </summary>
		public interface Toolbar
		{
			/// <summary>
			/// Adds a Toolbar group to the Main Toolbar
			/// </summary>
			/// <param name="Name">The name to give to the Toolbar item</param>
			/// <returns>true on success, false on failure</returns>
			bool AddToolbar(string Name);
			
			/// <summary>
			/// Adds a button to a specified to the default Toolbar
			/// </summary>
			/// <param name="Name">The name to give to the new ToolbarButton</param>
			ToolbarButton AddButton(string Name);

			/// <summary>
			/// Adds a button to a specified to the default Toolbar
			/// </summary>
			/// <param name="Name">The name to give to the new ToolbarButton</param>
			/// <param name="IsDropDown">Should this button support drop-down items?</param>
			ToolbarButton AddButton(string Name, bool IsDropDown);

			/// <summary>
			/// Adds a button to a specified to the default Toolbar
			/// </summary>
			/// <param name="Name">The name to give to the new ToolbarButton</param>
			/// /// <param name="Toolbar">The name of the Toolbar to which this ToolbarButton should belong (if null or empty, then the default Toolbar will be used</param>
			/// <param name="IsDropDown">Should this button support drop-down items?</param>
			ToolbarButton AddButton(string Name, string Toolbar, bool IsDropDown);

			/// <summary>
			/// Adds a separator to a toolstrip dropdown button.
			/// </summary>
			/// <param name="Name">The name to give to the new separator.</param>
			/// <param name="ParentButton">The name of the ToolbarButton to which this new separator should be added as a subitem</param>
			/// <param name="Toolbar">The name of the Toolbar to which this separator should belong (if null or empty, then the default Toolbar will be used</param>
			void AddButtonDropDownSeparator(string Name, string Toolbar, string ParentButton);

			/// <summary>
			/// Adds a button to a specified to the default Toolbar
			/// </summary>
			/// <param name="Name">The name to give to the new ToolbarButton</param>
			/// <param name="Picture">The Icon/Bitmap to use as a picture on the ToolbarButton face</param>
			ToolbarButton AddButton(string Name, object Picture);
			/// <summary>
			/// Adds a button to a specified to the default Toolbar
			/// </summary>
			/// <param name="Name">The name to give to the new ToolbarButton</param>
			/// <param name="Picture">The Icon/Bitmap to use as a picture on the ToolbarButton face</param>
			/// <param name="Text">The text name for the ToolbarButton.  This is the text the user will see if customizing the Toolbar</param>
			ToolbarButton AddButton(string Name,object Picture, string Text);
			/// <summary>
			/// Adds a button to a specified to the specified Toolbar
			/// </summary>
			/// <param name="Name">The name to give to the new ToolbarButton</param>
			/// <param name="After">The name of the ToolbarButton after which this new ToolbarButton should be added</param>
			/// <param name="ParentButton">The name of the ToolbarButton to which this new ToolbarButton should be added as a subitem</param>
			/// <param name="Toolbar">The name of the Toolbar to which this ToolbarButton should belong (if null or empty, then the default Toolbar will be used</param>
			ToolbarButton AddButton(string Name, string Toolbar, string ParentButton, string After);
			/// <summary>
			/// Adds a ComboBoxItem to a specified to the default Toolbar
			/// </summary>
			/// <param name="Name">The name to give to the new ComboBoxItem</param>
			/// <param name="After">The name of the ToolbarButton/ComboBoxItem afterwhich this new item should be added</param>
			/// <param name="Toolbar">The name of the Toolbar to which this ToolbarButton should belong</param>
			ComboBoxItem AddComboBox(string Name, string Toolbar, string After);
			/// <summary>
			/// returns the specified ToolbarButton (null on failure)
			/// </summary>
			/// <param name="Name">The name of the ToolbarButton to retrieve</param>
			ToolbarButton ButtonItem(string Name);

			/// <summary>
			/// returns the specified ComboBoxItem
			/// </summary>
			/// <param name="Name">Name of the item to retrieve</param>
			ComboBoxItem ComboBoxItem(string Name);

			/// <summary>
			/// Removes the specified Toolbar and any ToolbarButton/ComboBoxItems contained within the control
			/// </summary>
			/// <param name="Name">The name of the Toolbar to be removed</param>
			/// <returns>true on success, false on failure</returns>
			bool RemoveToolbar(string Name);
			/// <summary>
			/// Removes the specified ToolbarButton item
			/// </summary>
			/// <param name="Name">The name of the ToolbarButton to be removed</param>
			/// <returns>true on success, false on failure</returns>
			bool RemoveButton(string Name);
			
			/// <summary>
			/// Removes the specified ComboBoxItem
			/// </summary>
			/// <param name="Name">The name of the ComboBoxItem to be removed</param>
			/// <returns>true on success, false on failure</returns>
			bool RemoveComboBox(string Name);

			/// <summary>
			/// Returns the number of buttons on the specified toolbar, or 0 if the toolbar can't be found.
			/// </summary>
			/// <param name="ToolbarName">The name of the toolbar.</param>
			/// <returns>The number of buttons on the toolbar.</returns>
			int NumToolbarButtons(string ToolbarName);

			/// <summary>
			/// Presses the specified ToolBar button (if it's enabled) as if a user
			/// had pressed it.
			/// </summary>
			/// <param name="Name">The name of the toolbar button to press.</param>
			/// <returns>true on success, false on failure (i.e. bad toolbar button name)</returns>
			bool PressToolbarButton(string Name);
		}

		/// <summary>
		/// Used to manipulate the status bar at the bottom of Mapwindow.
		/// </summary>
		public interface StatusBar
		{
			/// <summary>
			/// Gets/Sets the enabled state of the StatusBar
			/// </summary>
			bool Enabled{get;set;}
			/// <summary>
			/// Gets/Sets whether or not the StatusBar's ProgressBar should be shown
			/// </summary>
			bool ShowProgressBar{get;set;}
			/// <summary>
			/// Gets/Sets the value of the StatusBar's ProgressBar
			/// </summary>
			int ProgressBarValue {get; set;}

			/// <summary>
			/// Adds a new panel to the status bar.  This function has been deprecated.  Please use the 
			/// <c>AddPanel(Text)</c> overload.
			/// </summary>
			/// <returns>The StatusBarItem that was just added</returns>
			StatusBarItem AddPanel();

			/// <summary>
			///	Adds a new panel to the status bar.  This function has been deprecated.  Please use the 
			/// <c>AddPanel(Text)</c> overload.
			/// </summary>
			/// <param name="InsertAt">The index at which the panel should be added</param>
			/// <returns>The StatusBarItem that was just added</returns>
			StatusBarItem AddPanel(int InsertAt);

			/// <summary>
			/// This is the preferred method to use to add a statusbar panel.
			/// </summary>
			/// <param name="Text">Text to display in the panel.</param>
			/// <param name="Position">Position to insert panel at.</param>
			/// <param name="Width">Width of the panel in pixels.</param>
			/// <param name="AutoSize">Panel <c>AutoSize</c> property.</param>
			/// <returns>A <c>System.Windows.Forms.StatusBarPanel</c> object.</returns>
			System.Windows.Forms.StatusBarPanel AddPanel(string Text, int Position, int Width, System.Windows.Forms.StatusBarPanelAutoSize AutoSize);

			/// <summary>
			/// Removes the specified Panel.  There must always be one panel.  If you remove the last panel, the <c>MapWindow</c> will automatically add one.
			/// </summary>
			/// <param name="Index">Zero-Based index of the panel to be removed</param>
			void RemovePanel(int Index);

			/// <summary>
			/// Removes the panel object specified.  There must always be one panel.  If you remove the last panel, the <c>MapWindow</c> will automatically add one.
			/// </summary>
			/// <param name="Panel"><c>StatusBarPanel</c> to remove.</param>
			void RemovePanel(ref System.Windows.Forms.StatusBarPanel Panel);

			/// <summary>
			/// Iterator for all panels within the StatusBar
			/// </summary>
			/// <param name="index">Index of the StatusBarItem to retrieve</param>
			StatusBarItem this[int index]{get;}

			/// <summary>
			/// Returns the number of panels in the <c>StatusBar</c>.
			/// </summary>
			/// <returns>Number of panels in the <c>StatusBar</c>.</returns>
			int NumPanels{get;}

			/// <summary>
			/// This function makes the progress bar fit into the last panel of the status bar. Call this function whenever you change the size of ANY panel in the status bar.  You do not need to call this on <c>AddPanel</c> or <c>RemovePanel</c>.
			/// </summary>
			void ResizeProgressBar();

		}

		/// <summary>
		/// The object given back when a panel is added to the status bar.  This object can
		/// be used to 
		/// </summary>
		public interface StatusBarItem
		{
			/// <summary>
			/// Gets/Sets the Alignment of the text
			/// </summary>
			eAlignment Alignment{get;set;}

			/// <summary>
			/// Gets/Sets whether or not this StatusBarItem should auto size itself
			/// </summary>
			bool AutoSize{get;set;}

			/// <summary>
			/// Gets/Sets the minimum allowed width for this StatusBarItem
			/// </summary>
			int MinWidth{get;set;}

			/// <summary>
			/// Gets/Sets the Text within the StatusBarItem
			/// </summary>
			string Text{get;set;}

			/// <summary>
			/// Gets/Sets the width of the StatusBarItem
			/// </summary>
			int Width{get;set;}
		}

		/// <summary>
		/// Interface for manipulating the PreviewMap
		/// </summary>
		public interface PreviewMap
		{
			/// <summary>
			/// Gets/Sets the back color
			/// </summary>
			System.Drawing.Color BackColor{get;set;}

			/// <summary>
			/// Gets/Sets the Picture to be displayed
			/// </summary>
			System.Drawing.Image Picture{get;set;}
			/// <summary>
			/// Gets/Sets the color used for the LocatorBox
			/// </summary>
			System.Drawing.Color LocatorBoxColor{get;set;}

			/// <summary>
			/// Tells the PreviewMap to rebuild itself by getting new data from the main view
			/// </summary>
			void GetPictureFromMap();

			/// <summary>
			/// Tells the PreviewMap to rebuild itself by getting new data from the main view (current extents).
			/// </summary>
			void Update();

			/// <summary>
			/// Tells the PreviewMap to rebuild itself by getting new data from the main view.
			/// <param name="UpdateExtents">Update from full extent or current view?</param>
			/// </summary>
			void Update(ePreviewUpdateExtents UpdateExtents);

			/// <summary>
			/// Loads a picture into the PreviewMap from a specified file
			/// </summary>
			/// <param name="Filename">The path to the file to load</param>
			/// <returns>true on success, false on failure</returns>
			bool GetPictureFromFile(string Filename);
		}
		/// <summary>
		/// A collection of information about an available plugin
		/// </summary>
		public interface PluginInfo
		{
			/// <summary>
			/// Gets the Author information
			/// </summary>
			string Author{get;}

			/// <summary>
			/// Gets the build date
			/// </summary>
			string BuildDate{get;}

			/// <summary>
			/// Gets the plugin's description
			/// </summary>
			string Description{get;}

			/// <summary>
			/// Gets the name of the plugin
			/// </summary>
			string Name{get;}
			/// <summary>
			/// Gets the Version of the plugin
			/// </summary>
			string Version{get;}
			/// <summary>
			/// Gets the Globally Unique ID Number (if the plugin has one)
			/// </summary>
			string GUID{get;}
			/// <summary>
			/// Gets the Key for the plugin (the key is used in identifying this plugin from other available plugins)
			/// </summary>
			string Key{get;}
		}

		/// <summary>
		/// Interface for manipulating plugins of the IPlugin type.
		/// This differs from "CondensedPlugins" in that the Item ([]) property returns IPlugin
		/// instead of IPluginDetails. The original "Plugins" (this one) cannot be changed without breaking
		/// the backward compatibility of the interface.
		/// </summary>
        public interface Plugins : System.Collections.IEnumerable
		{
			/// <summary>
			/// clears all plugins from the list of available plugins, but doesn't unload loaded plugins
			/// </summary>
			void Clear();
			/// <summary>
			/// Add a plugin from a file
			/// </summary>
			/// <param name="Path">path to the plugin</param>
			/// <returns>true on success, false on failure</returns>
			bool AddFromFile(string Path);
			/// <summary>
			/// Adds any compatible plugins from a directory(recursive into subdirs)
			/// </summary>
			/// <param name="Path">path to the directory</param>
			/// <returns>true on success, false otherwise</returns>
			bool AddFromDir(string Path);
			/// <summary>
			/// Loads a plugin from an instance of an object
			/// </summary>
			/// <param name="Plugin">the Plugin object to load</param>
			/// <param name="PluginKey">The Key by which this plugin can be identified at a later time</param>
			/// <param name="SettingsString">A string that contains any settings that should be passed to the plugin after it is loaded into the system</param>
			/// <returns>true on success, false otherwise</returns>
			bool LoadFromObject(IPlugin Plugin, string PluginKey, string SettingsString);
			/// <summary>
			/// Loads a plugin from an instance of an object
			/// </summary>
			/// <param name="Plugin">the Plugin object to load</param>
			/// <param name="PluginKey">The Key by which this plugin can be identified at a later time</param>
			/// <returns>true on success, false otherwise</returns>
			bool LoadFromObject(IPlugin Plugin, string PluginKey);
			/// <summary>
			/// Starts (loads) a specified plugin
			/// </summary>
			/// <param name="Key">Identifying key for the plugin to start</param>
			/// <returns>true on success, false otherwise</returns>
			bool StartPlugin(string Key);
			/// <summary>
			/// Stops (unloads) a specified plugin
			/// </summary>
			/// <param name="Key">Identifying key for the plugin to stop</param>
			void StopPlugin(string Key);
			/// <summary>
			/// number of available plugins
			/// </summary>
			int Count{get;}

			/// <summary>
			/// Gets an IPlugin object from the list of all loaded plugins
			/// <param name="Index">0-based index into the list of plugins</param>
			/// </summary>
			IPlugin this[int Index]{get;}

			/// <summary>
			/// Removes a plugin from the list of available plugins and unloads the plugin if loaded
			/// </summary>
			/// <param name="IndexOrKey">0-based integer index or string key for the plugin to remove</param>
			void Remove(object IndexOrKey);

			/// <summary>
			/// Gets or Sets the default folder where plugins are loaded from 
			/// </summary>
			string PluginFolder{get;set;}

			/// <summary>
			/// Checks to see if a plugin is currently loaded (running)
			/// </summary>
			/// <param name="Key">Unique key identifying the plugin</param>
			/// <returns>true if loaded, false otherwise</returns>
			bool PluginIsLoaded(string Key);

			/// <summary>
			/// Shows the dialog for loading/starting/stopping plugins
			/// </summary>
			void ShowPluginDialog();

			/// <summary>
			/// Sends a broadcast message to all loaded plugins
			/// </summary>
			/// <param name="Message">The message that should be sent</param>
			void BroadcastMessage(string Message);

			/// <summary>
			/// Returns the key belonging to a plugin with the given name. An empty string is returned if the name is not found.
			/// </summary>
			/// <param name="PluginName">The name of the plugin</param>
			string GetPluginKey(string PluginName);
		}

		/// <summary>
		/// An object that represents a menu item within the Main Menu
		/// </summary>
		public interface MenuItem
		{
			/// <summary>
			/// Gets/Sets the Text shown for the MenuItem
			/// </summary>
			string Text{get;set;}

			/// <summary>
			/// Gets/Sets the icon for the menu item
			/// </summary>
			object Picture{get;set;}

			/// <summary>
			/// Gets/Sets the category for this item (used when the user customizes the menu)
			/// </summary>
			string Category{get;set;}

			/// <summary>
			/// Gets/Sets the checked state of the item
			/// </summary>
			bool Checked{get;set;}

			/// <summary>
			/// Gets/Sets the tool tip text that will pop up for the item when a mouse over event occurs
			/// </summary>
			string Tooltip{get;set;}

			/// <summary>
			/// Gets/Sets whether or not this item should draw a dividing line between itself and any
			/// items before this item
			/// </summary>
			bool BeginsGroup{get;set;}

			/// <summary>
			/// Gets/Sets the cursor used when the mouse is over this control
			/// </summary>
			System.Windows.Forms.Cursor Cursor{get;set;}

			/// <summary>
			/// Gets/Sets the description of this menu item, used in customization of menu by the user
			/// </summary>
			string Description{get;set;}

			/// <summary>
			/// Gets/Sets the Displayed state of this item
			/// </summary>
			bool Displayed{get;set;}

			/// <summary>
			///	Gets/Sets the enabled state of this item
			/// </summary>
			bool Enabled{get;set;}

			/// <summary>
			/// Gets the Name of this item
			/// </summary>
			string Name{get;}

			/// <summary>
			/// Gets/Sets the visibility state of this item
			/// </summary>
			bool Visible{get;set;}

			/// <summary>
			/// Gets the count of the submenu items contained within this item
			/// </summary>
			int NumSubItems{get;}

			/// <summary>
			/// Gets a submenu item by its 0-based index
			/// </summary>
			MenuItem SubItem(int Index);

			/// <summary>
			/// Gets a submenu item by its string name
			/// </summary>
			MenuItem SubItem(string Name);

			/// <summary>
			/// Returns whether this menu item is the first visible submenu item.
			/// This is only valid in submenus, i.e. menus which have a parent.
			/// </summary>
			bool IsFirstVisibleSubmenuItem{get;}
		}

		/// <summary>
		/// Used for manipulation of the menu system for the application
		/// </summary>
        public interface Menus
		{
			/// <summary>
			/// Adds a menu with the specified name
			/// </summary>
			MenuItem AddMenu(string Name);
			/// <summary>
			/// Adds a menu with the specified name and icon
			/// </summary>
			MenuItem AddMenu(string Name, object Picture);

			/// <summary>
			/// Adds a menu with the specified name, icon and text
			/// </summary>
			MenuItem AddMenu(string Name, object Picture, string Text);

			/// <summary>
			/// Adds a menu with the specified name to the menu indicated by ParentMenu
			/// </summary>
			MenuItem AddMenu(string Name, string ParentMenu);

			/// <summary>
			/// Adds a menu with the specified name and icon to the menu indicated by ParentMenu
			/// </summary>
			MenuItem AddMenu(string Name, string ParentMenu, object Picture);
			/// <summary>
			/// Adds a menu with the specified name, icon and text to the specified ParentMenu
			/// </summary>
			MenuItem AddMenu(string Name, string ParentMenu, object Picture, string Text);

			/// <summary>
			/// Adds a menu with the specified name, icon and text to the specified ParentMenu and after the specifed item
			/// </summary>
			MenuItem AddMenu(string Name, string ParentMenu, object Picture, string Text, string After);

			/// <summary>
			/// Adds a menu with the specified name and text to the specified ParentMenu and before the specifed item
			/// </summary>
			MenuItem AddMenu(string Name, string ParentMenu, string Text, string Before);

			/// <summary>
			/// Gets a MenuItem by its name
			/// </summary>
			MenuItem this[string MenuName]{get;}

			/// <summary>
			/// Removes a MenuItem
			/// </summary>
			/// <param name="Name">Name of the item to remove</param>
			/// <returns>true on success, false otherwise</returns>
			bool Remove(string Name);
		}

		
		/// <summary>
		/// The <c>SelectedShape</c> interface is used to access information about a shape that is selected in the MapWindow.
		/// </summary>
        public interface SelectedShape
		{
			/// <summary>
			/// Initializes all information in the <c>SelectedShape</c> object then highlights the shape on the map.
			/// </summary>
			/// <param name="ShapeIndex">Index of the shape in the shapefile.</param>
			/// <param name="SelectColor">Color to use when highlighting the shape.</param>
			void Add(int ShapeIndex, System.Drawing.Color SelectColor);

			/// <summary>
			/// Returns the extents of this selected shape.
			/// </summary>
			MapWinGIS.Extents Extents{get;}

			/// <summary>
			/// Returns the shape index of this selected shape.
			/// </summary>
			int ShapeIndex {get;}
		}

		/// <summary>
		/// This interface is used to manage and access all selected shapes.
		/// </summary>
		/// <remarks>All selection is done only to the selected layer.  The selected layer handle can be accessed using the <c>LayerHandle</c> property.</remarks>
        public interface SelectInfo : System.Collections.IEnumerable
		{
			/// <summary>
			/// Adds a <c>SelectedShape</c> object to the managed collection of all selected shapes.
			/// </summary>
			/// <param name="newShape">The <c>SelectedShape</c> object to add.</param>
			void AddSelectedShape(SelectedShape newShape);

			/// <summary>
			/// Adds a new <c>SelectedShape</c> to the collection from the provided shape index.
			/// </summary>
			/// <param name="ShapeIndex">The index of the shape to add.</param>
			/// <param name="SelectColor">The color to use when highlighting the shape.</param>
			void AddByIndex(int ShapeIndex, System.Drawing.Color SelectColor);

			/// <summary>
			/// Clears the list of selected shapes, returning each selected shape to it's original color.
			/// </summary>
			void ClearSelectedShapes();

			/// <summary>
			/// Removes a <c>SelectedShape</c> from the collection, reverting it to it's original color.
			/// </summary>
			/// <param name="ListIndex">Index in the collection of the <c>SelectedShape</c>.</param>
			void RemoveSelectedShape(int ListIndex);

			/// <summary>
			/// Removes a <c>SelectedShape</c> from the collection, reverting it to it's original color.
			/// </summary>
			/// <param name="ShapeIndex">The shape index of the <c>SelectedShape</c> to remove.</param>
			void RemoveByShapeIndex(int ShapeIndex);

			/// <summary>
			/// Returns the LayerHandle of the selected layer.
			/// </summary>
			int LayerHandle{get;}

			/// <summary>
			/// Returns the number of shapes that are currently selected.
			/// </summary>
			int NumSelected{get;}

			/// <summary>
			/// Returns the total extents of all selected shapes.
			/// </summary>
			MapWinGIS.Extents SelectBounds{get;}

			/// <summary>
			/// Returns the <c>SelectedShape</c> at the specified index.
			/// </summary>
			SelectedShape this[int Index] {get;}
		}

		/// <summary>
		/// The draw interface is used to add custom drawing to the MapWindow view.
		/// </summary>
		public interface Draw
		{
			/// <summary>
			/// Clears all custom drawing on the specified drawing layer.
			/// </summary>
			/// <param name="DrawHandle">Handle of the drawing layer to clear.</param>
			/// <remarks>Clearing a single drawing (using the drawing handle) is faster than clearing all drawings.</remarks>
			void ClearDrawing(int DrawHandle);

			/// <summary>
			/// Clears all custom drawings on all drawing layers.
			/// </summary>
			/// <remarks>Clearing a single drawing (using the drawing handle) is faster than clearing all drawings.</remarks>
			void ClearDrawings();

			/// <summary>
			/// Draws a circle on the current drawing layer.
			/// </summary>
			/// <param name="x">X coordinate of the center of the circle.</param>
			/// <param name="y">Y coordinate of the center of the circle.</param>
			/// <param name="PixelRadius">Radius of the circle in pixels.</param>
			/// <param name="Color">Color to use when drawing the circle.</param>
			/// <param name="FillCircle">Specifies whether or not the circle is drawn filled.</param>
			void DrawCircle(double x, double y, double PixelRadius, System.Drawing.Color Color, bool FillCircle);

			/// <summary>
			/// Draws a line on the current drawing layer.
			/// </summary>
			/// <param name="X1">First x coordinate.</param>
			/// <param name="Y1">First y coordinate.</param>
			/// <param name="X2">Second x coordinate.</param>
			/// <param name="Y2">Second y coordinate.</param>
			/// <param name="PixelWidth">Width of the line in pixels</param>
			/// <param name="Color">Color to draw the line with.</param>
			void DrawLine(double X1, double Y1, double X2, double Y2, int PixelWidth, System.Drawing.Color Color);

			/// <summary>
			/// Draws a point on the current drawing layer.
			/// </summary>
			/// <param name="x">X coordinate.</param>
			/// <param name="y">Y coordinate.</param>
			/// <param name="PixelSize">Size of the point in pixels.</param>
			/// <param name="Color">Color to draw the point with.</param>
			void DrawPoint(double x, double y , int PixelSize, System.Drawing.Color Color);

			/// <summary>
			/// Draws a polygon on the current drawing layer.
			/// </summary>
			/// <param name="x">Array of x points for the polygon.</param>
			/// <param name="y">Array of y points for the polygon.</param>
			/// <param name="Color">Color to draw the polygon with.</param>
			/// <param name="FillPolygon">Specifies whether or not to fill the polygon.</param>
			/// <remarks>The points in a polygon should be defined in a clockwise order and have no
			/// crossing lines if they are to be filled.  The first and last point should be the same.</remarks>
			void DrawPolygon(double [] x , double [] y, System.Drawing.Color Color, bool FillPolygon );

			/// <summary>
			/// Creates a new drawing layer.
			/// </summary>
			/// <param name="Projection">Specifies whether to use screen coordinates or projected map coordinates.</param>
			/// <returns>Returns a drawing handle.  You should save this handle if you wish to clear this drawing later.</returns>
			/// <remarks>The concept of drawing layers is only partially implemented in this version of the MapWinGIS, which is used
			/// by the MapWindow.  There is only one active drawing layer, which is the most recently created one.  There is no
			/// way to access any other drawing layers other than the current one.</remarks>
			int  NewDrawing(MapWinGIS.tkDrawReferenceList Projection);

			/// <summary>
			/// Specifies whether or not to use double buffering.  Double buffering makes the drawing of the 
			/// custom drawings smoother (not flickering). It is recommended that you use double buffering. 
			/// </summary>
			bool DoubleBuffer{get;set;}
		}

		/// <summary>
		/// This interface is used to access the list of shapes that were found during an Identify function call.
		/// </summary>
		public interface IdentifiedShapes
		{
			/// <summary>
			/// Returns the number of shapes that were identified.
			/// </summary>
			int Count{get;}

			/// <summary>
			/// Returns the shape index of an identified that is stored at the position 
			/// specified by the Index parameter.
			/// </summary>
			int this[int Index]{get;}
		}

		/// <summary>
		/// IdentifiedLayers is used to access the list of layers that contained any 
		/// information gathered during an Identify function call.
		/// </summary>
		public interface IdentifiedLayers
		{
			/// <summary>
			/// Returns the number of layers that had information from the Identify function call.
			/// </summary>
			int Count{get;}

			/// <summary>
			/// Returns an <c>IdentifiedShapes</c> object containing inforamtion about shapes that were 
			/// identified during the Identify function call.
			/// </summary>
			IdentifiedShapes this[int LayerHandle]{get;}
		}

		/// <summary>
		/// The View interface is used to manipulate or work with the main MapWindow display.
		/// </summary>
		public interface View
		{
			/// <summary>
			/// Clears all selected shapes from the MapWindow, reverting them to their original colors.
			/// </summary>
			void ClearSelectedShapes();

			/// <summary>
			/// Queries all of the active shapefile layers for any within the specified tolerance of the given point.
			/// </summary>
			/// <param name="ProjX">The x coordinate, in projected map units, of the point to query.</param>
			/// <param name="ProjY">The y coordinate, in projected map units, of the point to query.</param>
			/// <param name="Tolerance">Tolerance is the distance, in projected map units, around the point to include in the query.</param>
			/// <returns>Returns an <c>IdentifiedLayers</c> object containing query results.</returns>
			IdentifiedLayers Identify(double ProjX, double ProjY, double Tolerance);

			/// <summary>
			/// Prevents the legend from showing any changes made to it until the <c>UnlockLegend</c> function is called. 
			/// The legend maintains a count of the number of locks it has, only redrawing if there are no locks.
			/// </summary>
			void LockLegend();

			/// <summary>
			/// Unlocking the Legend allows it to redraw and update the view to reflect any changes that were made. 
			/// The legend maintains a count of the number of locks it has, only redrawing if there are no locks.  
			/// There can never be a negative number of locks. 
			/// </summary>
			void UnlockLegend();

			/// <summary>
			/// Prevents the map from updating due to any changes made to the layers that are loaded until the <c>UnlockMap</c> function is called. 
			/// The map maintains a count of the number of locks it has, only redrawing if there are no locks. 
			/// </summary>
			void LockMap();

			/// <summary>
			/// Determines whether the preview map panel is visible.
			/// </summary>
			bool PreviewVisible{get;set;}

			/// <summary>
			/// Determines whether the legend panel is visible.
			/// </summary>
			bool LegendVisible{get;set;}

			/// <summary>
			/// Allows the map to redraw entirely when changes are made. 
			/// The map maintains a count of the number of locks it has, only redrawing if there are no locks. 
			/// There can never be a negative number of locks. 
			/// </summary>
			void UnlockMap();

			/// <summary>
			/// Converts a point in pixel coordinates to a point in projected map units. 
			/// </summary>
			/// <param name="PixelX">X coordinate of the original point in pixels.</param>
			/// <param name="PixelY">Y coordinate of the original point in pixels.</param>
			/// <param name="ProjX">ByRef.  X coordinate of the projected point.</param>
			/// <param name="ProjY">ByRef.  Y coordinate of the projected point.</param>
			void PixelToProj(double PixelX, double PixelY, ref double ProjX, ref double ProjY);

			/// <summary>
			/// Converts a point in projected map units to a point in screen coordinates. 
			/// </summary>
			/// <param name="ProjX">X coordinate of the projected map point.</param>
			/// <param name="ProjY">Y coordinate of the projected map point.</param>
			/// <param name="PixelX">ByRef. X coordinate of the screen point in pixels.</param>
			/// <param name="PixelY">ByRef. Y coordinate of the screen point in pixels.</param>
			void ProjToPixel(double ProjX, double ProjY, ref double PixelX, ref double PixelY);

			/// <summary>
			/// Forces the map to redraw.  This function has no effect if the map is locked. 
			/// </summary>
			void Redraw();

			/// <summary>
			/// Shows a tooltip under the cursor on the map. 
			/// </summary>
			/// <param name="Text">The text to display in the tooltip.</param>
			/// <param name="Milliseconds">Number of milliseconds before the tooltip automatically disappears.</param>
			void ShowToolTip(string Text, int Milliseconds);

			/// <summary>
			/// Zooms the view to the maximum extents of all the loaded and visible layers. 
			/// </summary>
			void ZoomToMaxExtents();

			/// <summary>
			/// Zooms the display in by the given factor. 
			/// </summary>
			/// <param name="Percent">The percentage to zoom by.</param>
			void ZoomIn(double Percent);

			/// <summary>
			/// Zooms the display out by the given factor. 
			/// </summary>
			/// <param name="Percent">The percentage to zoom by.</param>
			void ZoomOut(double Percent);

			/// <summary>
			/// Zooms to the previous extent. 
			/// </summary>
			void ZoomToPrev();

			/// <summary>
			/// Takes a snapshot of the currently visible layers at the extents specified. 
			/// </summary>
			/// <param name="Bounds">The area to take the snapshot of.</param>
			MapWinGIS.Image Snapshot(MapWinGIS.Extents Bounds);

			/// <summary>
			/// Gets or sets the background color of the map. 
			/// </summary>
			System.Drawing.Color BackColor{get;set;}

			/// <summary>
			/// Gets or sets the current cursor mode.  The cursor mode can be any of the following: 
			/// <list type="bullet">
			/// <item>cmNone</item>
			/// <item>cmPan</item>
			/// <item>cmSelection</item>
			/// <item>cmZoomIn</item>
			/// <item>cmZoomOut</item>
			/// </list>
			/// </summary>
			MapWinGIS.tkCursorMode CursorMode{get;set;}
			
			/// <summary>
			/// Returns a <c>MapWindow.Interfaces.Draw</c> interface used to add custom drawing to the map. 
			/// </summary>
			Draw Draw{get;}

			/// <summary>
			/// Gets or sets the amount to pad around the extents when calling <c>ZoomToMaxExtents</c>, 
			/// <c>ZoomToLayer</c>, and <c>ZoomToShape</c>.
			/// </summary>
			double ExtentPad{get;set;}

			/// <summary>
			/// Gets or sets the map's current extents. 
			/// </summary>
			MapWinGIS.Extents Extents{get;set;}

			/// <summary>
			/// Gets or sets the cursor to use on the map.  The enumeration can be any of the following: 
			/// <list type="bullet">
			/// <item>crsrAppStarting</item>
			/// <item>crsrArrow</item>
			/// <item>crsrCross</item>
			/// <item>crsrHelp</item>
			/// <item>crsrIBeam</item>
			/// <item>crsrMapDefault</item>
			/// <item>crsrNo</item>
			/// <item>crsrSizeAll</item>
			/// <item>crsrSizeNESW</item>
			/// <item>crsrSizeNS</item>
			/// <item>crsrSizeNWSE</item>
			/// <item>crsrSizeWE</item>
			/// <item>crsrUpArrow</item>
			/// <item>crsrUserDefined</item>
			/// <item>crsrWait</item>
			/// </list>
			/// </summary>
			MapWinGIS.tkCursor MapCursor{get;set;}

			/// <summary>
			/// Indicates that the map should handle file drag-drop events (as opposed to firing a message indicating file(s) were dropped).
			/// </summary>
			bool HandleFileDrop{get;set;}

			/// <summary>
			/// Gets or sets the <c>MapState</c> string which describes in a single string the entire 
			/// map state, including layers and coloring schemes. 
			/// </summary>
			string MapState{get;set;}

			/// <summary>
			/// Returns a <c>SelectInfo</c> object containing information about all shapes that are currently selected. 
			/// </summary>
			SelectInfo SelectedShapes{get;}

			/// <summary>
			/// Determines whether labels are loaded from and saved to a project-specific label file or from a shapefile-specific label file. Using a project-level label file will create a new subdirectory with the project's name.
			/// </summary>
			bool LabelsUseProjectLevel{get; set;}

			/// <summary>
			/// Triggers reloading of field values for the given layer. No action will occur if the layer handle is invalid, not a shapefile, or has no labels.
			/// </summary>
			/// <param name="LayerHandle"></param>
			void LabelsRelabel(int LayerHandle);

			/// <summary>
			/// Displays the label editor form for the specified layer. No action will occur if the layer handle is invalid or not a shapefile.
			/// </summary>
			/// <param name="LayerHandle"></param>
			void LabelsEdit(int LayerHandle);

			/// <summary>
			/// Gets or sets whether selection should be persistent.  If selection is persistent, previously selected 
			/// shapes are not cleared before selecting the new shapes.  When selection is persistent you must select 
			/// nothing to clear the selection.  The default value for this property is false.  When selection is not 
			/// persistent, all selected shapes are cleared between selection routines unless the user is holding down 
			/// a control or shift key. 
			/// </summary>
			bool SelectionPersistence{get;set;}

			/// <summary>
			/// The tolerance, in projected map units, to use for selection. 
			/// </summary>
			double SelectionTolerance{get;set;}

			/// <summary>
			/// Gets or sets the selection method to use.   
			/// <list type="bullet">
			/// <item>Inclusion</item>
			/// <item>Intersection</item>
			/// </list>
			/// Inclusion means that the entire shape must be within the selection bounds in order to select 
			/// the shape.  Intersection means that only a portion of the shape must be within the selection 
			/// bounds in order for the shape to be selected. 
			/// </summary>
			MapWinGIS.SelectMode SelectMethod{get;set;}
			
			/// <summary>
			/// Gets or sets the color used to indicate a selected shape. 
			/// </summary>
			System.Drawing.Color SelectColor{get;set;}

			/// <summary>
			/// Gets or sets a tag for the map.  The tag is a string variable that can be used by a developer 
			/// to store any information they desire. 
			/// </summary>
			string Tag{get;set;}

			/// <summary>
			/// Gets or sets the handle of the cursor to use when the <c>CursorMode</c> is <c>cmUserDefined</c>. 
			/// </summary>
			int UserCursorHandle{get;set;}

			/// <summary>
			/// Gets or sets the default zoom percentage to use when interacting with the map using a mouse. 
			/// </summary>
			double ZoomPercent{get;set;}

			/// <summary>
			/// Selects shapes in the mapwindow from the specified point.  The tolerance used is the global 
			/// tolerance set through the <c>View.SelectionTolerance</c>.  This function uses the same selection 
			/// routines that are called when a user selects with a mouse. 
			/// </summary>
			/// <param name="ScreenX">The x coordinate in pixels of the location to select.</param>
			/// <param name="ScreenY">The y coordinate in pixels of the location to select.</param>
			/// <param name="ClearOldSelection">Specifies whether to clear all previously selected shapes or not.</param>
			SelectInfo Select(int ScreenX, int ScreenY, bool ClearOldSelection);

			/// <summary>
			/// Selects shapes in the mapwindow from the specified rectangle.  This function uses the 
			/// same selection routines that are called when a user selects with a mouse.
			/// </summary>
			/// <param name="ScreenBounds">The rectangle to select shapes with.  This rectangle must be in screen (pixel) coordinates.</param>
			/// <param name="ClearOldSelection">Specifies whether to clear all previously selected shapes or not.</param>
			SelectInfo Select(System.Drawing.Rectangle ScreenBounds, bool ClearOldSelection);
		}

		/// <summary>
		/// The shape interface contains the prperties and methods relating to a single shape in a shapefile. 
		/// </summary>
		public interface Shape
		{
			/// <summary>
			/// Zooms the display so that this shape fills the view.  The <c>View.ExtentPad</c> will add a little 
			/// space around the shape so that is is easy to see the whole shape. 
			/// </summary>
			void ZoomTo();

			/// <summary>
			/// Gets or sets the color of this shape. 
			/// </summary>
			System.Drawing.Color Color {get; set;}

			/// <summary>
			/// Gets or sets whether to draw the fill for this shape.  Only applies to polygon shapes. 
			/// </summary>
			bool DrawFill {get; set;}

			/// <summary>
			/// Gets or sets the fill stipple for the shape.  Only applies to polygon shapes. 
			/// 
			/// The valid values for this property are: 
			/// <list type="bullet">
			/// <item>fsCustom</item>
			/// <item>fsDiagonalDownLeft</item>
			/// <item>fsDiagonalDownRight</item>
			/// <item>fsHorizontalBars</item>
			/// <item>fsNone</item>
			/// <item>fsPolkaDot</item>
			/// <item>fsVerticalBars</item>
			/// </list>
			/// </summary>
			MapWinGIS.tkFillStipple FillStipple {get; set;}

			/// <summary>
			/// Gets or sets the line or point size.  If the <c>PointType</c> is <c>ptUserDefined</c> then the 
			/// size of the user defined point will be multiplied by the <c>LineOrPointSize</c>.  For all other 
			/// points and for lines, the <c>LineOrPointSize</c> is represented in pixels. 
			/// </summary>
			float LineOrPointSize {get; set;}

			/// <summary>
			/// Gets or sets the stipple pattern to use for the shape. 
			/// 
			/// The valid values for this property are:
			/// <list type="bullet">
			/// <item>lsCustom</item>
			/// <item>lsDashDotDash</item>
			/// <item>lsDashed</item>
			/// <item>lsDotted</item>
			/// <item>lsNone</item>
			/// </list>
			/// </summary>
			MapWinGIS.tkLineStipple LineStipple {get; set;}

			/// <summary>
			/// Gets or sets the outline color for this shape.  Only applies to polygon shapes. 
			/// </summary>
			System.Drawing.Color OutlineColor {get; set;}

			/// <summary>
			/// Gets or sets the point type for this shape. 
			/// 
			/// The valid values for this property are: 
			/// <list type="bullet">
			/// <item>ptCircle</item>
			/// <item>ptDiamond</item>
			/// <item>ptImageList</item>
			/// <item>ptSquare</item>
			/// <item>ptTriangleDown</item>
			/// <item>ptTriangleLeft</item>
			/// <item>ptTriangleRight</item>
			/// <item>ptTriangleUp</item>
			/// <item>ptUserDefined</item>
			/// </list>
			/// </summary>
			MapWinGIS.tkPointType PointType {get; set;}

			/// <summary>
			/// Gets or sets whether this shape is visible or not. 
			/// </summary>
			bool Visible {get; set;}


			/// <summary>
			/// Shows all vertices for this line or polygon shape.  Vertices can be hidden by calling 
			/// <c>HideVertices</c>.
			/// </summary>
			/// <param name="color">Color used to draw vertices.</param>
			/// <param name="vertexSize">Size of the vertices, in pixels.</param>
			void ShowVertices(System.Drawing.Color color, int vertexSize);

			/// <summary>
			/// Hides all vertices that have been shown by calling <c>ShowVertices</c>. 
			/// </summary>
			void HideVertices();

			/// <summary>
			/// Gets or sets the image index to be used from the list of images for the tkImageList point type.
			/// See also (on the layer interface) UserPointImageListAdd, UserPointImageListCount, ClearUDPointImageList.
			/// </summary>
			long ShapePointImageListID {get; set;}

			/// <summary>
			/// Gets or sets the percentage of transparency for a given polygon shape.
			/// </summary>
			float ShapeFillTransparency {get; set;}
		}

		/// <summary>
		/// This interface is used to access individual shapes from a shapefile layer. 
		/// </summary>
        public interface Shapes : System.Collections.IEnumerable
		{
			/// <summary>
			/// Returns the number of shapes in a shapefile. 
			/// </summary>
			int NumShapes {get;}

			/// <summary>
			/// Returns a single shape in the shapefile by it's index. 
			/// </summary>
			Shape this[int Index] {get;}
		}

	
		/// <summary>
		/// This interface is used to access properties and methods for a layer. 
		/// </summary>
		public interface Layer
		{
            ///The following was added for plug-in 3.1 version compatibility
			/// <summary>
			/// Sets the width between lines for multiple-line drawing styles (e.g, doublesolid).
			/// </summary>
			int LineSeparationFactor{get; set;}

			/// <summary>
			/// Adds a label to this layer.
			/// </summary>
			/// <param name="Text">The text of the label.</param>
			/// <param name="TextColor">The color of the label text.</param>
			/// <param name="xPos">X position in projected map units.</param>
			/// <param name="yPos">Y position in projected map units.</param>
			/// <param name="Justification">Text justification.  Can be hjCenter, hjLeft or hjRight.</param>
			void AddLabel(string Text, System.Drawing.Color TextColor, double xPos, double yPos, MapWinGIS.tkHJustification Justification);

            ///The following function was added for plug-in 3.1 version compatibility
			/// <summary>
			/// Adds an extended label to this layer.
			/// </summary>
			/// <param name="Text">The text of the label.</param>
			/// <param name="TextColor">The color of the label text.</param>
			/// <param name="xPos">X position in projected map units.</param>
			/// <param name="yPos">Y position in projected map units.</param>
			/// <param name="Justification">Text justification.  Can be hjCenter, hjLeft or hjRight.</param>
			/// <param name="Rotation">The rotation angle for the label.</param>
			void AddLabelEx(string Text, System.Drawing.Color TextColor, double xPos, double yPos, MapWinGIS.tkHJustification Justification, double Rotation);

			/// <summary>
			/// Updates the label information file stored for this layer. 
			/// </summary>
			void UpdateLabelInfo();

			/// <summary>
			/// Clears all labels for this layer.
			/// </summary>
			void ClearLabels();
        
			/// <summary>
			/// Sets the font to use for all labels on this layer. 
			/// </summary>
			/// <param name="FontName">Name of the font or font family.  Example:  "Arial"</param>
			/// <param name="FontSize">Size of the font.</param>
			void Font(string FontName, int FontSize);

			/// <summary>
			/// Zooms the display to this layer, taking into acount the <c>View.ExtentPad</c>. 
			/// </summary>
			void ZoomTo();
			
			/// <summary>
			/// Gets the underlying MapWinGIS object for this layer.  The object can be either a 
			/// <c>MapWinGIS.Shapefile</c> or a <c>MapWinGIS.Image</c>.  If the layer is a grid layer the 
			/// <c>MapWinGIS.Grid</c> object can be retrieved using the <c>GetGridObject</c> method. 
			/// </summary>
			Object GetObject();

			/// <summary>
			/// Moves this layer to a new position in the layer list.  The highest position is the topmost layer 
			/// in the display.
			/// </summary>
			/// <param name="NewPosition">The new position.</param>
			/// <param name="TargetGroup">The group to put this layer in.</param>
			void MoveTo(int NewPosition, int TargetGroup);

			/// <summary>
			/// Gets or sets the color of this shapefile.  Applies only to shapefiles.  Setting the color of the 
			/// shapefile will clear any selected shapes and will also reset each individual shape to the same color. 
			/// The coloring scheme will also be overriden.
			/// </summary>
			System.Drawing.Color Color {get; set;}

			/// <summary>
			/// Gets or sets whether or not to draw the fill for a polygon shapefile. 
			/// </summary>
			bool  DrawFill {get; set;}

			/// <summary>
			/// Gets or sets whether the layer's coloring scheme is expanded in the legend. 
			/// </summary>
			bool Expanded {get; set;}

			/// <summary>
			/// Returns the extents of this layer.
			/// </summary>
			MapWinGIS.Extents Extents{get;}

			/// <summary>
			/// Returns the filename of this layer.  If the layer is memory-based only it may not have a valid filename. 
			/// </summary>
			string FileName{get;}

			/// <summary>
			/// Returns or sets the projection of this layer.
			/// Projections must be / will be in PROJ4 format.
			/// If no projection is present, "" will be returned.
			/// If an invalid projection is provided, it's not guaranteed to be saved!
			/// </summary>
			string Projection{get; set;}

			/// <summary>
			/// Gets or sets the stipple pattern to use for the entire shapefile. 
			/// 
			/// The valid values for this property are:
			/// <list type="bullet">
			/// <item>lsCustom</item>
			/// <item>lsDashDotDash</item>
			/// <item>lsDashed</item>
			/// <item>lsDotted</item>
			/// <item>lsNone</item>
			/// </list>
			/// </summary>
			MapWinGIS.tkFillStipple FillStipple {get; set;}

			/// <summary>
			/// Returns the <c>MapWinGIS.Grid</c> object associated with the layer.  If the layer is not a 
			/// grid layer, "Nothing" will be returned.
			/// </summary>
			MapWinGIS.Grid GetGridObject{get;}

			/// <summary>
			/// Returns the layer handle of this layer.  The MapWindow automatically sets the <c>LayerHandle</c> for the layer, and it cannot be reset.
			/// </summary>
			int Handle {get; set;}
            ///The following label properties were added for plug-in 3.1 version compatibility           
			/// <summary>
			/// Determines the distance from the label point to the text for the label in pixels.
			/// </summary>
			int LabelsOffset {get; set;}

			/// <summary>
			/// Determines whether labels are scaled for this layer.
			/// </summary>
			bool LabelsScale {get; set;}

			/// <summary>
			/// Determines the color of the labels shadows.
			/// </summary>
			System.Drawing.Color LabelsShadowColor {get; set;}

            /// <summary>
            /// Causes any hatching coloring schemes to be recalculated and reapplied.
            /// </summary>
            void HatchingRecalculate();

			/// <summary>
			/// Determines whether labels are shadowed for this layer.
			/// </summary>
			bool LabelsShadow {get; set;}

			/// <summary>
			/// Turns labels on or off for this layer.
			/// </summary>
			bool LabelsVisible {get; set;}

			/// <summary>
			/// Determines whether MapWinGIS ocx will hide labels which collide with already drawn labels or not.
			/// </summary>
			bool UseLabelCollision{get;set;}

			/// <summary>
			/// Returns the type of this layer.  Valid values are:
			/// <list type="bullet">
			/// <item>Grid</item>
			/// <item>Image</item>
			/// <item>Invalid</item>
			/// <item>LineShapefile</item>
			/// <item>PointShapefile</item>
			/// <item>PolygonShapefile</item>
			/// </list>
			/// </summary>
			eLayerType LayerType {get;}

			/// <summary>
			/// Gets or sets the coloring scheme.  The <c>Shapefile</c> and <c>Grid</c> objects each have 
			/// their own coloring scheme object.  It is important to cast the <c>ColoringScheme</c> to the 
			/// proper type.
			/// </summary>
			object ColoringScheme {get; set;}

            /// <summary>
            /// Gets or sets the hatching scheme. This is used to define hatch patterns for polygon shapes.
            /// </summary>
            MapWindow.Interfaces.ShapefileFillStippleScheme FillStippleScheme {get; set;}

            /// <summary>
            /// Gets or sets the hatching line color. This is used to define hatch patterns for polygon shapes.
            /// </summary>
            System.Drawing.Color FillStippleLineColor { get; set;}

            /// <summary>
            /// Gets or sets the hatching transparency. This is used to define hatch patterns for polygon shapes.
            /// </summary>
            bool FillStippleTransparency { get; set;}

			/// <summary>
			/// Gets or sets the icon to use in the legend for this layer.
			/// </summary>
			object Icon {get;set;}

			/// <summary>
			/// Gets or sets the line or point size.  If the <c>PointType</c> is <c>ptUserDefined</c> then the 
			/// size of the user defined point will be multiplied by the <c>LineOrPointSize</c>.  For all other 
			/// points and for lines, the <c>LineOrPointSize</c> is represented in pixels.
			/// </summary>
			float LineOrPointSize {get; set;}

            /// <summary>
            /// Allows you to force the expansion box option to be shown, e.g. you're planning to use ExpansionBoxCustomRenderFunction.
            /// </summary>
            bool ExpansionBoxForceAllowed {get; set;}

            /// <summary>
            /// Allows you to render the expanded region of a layer yourself. Useful with ExpansionBoxForceAllowed=true.
            /// If you use this, you must also set ExpansionBoxCustomHeight.
            /// </summary>
            LegendControl.ExpansionBoxCustomRenderer ExpansionBoxCustomRenderFunction {get; set;}

            /// <summary>
            /// Tells the legend how high your custom rendered legend will be, so that it can
            /// arrange items around it.
            /// </summary>
            LegendControl.ExpansionBoxCustomHeight ExpansionBoxCustomHeightFunction { get; set;}

			/// <summary>
			/// Gets or sets the stipple pattern to use for the entire shapefile. 
			/// 
			/// The valid values for this property are:
			/// <list type="bullet">
			/// <item>lsCustom</item>
			/// <item>lsDashDotDash</item>
			/// <item>lsDashed</item>
			/// <item>lsDotted</item>
			/// <item>lsNone</item>
			/// </list>
			/// </summary>
			MapWinGIS.tkLineStipple LineStipple {get; set;}

			/// <summary>
			/// Gets or sets the layer name.
			/// </summary>
			string Name {get; set;}

			/// <summary>
			/// Gets or sets the outline color for this layer.  Only applies to polygon shapefile layers.
			/// </summary>
			System.Drawing.Color OutlineColor {get; set;}

			/// <summary>
			/// Gets or sets the point type for this shapefile.
			/// 
			/// The valid values for this property are:
			/// <list type="bullet">
			/// <item>ptCircle</item>
			/// <item>ptDiamond</item>
			/// <item>ptSquare</item>
			/// <item>ptTriangleDown</item>
			/// <item>ptTriangleLeft</item>
			/// <item>ptTriangleRight</item>
			/// <item>ptTriangleUp</item>
			/// <item>ptUserDefined</item>
			/// </list>
			/// </summary>
			MapWinGIS.tkPointType PointType {get; set;}

			/// <summary>
			/// Gets or sets the position of the layer without respect to any group.
			/// </summary>
			int GlobalPosition {get; set;}

			/// <summary>
			/// Gets or sets the position of the layer within a group.
			/// </summary>
			int GroupPosition {get; set;}
			
			/// <summary>
			/// Gets or sets the handle of the group that this layer belongs to.
			/// </summary>
			int GroupHandle {get; set;}
			
			/// <summary>
			/// This property gives access to all shapes in the layer.  Only applies to shapefile layers.
			/// </summary>
			Shapes Shapes {get;}

            ///The following property was added for plug-in 3.1 version compatibility
			/// <summary>
			/// This property allows the user to select the standard view width for the layer.
			/// </summary>
			double StandardViewWidth {get; set;}

			/// <summary>
			/// Gets or sets the tag for this layer.  The tag is simply a string that can be used by the 
			/// programmer to store any information desired. 
			/// </summary>
			string Tag {get; set;}

			/// <summary>
			/// Gets or sets the color that represents transparent in an <c>Image</c> layer.
			/// </summary>
			System.Drawing.Color ImageTransparentColor {get; set;}

			/// <summary>
			/// Gets or sets whether to use transparency on an <c>Image</c> layer.
			/// </summary>
			bool UseTransparentColor {get; set;}

			/// <summary>
			/// Gets or sets the user defined line stipple.  A line stipple is simply a 32-bit integer 
			/// whose bits define a pattern that can be displayed on the screen.  For example, the value 
			/// 0011 0011 in binary would represent a dashed line (  --  --). 
			/// </summary>
			int UserLineStipple {get; set;}

			/// <summary>
			/// Gets a single row in the user defined line stipple.  There are 32 rows in a fill stipple 
			/// (0-31).  Each row is defined the same way as a <c>UserLineStipple</c>.
			/// </summary>
			/// <param name="Row">The index of the row to get.  Must be between 0 and 31 inclusive.</param>
			/// <returns>A single stipple row.</returns>
			int GetUserFillStipple(int Row);

			/// <summary>
			/// Sets a single row in the user defined line stipple.  There are 32 rows in a fill stipple 
			/// (0-31).  Each row is defined the same way as a <c>UserLineStipple</c>.
			/// </summary>
			/// <param name="Row">The index of the row to set.  Must be between 0 and 31 inclusive.</param>
			/// <param name="Value">The row value to set in the fill stipple.</param>
			void SetUserFillStipple(int Row, int Value);

			/// <summary>
			/// Gets or sets the user defined point image for this layer.  To display the user defined point 
			/// the layer's <c>PointType</c> must be set to <c>ptUserDefined</c>.
			/// </summary>
			MapWinGIS.Image UserPointType {get; set;}

			/// <summary>
			/// Gets or sets whether the layer is visible.
			/// </summary>
			bool Visible {get; set;}

			/// <summary>
			/// Shows all vertices for the entire shapefile.  Applies only to line and polygon shapefiles. 
			/// </summary>
			/// <param name="color">The color to draw vertices with.</param>
			/// <param name="vertexSize">The size of each vertex.</param>
			void ShowVertices(System.Drawing.Color color, int vertexSize);

			/// <summary>
			/// (Doesn't apply to line shapefiles)
			/// Indicates whether the vertices of a line or polygon are visible.
			/// </summary>
			bool VerticesVisible {get;set;}

			/// <summary>
			/// Hides all vertices in the shapefile.  Only applies to line and polygon shapefiles.
			/// </summary>
			void HideVertices();

			/// <summary>
			/// Gets or sets the extents where the layer changes from visible to not visible or vice versa. 
			/// 
			/// If the map is zoomed beyond these extents, the layer is invisible until the map is zoomed to 
			/// be within these extents.
			/// </summary>
			MapWinGIS.Extents DynamicVisibilityExtents{get; set;}

			/// <summary>
			/// Specifies whether or not to use <c>DynamicVisibility</c>.
			/// </summary>
			bool UseDynamicVisibility{get; set;}

            /// <summary>
            /// Causes the labels for a layer to be cleared and reloaded from the specified label (.lbl) file.
            /// </summary>
            /// <param name="lblFilename">Label file to reload for the layer.</param>
            void ReloadLabels(string lblFilename);

			/// <summary>
			/// Adds an image to the list of point images used by the tkImageList point type.
			/// See also UserPointImageListItem, UserPointImageListCount, ClearUDPointImageList,
			/// and (on the shape interface) ShapePointImageListID.
			/// </summary>
			/// <param name="newValue">The new image to add.</param>
			/// <returns>The index for this image, to be passed to ShapePointImageListID or other functions.</returns>
			long UserPointImageListAdd(MapWinGIS.Image newValue);

			/// <summary>
			/// Gets an image from the list of images to be used by the tkImageList point type.
			/// See also UserPointImageListAdd, UserPointImageListCount, ClearUDPointImageList,
			/// and (on the shape interface) ShapePointImageListID.
			/// </summary>
			/// <param name="ImageIndex">The image index to retrieve.</param>
			/// <returns>The index associated with this index; or null/nothing if nonexistant.</returns>
			MapWinGIS.Image UserPointImageListItem(long ImageIndex);

			/// <summary>
			/// Clears out the list of images to be used by the tkImageList point type.
			/// See also UserPointImageListAdd, UserPointImageListItem, UserPointImageListCount,
			/// and (on the shape interface) ShapePointImageListID.
			/// </summary>
			void ClearUDPointImageList();

			/// <summary>
			/// Gets the count of images from the list of images to be used by the tkImageList point type.
			/// See also UserPointImageListAdd, UserPointImageListItem, ClearUDPointImageList,
			/// and (on the shape interface) ShapePointImageListID.
			/// </summary>
			/// <returns>The count of items in the image list.</returns>
			long UserPointImageListCount();

			/// <summary>
			/// Indicates whether to skip over the layer when saving a project.
			/// </summary>
			bool SkipOverDuringSave{get; set;}

			/// <summary>
			/// Indicates whether to skip over the layer when drawing the legend.
			/// </summary>
		    bool HideFromLegend{get; set;}

			/// <summary>
			/// Gets or sets the percentage of transparency for a given polygon shapefile layer.
			/// </summary>
			float ShapeLayerFillTransparency {get; set;}

			/// <summary>
			/// Gets or sets the Point Image Scheme object for a given point layer. To be used from MapWindow only
			/// </summary>
			object PointImageScheme {get; set;}

			/// <summary>
			/// Saves the shapefile rendering properties to the specified filename.
			/// Function call is ignored if the layer is a grid.
			/// </summary>
			bool SaveShapeLayerProps(string saveToFilename);

			/// <summary>
			/// Saves the shapefile rendering properties to a .mwsr file whose base filename matches the shapefile.
			/// Function call is ignored and returns false if the layer is a grid.
			/// </summary>
			bool SaveShapeLayerProps();

			/// <summary>
			/// Loads the shapefile rendering properties from the specified filename.
			/// Function call is ignored and returns false if the layer is a grid.
			/// </summary>
			bool LoadShapeLayerProps(string loadFromFilename);

			/// <summary>
			/// Loads the shapefile rendering properties from a .mwsr file whose base filename matches the shapefile.
			/// If the file isn't found, false is returned.
			/// Function call is ignored and returns false if the layer is a grid.
			/// </summary>
			bool LoadShapeLayerProps();

			/// <summary>
			/// Returns information about the given layer in a human-readible string.
			/// </summary>
			string ToString();
		}
	
		/// <summary>
		/// The layers interface manages all the layers in the MapWindow.
		/// </summary>
        public interface Layers : System.Collections.IEnumerable
		{
			/// <summary>
			/// Removes all layers from the map.
			/// </summary>
			void Clear();

			/// <summary>
			/// Moves a layer to another position and/or group.
			/// </summary>
			/// <param name="Handle">Handle of the layer to move.</param>
			/// <param name="NewPosition">New position in the target group.</param>
			/// <param name="TargetGroup">Group to move the layer to.</param>
			void MoveLayer(int Handle, int NewPosition, int TargetGroup);

			/// <summary>
			/// Removes the layer from the MapWindow.
			/// </summary>
			/// <param name="LayerHandle"></param>
			void Remove(int LayerHandle);

			/// <summary>
			/// Returns true if the layer handle specified belongs to a valid layer.  Drawing layers are not 
			/// considered normal layers so this function will not return consistent results if a drawing 
			/// layer is passed in.
			/// </summary>
			/// <param name="LayerHandle">Handle of the layer to check.</param>
			/// <returns>True if the layer handle is valid.  False otherwise.</returns>
			bool IsValidHandle(int LayerHandle);

			/// <summary>
			/// Default add layer overload.  Displays an open file dialog
			/// </summary>
			/// <returns>An array of <c>MapWindow.Interfaces.Layer</c> objects.</returns>
			Layer[] Add();

			/// <summary>
			/// Adds a layer by filename.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(string Filename);

			/// <summary>
			/// Adds a layer by filename.  The layer name is also set.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(string Filename, string LayerName);

			/// <summary>
			/// Adds an <c>Image</c> layer to the MapWindow.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Image ImageObject);

			/// <summary>
			/// Adds an <c>Image</c> layer to the MapWindow with the specified layer name.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Image ImageObject, string LayerName);

			/// <summary>
			/// Adds a <c>Shapefile</c> layer to the MapWindow.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Shapefile ShapefileObject);

			/// <summary>
			/// Adds a <c>Shapefile</c> layer to the MapWindow with the specified layer name.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Shapefile ShapefileObject, string LayerName);

			/// <summary>
			/// Adds a <c>Shapefile</c> layer to the MapWindow with the specified properties.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Shapefile ShapefileObject, string LayerName, int Color, int OutlineColor);

			/// <summary>
			/// Adds a <c>Shapefile</c> layer to the MapWindow with the specified properties.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Shapefile ShapefileObject, string LayerName, int Color, int OutlineColor, int LineOrPointSize);

			/// <summary>
			/// Adds a <c>Grid</c> layer to the MapWindow.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Grid GridObject);

			/// <summary>
			/// Adds a <c>Grid</c> layer to the MapWindow, with the specified coloring scheme.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Grid GridObject, MapWinGIS.GridColorScheme ColorScheme);

			/// <summary>
			/// Adds a <c>Grid</c> layer to the MapWindow with the specified layer name.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Grid GridObject, string LayerName);

			/// <summary>
			/// Adds a <c>Grid</c> object to the MapWindow with the specified properties.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(ref MapWinGIS.Grid GridObject, MapWinGIS.GridColorScheme ColorScheme, string LayerName);

			/// <summary>
			/// Gets or sets the current layer handle.
			/// </summary>
			int CurrentLayer {get; set;}

			/// <summary>
			/// Finds a layer handle when given the global position of a layer.
			/// </summary>
			/// <param name="GlobalPosition">Position in the layers list, disregarding groups.</param>
			/// <returns>The handle of the layer at the specified position, or -1 if no layer is found there.</returns>
			int GetHandle(int GlobalPosition);

			/// <summary>
			/// Returns the layer object corresponding the the specified <c>LayerHandle</c>
			/// </summary>
			Layer this[int LayerHandle] {get;}

			/// <summary>
			/// Returns the number of layers loaded in the MapWindow.  Drawing layers are not counted.
			/// </summary>
			int NumLayers {get;}

			/// <summary>
			/// Rebuilds a grid layer using the specified <c>GridColorScheme</c>
			/// </summary>
			/// <param name="LayerHandle">Handle of the grid layer.</param>
			/// <param name="GridObject">Grid object corresponding to that layer handle.</param>
			/// <param name="ColorScheme">Coloring scheme to use when rebuilding.</param>
			/// <returns></returns>
			bool RebuildGridLayer(int LayerHandle, MapWinGIS.Grid GridObject, MapWinGIS.GridColorScheme ColorScheme);

			/// <summary>
			/// Allows access to group properties in the legend.
			/// </summary>
			LegendControl.Groups Groups {get;}

			/// <summary>
			/// Adds a layer by filename.  The layer name is also set, as well as the legend visibility.
			/// </summary>
			/// <returns>Returns a <c>Layer</c> object.</returns>
			Layer Add(string Filename, string LayerName, bool VisibleInLegend);

			/// <summary>
			/// Adds a layer to the map, optionally placing it above the currently selected layer (otherwise at top of layer list).
			/// </summary>
			/// <param name="Visible">Whether or not the layer is visible upon adding it</param>
			/// <param name="PlaceAboveCurrentlySelected">Whether the layer should be placed above currently selected layer, or at top of layer list.</param>
            /// <param name="Filename">The name of the file to add.</param>
            /// <param name="LayerName">The name of the layer, as displayed in the legend.</param>
			Layer Add(string Filename, string LayerName, bool Visible, bool PlaceAboveCurrentlySelected);
		}
	
		/// <summary>
		/// The <c>AppInfo</c> interface allows access to MapWindow-related data like versions, whether to display splash screens, and the help file path.
		/// </summary>
		public interface AppInfo
		{
			/// <summary>
			/// The path to the help file to be displayed from the Help menu.
			/// </summary>
			string HelpFilePath {get;set;}
			
			/// <summary>
			/// Whether to display a splash screen on starting the application
			/// </summary>
			bool UseSplashScreen {get;set;}

			/// <summary>
			/// The name of the plugin responsible for displaying a custom welcome screen
			/// in response to the WELCOME_SCREEN message.
			/// </summary>
			string WelcomePlugin {get;set;}

			/// <summary>
			/// The image to be displayed on the splash screen.
			/// </summary>
			System.Drawing.Image SplashPicture {get;set;}

			/// <summary>
			/// The icon to be displayed as the default form icon
			/// </summary>
			System.Drawing.Icon FormIcon {get;set;}

			/// <summary>
			/// How long the splash screen should be displayed
			/// </summary>
			double SplashTime {get;set;}

			/// <summary>
			/// The default directory for file dialogs
			/// </summary>
			string DefaultDir {get;set;}
			
			/// <summary>
			/// The URL to be displayed on the Help->About dialog.
			/// </summary>
			string URL {get;set;}

			/// <summary>
			/// The name of the main application.
			/// </summary>
			string ApplicationName {get;set;}

			/// <summary>
			/// Whether or not to show a welcome screen (overriding the Splash Screen)
			/// </summary>
			bool ShowWelcomeScreen {get;set;}
		}

		/// <summary>
		/// The <c>Project</c> interface manages the project and configuration files in the MapWindow.
		/// </summary>
		public interface Project
		{
			/// <summary>
			/// Returns the filename of the configuration file that was used to load the current MapWindow project.
			/// </summary>
			string ConfigFileName {get;}

			/// <summary>
			/// Returns the filename of the current project.
			/// </summary>
			string FileName {get;}

			/// <summary>
			/// Saves the current project.
			/// </summary>
			/// <param name="Filename">Filename to save the project as.</param>
			/// <returns>Returns true if successful.</returns>
			bool Save(string Filename);

			/// <summary>
			/// Loads a project file.
			/// </summary>
			/// <param name="Filename">Filename of the project to load.</param>
			/// <returns>Returns true if successful.</returns>
			bool Load(string Filename);

			/// <summary>
			/// Loads a project file into the current project as a subgroup.
			/// </summary>
			/// <param name="Filename">Filename of the project to load.</param>
			void LoadIntoCurrentProject(string Filename);

			/// <summary>
			/// Saves the current configuration to a configuration file.
			/// </summary>
			/// <param name="Filename">The filename to save the configuration as.</param>
			/// <returns>Returns true if successful.</returns>
			bool SaveConfig(string Filename);

			/// <summary>
			/// Gets or sets the project modified flag.
			/// </summary>
			bool Modified {get;set;}

			/// <summary>
			/// Return or set the current project projection, in the format
			/// "+proj=tmerc +ellps=WGS84 etc etc +datum=WGS84"
			/// </summary>
			string ProjectProjection{get;set;}

			/// <summary>
			/// Returns whether the configuration file specified by the project has been loaded.
			/// </summary>
			bool ConfigLoaded{get;}

			/// <summary>
			/// Returns an ArrayList of the recent projects (the full path to the projects)
			/// </summary>
			System.Collections.ArrayList RecentProjects{get;}

			/// <summary>
			/// Return or set the current map units, in the format
			/// "Meters", "Feet", etc
			/// </summary>
			string MapUnits{get;set;}

			/// <summary>
			/// Return or set the current alternate display units, in the format
			/// "Meters", "Feet", etc
			/// </summary>
			string MapUnitsAlternate{get;set;}

            /// <summary>
            /// Gets or sets the option to save shape-level formatting.
            /// </summary>
            bool SaveShapeSettings { get;set;}

        }

		/// <summary>
		/// The IMapWin interface is the root interface for the MapWindow.  All other interfaces can be accessed or used through this interface.
		/// </summary>
		public interface IMapWin
		{
			/// <summary>
			/// Refreshes the MapWindow display.
			/// </summary>
			void Refresh();

			/// <summary>
			/// Gets the last error message set.  Note:  This error message could have been set at any time.
			/// </summary>
			string LastError {get;}

			/// <summary>
			/// Returns the <c>Layers</c> object that handles layers.
			/// </summary>
			Interfaces.Layers Layers {get;}

			/// <summary>
			/// Returns the <c>View</c> object that handles the map view.
			/// </summary>
			Interfaces.View View {get;}

			/// <summary>
			/// Returns the <c>Menus</c> object that manages the menus.
			/// </summary>
			Interfaces.Menus Menus {get;}

			/// <summary>
			/// Returns the <c>Plugins</c> object that manages plugins.
			/// </summary>
			Interfaces.Plugins Plugins {get;}

			/// <summary>
			/// Returns the <c>PreviewMap</c> object that manages the preview map.
			/// </summary>
			Interfaces.PreviewMap PreviewMap {get;}

			/// <summary>
			/// Returns the <c>StausBar</c> object that manages the status bar.
			/// </summary>
			Interfaces.StatusBar StatusBar {get;}

			/// <summary>
			/// Returns the <c>Toolbar</c> object that manages toolbars.
			/// </summary>
			Interfaces.Toolbar Toolbar {get;}

			/// <summary>
			/// Provides access to report generation methods and properties.
			/// </summary>
			Interfaces.Reports Reports {get;}

			/// <summary>
			/// Provides control over project and configuration files.
			/// </summary>
			Interfaces.Project Project {get;}

			/// <summary>
			/// Provides control over application-level settings like the app name.
			/// </summary>
			Interfaces.AppInfo ApplicationInfo {get;}

			/// <summary>
			/// Displays the MapWindow error dialog.
			/// </summary>
			/// <param name="ex"></param>
			void ShowErrorDialog(System.Exception ex);

            /// <summary>
            /// Displays the MapWindow error dialog, sending to a specific address.
            /// </summary>
            /// <param name="ex"></param>
            /// <param name="SendEmailTo"></param>
            void ShowErrorDialog(System.Exception ex, string SendEmailTo);

			/// <summary>
			/// Sets the dialog title to be displayed after the "AppInfo" name for the main window.
			/// Overrides the default "project name" title.
			/// </summary>
			void SetCustomWindowTitle(string NewTitleText);

			/// <summary>
			/// Returns dialog title for the main window to the default "project name" title.
			/// </summary>
			void ClearCustomWindowTitle();

			/// <summary>
			/// Specify whether the full project path should be specified rather than just filename, in title bar for main window.
			/// </summary>
			bool DisplayFullProjectPath{set;}

			/// <summary>
			///  Prompt the user to select a projection, and return the PROJ4 representation of this
			///  projection. Specify the dialog caption and an optional default projection ("" for none).
			/// </summary>
			/// <param name="DialogCaption">The text to be displayed on the dialog, e.g. "Please select a projection."</param>
			/// <param name="DefaultProjection">The PROJ4 projection string of the projection to default to, "" for none.</param>
			/// <returns></returns>
			string GetProjectionFromUser(string DialogCaption, string DefaultProjection);

			/// <summary>
			/// Provides access to the user panel in the lower right of the MapWindow form.
			/// </summary>
			Interfaces.UIPanel UIPanel {get;}

			/// <summary>
			/// User-interactive functions. Used to prompt users to enter things, or otherwise prompt users.
			/// </summary>
			Interfaces.UserInteraction UserInteraction {get;}

			/// <summary>
			/// Returns the underlying MapWinGIS activex control for advanced operations.
			/// </summary>
			object GetOCX {get;}

            void RefreshDynamicVisibility();
		}

		/// <summary>
		/// User-interactive functions. Used to prompt users to enter things, or otherwise prompt users.
		/// </summary>
		[System.Runtime.InteropServices.Guid("c28ee5b0-70e8-11db-9fe1-0800200c9a66")]
		public interface UserInteraction
		{
			/// <summary>
			///  Prompt the user to select a projection, and return the PROJ4 representation of this
			///  projection. Specify the dialog caption and an optional default projection ("" for none).
			/// </summary>
			/// <param name="DialogCaption">The text to be displayed on the dialog, e.g. "Please select a projection."</param>
			/// <param name="DefaultProjection">The PROJ4 projection string of the projection to default to, "" for none.</param>
			/// <returns></returns>
			string GetProjectionFromUser(string DialogCaption, string DefaultProjection);

			/// <summary>
			///  Retrieve a color ramp, defined by a start and end color, from the user.
			/// </summary>
			/// <param name="suggestedStart">The start color to initialize the dialog with.</param>
			/// <param name="suggestedEnd">The end color to initialize the dialog with.</param>
			/// <param name="selectedEnd">The end color that the user selected.</param>
			/// <param name="selectedStart">The start color that the user selected.</param>
			/// <returns></returns>
			bool GetColorRamp(System.Drawing.Color suggestedStart, System.Drawing.Color suggestedEnd, out System.Drawing.Color selectedStart, out System.Drawing.Color selectedEnd);
		}

		/// <summary>
		/// The IPlugin interface is the interface that must be implemented to create a plugin.
		/// </summary>
		[System.Runtime.InteropServices.Guid("CD0906F9-E87A-42DC-9365-E502DC993713")]
		public interface IPlugin
		{
			/// <summary>
			/// Author of the plugin.
			/// </summary>
			string Author {get;}

			/// <summary>
			/// Short description of the plugin.
			/// </summary>
			string Description {get;}

			/// <summary>
			/// Plugin serial number.  NO LONGER NEEDED; kept for backward compatibility.
			/// </summary>
			string SerialNumber {get;}

			/// <summary>
			/// Name of the plugin.
			/// </summary>
			string Name {get;}

			/// <summary>
			/// Build date.
			/// </summary>
			string BuildDate {get;}

			/// <summary>
			/// Plugin version.
			/// </summary>
			string Version {get;}

			/// <summary>
			/// This method is called by the MapWindow when a project is being loaded.
			/// </summary>
			/// <param name="ProjectFile">Filename of the project file.</param>
			/// <param name="SettingsString">Settings string for this plugin from the project file.</param>
			void ProjectLoading(string ProjectFile, string SettingsString);
			
			/// <summary>
			/// This method is called by the MapWindow when a project is being saved.
			/// </summary>
			/// <param name="ProjectFile">Filename of the project file.</param>
			/// <param name="SettingsString">Reference parameter.  Set this value in order to save your plugin's settings string in the project file.</param>
			void ProjectSaving(string ProjectFile, ref string SettingsString);

			/// <summary>
			/// This method is called by the MapWindow when the plugin is loaded.
			/// </summary>
			/// <param name="MapWin">The <c>IMapWin</c> interface to use when interacting with the MapWindow.</param>
			/// <param name="ParentHandle">The windows handle of the MapWindow form.  This can be used to make the MapWindow the parent of any forms in the plugin.</param>
			void Initialize(Interfaces.IMapWin MapWin, int ParentHandle);

			/// <summary>
			/// This method is called by the MapWindow when the plugin is unloaded.
			/// </summary>
			void Terminate();

			/// <summary>
			/// This method is called by the MapWindow when the user double-clicks on the legend.
			/// </summary>
			/// <param name="Handle">Handle of the layer or group that was double-clicked</param>
			/// <param name="Location">Location that was clicked.  Either a layer or a group.</param>
			/// <param name="Handled">Set this parameter to true if your plugin handles this so that no other plugins recieve this message.</param>
			void LegendDoubleClick(int Handle, Interfaces.ClickLocation Location, ref bool Handled);

			/// <summary>
			/// This method is called by the MapWindow when the user presses a mouse button on the legend.
			/// </summary>
			/// <param name="Handle">Handle of the layer or group that was under the cursor.</param>
			/// <param name="Button">The mouse button that was pressed.  You can use the <c>vb6Buttons</c> enumeration to determine which button was pressed.</param>
			/// <param name="Location">Location that was clicked.  Either a layer or a group</param>
			/// <param name="Handled">Set this parameter to true if your plugin handles this so that no other plugins recieve this message.</param>
			void LegendMouseDown(int Handle, int Button, Interfaces.ClickLocation Location, ref bool Handled);

			/// <summary>
			/// This method is called by the MapWindow when the user releases a mouse button on the legend.
			/// </summary>
			/// <param name="Handle">Handle of the layer or group that was under the cursor.</param>
			/// <param name="Button">The mouse button that was released.  You can use the <c>vb6Buttons</c> enumeration to determine which button it was.</param>
			/// <param name="Location">Location that was clicked.  Either a layer or a group</param>
			/// <param name="Handled">Set this parameter to true if your plugin handles this so that no other plugins recieve this message.</param>
			void LegendMouseUp(int Handle, int Button, Interfaces.ClickLocation Location, ref bool Handled);

			/// <summary>
			/// This method is called by the MapWindow when the extents of the map have changed.
			/// </summary>
			void MapExtentsChanged();

			/// <summary>
			/// This method is called by the MapWindow when the user presses a mouse button over the map.
			/// </summary>
			/// <param name="Button">The button that was pressed.  These values can be compared to the <c>vb6Butttons</c> enumerations.</param>
			/// <param name="Shift">This value represents the state of the <c>ctrl</c>, <c>alt</c> and <c>shift</c> keyboard buttons.  The values use VB6 values.</param>
			/// <param name="x">The x coordinate in pixels.</param>
			/// <param name="y">The y coordinate in pixels.</param>
			/// <param name="Handled">Set this parameter to true if your plugin handles this so that no other plugins recieve this message.</param>
			void MapMouseDown(int Button, int Shift, int x, int y, ref bool Handled);

			/// <summary>
			/// This method is called by the MapWindow when the user moves the mouse over the map display.
			/// </summary>
			/// <param name="ScreenX">The x coordinate in pixels.</param>
			/// <param name="ScreenY">The y coordinate in pixels.</param>
			/// <param name="Handled">Set this parameter to true if your plugin handles this so that no other plugins recieve this message.</param>
			void MapMouseMove(int ScreenX, int ScreenY, ref bool Handled);

			/// <summary>
			/// This method is called by the MapWindow when the user releases a mouse button over the map.
			/// </summary>
			/// <param name="Button">The button that was released.  These values can be compared to the <c>vb6Butttons</c> enumerations.</param>
			/// <param name="Shift">This value represents the state of the <c>ctrl</c>, <c>alt</c> and <c>shift</c> keyboard buttons.  The values use VB6 values.</param>
			/// <param name="x">The x coordinate in pixels.</param>
			/// <param name="y">The y coordinate in pixels.</param>
			/// <param name="Handled">Set this parameter to true if your plugin handles this so that no other plugins recieve this message.</param>
			void MapMouseUp(int Button, int Shift, int x, int y, ref bool Handled);

			/// <summary>
			/// This method is called by the MapWindow when the user completes a dragging operation on the map.
			/// </summary>
			/// <param name="Bounds">The rectangle that was selected, in pixel coordinates.</param>
			/// <param name="Handled">Set this parameter to true if your plugin handles this so that no other plugins recieve this message.</param>
			void MapDragFinished(System.Drawing.Rectangle Bounds, ref bool Handled);

			/// <summary>
			/// This method is called by the MapWindow when one or more layer(s) is/are added.
			/// </summary>
			/// <param name="Layers">An array of <c>Layer</c> objects that were added.</param>
			void LayersAdded(Interfaces.Layer [] Layers);

			/// <summary>
			/// This method is called by the MapWindow when a layer is removed from the map.
			/// </summary>
			/// <param name="Handle">Handle of the layer that was removed.</param>
			void LayerRemoved(int Handle);

			/// <summary>
			/// This method is called by the MapWindow when a layer is selected in code or by the legend.
			/// </summary>
			/// <param name="Handle">Handle of the newly selected layer.</param>
			void LayerSelected(int Handle);

			/// <summary>
			/// This method is called by the MapWindow when all layers are cleared from the map.
			/// </summary>
			void LayersCleared();

			/// <summary>
			/// This method is called by the MapWindow when shapes are selected by the user.
			/// </summary>
			/// <param name="Handle">Handle of the shapefile layer that was selected on.</param>
			/// <param name="SelectInfo">The <c>SelectInfo</c> object containing information about the selected shapes.</param>
			void ShapesSelected(int Handle, Interfaces.SelectInfo SelectInfo);

			/// <summary>
			/// This method is called by the MapWindow when a toolbar or menu item is clicked.
			/// </summary>
			/// <param name="ItemName">Name of the item that was clicked.</param>
			/// <param name="Handled">Set this parameter to true if your plugin handles this so that no other plugins recieve this message.</param>
			void ItemClicked(string ItemName, ref bool Handled);

			/// <summary>
			/// This message is relayed by the MapWindow when another plugin broadcasts a message.  Messages can be used to send messages between plugins.
			/// </summary>
			/// <param name="msg">The message being relayed.</param>
			/// <param name="Handled">Set this parameter to true if your plugin handles this so that no other plugins recieve this message.</param>
			void Message(string msg, ref bool Handled);
		}

		/// <summary>
		/// The <c>Reports</c> contains tools that are useful when generating a report from the data in the MapWindow.
		/// </summary>
		public interface Reports
		{
			/// <summary>
			/// Returns an image of a north arrow.
			/// </summary>
			System.Drawing.Image GetNorthArrow();

			/// <summary>
			/// Returns a <c>MapWinGIS.Image</c> of the view at the specified extents.
			/// </summary>
			/// <param name="BoundBox">The area that you wish to take the picture of.  Uses projected map units.</param>
			MapWinGIS.Image GetScreenPicture(MapWinGIS.Extents BoundBox);

			/// <summary>
			/// Returns an image of the legend.
			/// </summary>
			/// <param name="VisibleLayersOnly">Specifies that only the visible layers are part of the snapshot.</param>
			/// <param name="imgWidth">Maximum width of the image.  The height of the image depends on the number of layers loaded.</param>
			System.Drawing.Image GetLegendSnapshot(bool VisibleLayersOnly, int imgWidth);

			/// <summary>
			/// Similar to <c>GetLegendSnapshot</c> except that only one layer is considered.
			/// </summary>
			/// <param name="LayerHandle">Handle of the layer to take a snapshot of.</param>
			/// <param name="imgWidth">Maximum width of the image.  The height of the image depends on the coloring scheme of the layer.</param>
			System.Drawing.Image GetLegendLayerSnapshot(int LayerHandle, int imgWidth);

			/// <summary>
			/// Returns an image that represents an accurate scale bar.
			/// </summary>
			/// <param name="MapUnits">You must specify what the map units are.</param>
			/// <param name="ScalebarUnits">The unit of measurement to display on the scale bar.  This function can convert the map units to any other unit.</param>
			/// <param name="MaxWidth">Maximum width of the scale bar image.</param>
			System.Drawing.Image GetScaleBar(UnitOfMeasure MapUnits, UnitOfMeasure ScalebarUnits, int MaxWidth);

			/// <summary>
			/// Returns an image that represents an accurate scale bar.
			/// </summary>
			/// <param name="MapUnits">You must specify what the map units are.</param>
			/// <param name="ScalebarUnits">The unit of measurement to display on the scale bar.  This function can convert the map units to any other unit.</param>
			/// <param name="MaxWidth">Maximum width of the scale bar image.</param>
			System.Drawing.Image GetScaleBar(string MapUnits, string ScalebarUnits, int MaxWidth);
		}
	
		/// <summary>
		/// Allows a plug-in to utilize the panel underneath the main map pane.
		/// </summary>
		public interface UIPanel
		{
			/// <summary>
			/// Returns a System.Windows.Forms.Panel that can be used to add dockable content to MapWindow.
			/// </summary>
			System.Windows.Forms.Panel CreatePanel(string Caption, MapWindowDockStyle DockStyle);

			/// <summary>
			/// Returns a System.Windows.Forms.Panel that can be used to add dockable content to MapWindow.
			/// </summary>
			System.Windows.Forms.Panel CreatePanel(string Caption, System.Windows.Forms.DockStyle DockStyle);

			/// <summary>
			/// Deletes the specified panel.
			/// </summary>
			void DeletePanel(string Caption);

			/// <summary>
			/// Hides or shows a panel without necessarily deleting it.
			/// </summary>
			void SetPanelVisible(string Caption, bool Visible);

			/// <summary>
			/// Adds a function (OnCloseFunction) which
			/// is called when the panel specified by Caption is closed.
			/// </summary>
			void AddOnCloseHandler(string Caption, OnPanelClose OnCloseFunction);
		}
	}
}
