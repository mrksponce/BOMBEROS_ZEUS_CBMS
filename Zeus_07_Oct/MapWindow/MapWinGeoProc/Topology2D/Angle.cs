using System;
using System.Collections.Generic;
using System.Text;
namespace MapWinGeoProc.Topology2D
{
    /// <summary>
    /// A geometric angle mesured in degrees or radians
    /// the angle will wrap around, so setting larger values will
    /// result in an appropriate angle.
    /// </summary>
    public struct Angle
    {
        #region Variables
        /// <summary>
        /// The value of 3.14159 or whatever from Math.PI
        /// </summary>
        public const double PI = Math.PI;
        double m_rad;
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new instance of an angle with the Radians specified
        /// </summary>
        /// <param name="Radians">The angle in radians</param>
        public Angle(double Radians)
        {
            if (Radians > 2 * Math.PI || Radians < -2 * Math.PI)
            {
                m_rad = Radians % (Math.PI * 2);
                return;
            }
            m_rad = Radians;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the angle in degrees, ranging from -360 to 360
        /// </summary>
        public double Degrees
        {
            get
            {
                return m_rad * 180 / Math.PI;
            }
            set
            {
                if (value > 360 || value < -360)
                {
                    m_rad = (value % 360) * Math.PI / 180;
                    return;
                }
                m_rad = value * Math.PI / 180;
            }
        }
        /// <summary>
        /// Gets or sets the angle in degrees ranging from 0 to 360
        /// </summary>
        public double Degrees_Pos
        {
            get
            {
                double dg = m_rad * 180 / Math.PI;
                if (dg < 0)
                {
                    return 360 + dg;
                }
                else
                {
                    return dg;
                }
            }
            set
            {
                double dg = value;
                
                if (value > 360 || value < -360)
                {
                    dg = (dg % 360);
                }
                if (dg < 360)
                {
                    dg = 360 - dg;
                }
                m_rad = dg*Math.PI / 180;
            }
        }
        /// <summary>
        /// Only allows values from -2PI to 2PI.
        /// </summary>
        public double Radians
        {
            get
            {
                return m_rad;
            }
            set
            {
                if (value > 2 * Math.PI || value < -2 * Math.PI)
                {
                    m_rad = value % (Math.PI * 2);
                    return;
                }
                m_rad = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a new instance of the Angle class with the same angle as this object.
        /// </summary>
        /// <returns>Angle which has the same values</returns>
        public Angle Copy()
        {
            Angle NewAngle = new Angle(m_rad);
            return NewAngle;
        }
        /// <summary>
        /// False for anything that is not an angle.
        /// Tests two angles to see if they have the same value.
        /// </summary>
        /// <param name="obj">An object to test.</param>
        /// <returns>Boolean, true if the angles have the same value.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Angle)) return false;
            Angle A = (Angle)obj;
            if (A.Radians == Radians) return true;
            return false;
        }
        /// <summary>
        /// Gets a hash code 
        /// </summary>
        /// <returns>Int hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region ---------------------- Operators ---------------------------
        /// <summary>
        /// Returns a new angle object with an angle of Value in radians
        /// </summary>
        /// <param name="Value">The double value indicating the angle</param>
        /// <returns>An Angle structure with the specified value</returns>
        public static explicit operator Angle(double Value)
        {
            return new Angle(Value);
        }
        /// <summary>
        /// Returns a double specifying the radian value of the angle
        /// </summary>
        /// <param name="Value">The angle structure to determine the angle of</param>
        /// <returns>A Double with the angle in radians</returns>
        public static explicit operator double(Angle Value)
        {
            return Value.Radians;
        }

        /// <summary>
        /// Returns true if the two angles are equal to each other.
        /// </summary>
        /// <param name="A">An angle to compare</param>
        /// <param name="B">A second angle.</param>
        /// <returns>Boolean, true if they are equal.</returns>
        public static bool operator ==(Angle A, Angle B)
        {
            return (A.Radians == B.Radians);
        }
        /// <summary>
        /// Returns true if the two angles are equal to each other.
        /// </summary>
        /// <param name="A">An angle to compare</param>
        /// <param name="B">A second angle.</param>
        /// <returns>Boolean, true if they are equal.</returns>
        public static bool operator !=(Angle A, Angle B)
        {
            return (A.Radians != B.Radians);
        }

        /// <summary>
        /// Returns the sum of the two angles, cycling if greater than 2 pi.
        /// </summary>
        /// <param name="A">An angle to add</param>
        /// <param name="B">A second angle to add</param>
        /// <returns>A new Angle structure equal to the sum of the two angles</returns>
        public static Angle operator +(Angle A, Angle B)
        {
            return new Angle(A.Radians + B.Radians);
        }

        /// <summary>
        /// Returns the difference of two angles.
        /// </summary>
        /// <param name="A">An angle to subtract from</param>
        /// <param name="B">The angle to subtract</param>
        /// <returns>A new angle structure with a sum equal to the two angles</returns>
        public static Angle operator -(Angle A, Angle B)
        {
            return new Angle(A.Radians - B.Radians);
        }
        /// <summary>
        /// Divides angle A by angle B
        /// </summary>
        /// <param name="A">An angle to divide</param>
        /// <param name="B">An angle to divide into A</param>
        /// <returns>A new angle with the quotient of the division</returns>
        public static Angle operator /(Angle A, Angle B)
        {
            return new Angle(A.Radians / B.Radians);
        }
        /// <summary>
        /// Multiplies angle A by Angle B.
        /// </summary>
        /// <param name="A">An angle to multiply</param>
        /// <param name="B">A second angle to multiply.</param>
        /// <returns>A new angle with the product of the two angles.</returns>
        public static Angle operator *(Angle A, Angle B)
        {
            return new Angle(A.Radians * B.Radians);
        }

        #endregion

        #region -------------------- TRIG OVERLOADS -------------------------

        /// <summary>
        /// Returns the mathematical Cos of the angle specified
        /// </summary>
        /// <param name="Value">The Angle to find the cosign of</param>
        /// <returns>Double, the cosign of the angle specified</returns>
        public static double Cos(Angle Value)
        {
            return Math.Cos(Value.Radians);
        }
        /// <summary>
        /// Returns the mathematical Sin of the angle specified
        /// </summary>
        /// <param name="Value">The Angle to find the Sin of</param>
        /// <returns>Double, the Sin of the Angle</returns>
        public static double Sin(Angle Value)
        {
            return Math.Sin(Value.Radians);
        }
        /// <summary>
        /// Returns the mathematical Tan of the angle specified
        /// </summary>
        /// <param name="Value">The Angle to find the Tan of</param>
        /// <returns>Double, the Tan of the Angle</returns>
        public static double Tan(Angle Value)
        {
            return Math.Sin(Value.Radians);
        }
        /// <summary>
        /// Returns the mathematical ATan of the value specified
        /// </summary>
        /// <param name="Value">The Double to find the ATan of</param>
        /// <returns>Angle, the ATan of the Value specified</returns>
        public static Angle ATan(double Value)
        {
            return new Angle(Math.Atan(Value));
        }
        /// <summary>
        /// Returns the mathematical ACos of the value specified
        /// </summary>
        /// <param name="Value">The Double to find the ACos of</param>
        /// <returns>Angle, the ACos of the Value specified</returns>
        public static Angle ACos(double Value)
        {
            return new Angle(Math.Acos(Value));
        }
        /// <summary>
        /// Returns the mathematical ASin of the value specified
        /// </summary>
        /// <param name="Value">The Double to find the ASin of</param>
        /// <returns>Angle, the ASin of the Value specified</returns>
        public static Angle ASin(double Value)
        {
            return new Angle(Math.Asin(Value));
        }


        #endregion
    }

}