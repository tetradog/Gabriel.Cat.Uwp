using Gabriel.Cat.Extension;
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
        public static async Task<MessageResult> Show(string message, string title = "", MessageButtons buttons = MessageButtons.Ok)
        {
            MessageDialog msgDialog = new MessageDialog(message, title);
            MessageResult reusult;
            msgDialog.Commands.Clear();
            switch (buttons)
            {
                case MessageButtons.Ok: msgDialog.Commands.Add(new UICommand { Label = "Ok", Id = (int)MessageResult.Ok }); break;
                case MessageButtons.YesNo:
                case MessageButtons.YesNoCancel:
                    msgDialog.Commands.Add(new UICommand { Label = "Yes", Id = (int)MessageResult.Yes });
                    msgDialog.Commands.Add(new UICommand { Label = "No", Id = (int)MessageResult.No });
                    if (buttons == MessageButtons.YesNoCancel)
                        msgDialog.Commands.Add(new UICommand { Label = "Cancel", Id = (int)MessageResult.Cancel });
                    break;

            }
            reusult = (MessageResult)Convert.ToInt32((await msgDialog.ShowAsync()).Id);
            return reusult;
        }
    }
}
