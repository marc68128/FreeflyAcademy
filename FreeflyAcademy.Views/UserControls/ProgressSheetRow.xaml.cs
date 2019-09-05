using System;
using System.Windows;
using System.Windows.Controls;
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
