/*// Задача 2

// -----------------------------------

//CheckReaders();
CheckWriters();

// -----------------------------------

void CheckReaders()
{
    Server.AddToCount(10);
    var tasks = new Task<int>[10];
    for (int i = 0; i < 10; i++)
    {
        tasks[i] = Task.Run(() => Server.GetCount());
    }

    Task.WaitAll(tasks);
    foreach (var task in tasks)
    {
        Console.WriteLine($"результат: {task.Result}. равен? {task.Result.Equals(10)}");
    }
}

void CheckWriters()
{
    int iterations = 100;
    var tasks = new Task[iterations];
    for (int i = 0; i < iterations; i++)
    {
        int value = i;
        tasks[i] = Task.Run(() => Server.AddToCount(1));
    }

    Task.WaitAll(tasks);
    Console.WriteLine($"итерации: {iterations}, чиселка с сервера: {Server.GetCount()}");
}

// -----------------------------------


public static class Server
{
    private static int count = 0;
    private static readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

    public static int GetCount()
    {
        rwLock.EnterReadLock();
        try
        {
            return count;
        }
        finally
        {
            rwLock.ExitReadLock();
        }
    }

    public static void AddToCount(int value)
    {
        rwLock.EnterWriteLock();
        try
        {
            count += value;
        }
        finally
        {
            rwLock.ExitWriteLock();
        }
    }
}*/