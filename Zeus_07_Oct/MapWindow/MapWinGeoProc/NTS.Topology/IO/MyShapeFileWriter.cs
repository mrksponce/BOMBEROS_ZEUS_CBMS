using System;
using System.Collections;
using System.IO;
using System.Text;

using MapWinGeoProc.NTS.Topology.Geometries;

using MapWindow.Interfaces.Geometries;
namespace MapWinGeoProc.NTS.Topology.IO
{
    /// <summary>
    ///  A class for writing shapefiles data.
    /// </summary>
    [Obsolete("Use ShapefileWriter instead")]
    public class MyShapeFileWriter
    {
        private int recordCounter = 0;

        /// <summary>
        /// 
        /// </summary>
        protected ShapeWriter shapeWriter = null; 

         /// <summary>
        /// Default empty constructor
        /// </summary>
        public MyShapeFileWriter()
        {
            shapeWriter = new ShapeWriter();
        }

        /// <summary>
        /// Writes an homogeneus <c>GometryCollection</c> into a binary shapefile.
        /// </summary>
        /// <param name="geometries">If geometries are not of the same type throws <c>System.ArgumentException</c>.</param>
        /// <param name="shapepath">Path of the shapefile to create: will be created a new file using the given path.
        /// if file exists throws <c>System.IO.IOException</c>.</param>        
        public virtual void Write(GeometryCollection geometries, string shapepath)
        {            
            using (Stream stream = new FileStream(shapepath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                Write(geometries, stream);
            }
        }

        /// <summary>
        /// Writes an homogeneus <c>GometryCollection</c> into a binary stream.
        /// </summary>
        /// <param name="geometries"></param>
        /// <param name="stream"></param>
        protected virtual void Write(GeometryCollection geometries, Stream stream)
        {
            if (!geometries.IsHomogeneous)
                throw new ArgumentException("Shapefile does contain only geometries of th esame type!");

            // Init counter
            recordCounter = 0;

            using (BigEndianBinaryWriter beWriter = new BigEndianBinaryWriter(stream))
            {               
                using (BinaryWriter leWriter = new BinaryWriter(stream))
                {
                    // Evaluate stream length 
                    int fileLength = 0;
                    foreach (Geometry geometry in geometries.Geometries)
                        fileLength += (shapeWriter.GetBytesLength(geometry) + 8);  // 12 is the length of record header
                    fileLength += 100;  // Add main header
                    WriteHeaderFile(geometries, leWriter, beWriter, (int)(fileLength / 2));     // Write length in 16 bit words!

                    foreach (Geometry geometry in geometries.Geometries)
                        Write(geometry, leWriter, beWriter);
                }    
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="leWriter"></param>
        /// <param name="beWriter"></param>
        protected virtual void Write(Geometry geometry, BinaryWriter leWriter, BigEndianBinaryWriter beWriter)
        {
            WriteFeatureHeader(geometry, beWriter);             
                          
            if (geometry is Point)                
                shapeWriter.Write(geometry as Point, leWriter);
            else if (geometry is LineString)
                shapeWriter.Write(geometry as LineString, leWriter);
            else if (geometry is Polygon)
                shapeWriter.Write(geometry as Polygon, leWriter);
            else if (geometry is MultiPoint)
                shapeWriter.Write(geometry as MultiPoint, leWriter);
            else if (geometry is MultiLineString)
                shapeWriter.Write(geometry as MultiLineString, leWriter);
            else if (geometry is MultiPolygon)
                shapeWriter.Write(geometry as MultiPolygon, leWriter);
            else throw new NotSupportedException("Unsupported Geometry implementation:" + geometry.GetType());
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geometry"></param>
        /// <returns></returns>
        protected virtual ShapeGeometryTypes GetShapeType(IGeometry geometry)
        {
            if (geometry is Point)
                return ShapeGeometryTypes.Point;
            else if (geometry is LinearRing)
                return ShapeGeometryTypes.LineString;
            else if (geometry is LineString)
                return ShapeGeometryTypes.LineString;
            else if (geometry is Polygon)
                return ShapeGeometryTypes.Polygon;
            else if (geometry is MultiPoint)
                return ShapeGeometryTypes.MultiPoint;
            else if (geometry is MultiLineString)
                return ShapeGeometryTypes.LineString;
            else if (geometry is MultiPolygon)
                return ShapeGeometryTypes.Polygon;
            else throw new NotSupportedException("Unsupported Geometry implementation:" + geometry.GetType());            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geometries"></param>
        /// <param name="beWriter">Big Endian Writer</param>
        /// <param name="leWriter">Little Endian Endian Writer</param>
        /// <param name="streamLength"></param>
        protected virtual void WriteHeaderFile(GeometryCollection geometries, BinaryWriter leWriter, BigEndianBinaryWriter beWriter, int streamLength)
        {
            // Write stub value for FileCode (big endian)            
            beWriter.WriteIntBE((int)9994);
            // Write stub values for unused (big endian)
            beWriter.WriteIntBE((int)0);
            beWriter.WriteIntBE((int)0);
            beWriter.WriteIntBE((int)0);
            beWriter.WriteIntBE((int)0);
            beWriter.WriteIntBE((int)0);
            // Write stub value for Length (big endian)
            beWriter.WriteIntBE((int)streamLength);

            // Write version
            leWriter.Write((int)1000);
            // Write ShapeTipe
            leWriter.Write((int)GetShapeType(geometries.Geometries[0]));
            // Write values for boundingbox      
            IEnvelope envelope = geometries.EnvelopeInternal;
            leWriter.Write((double)envelope.MinX);
            leWriter.Write((double)envelope.MinY);
            leWriter.Write((double)envelope.MaxX);
            leWriter.Write((double)envelope.MaxY);
            leWriter.Write((double)0);
            leWriter.Write((double)0);
            leWriter.Write((double)0);
            leWriter.Write((double)0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="beWriter"></param>
        protected virtual void WriteFeatureHeader(Geometry geometry, BigEndianBinaryWriter beWriter)
        {            
            // Write record number (big endian)
            beWriter.WriteIntBE((int)++recordCounter);            
            // Write content length (big endian) 
            int contentLength = shapeWriter.GetBytesLength(geometry);
            beWriter.WriteIntBE((int)(contentLength / 2));  // Write length in 16 bit words!
        }
    }
}
