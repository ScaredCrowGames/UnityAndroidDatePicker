using System;
using UnityEngine;

// public delegate void ResponseDelegate();
public class AndroidDatePicker : IDatePicker
{
    private Action<DateTime> _dateSelectedCallback;
    private DateTime _initDate;

    public void Show(DateTime initDate, Action<DateTime> callback)
    {
        _initDate = initDate;
        _dateSelectedCallback = callback;

        var unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var activity = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");

        activity.Call("runOnUiThread",
            new AndroidJavaRunnable(() =>
            {
                new AndroidJavaObject("android.app.DatePickerDialog", activity, new DateCallback(this),
                    _initDate.Year, _initDate.Month - 1, _initDate.Day).Call("show");
            }));
    }

    private void DateSelectedHandler(DateTime date)
    {
        _dateSelectedCallback?.Invoke(date);
    }


    class DateCallback : AndroidJavaProxy
    {
        private AndroidDatePicker mDialog;

        public DateCallback(AndroidDatePicker d) : base("android.app.DatePickerDialog$OnDateSetListener")
        {
            mDialog = d;
        }

        private void onDateSet(AndroidJavaObject view, int year, int monthOfYear, int dayOfMonth)
        {
            var selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);

            mDialog.DateSelectedHandler(selectedDate);
        }
    }
}