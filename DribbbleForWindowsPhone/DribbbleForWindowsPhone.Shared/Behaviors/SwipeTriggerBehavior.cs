using DribbbleForWindowsPhone.Behaviors.Utils;
using DribbbleForWindowsPhone.Extensions;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;

namespace DribbbleForWindowsPhone.Behaviors
{
    /// <summary>
    /// Represents a Swipe Trigger Behavior.
    /// </summary>
    [ContentProperty(Name = "Actions")]
    public class SwipeTriggerBehavior : Behavior<UIElement>
    {
        #region Fields

        /// <summary>
        /// Backing storage for Actions collection.
        /// </summary>
        public static readonly DependencyProperty ActionsProperty = DependencyProperty.Register("Actions", typeof(ActionCollection), typeof(SwipeTriggerBehavior), new PropertyMetadata(null));

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets/Sets the direction of the Swipe gesture.
        /// </summary>
        public SwipeDirection Direction { get; set; }

        /// <summary>
        /// Actions collection.
        /// </summary>
        public ActionCollection Actions
        {
            get
            {
                ActionCollection actions = (ActionCollection)GetValue(ActionsProperty);

                if (actions == null)
                {
                    actions = new ActionCollection();

                    SetValue(ActionsProperty, actions);
                }

                return actions;
            }
        }

        #endregion Properties

        #region Methods

        #region Private

        /// <summary>
        /// The event handler that is fired when the manipulation is completed.
        /// </summary>
        /// <param name="sender">Sender details.</param>
        /// <param name="e">Manipulation completed routed event arguments.</param>
        private void OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            // TODO: Improve the detection of swipes direction. Most important on right and left.

            bool isRight = e.Velocities.Linear.X.Between(0.03, 100);
            bool isLeft = e.Velocities.Linear.X.Between(-100, -0.03);

            bool isUp = e.Velocities.Linear.Y.Between(-100, -0.03);
            bool isDown = e.Velocities.Linear.Y.Between(0.03, 100);

            switch (Direction)
            {
                case SwipeDirection.Left:
                    if (isLeft && !(isUp || isDown))
                        Execute(AssociatedObject, null);
                    break;

                case SwipeDirection.Right:
                    if (isRight && !(isUp || isDown))
                        Execute(AssociatedObject, null);
                    break;

                case SwipeDirection.Up:
                    if (isUp && !(isRight || isLeft))
                        Execute(AssociatedObject, null);
                    break;

                case SwipeDirection.Down:
                    if (isDown && !(isRight || isLeft))
                        Execute(AssociatedObject, null);
                    break;

                case SwipeDirection.LeftDown:
                    if (isLeft && isDown)
                        Execute(AssociatedObject, null);
                    break;

                case SwipeDirection.LeftUp:
                    if (isLeft && isUp)
                        Execute(AssociatedObject, null);
                    break;

                case SwipeDirection.RightDown:
                    if (isRight && isDown)
                        Execute(AssociatedObject, null);
                    break;

                case SwipeDirection.RightUp:
                    if (isRight && isUp)
                        Execute(AssociatedObject, null);
                    break;
            }
        }

        #endregion Private

        #region Protected

        /// <summary>
        /// Execute the actions when the behavior was triggered.
        /// </summary>
        /// <param name="sender">Sender informations.</param>
        /// <param name="parameter">Parameter to help the execute logic.</param>
        protected void Execute(object sender, object parameter)
        {
            Interaction.ExecuteActions(sender, Actions, parameter);
        }

        /// <summary>
        /// Execute when the behavior is attached.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.ManipulationMode = AssociatedObject.ManipulationMode | ManipulationModes.TranslateX | ManipulationModes.TranslateY;

            AssociatedObject.ManipulationCompleted += OnManipulationCompleted;
        }

        /// <summary>
        /// Execute when the behavior is detached.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.ManipulationCompleted -= OnManipulationCompleted;
        }

        #endregion Protected

        #endregion Methods
    }
}
