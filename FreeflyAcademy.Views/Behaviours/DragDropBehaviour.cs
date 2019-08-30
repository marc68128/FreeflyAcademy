using FreeflyAcademy.ViewModels.Contracts.Base;
using System;
using System.Windows;

namespace FreeflyAcademy.Views.Behaviours
{
    public class DragDropBehaviour
    {
        public static bool GetIsFileDragDropEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFileDragDropEnabledProperty);
        }

        public static void SetIsFileDragDropEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFileDragDropEnabledProperty, value);
        }

        public static bool GetFileDragDropTarget(DependencyObject obj)
        {
            return (bool)obj.GetValue(FileDragDropTargetProperty);
        }

        public static void SetFileDragDropTarget(DependencyObject obj, bool value)
        {
            obj.SetValue(FileDragDropTargetProperty, value);
        }

        public static readonly DependencyProperty IsFileDragDropEnabledProperty =
                DependencyProperty.RegisterAttached("IsFileDragDropEnabled", typeof(bool), typeof(DragDropBehaviour), new PropertyMetadata(OnFileDragDropEnabled));

        public static readonly DependencyProperty FileDragDropTargetProperty =
                DependencyProperty.RegisterAttached("FileDragDropTarget", typeof(object), typeof(DragDropBehaviour), null);

        private static void OnFileDragDropEnabled(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == e.OldValue) return;
            if (d is FrameworkElement control) control.Drop += OnDrop;
        }

        private static void OnDrop(object _sender, DragEventArgs _dragEventArgs)
        {
            DependencyObject d = _sender as DependencyObject;
            if (d == null) return;
            Object target = d.GetValue(FileDragDropTargetProperty);
            if (target is IDragDropTarget fileTarget)
            {
                if (_dragEventArgs.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    fileTarget.OnFileDrop((string[])_dragEventArgs.Data.GetData(DataFormats.FileDrop));
                }
            }
            else
            {
                throw new Exception("FileDragDropTarget object must be of type IFileDragDropTarget");
            }
        }
    }
}
