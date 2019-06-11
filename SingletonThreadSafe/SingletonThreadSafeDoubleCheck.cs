﻿namespace SingletonThreadSafeDoubleCheck
{
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
}
