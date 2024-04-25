using System.Threading;
using UnityEngine;

public class GenericClassExample : MonoBehaviour
{
    static object locker = new object();

    Vector2 vector2;

    private void Update()
    {
        vector2 = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        for (int i = 0; i < 2; i++)
        {
            Thread myThread = new Thread(ThreadTest);
            myThread.Name = "Поток " + i.ToString();
            myThread.Start();
        }
    }

    void ThreadTest()
    {
        lock (locker)
        {
            Thread myThread = Thread.CurrentThread;
            Point<float> intPoint = new Point<float>(vector2.x, vector2.y);
            intPoint.PrintCoordinates(myThread);
            Thread.Sleep(100);
        }
    }
}

public class Point<T>
{
    public T x;
    public T y;

    public Point(T x, T y)
    {
        this.x = x;
        this.y = y;
    }

    public void PrintCoordinates(Thread myThread)
    {
        if (myThread.Name == "Поток 1")
            Debug.Log(myThread.Name + $" координаты: ({x}, {y})");
        else
        {
            Debug.Log(myThread.Name + $" координаты: ({0}, {0})");
        }
    }
}
