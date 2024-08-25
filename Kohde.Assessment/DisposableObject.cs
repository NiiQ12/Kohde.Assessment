using System;
using System.Collections.Generic;
using System.Linq;

namespace Kohde.Assessment {
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable {
        public event MyEventHandler SomethingHappened;

        // Create list used to track eventHandlers
        private List<MyEventHandler> eventHandlers = new List<MyEventHandler>();

        public int Counter { get; private set; }

        public void PerformSomeLongRunningOperation() {
            foreach (var i in Enumerable.Range(1, 10)) {
                var eventHandler = new MyEventHandler(HandleSomethingHappened);
                this.SomethingHappened += eventHandler;
                eventHandlers.Add(eventHandler);
            }
        }

        public void RaiseEvent(string data) {
            // Removed the (SomethingHappened = null) check.  Handled with the null-conditional operator
            this.SomethingHappened?.Invoke(data);
        }

        private void HandleSomethingHappened(string foo) {
            // Use increment operator
            this.Counter++;
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", this.Counter, foo);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                // Dispose managed resources
                // Unsubscribe from events to prevent memory leaks
                foreach (MyEventHandler handler in eventHandlers) {
                    this.SomethingHappened -= handler;
                }
            }

            // Free native resources
            this.Counter = 1;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableObject() {
            Dispose(false);
        }
    }
}