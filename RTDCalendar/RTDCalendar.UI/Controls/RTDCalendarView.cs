using RTDCalendar.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace RTDCalendar.UI.Controls
{
    public class RTDCalendarView : Control
    {
        public RTDCalendarView()
        {
            DefaultStyleKey = typeof(RTDCalendarView);

            RCompositor = new RCompositor();
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            RCompositor = new RCompositor();

            var XD = GetTemplateChild("XD") as FlipView;
            if (XD != null)
            {
                var listDates = RCompositor.CurrentRDate.Months;
                XD.Items.Clear();
                foreach (var item in listDates)
                {
                    var adaptiveGridView = new RTDCalendarContainer
                    {
                        RowsCount = 6,
                        ColumnsCount = 7,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Items = item.Days.Select(x => new RTDToggleButton
                        {
                            Content = x.Day,
                            IsCornerRadiusVisible = true
                        }),
                        //Background = new SolidColorBrush(Colors.Red)
                    };
                   
                   XD.Items.Add(adaptiveGridView);
                }
            }

            //var lol = GetTemplateChild("lol") as RTDCalendarContainer;
            //if (lol != null)
            //    lol.Items = RCompositor.CurrentRDate.Days;
        }

        public RCompositor RCompositor
        {
            get => (RCompositor)GetValue(RCompositorProperty);
            set => SetValue(RCompositorProperty, value);
        }

        public static readonly DependencyProperty RCompositorProperty =
            DependencyProperty.Register(nameof(RCompositor), typeof(RCompositor), typeof(RTDCalendarView),
                new PropertyMetadata(default(RCompositor)));
    }
}
