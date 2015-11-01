using Microsoft.Xaml.Interactivity;
using System.ComponentModel;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace DribbbleForWindowsPhone.Behaviors
{
    /// <summary>
    /// The base class of Behaviors.
    /// </summary>
    /// <typeparam name="T">Type in the behavior it will work.</typeparam>
    public abstract class Behavior<T> : DependencyObject, IBehavior 
        where T : DependencyObject
    {
        #region Properties

        /// <summary>
        /// Represents the associated object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T AssociatedObject { get; set; }

        #endregion Properties

        #region Methods

        #region Protected

        /// <summary>
        /// Action to occurs when a behavior is attached on an object.
        /// </summary>
        protected virtual void OnAttached()
        { }

        /// <summary>
        /// Action to occurs when a behavior is detached on an object.
        /// </summary>
        protected virtual void OnDetaching()
        { }

        #endregion Protected

        #endregion Methods

        #region IBehavior members

        /// <summary>
        /// Attach the behavior on a associated object.
        /// </summary>
        /// <param name="associatedObject">The object that will contains a concret behavior.</param>
        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject == this.AssociatedObject || DesignMode.DesignModeEnabled)
                return;

            this.AssociatedObject = (T)associatedObject;

            OnAttached();
        }

        /// <summary>
        /// Detach the behavior of the its associated object.
        /// </summary>
        public void Detach()
        {
            if (!DesignMode.DesignModeEnabled)
                OnDetaching();
        }

        DependencyObject IBehavior.AssociatedObject
        {
            get { return this.AssociatedObject; }
        }

        #endregion IBehavior members
    }
}
