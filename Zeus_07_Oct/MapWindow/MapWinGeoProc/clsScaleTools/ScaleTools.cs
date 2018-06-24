//********************************************************************************************************
// File name: ScaleTools.cs
// Description: Returns an extent based on a passed in scale and centerPoint
//
//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specific language governing rights and 
//limitations under the License. 
//
//For more information about the Bresenham algorithm, see the Wikipedia 
//(http://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm) 
//
// Author: Brian Marchionni Feb. 9, 2009
//
// Contributor(s):
//				
//********************************************************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace MapWinGeoProc
{

    /// <summary>
    /// Returns an extent based on a passed in scale and centerPoint
    /// </summary>
    public static class ScaleTools
    {
        /// <summary>
        /// Returns an extent based on a passed in scale and centerPoint
        /// </summary>
        /// <param name="Scale">The scale to use in the form of 1:scale</param>
        /// <param name="CenterPoint">The center location to calculate the extents</param>
        /// <param name="MapWinUnits">The units that the map is in</param>
        /// <param name="MapWidthInPixels">Width of the map in pixels</param>
        /// <param name="MapHeightInPixels">Height of the map in pixels</param>
        /// <returns>The new extents. Returns null if something went wrong</returns>
        public static MapWinGIS.Extents ExtentFromScale(int Scale, MapWinGIS.Point CenterPoint, string MapWinUnits, int MapWidthInPixels, int MapHeightInPixels)
        {
            double convert = getConversionFactor(MapWinUnits, CenterPoint);
            if (convert == 0)
                return null;

            //96 is the standard dpi for windows theres no easy way of getting it from the system so its just hard coded here
            //Technically this is incorrect but hey nobody will notice.

            double screenInchWidth = MapWidthInPixels / 96.0;
            double mapInchWidth = Scale * screenInchWidth;
            double mapProjWidth = mapInchWidth / convert;

            double screenInchHeight = MapHeightInPixels / 96.0;
            double mapInchHeight = Scale * screenInchHeight;
            double mapProjHeight = mapInchHeight / convert;

            MapWinGIS.Extents ext = new MapWinGIS.Extents();
            ext.SetBounds(CenterPoint.x - (mapProjWidth/2), CenterPoint.y - (mapProjHeight/2), 0, CenterPoint.x + (mapProjWidth/2), CenterPoint.y + (mapProjHeight/2), 0);
            return (ext);
        }

        /// <summary>
        /// Returns the conversion factor between the map units and inches
        /// </summary>
        /// <param name="MapWinUnits">A string represing the MapUnits</param>
        /// <param name="CenterPoint">The center coodinates of the screen in MapUnits</param>
        /// <returns>A double representing the conversion factor between MapUnits and inches. If something goes wrong we return 0</returns>
        private static double getConversionFactor(string MapWinUnits, MapWinGIS.Point CenterPoint)
        {
            switch (MapWinUnits.ToLower())
            {
                case "lat/long":
                    return (DegreesFactor(CenterPoint));
                case "meters":
                    return (39.3700787);
                case "centimeters":
                    return (0.393700787);
                case "feet":
                    return (12);
                case "inches":
                    return (1);
                case "kilometers":
                    return (39370.0787);
                case "miles":
                    return (63360);
                case "millimeters":
                    return (0.0393700787);
                case "yards":
                    return (36);
                default:
                    return (0);
            }
        }

        /// <summary>
        /// Returns the conversion factor if the map is in degrees
        /// </summary>
        /// <returns></returns>
        private static double DegreesFactor(MapWinGIS.Point CenterPoint)
        {
            //Gets the latitude of the center of the screen in radians
            double centerLat = (CenterPoint.y * (Math.PI / 180));

            //The define the spheroid of the earth in meters
            double a = 6378137;
            double b = 6356752.3;

            //Calculates the Earth's Merdional Radius (mR) at a specific latitude
            double numerator = Math.Pow(a, 4) * Math.Pow(Math.Cos(centerLat), 2) + Math.Pow(b, 4) * Math.Pow(Math.Sin(centerLat), 2);
            double denominator = Math.Pow(a * Math.Cos(centerLat), 2) + Math.Pow(b * Math.Cos(centerLat), 2);
            double mR = Math.Sqrt(numerator / denominator);

            //Returns width of a degree at a specific latitude in inches
            return ((Math.PI / 180) * Math.Cos(centerLat) * mR * 39.3700787);
        }
    }
}
