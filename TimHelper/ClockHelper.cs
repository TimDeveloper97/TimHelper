using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;

namespace TimHelper
{
    public class ClockHelper
    {
        //readonly DispatcherTimer _dispatcher;
        //readonly Clock _clock;
        //Action _action;

        //public ClockHelper()
        //{
        //    _dispatcher = new DispatcherTimer();
        //    _clock = new Clock();

        //}
        //public void Start(Action action, int seconds = -1)
        //{
        //    if (seconds == -1)
        //        _dispatcher.Interval = new TimeSpan(0, 1, 0);
        //    else
        //        _dispatcher.Interval = new TimeSpan(0, 0, seconds);

        //    _action = action;
        //    _dispatcher.Tick += eventTick(_action);

        //    _dispatcher.Start();
        //}

        //public void Close()
        //{
        //    _dispatcher -= eventTick(_action);
        //    _dispatcher.Stop();
        //}

        //public new string ToString
        //{
        //    get => _clock.ToString;
        //}

        //private void eventTick(Action action)
        //{
        //    _clock.Minutes++;

        //    if (_clock.Minutes == 60)
        //    {
        //        _clock.Minutes = 0;
        //        _clock.Hours++;
        //    }
        //    action?.Invoke();
        //}
    }

    public class Clock
    {
        public double Hours { get; set; } = 0;
        public double Minutes { get; set; } = 0;
        public double Seconds { get; set; } = 0;

        public new string ToString
        {
            get
            {
                var h = Hours < 10 ? "0" + Hours.ToString() : Hours.ToString();
                var m = Minutes < 10 ? "0" + Minutes.ToString() : Minutes.ToString();
                //var s = Seconds < 10 ? "0" + Seconds.ToString() : Seconds.ToString();
                return $"{h}:{m}";
            }
        }
    }
}
