using System;
using System.Collections;
using System.Text;

using MapWinGeoProc.NTS.Topology.Algorithm;

namespace MapWinGeoProc.NTS.Topology.Simplify
{
    /// <summary>
    /// Simplifies a collection of TaggedLineStrings, preserving topology
    /// (in the sense that no new intersections are introduced).
    /// </summary>
    public class TaggedLinesSimplifier
    {
        private LineSegmentIndex inputIndex = new LineSegmentIndex();
        private LineSegmentIndex outputIndex = new LineSegmentIndex();
        private double distanceTolerance = 0.0;

        /// <summary>
        /// 
        /// </summary>
        public TaggedLinesSimplifier() { }

        /// <summary>
        /// Gets/Sets the distance tolerance for the simplification.
        /// Points closer than this tolerance to a simplified segment may
        /// be removed.
        /// </summary>        
        public virtual double DistanceTolerance
        {
            get
            {
                return distanceTolerance;
            }
            set
            {
                distanceTolerance = value;
            }
        }

        /// <summary>
        /// Simplify a collection of <c>TaggedLineString</c>s.
        /// </summary>
        /// <param name="taggedLines">The collection of lines to simplify.</param>
        public virtual void Simplify(IList taggedLines)
        {
            for (IEnumerator i = taggedLines.GetEnumerator(); i.MoveNext(); )            
                inputIndex.Add((TaggedLineString)i.Current);
            for (IEnumerator i = taggedLines.GetEnumerator(); i.MoveNext(); )
            {
                TaggedLineStringSimplifier tlss
                              = new TaggedLineStringSimplifier(inputIndex, outputIndex);
                tlss.DistanceTolerance = distanceTolerance;
                tlss.Simplify((TaggedLineString)i.Current);
            }
        }
    }
}