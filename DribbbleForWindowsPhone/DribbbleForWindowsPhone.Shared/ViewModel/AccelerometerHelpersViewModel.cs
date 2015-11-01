using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Sensors;
using Windows.System.Threading;
using DribbbleForWindowsPhone.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ShakeGestures;

namespace DribbbleForWindowsPhone.ViewModel
{
    /// <summary>
    /// A class to encapsulate the properties of Axis X, Y and Z from the Accelerometer to binding it.
    /// In addition to contain methods and event handler to manipulate the event from the Accelerometer.
    /// </summary>
    public class AccelerometerHelpersViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// A multiply increase element to help the animate behavior of elements.
        /// </summary>
        private double _growthRate;

        /// <summary>
        /// The device is shaken? True if it is shaken, otherwise, it is false.
        /// </summary>
        private bool _isShaken;

        /// <summary>
        /// Represents the native accelerometer.
        /// </summary>
        private Accelerometer _nativeAccelerometer;

        /// <summary>
        /// The axis X.
        /// </summary>
        private double _x;

        /// <summary>
        /// The axis Y.
        /// </summary>
        private double _y;

        /// <summary>
        /// The axis Z.
        /// </summary>
        private double _z;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The growth rate to increase the Axis X, Y and Z to help in animate a element.
        /// </summary>
        public double GrowthRate
        {
            get { return _growthRate; }
            set { Set(() => GrowthRate, ref _growthRate, value); }
        }

        /// <summary>
        /// Checks if the device was shaken or not.
        /// </summary>
        /// <remarks>True, in case of shaken, otherwise, false.</remarks>
        public bool IsShaken
        {
            get { return _isShaken; }
            set { Set(() => IsShaken, ref _isShaken, value); }
        }

        /// <summary>
        /// Represents the native accelerometer.
        /// </summary>
        public Accelerometer NativeAccelerometer
        {
            get { return _nativeAccelerometer; }
            set { Set(() => NativeAccelerometer, ref _nativeAccelerometer, value); }
        }

        /// <summary>
        /// The Axis X.
        /// </summary>
        public double X
        {
            get { return _x * _growthRate; }
            set { Set(() => X, ref _x, value); }
        }

        /// <summary>
        /// The Axis Y.
        /// </summary>
        public double Y
        {
            get { return _y * _growthRate; }
            set { Set(() => Y, ref _y, value); }
        }

        /// <summary>
        /// The Axis Z.
        /// </summary>
        public double Z
        {
            get { return _z * _growthRate; }
            set { Set(() => Z, ref _z, value); }
        }



        /// <summary>
        /// Represents a command to turn on the accelerometer of the current device.
        /// </summary>
        public ICommand StartAccelerometerCommand { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public AccelerometerHelpersViewModel()
        {
            StartAccelerometerCommand = new RelayCommand<string>(s => StartingAccelerometer(s));

            GrowthRate = 1;

            IsShaken = false;
        }

        #endregion Constructors

        #region Methods

        #region Private

        /// <summary>
        /// Update the <see cref="IsShaken"/> property when the device is shaken.
        /// </summary>
        /// <param name="sender">Sender details.</param>
        /// <param name="e">Shake gesture event arguments.</param>
        /// <remarks>
        /// Set the <see cref="GrowthRate"/> property 1 or less, to always reset the <see cref="IsShaken"/> property to its original state.
        /// </remarks>
        private async void Instance_ShakeGesture(object sender, ShakeGestureEventArgs e)
        {
            await ThreadPool.RunAsync(
                p => UIDispatcher.Execute(() =>
                {
                    IsShaken = true;

                    if (GrowthRate <= 1)
                        IsShaken = false;
                })
            );
        }

        /// <summary>
        /// Update the Axis Accelerometer properties to reflect the reading changed method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void NativeAccelerometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            await ThreadPool.RunAsync(
                p => UIDispatcher.Execute(() =>
                {
                    AccelerometerReading accelerometerReading = args.Reading;

                    UpdateAccelerometerAxis(accelerometerReading);
                })
            );
        }

        /// <summary>
        /// The method that active the accelerometer.
        /// </summary>
        /// <param name="growthRate">The growth rate to help in animation activities.</param>
        private void StartingAccelerometer(string growthRate)
        {
            GrowthRate = double.Parse(growthRate);

            StartShakeGesturesHelper();

            StartNativeAccelerometer();
        }

        /// <summary>
        /// Start the shake gesture helper instance.
        /// </summary>
        private void StartShakeGesturesHelper()
        {
            ShakeGesturesHelper.Instance.ShakeGesture += Instance_ShakeGesture;

            ShakeGesturesHelper.Instance.MinimumRequiredMovesForShake = 2;

            ShakeGesturesHelper.Instance.Active = true;
        }

        /// <summary>
        /// Start the native accelerometer.
        /// </summary>
        private void StartNativeAccelerometer()
        {
            NativeAccelerometer = Accelerometer.GetDefault();

            if (NativeAccelerometer != null)
            {
                // Establish the report interval.
                uint minReportInterval = NativeAccelerometer.MinimumReportInterval;
                uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;

                NativeAccelerometer.ReportInterval = reportInterval;

                // Assign an event handler for reading-changed event.
                NativeAccelerometer.ReadingChanged += NativeAccelerometer_ReadingChanged;
            }
        }

        /// <summary>
        /// Updates the accelerometer's axis.
        /// </summary>
        /// <param name="accelerometerReading">The value of reading on accelerometer.</param>
        private void UpdateAccelerometerAxis(AccelerometerReading accelerometerReading)
        {
            X = accelerometerReading.AccelerationX;
            Y = accelerometerReading.AccelerationY;
            Z = accelerometerReading.AccelerationZ;
        }

        #endregion Private

        #endregion Methods
    }
}
