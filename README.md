# Singleton
## Non Thread Safe
```csharp
public sealed class Singleton
{
    private static Singleton instance = null;

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
```

## Thread Safe
```csharp
public sealed class Singleton
{
    private static Singleton instance = null;
    private static readonly object locker = new object();

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
```

## Thread Safe Double Check
```csharp
public sealed class Singleton
{
    private static Singleton instance = null;
    private static readonly object locker = new object();

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }
}
```

## Thread Safe Without Lock
```csharp
public sealed class Singleton
{
    private static readonly Singleton instance = new Singleton();

    static Singleton() { }

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            return instance;
        }
    }
}
```

## Thread Safe Fully Lazy
```csharp
public sealed class Singleton
{
    private Singleton() { }

    public static Singleton Instance { get { return Nested.instance; } }

    private class Nested
    {
        static Nested() { }

        internal static readonly Singleton instance = new Singleton();
    }
}
```

## Source
[Source: http://ramate.net/singleton-pattern](http://ramate.net/singleton-pattern)
