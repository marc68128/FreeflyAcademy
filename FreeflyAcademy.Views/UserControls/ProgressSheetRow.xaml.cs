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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FreeflyAcademy.Enums;

namespace FreeflyAcademy.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ProgressSheetRow.xaml
    /// </summary>
    public partial class ProgressSheetRow : UserControl
    {
        public static readonly DependencyProperty ProgressSheetItemProperty = DependencyProperty.Register("ProgressSheetItem", typeof(AcquisitionLevel), typeof(ProgressSheetRow));
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(ProgressSheetRow));


        public ProgressSheetRow()
        {
            InitializeComponent();
            GroupName = Guid.NewGuid().ToString();
        }

        public AcquisitionLevel ProgressSheetItem
        {
            get => (AcquisitionLevel)GetValue(ProgressSheetItemProperty);
            set => SetValue(ProgressSheetItemProperty, value);
        }
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public string GroupName { get; set; }
    }
}
