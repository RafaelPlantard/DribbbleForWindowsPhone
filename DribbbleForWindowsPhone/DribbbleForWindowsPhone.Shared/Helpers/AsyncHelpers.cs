using System;
using System.Threading;
using System.Threading.Tasks;

namespace DribbbleForWindowsPhone.Helpers
{
    /// <summary>
    /// A collection of methods to help to execute a task in a synchronous or asynchronous mode.
    /// </summary>
    public static class AsyncHelpers
    {
        #region Methods

        #region Public

        /// <summary>
        /// Execute's an async Task method which has a void return value synchronously.
        /// </summary>
        /// <param name="task">Task method to execute.</param>
        public static void RunSync(Func<Task> task)
        {
            SynchronizationContext oldContext = SynchronizationContext.Current;
            ExclusiveSynchronizationContext exclusiveContext = new ExclusiveSynchronizationContext();

            SynchronizationContext.SetSynchronizationContext(exclusiveContext);

            exclusiveContext.Post(
                async p =>
                {
                    try
                    {
                        await task();
                    }
                    catch (Exception e)
                    {
                        exclusiveContext.InnerException = e;
                        throw;
                    }
                    finally
                    {
                        exclusiveContext.EndMessageLoop();
                    }
                }
                , null);

            exclusiveContext.BeginMessageLoop();

            SynchronizationContext.SetSynchronizationContext(oldContext);
        }

        /// <summary>
        /// Execute's an async Task of T method which has a T return type synchronously.
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="task">Task of T method to execute.</param>
        public static T RunSync<T>(Func<Task<T>> task)
        {
            SynchronizationContext oldContext = SynchronizationContext.Current;
            ExclusiveSynchronizationContext exclusiveContext = new ExclusiveSynchronizationContext();

            SynchronizationContext.SetSynchronizationContext(exclusiveContext);

            T t = default(T);

            exclusiveContext.Post(
                async p =>
                {
                    try
                    {
                        t = await task();
                    }
                    catch (Exception e)
                    {
                        exclusiveContext.InnerException = e;
                        throw;
                    }
                    finally
                    {
                        exclusiveContext.EndMessageLoop();
                    }
                }
                , null);

            exclusiveContext.BeginMessageLoop();

            SynchronizationContext.SetSynchronizationContext(oldContext);

            return t;
        }

        #endregion Public

        #endregion Methods
    }
}
