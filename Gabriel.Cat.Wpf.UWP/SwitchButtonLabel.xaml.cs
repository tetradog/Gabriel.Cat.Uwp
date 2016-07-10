using Gabriel.Cat.Extension;
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
    public sealed partial class SwitchButtonLabel : UserControl
    {
        Llista<Brush> brushes;
        int index;
        public event EventHandler<SwitchButtonLabelArgs> IndexChanged;
        public SwitchButtonLabel()
        {
            index = 0;
            brushes = new Llista<Brush>();
            brushes.Updated +=(s,e)=>{ Index= Index; };
            this.InitializeComponent();
        }
        public SwitchButtonLabel(params Brush[] brushes):this()
        {
            if(brushes!=null)
               this.brushes.AfegirMolts(brushes);
        }
        public int Index
        {
            get { return index; }
            set {
                if (brushes.Count > 0)
                {
                    index = Math.Abs(value) % brushes.Count;
                    Background = brushes[index];
                }
                else { index = 0; Background = Windows.UI.Colors.White.ToBrush(); }

            }
        }
        public Llista<Brush> Brushes
        {
            get { return brushes; }
        }
        public string Text
        {
            get { return txLabel.Text; }
            set { txLabel.Text = value; }
        }
        public TextBlock Label {
            get { return txLabel; }
        }
        private void txLabel_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Index++;
            if (IndexChanged != null)
                IndexChanged(this, new SwitchButtonLabelArgs(index));
        }

    }
    public class SwitchButtonLabelArgs : EventArgs
    {
        public int Index { get; private set; }
        public SwitchButtonLabelArgs(int index)
        {
            Index = index;
        }
    }
}
