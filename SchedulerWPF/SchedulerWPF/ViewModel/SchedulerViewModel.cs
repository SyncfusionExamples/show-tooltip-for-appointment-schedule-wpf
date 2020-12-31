using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel
    {
        public ScheduleAppointmentCollection AppointmentCollection { get; set; } = new ScheduleAppointmentCollection();
        public SchedulerViewModel()
        {
            ScheduleAppointment appointment1 = new ScheduleAppointment()
            {
                StartTime = new DateTime(2020, 12, 30, 10, 0, 0),
                EndTime = new DateTime(2020, 12, 30, 11, 0, 0),
                Subject = "Booked",
                Location = "Hutchison road",
                AppointmentBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#889e81"))
        };
            AppointmentCollection.Add(appointment1);
        }
    }
}
