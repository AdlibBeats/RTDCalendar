using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RTDCalendar.UI.Controls
{
    public sealed class RTDCalendarContainer : Control
    {
        #region Public Events

        public event RoutedEventHandler SelectionChanged;

        #endregion

        #region Private Fields 

        private int _currentColumn = 0;
        private int _currentRow = 0;

        #endregion

        #region Public Cotr
        public RTDCalendarContainer()
        {
            DefaultStyleKey = typeof(RTDCalendarContainer);
        }
        #endregion

        #region Protected OnApplyTemplate
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ItemsPanelRoot = GetTemplateChild("ItemsPanelRoot") as Grid;

            UpdateColumnsCount();
            UpdateRowsCount();
            UpdateItems();
            //UpdateItemWidth();
            //UpdateItemHeigh();
        }
        #endregion

        #region Private Updating Methods
        private void UpdateColumnsCount()
        {
            if (ItemsPanelRoot == null) return;

            ItemsPanelRoot.ColumnDefinitions.Clear();

            for (int column = 0; column < ColumnsCount; column++)
                ItemsPanelRoot.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
        }

        private void UpdateRowsCount()
        {
            if (ItemsPanelRoot == null) return;

            ItemsPanelRoot.RowDefinitions.Clear();

            for (int row = 0; row < RowsCount; row++)
                ItemsPanelRoot.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(1, GridUnitType.Star)
                });
        }

        private void UpdateItems()
        {
            if (Items == null || !Items.Any()) return;
            if (ItemsPanelRoot?.Children != null)
                Clear();

            foreach (var item in Items)
                Add(item);
        }

        //private void UpdateItemWidth()
        //{
        //    if (ItemsPanelRoot?.Children == null) return;

        //    foreach (FrameworkElement child in ItemsPanelRoot.Children)
        //        child.Width = ItemWidth;
        //}

        //private void UpdateItemHeigh()
        //{
        //    if (this.ItemsPanelRoot?.Children == null) return;

        //    foreach (FrameworkElement child in this.ItemsPanelRoot.Children)
        //        child.Height = this.ItemHeight;
        //}
        #endregion

        #region Public Dependency Properties
        public IEnumerable<FrameworkElement> Items
        {
            get => (IEnumerable<FrameworkElement>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(IEnumerable<FrameworkElement>), typeof(RTDCalendarContainer),
                new PropertyMetadata(default(IEnumerable<FrameworkElement>), (d, e) => ((RTDCalendarContainer)d).UpdateItems()));

        public Grid ItemsPanelRoot
        {
            get => (Grid)GetValue(ItemsPanelRootProperty);
            private set => SetValue(ItemsPanelRootProperty, value);
        }

        public static readonly DependencyProperty ItemsPanelRootProperty =
            DependencyProperty.Register(nameof(ItemsPanelRoot), typeof(Grid), typeof(RTDCalendarContainer),
                new PropertyMetadata(default(Grid)));

        public int RowsCount
        {
            get => (int)GetValue(RowsCountProperty);
            set => SetValue(RowsCountProperty, value);
        }

        public static readonly DependencyProperty RowsCountProperty =
            DependencyProperty.RegisterAttached(nameof(RowsCount), typeof(int), typeof(RTDCalendarContainer),
                new PropertyMetadata(0, (d, e) => ((RTDCalendarContainer)d).UpdateRowsCount()));

        public int ColumnsCount
        {
            get => (int)GetValue(ColumnsCountProperty);
            set => SetValue(ColumnsCountProperty, value);
        }

        public static readonly DependencyProperty ColumnsCountProperty =
            DependencyProperty.RegisterAttached(nameof(ColumnsCount), typeof(int), typeof(RTDCalendarContainer),
                new PropertyMetadata(0, (d, e) => ((RTDCalendarContainer)d).UpdateColumnsCount()));

        //public double ItemWidth
        //{
        //    get { return (double)GetValue(ItemWidthProperty); }
        //    set { SetValue(ItemWidthProperty, value); }
        //}

        //public static readonly DependencyProperty ItemWidthProperty =
        //    DependencyProperty.RegisterAttached("ItemWidth", typeof(double), typeof(RTDCalendarContainer), new PropertyMetadata(36d, OnItemWidthChanged));

        //private static void OnItemWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var adaptiveGridView = d as RTDCalendarContainer;
        //    if (adaptiveGridView == null) return;

        //    adaptiveGridView.UpdateItemWidth();
        //}

        //public double ItemHeight
        //{
        //    get { return (double)GetValue(ItemHeightProperty); }
        //    set { SetValue(ItemHeightProperty, value); }
        //}

        //public static readonly DependencyProperty ItemHeightProperty =
        //    DependencyProperty.RegisterAttached("ItemHeight", typeof(double), typeof(RTDCalendarContainer), new PropertyMetadata(36d, OnItemHeightChanged));

        //private static void OnItemHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var adaptiveGridView = d as RTDCalendarContainer;
        //    if (adaptiveGridView == null) return;

        //    adaptiveGridView.UpdateItemHeigh();
        //}
        #endregion

        #region Public IList Methods & Properties

        public void Add(FrameworkElement item)
        {
            if (_currentRow == RowsCount)  return;

            if (item == null) return;
            if (ItemsPanelRoot?.Children == null) return;

            //item.Width = 50;
            //item.Height = 50;
            item.HorizontalAlignment = HorizontalAlignment.Stretch;
            item.VerticalAlignment = VerticalAlignment.Stretch;

            //var proCalendarToggleButton = item as RTDToggleButton;
            //if (proCalendarToggleButton != null)
            //{
            //    proCalendarToggleButton.Selected -= OnSelected;
            //    proCalendarToggleButton.Selected += OnSelected;

            //    proCalendarToggleButton.Unselected -= OnSelected;
            //    proCalendarToggleButton.Unselected += OnSelected;

            //    void OnSelected(object sender, RoutedEventArgs e) =>
            //        SelectionChanged?.Invoke(sender, null);
            //}

            Grid.SetColumn(item, _currentColumn);
            Grid.SetRow(item, _currentRow);

            _currentColumn++;
            if (_currentColumn == ColumnsCount)
            {
                _currentColumn = 0;
                _currentRow++;
            }

            ItemsPanelRoot.Children.Add(item);
        }

        public int Count => ItemsPanelRoot?.Children == null ?
            0 : ItemsPanelRoot.Children.Count;

        public void Clear()
        {
            if (ItemsPanelRoot?.Children == null) return;
            ItemsPanelRoot.Children.Clear();
        }
        #endregion
    }
}
