using NAIMS2.Operator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Label = System.Windows.Controls.Label;
using NAIMS2.Operator.ViewModels;
using MessageBox = System.Windows.Forms.MessageBox;
using NAIMS2.Common.Utils;

namespace NAIMS2.Common.Views
{
    /// <summary>
    /// CollectDataPopup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CollectDataPopup : Window
    {
        public class GroupNode
        {
            public string GroupName { get; set; }
            public List<ItemNode> Items { get; set; } = new List<ItemNode>();
        }

        // 하위 노드 (항목)를 나타내는 클래스
        public class ItemNode
        {
            public string ItemName { get; set; }
        }

        public CollectDataPopup()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //cb_signal.DataContext = new cbsignalDummyViewModel(); //수집체계
            //cb_collect.DataContext = new cbcollectDummyViewModel(); //신호종류
            //LabelAlignmentProcessor.ApplyLabelAlignment(this);
            Datainit();
        }

        private void Datainit()
        {
            try
            {

                string[][] List = new string[][]
                {
                    new string[]{"250101","250101(1)-1"},
                    new string[]{"250101","250101(1)-2"},
                    new string[]{"250101","250101(1)-3"},
                    new string[]{"250102","250102(1)-1"},
                    new string[]{"250103","250103(1)-1"},
                };

                /*
                tr_up.Items.Clear();
                var groupedData = List
                .GroupBy(row => row[0]) // 첫 번째 열로 그룹화
                .Select(group => new GroupNode
                {
                    GroupName = group.Key, // 그룹 이름 (예: "250101")
                    Items = group.Select(row => new ItemNode { ItemName = row[1] }).ToList() // 하위 항목
                })
                .ToList();

                // TreeView에 데이터 바인딩
                tr_up.ItemsSource = groupedData;
                /*
                List<PersonNode> personNodes = new List<PersonNode>();
                string[] propertyNames = { "이름", "성", "나이" }; // 속성 이름
                for (int i=0; i<List.Length; i++)
                {
                    var person = new PersonNode { Name = $"사람 {i + 1}" }; // 예: "사람 1", "사람 2"
                    for (int j = 0; j < List[i].Length; j++)
                    {
                        person.Properties.Add(new PropertyNode { Value = $"{propertyNames[j]}: {List[i][j]}" });
                    }
                    personNodes.Add(person);
                }

                tr_up.ItemsSource = personNodes;
                */
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void btn_down_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_up_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
