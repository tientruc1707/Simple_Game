using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private static ViewManager Instance;
    [SerializeField] private View _startingUI;
    [SerializeField] private View[] _views;
    private View _currentUI;
    private readonly Stack<View> _history = new Stack<View>();



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Init UIs
    private void Start()
    {
        for (int i = 0; i < _views.Length; ++i)
        {
            _views[i].Initialize();

            _views[i].Hide();
        }
        if (_startingUI != null)
        {
            Show(_startingUI, true);
        }
    }
    //return UI 
    public static T GetUI<T>() where T : View
    {
        for (int i = 0; i < Instance._views.Length; ++i)
        {
            if (Instance._views[i] is T tUI)
            {
                return tUI;
            }
        }
        return null;
    }
    //Show UI inhertance from View
    public static void Show<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < Instance._views.Length; ++i)
        {
            if (Instance._views[i] is T)
            {
                //push current UI to history and hide it
                if (Instance._currentUI != null)
                {
                    if (remember)
                    {
                        //push current UI to history stack
                        Instance._history.Push(Instance._currentUI);
                    }
                    //Hide current UI
                    Instance._currentUI.Hide();
                }
                //show this UI
                Instance._views[i].Show();
                //assign current UI = this UI
                Instance._currentUI = Instance._views[i];
            }
        }
    }
    //Show this UI and assign current UI = this UI
    public static void Show(View view, bool remember)
    {
        if (Instance._currentUI != null)
        {
            if (remember)
            {
                Instance._history.Push(Instance._currentUI);
            }
            Instance._currentUI.Hide();
        }
        view.Show();
        Instance._currentUI = view;
    }
    //Show last UI
    public static void ShowLast()
    {
        if (Instance._history.Count != 0)
        {
            Show(Instance._history.Pop(), false);
        }
    }
    //open panel in main
    public static void Open<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < Instance._views.Length; ++i)
        {
            if (Instance._views[i] is T)
            {
                if (Instance._currentUI != null)
                {
                    if (remember)
                        Instance._history.Push(Instance._currentUI);
                }
                Instance._views[i].Show();
                Instance._currentUI = Instance._views[i];
            }
        }
    }
}
