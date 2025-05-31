using System;
using UnityEngine;
using UnityEngine.UI;

public class DatePickerDemo : MonoBehaviour
{
    // Recommended to use TextMeshPro instead
    [SerializeField] private Text _buttonText;
    [SerializeField] private Button _button;

    private IDatePicker _calendar;

    private void Start()
    {
        _button.onClick.AddListener(OnDateButtonClicked);

#if UNITY_EDITOR
        _calendar = new UnityEditorCalendar();
#elif UNITY_ANDROID
        _calendar = new AndroidDatePicker();
#endif
    }

    private void OnDateButtonClicked()
    {
        _calendar?.Show(DateTime.Now, OnDateSelected);
    }

    private void OnDateSelected(DateTime value)
    {
        _buttonText.text = value.ToString();

        Debug.Log($"Date selected: {value.ToShortDateString()}");
    }
}

#if UNITY_EDITOR
class UnityEditorCalendar : IDatePicker
{
    public void Show(DateTime initDate, Action<DateTime> callback)
    {
        callback?.Invoke(initDate);
    }
}
#endif