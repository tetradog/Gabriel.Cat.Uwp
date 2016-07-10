using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Gabriel.Cat.Extension
{
  public static class Brushes
    {
        public static Brush ToBrush(this Windows.UI.Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}
