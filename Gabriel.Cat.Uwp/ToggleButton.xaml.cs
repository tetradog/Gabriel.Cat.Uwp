using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Gabriel.Cat.Uwp
{
    public sealed partial class ToggleButton : UserControl
    {
        private int indice;
        Llista<Image> lstBmps;
        public event EventHandler<ToggleButtonArgs> ChangeIndex;
        public ToggleButton()
        {
            lstBmps = new Llista<Image>();
            lstBmps.Updated += (s, e) => { Index = Index; };
            this.InitializeComponent();
        }
        public int Index
        {
            get { return indice; }
            set
            {
                if (lstBmps.Count != 0)
                {
                    indice = value % lstBmps.Count;
                    imgButton.Source = lstBmps[indice].Source;
                }
                else
                {
                    imgButton.Source = new Image().Source;
                    indice = 0;
                }
            }
        }
        public Llista<Image> Images
        {
            get { return lstBmps; }
        }
        private void imgButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Index++;
            if (ChangeIndex != null)
                ChangeIndex(this, new ToggleButtonArgs(Index));
        }
    }
    public class ToggleButtonArgs : EventArgs
    {
        public int Index { get; private set; }
        public ToggleButtonArgs(int index)
        {
            Index = index;
        }
    }
}
