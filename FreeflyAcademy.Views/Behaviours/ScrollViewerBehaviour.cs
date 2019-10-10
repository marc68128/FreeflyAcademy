using FreeflyAcademy.ViewModels.Annotations;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FreeflyAcademy.Views.Behaviours
{
    public static class ScrollViewerBehaviour
    {
        public static readonly DependencyProperty ShiftWheelScrollsHorizontallyProperty
            = DependencyProperty.RegisterAttached("ShiftWheelScrollsHorizontally",
                typeof(bool),
                typeof(ScrollViewerBehaviour),
                new PropertyMetadata(false, UseHorizontalScrollingChangedCallback));

        public static readonly DependencyProperty ScrollRightButtonProperty
            = DependencyProperty.RegisterAttached("ScrollRightButton",
                typeof(Button),
                typeof(ScrollViewerBehaviour),
                new PropertyMetadata(null, ScrollRightButtonChangedCallback));

        public static readonly DependencyProperty ScrollLeftButtonProperty
            = DependencyProperty.RegisterAttached("ScrollLeftButton",
                typeof(Button),
                typeof(ScrollViewerBehaviour),
                new PropertyMetadata(null, ScrollLeftButtonChangedCallback));

        private static void ScrollRightButtonChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (Button)e.NewValue;
            var listView = d as ListView;

            if (button != null)
            {
                button.Click += (sender, args) =>
                {
                    var scrollViewer = (ScrollViewer)GetScrollViewer(listView);
                    var offset = Math.Max(0d, Math.Min(scrollViewer.HorizontalOffset + 16, scrollViewer.ScrollableWidth));
                    scrollViewer.ScrollToHorizontalOffset(offset);
                };
            }
        }
        private static void ScrollLeftButtonChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (Button)e.NewValue;
            var listView = d as ListView;

            if (button != null)
            {
                button.Click += (sender, args) =>
                {
                    var scrollViewer = (ScrollViewer)GetScrollViewer(listView);
                    var offset = Math.Max(0d, Math.Min(scrollViewer.HorizontalOffset - 16, scrollViewer.ScrollableWidth));
                    scrollViewer.ScrollToHorizontalOffset(offset);
                };
            }
        }

        private static void UseHorizontalScrollingChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;

            if (element == null)
                throw new Exception("Attached property must be used with UIElement.");

            if ((bool)e.NewValue)
                element.PreviewMouseWheel += OnPreviewMouseWheel;
            else
                element.PreviewMouseWheel -= OnPreviewMouseWheel;
        }
        private static void OnPreviewMouseWheel(object sender, MouseWheelEventArgs args)
        {
            var scrollViewer = ((UIElement)sender).FindDescendant<ScrollViewer>();

            if (scrollViewer == null)
                return;

            if (args.Delta < 0)
                scrollViewer.LineRight();
            else
                scrollViewer.LineLeft();

            args.Handled = true;
        }

        public static void SetShiftWheelScrollsHorizontally(UIElement element, bool value) => element.SetValue(ShiftWheelScrollsHorizontallyProperty, value);
        public static bool GetShiftWheelScrollsHorizontally(UIElement element) => (bool)element.GetValue(ShiftWheelScrollsHorizontallyProperty);

        public static void SetScrollRightButton(UIElement element, Button value) => element.SetValue(ScrollRightButtonProperty, value);
        public static Button GetScrollRightButton(UIElement element) => (Button)element.GetValue(ScrollRightButtonProperty);

        public static void SetScrollLeftButton(UIElement element, Button value) => element.SetValue(ScrollLeftButtonProperty, value);
        public static Button GetScrollLeftButton(UIElement element) => (Button)element.GetValue(ScrollLeftButtonProperty);


        [CanBeNull]
        private static T FindDescendant<T>([CanBeNull] this DependencyObject d) where T : DependencyObject
        {
            if (d == null)
                return null;

            var childCount = VisualTreeHelper.GetChildrenCount(d);

            for (var i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(d, i);

                var result = child as T ?? FindDescendant<T>(child);

                if (result != null)
                    return result;
            }

            return null;
        }
        private static DependencyObject GetScrollViewer(DependencyObject o)
        {
            // Return the DependencyObject if it is a ScrollViewer
            if (o is ScrollViewer)
                return o;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
            {
                var child = VisualTreeHelper.GetChild(o, i);

                var result = GetScrollViewer(child);
                if (result == null)
                {
                    continue;
                }
                else
                {
                    return result;
                }
            }
            return null;
        }
    }
}
