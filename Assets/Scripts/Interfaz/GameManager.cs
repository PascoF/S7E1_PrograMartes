using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ISubject
{
    private static GameManager instance;
    public event Action<int> OnProgressionChanged;

    private float timer;
    private int progression;

    private List<IObserver> observers;


    public int Progression
    {
        get
        {
            return progression;
        }
    }

    public static GameManager GetInstance
    {
            return instance;
    }

    void Awake()
    {
        instance = this;
        observers = new List<IObserver>();
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in observers)
        {
            observer.Execute(this);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= progression)
        {
            progression++;
            OnProgressionChanged(progression);
        }
    }
}
