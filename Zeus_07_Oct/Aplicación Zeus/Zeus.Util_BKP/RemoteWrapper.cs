using System;

namespace Zeus.Util
{
    public class RemoteWrapper : MarshalByRefObject
    {
        /// <summary>
        /// Occurs when a broadcast message received.
        /// </summary>
        public event IdHandler WrapperMessageReceived;

        /// <summary>
        /// Wrapper method for sending message to the clients.
        /// </summary>
        public void WrapperMessageReceivedHandler(int id)
        {
            // forward the message to the client
            if (WrapperMessageReceived != null)
                WrapperMessageReceived(id);
        }

        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this
        /// instance.
        /// </summary>
        /// <returns>
        ///An object of type System.Runtime.Remoting.Lifetime.ILease used to control
        ///the lifetime policy for this instance. This is the current lifetime service
        ///object for this instance if one exists; otherwise, a new lifetime service
        ///object initialized to the value of the System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime
        ///property.
        ///null value means this object has to live forever.
        /// </returns>
        public override object InitializeLifetimeService()
        {
            // this object has to live "forever"
            return null;
        }
    }
}