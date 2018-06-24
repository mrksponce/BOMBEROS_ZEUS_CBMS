using System;

namespace KDTreeDLL
{
    /// <summary>
    /// Key-size mismatch exception supporting KDTree class
    /// 
    /// @author Simon Levy
    /// Translation by Marco A. Alvarez
    /// </summary> 
    public class KeyMissingException : Exception
    {
        /// <summary>
        /// KeyMissing Exception
        /// </summary>
        public KeyMissingException()
        {
            Console.WriteLine("Key not found");
        }
    }
}
