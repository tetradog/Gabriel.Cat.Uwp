using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
namespace Gabriel.Cat
{
   public static class MessageBox
    {
       public enum MessageButtons
        {
            Ok,YesNo,YesNoCancel
        }

       public enum MessageResult
        {
            Yes,No,Cancel,Ok,None
        }
        public static MessageResult Show(string message, string title = "", MessageButtons buttons = MessageButtons.Ok)
        {
            MessageDialog msgDialog = new MessageDialog(message, title);
            msgDialog.Commands.Clear();
            switch (buttons)
            {
                case MessageButtons.Ok: msgDialog.Commands.Add(new UICommand { Label = "Ok", Id = MessageResult.Ok }); break;
                case MessageButtons.YesNo:
                case MessageButtons.YesNoCancel:
                    msgDialog.Commands.Add(new UICommand { Label = "Yes", Id = MessageResult.Yes });
                    msgDialog.Commands.Add(new UICommand { Label = "No", Id = MessageResult.No });
                    if (buttons == MessageButtons.YesNoCancel)
                        msgDialog.Commands.Add(new UICommand { Label = "Cancel", Id = MessageResult.Cancel });
                    break;

            }
            return (MessageResult)Convert.ToInt32(msgDialog.ShowAsync().Id);
        }
    }
}
