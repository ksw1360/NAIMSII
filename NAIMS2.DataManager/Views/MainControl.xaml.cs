using System.Collections;
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

namespace NAIMS2.DataManager.Views
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : NAIMS2.Common.UI.UserControl
    {
        public string LayoutKey {
            get
            {
                return this.dockManager.LayoutKey;
            }
            set
            {
                this.dockManager.LayoutKey = value;
            }
        }
        public string LayoutFileName
        {
            get
            {
                return this.dockManager.LayoutFileName;
            }
            set
            {
                this.dockManager.LayoutFileName = value;
            }
        }

        public MainControl()
        {
            InitializeComponent();
        }

        public override void Init(Hashtable info)
        {
            base.Init(info);
        }
    }

}
