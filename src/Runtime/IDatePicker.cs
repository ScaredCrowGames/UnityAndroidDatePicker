using System;

public interface IDatePicker
{
    void Show(DateTime initDate, Action<DateTime> callback);
}