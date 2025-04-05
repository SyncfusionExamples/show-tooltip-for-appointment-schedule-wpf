namespace WPFSchedulerDemo
{
    using System.Windows.Media;
    using System.ComponentModel;
    using Syncfusion.UI.Xaml.Scheduler;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents the ViewModel for scheduling operations and bindings.
    /// </summary>
    public class SchedulerViewModel
    {
        #region Fields

        /// <summary>
        /// The schedule appointment collection.
        /// </summary>
        private ScheduleAppointmentCollection appointments;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SchdulerViewModel" /> class.
        /// </summary>
        public SchedulerViewModel()
        {
            this.Appointments = this.GenerateRandomAppointments();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the collection of appointments for the scheduler.
        /// </summary>
        public ScheduleAppointmentCollection Appointments
        {
            get
            {
                return appointments;
            }
            set
            {
                appointments = value;
                this.RaisePropertyChanged("Appointments");
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Method to generate scheduler appointments based on current visible date range.
        /// </summary>
        private ScheduleAppointmentCollection GenerateRandomAppointments()
        {
            var WorkWeekDays = new ObservableCollection<DateTime>();
            var WorkWeekSubjects = new ObservableCollection<string>()
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Project Status Discussion",
                                                             "Auditing", "Client Meeting", "Generate Report", "Target Meeting", "General Meeting" };

            var NonWorkingDays = new ObservableCollection<DateTime>();
            var NonWorkingSubjects = new ObservableCollection<string>()
                                                           { "Go to party", "Order Pizza", "Buy Gift",
                                                             "Vacation" };
            var YearlyOccurrance = new ObservableCollection<DateTime>();
            var YearlyOccurranceSubjects = new ObservableCollection<string>() { "Wedding Anniversary", "Sam's Birthday", "Jenny's Birthday" };
            var MonthlyOccurrance = new ObservableCollection<DateTime>();
            var MonthlyOccurranceSubjects = new ObservableCollection<string>() { "Pay House Rent", "Car Service", "Medical Check Up" };
            var WeekEndOccurrance = new ObservableCollection<DateTime>();
            var WeekEndOccurranceSubjects = new ObservableCollection<string>() { "FootBall Match", "TV Show" };

            var brush = new ObservableCollection<SolidColorBrush>();

            brush.Add(new SolidColorBrush(Color.FromArgb(255, 133, 81, 242)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 140, 245, 219)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 255, 222, 133)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 45, 153, 255)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 253, 183, 165)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 198, 237, 115)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 253, 185, 222)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));

            Random ran = new Random();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
                today = today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
                today = today.AddMonths(1);
            }

            DateTime startMonth = new DateTime(today.Year, today.Month - 1, 1, 0, 0, 0);
            DateTime endMonth = new DateTime(today.Year, today.Month + 1, 30, 0, 0, 0);
            DateTime dt = new DateTime(today.Year, today.Month, 15, 0, 0, 0);
            int day = (int)startMonth.DayOfWeek;
            DateTime CurrentStart = startMonth.AddDays(-day);

            var appointments = new ScheduleAppointmentCollection();
            for (int i = 0; i < 90; i++)
            {
                if (i % 7 == 0 || i % 7 == 6)
                {
                    //add weekend appointments
                    NonWorkingDays.Add(CurrentStart.AddDays(i));
                }
                else
                {
                    //Add Workweek appointment
                    WorkWeekDays.Add(CurrentStart.AddDays(i));
                }
            }

            for (int i = 0; i < 50; i++)
            {
                DateTime date = WorkWeekDays[ran.Next(0, WorkWeekDays.Count)].AddHours(ran.Next(9, 17));

                var appointment = new ScheduleAppointment();

                appointment.StartTime = date;
                appointment.EndTime = date.AddHours(1);
                appointment.AppointmentBackground = brush[i % brush.Count];
                appointment.Foreground = GetAppointmentForeground(appointment.AppointmentBackground);
                appointment.Subject = WorkWeekSubjects[i % WorkWeekSubjects.Count];

                appointments.Add(appointment);
            }
            int j = 0;
            int k = 0;
            int l = 0;

            while (j < YearlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)];
                var appointment = new ScheduleAppointment();

                appointment.StartTime = date;
                appointment.EndTime = date.AddHours(1);
                appointment.AppointmentBackground = brush[1];
                appointment.Foreground = GetAppointmentForeground(appointment.AppointmentBackground);
                appointment.Subject = YearlyOccurranceSubjects[j];

                appointments.Add(appointment);
                j++;
            }
            while (k < MonthlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(9, 23));
                var appointment = new ScheduleAppointment();

                appointment.StartTime = date;
                appointment.EndTime = date.AddHours(1);
                appointment.AppointmentBackground = brush[k];
                appointment.Foreground = GetAppointmentForeground(appointment.AppointmentBackground);
                appointment.Subject = MonthlyOccurranceSubjects[k];

                appointments.Add(appointment);
                k++;
            }
            while (l < WeekEndOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(0, 23));
                var appointment = new ScheduleAppointment();

                appointment.StartTime = date;
                appointment.EndTime = date.AddHours(1);
                appointment.AppointmentBackground = brush[l];
                appointment.Foreground = GetAppointmentForeground(appointment.AppointmentBackground);
                appointment.Subject = WeekEndOccurranceSubjects[l];

                appointments.Add(appointment);
                l++;
            }

            return appointments;
        }

        /// <summary>
        /// Method to get foreground color based on background.
        /// </summary>
        /// <param name="backgroundColor">The background color.</param>
        /// <returns>The background color.</returns>
        private Brush GetAppointmentForeground(Brush backgroundColor)
        {
            var brush = backgroundColor as SolidColorBrush;
            if (brush.Color.ToString().Equals("#FF8551F2") || brush.Color.ToString().Equals("#FF5363FA") || brush.Color.ToString().Equals("#FF2D99FF"))
            {
                return new SolidColorBrush(Colors.White);
            }
            else
            {
                return new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        protected virtual void RaisePropertyChanged(string propertyName, object oldValue = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
