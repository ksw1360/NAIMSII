using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;

namespace NAIMS2.Common.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NAIMS2.Common.UI.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public override void Init(Hashtable info)
        {
            base.Init(info);
        }

        private void Notice_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Notice click");
        }

        private void Message_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Message click");
        }
    }
}
