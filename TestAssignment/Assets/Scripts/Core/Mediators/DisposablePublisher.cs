using System;
using System.Collections.Generic;

namespace Core
{
    public class DisposablePublisher : IDisposablePublisher
    {
        private readonly List<IDisposable> _disposables;

        public DisposablePublisher(List<IDisposable> disposables)
        {
            _disposables = disposables;
        }

        public void Dispose()
        {
            foreach (var item in _disposables)
                item.Dispose();
        }
    }
}