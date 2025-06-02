using System;

namespace DatePicker
{
    public interface IDatePicker
    {
        void Show(DateTime initDate, Action<DateTime> callback);
    }
}