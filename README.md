# Android Date Picker for Unity

## Table of Contents
- [Installation](#installation)
- [How to use](#how-to-use)
- [Contact us](#contact-us)

## Installation

1. Use the Package Manager:

Window > Package Manager > Add package from git url...
```link
https://github.com/scaredcrowgames/androiddatepicker.git?path=src
```

2. Or add this to your Unity project's `Packages/manifest.json`:

```json
"com.scaredcrowgames.androiddatepicker": "https://github.com/scaredcrowgames/androiddatepicker.git?path=src"
```

## How to use

```csharp
public class DatePickerDemo : MonoBehaviour
{
    private IDatePicker _calendar;

    private void Start()
    {
#if UNITY_EDITOR
        _calendar = new UnityEditorDatePicker();
#elif UNITY_ANDROID
        _calendar = new AndroidDatePicker();
#endif
        _calendar?.Show(DateTime.Now, OnDateSelected);
    }

    private void OnDateSelected(DateTime value)
    {
        Debug.Log($"Date selected: {value.ToShortDateString()}");
    }

#if UNITY_EDITOR
    class UnityEditorDatePicker : IDatePicker
    {
        public void Show(DateTime initDate, Action<DateTime> callback)
        {
            callback?.Invoke(initDate);
        }
    }
#endif
}
```
> [!TIP]
> 📁 Samples/ contains DatePickerDemo.unity

## Contact us
> [!TIP]
> All discussions, requests and bug reports can be left in the corresponding [Discord channel](https://discord.gg/rh5ZQmHWap) or here in Discussions