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
using System.Collections.ObjectModel;
using System.Collections;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for Testing.xaml
    /// </summary>
    public partial class Testing : Window
    {
        public ObservableCollection<BoolStringClass> TheList { get; set; }
        ObservableCollection<string> zoneList = new ObservableCollection<string>();
        ListBox dragSource = null;

        public Testing()
        {
            InitializeComponent();
            //TheList = new ObservableCollection<BoolStringClass>();
            //TheList.Add(new BoolStringClass { IsSelected = true, TheText = "Some text for item #1" });
            //TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #2" });
            //TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #3" });
            //TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #4" });
            //TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #5" });
            //TheList.Add(new BoolStringClass { IsSelected = true, TheText = "Some text for item #6" });
            //TheList.Add(new BoolStringClass { IsSelected = false, TheText = "Some text for item #7" });

            //this.DataContext = this;
            foreach (TimeZoneInfo tzi in TimeZoneInfo.GetSystemTimeZones())
            {
                zoneList.Add(tzi.ToString());
            }
            lbOne.ItemsSource = zoneList;
        }

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(string));
            ((IList)dragSource.ItemsSource).Remove(data);
            parent.Items.Add(data);
        }

        #region GetDataFromListBox(ListBox,Point)
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (element == source)
                    {
                        return null;
                    }
                }

                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }

            return null;
        }
        #endregion
    }
    public class BoolStringClass
    {
        public string TheText { get; set; }
        public bool IsSelected { get; set; }
    }
}
