using System;
using System.Collections.Generic;
using System.Threading;

namespace DribbbleForWindowsPhone.Helpers
{
    /// <summary>
    /// Represents a exclusive context of synchronization.
    /// </summary>
    /// <remarks>Basically, a different context of threads to execute actions.</remarks>
    public sealed class ExclusiveSynchronizationContext : SynchronizationContext, IDisposable
    {
        #region Fields

        private bool _done;
        private readonly AutoResetEvent _workItemsWaiting = new AutoResetEvent(false);
        private readonly Queue<Tuple<SendOrPostCallback, object>> _items = new Queue<Tuple<SendOrPostCallback, object>>();

        /// <summary>
        /// To detect redundant calls.
        /// </summary>
        /// <remarks>To better impleentation of the IDisposable interface.</remarks>
        private bool _disposed;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Represents the inner exception that occurs when the class tried execute an action.
        /// </summary>
        public Exception InnerException { get; set; }

        #endregion Properties

        #region Methods

        #region Public

        /// <summary>
        /// Post an method on the context.
        /// </summary>
        /// <param name="d">The method to be posted.</param>
        /// <param name="state">The state to be shared.</param>
        public override void Post(SendOrPostCallback d, object state)
        {
            lock (_items)
            {
                _items.Enqueue(Tuple.Create(d, state));
            }

            _workItemsWaiting.Set();
        }

        /// <summary>
        /// Send a message.
        /// </summary>
        /// <param name="d">Method to be called.</param>
        /// <param name="state">State to be sent.</param>
        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotSupportedException("We cannot send to our same thread");
        }

        /// <summary>
        /// Create a copy of the current object of this class.
        /// </summary>
        /// <returns></returns>
        public override SynchronizationContext CreateCopy()
        {
            return this;
        }

        /// <summary>
        /// Finish the message loop.
        /// </summary>
        public void EndMessageLoop()
        {
            Post(p => _done = true, null);
        }

        /// <summary>
        /// Beginning the message loop.
        /// </summary>
        public void BeginMessageLoop()
        {
            while (!_done)
            {
                Tuple<SendOrPostCallback, object> task = null;

                lock (_items)
                {
                    if (_items.Count > 0)
                        task = _items.Dequeue();
                }

                if (task != null)
                {
                    task.Item1(task.Item2);

                    if (InnerException != null)
                        // The method threw an exception.
                        throw new AggregateException("AsyncHelpers.Run method threw an exception", InnerException);

                }
                else
                {
                    _workItemsWaiting.WaitOne();
                }
            }
        }

        #endregion Public

        #region Protected

        /// <summary>
        /// Dispose an object accordingly the <paramref name="disposing"/> parameter.
        /// </summary>
        /// <param name="disposing">True, if already is disposing this object.</param>
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    if (_workItemsWaiting != null)
                        _workItemsWaiting.Dispose();

                _disposed = true;
            }
        }

        #endregion Protected

        #endregion Methods

        #region IDisposable members

        /// <summary>
        /// Dispose the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        #endregion IDisposable members
    }
}
