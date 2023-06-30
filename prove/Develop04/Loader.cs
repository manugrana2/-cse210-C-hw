using System;
using System.Threading;
using System.Threading.Tasks;

public class Loader
{
    private bool _active;
    private Task _loaderTask;
    private CancellationTokenSource _cancellationTokenSource;

    public Loader()
    {
        _active = false;
        _loaderTask = null;
        _cancellationTokenSource = null;
    }

    public void Start()
    {
        if (_active)
        {
            return; // Animation is already active
        }

        Console.CursorVisible = false;
        _active = true;
        _cancellationTokenSource = new CancellationTokenSource();

        _loaderTask = Task.Run(async () =>
        {
            while (_active)
            {
                Console.Write("/");
                Thread.Sleep(200);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("-");
                Thread.Sleep(200);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("\\");
                Thread.Sleep(200);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("|");
                Thread.Sleep(200);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }

            Console.CursorVisible = true;
        }, _cancellationTokenSource.Token);
    }

    public void Stop()
    {
        if (!_active)
        {
            return; // Animation is not active
        }

        _active = false;
        _cancellationTokenSource.Cancel();

        if (_loaderTask != null)
        {
            _loaderTask.Wait();
        }
    }
}
