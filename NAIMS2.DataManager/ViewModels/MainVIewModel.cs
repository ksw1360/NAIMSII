using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.DataManager.ViewModels
{
    public class MainVIewModel : INotifyPropertyChanged
    {
        private Common.DB.DBManager DataManager = new Common.DB.DBManager();

        private Models.MainModel? _Model = new Models.MainModel();
        public Models.MainModel Model
        {
            get{ return this._Model; }
            set{
                this._Model = value;
                OnPropertyChanged("Model");
            }
        }

        /*
        public DataView DataTestGrid { 
            get { return this.Model.dvTestGrid; }
            set { this.Model.dvTestGrid = value;
                OnPropertyChanged("DV");
            }
        }
        */

        public MainVIewModel()
        {
            DataSet ds = this.DataManager.Select("select * from TB_TEST"); // Common.DB.DBManager.Test();
            //this.DataTestGrid = ds.Tables[0].DefaultView;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
