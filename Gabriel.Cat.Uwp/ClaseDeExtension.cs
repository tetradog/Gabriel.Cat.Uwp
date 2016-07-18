using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Gabriel.Cat.Extension
{
  public static  class ClaseDeExtension
    {
        #region UIElementCollection
        public static void AddRange(this UIElementCollection collection,IEnumerable<UIElement> elements)
        {
            if (elements == null)
                throw new ArgumentNullException();
            foreach (UIElement element in elements)
                collection.Add(element);
        }
        public static void RemoveRange(this UIElementCollection collection, IEnumerable<UIElement> elements)
        {
            if (elements == null)
                throw new ArgumentNullException();
            foreach (UIElement element in elements)
                collection.Remove(element);
        }
        #endregion
        #region Dispatcher
        public static void BeginInvoke(this CoreDispatcher dispatcher,Action act,CoreDispatcherPriority priority=CoreDispatcherPriority.Normal)
        {
            dispatcher.RunAsync(priority, () => {
                act.Invoke();
            }).AsTask();

        }
        #endregion
     /*   #region MesageDialog
        public static uint Show(this MessageDialog message)
        {
         Windows.Foundation.IAsyncOperation<IUICommand> command = message.ShowAsync();
            command.Wait();
            return command.Id;
      
        }


        #endregion*/
        #region Windows.Foundation.IAsyncOperation
        public static void Wait<T>(this Windows.Foundation.IAsyncOperation<T> asyncOp)
        {
            bool acabado = false;
            asyncOp.Completed = new AsyncOperationCompletedHandler<T>((s, a) => { acabado = true; });
            while (!acabado)
                Task.Delay(100);
        }
        #endregion
    }
}
