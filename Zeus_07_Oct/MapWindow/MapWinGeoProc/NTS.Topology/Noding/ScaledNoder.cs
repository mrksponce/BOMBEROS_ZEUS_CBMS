using System;
using System.Collections;
using System.Text;

using MapWinGeoProc.NTS.Topology.Geometries;
using MapWinGeoProc.NTS.Topology.Algorithm;
using MapWinGeoProc.NTS.Topology.Utilities;
using MapWindow.Interfaces.Geometries;
namespace MapWinGeoProc.NTS.Topology.Noding
{

    /// <summary>
    /// Wraps a <see cref="INoder" /> and transforms its input into the integer domain.
    /// This is intended for use with Snap-Rounding noders,
    /// which typically are only intended to work in the integer domain.
    /// Offsets can be provided to increase the number of digits of available precision.
    /// </summary>
    public class ScaledNoder : INoder
    {
        private INoder noder = null;
        private double scaleFactor = 0;
        private double offsetX = 0;
        private double offsetY = 0;
        private bool isScaled = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScaledNoder"/> class.
        /// </summary>
        /// <param name="noder"></param>
        /// <param name="scaleFactor"></param>
        public ScaledNoder(INoder noder, double scaleFactor) 
            : this(noder, scaleFactor, 0, 0) { }      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="noder"></param>
        /// <param name="scaleFactor"></param>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        public ScaledNoder(INoder noder, double scaleFactor, double offsetX, double offsetY) 
        {
            this.noder = noder;
            this.scaleFactor = scaleFactor;
            // no need to scale if input precision is already integral
            isScaled = ! isIntegerPrecision;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool isIntegerPrecision
        { 
            get
            {
                return scaleFactor == 1.0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList GetNodedSubstrings()
        {
            IList splitSS = noder.GetNodedSubstrings();
            if (isScaled) 
                Rescale(splitSS);
            return splitSS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputSegStrings"></param>
        public void ComputeNodes(IList inputSegStrings)
        {
            IList intSegStrings = inputSegStrings;
            if(isScaled)
                intSegStrings = Scale(inputSegStrings);
            noder.ComputeNodes(intSegStrings);
        }    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segStrings"></param>
        /// <returns></returns>
        private IList Scale(IList segStrings)
        {
            return CollectionUtil.Transform(segStrings, delegate(object obj)
            {
                SegmentString ss = (SegmentString)obj;
                return new SegmentString(Scale(ss.Coordinates), ss.Data);
            });
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pts"></param>
        /// <returns></returns>
        private Coordinate[] Scale(ICoordinate[] pts)
        {
            Coordinate[] roundPts = new Coordinate[pts.Length];
            for (int i = 0; i < pts.Length; i++)
                roundPts[i] = new Coordinate(Math.Round((pts[i].X - offsetX) * scaleFactor),
                                             Math.Round((pts[i].Y - offsetY) * scaleFactor));            
            return roundPts;
        }      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segStrings"></param>
        private void Rescale(IList segStrings)
        {
            CollectionUtil.Apply(segStrings, delegate(object obj)
            {
                SegmentString ss = (SegmentString)obj;
                Rescale(ss.Coordinates);
                return null;
            });                                           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pts"></param>
        private void Rescale(ICoordinate[] pts)
        {
            for (int i = 0; i < pts.Length; i++) 
            {
                pts[i].X = pts[i].X / scaleFactor + offsetX;
                pts[i].Y = pts[i].Y / scaleFactor + offsetY;
            }
        }

    }
}
