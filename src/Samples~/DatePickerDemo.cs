using System;
using UnityEngine;
using UnityEngine.UI;

namespace DatePicker.Samples
{
    public class DatePickerDemo : MonoBehaviour
    {
        // Recommended to use TextMeshPro instead
        [SerializeField] private Text _buttonText;
        [SerializeField] private Button _button;

        private IDatePicker _datePicker;

        private void Start()
        {
            _button.onClick.AddListener(OnDateButtonClicked);

#if UNITY_EDITOR
            _datePicker = new UnityEditorCalendar();
#elif UNITY_ANDROID
            _datePicker = new DatePicker.AndroidDatePicker();
#endif
        }

        private void OnDateButtonClicked()
        {
            _datePicker?.Show(DateTime.Now, OnDateSelected);
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
}
