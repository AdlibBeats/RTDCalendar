using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

// ReSharper disable once CheckNamespace
namespace RTDCalendar.UI.Controls
{
	public class RTDToggleButton : ToggleButton
	{
		private Border _contentBorder;

		public RTDToggleButton()
		{
			DefaultStyleKey = typeof(RTDToggleButton);

			SizeChanged += OnSizeChanged;
		}
		private void OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			UpdateCornerRadius();
		}

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			_contentBorder = GetTemplateChild("ContentBorder") as Border;

			UpdateCornerRadius();
		}

		private void UpdateCornerRadius()
		{
			if (_contentBorder == null)
				return;
			if (IsCornerRadiusVisible)
				_contentBorder.CornerRadius =
					CornerRadius.Equals(default(CornerRadius)) ? new CornerRadius(ActualHeight / 2) : CornerRadius;
			else
				_contentBorder.CornerRadius = default(CornerRadius);
		}

		public DataTemplate OnCheckedTemplate
		{
			get => (DataTemplate)GetValue(OnCheckedTemplateProperty);
			set => SetValue(OnCheckedTemplateProperty, value);
		}

		public static readonly DependencyProperty OnCheckedTemplateProperty =
			DependencyProperty.Register(nameof(OnCheckedTemplate), typeof(DataTemplate), typeof(RTDToggleButton),
				new PropertyMetadata(default(DataTemplate)));

		public object OnCheckedContent
		{
			get => GetValue(OnCheckedContentProperty);
			set => SetValue(OnCheckedContentProperty, value);
		}

		public static readonly DependencyProperty OnCheckedContentProperty =
			DependencyProperty.Register(nameof(OnCheckedContent), typeof(object), typeof(RTDToggleButton),
				new PropertyMetadata(default(object)));

		public Brush OnCheckedBackground
		{
			get => (Brush)GetValue(OnCheckedBackgroundProperty);
			set => SetValue(OnCheckedBackgroundProperty, value);
		}

		public static readonly DependencyProperty OnCheckedBackgroundProperty =
			DependencyProperty.Register(nameof(OnCheckedBackground), typeof(Brush), typeof(RTDToggleButton),
				new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 237, 28, 36))));

		public Brush OnCheckedForeground
		{
			get => (Brush)GetValue(OnCheckedForegroundProperty);
			set => SetValue(OnCheckedForegroundProperty, value);
		}

		public static readonly DependencyProperty OnCheckedForegroundProperty =
			DependencyProperty.Register(nameof(OnCheckedForeground), typeof(Brush), typeof(RTDToggleButton),
				new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));

		public Brush OnCheckedBorderBrush
		{
			get => (Brush)GetValue(OnCheckedBorderBrushProperty);
			set => SetValue(OnCheckedBorderBrushProperty, value);
		}

		public static readonly DependencyProperty OnCheckedBorderBrushProperty =
			DependencyProperty.Register(nameof(OnCheckedBorderBrush), typeof(Brush), typeof(RTDToggleButton),
				new PropertyMetadata(default(Brush)));

		public Thickness OnCheckedBorderThickness
		{
			get => (Thickness)GetValue(OnCheckedBorderThicknessProperty);
			set => SetValue(OnCheckedBorderThicknessProperty, value);
		}

		public static readonly DependencyProperty OnCheckedBorderThicknessProperty =
			DependencyProperty.Register(nameof(OnCheckedBorderThickness), typeof(Thickness), typeof(RTDToggleButton),
				new PropertyMetadata(new Thickness(0)));

		public DataTemplate OnDisabledTemplate
		{
			get => (DataTemplate)GetValue(OnDisabledTemplateProperty);
			set => SetValue(OnDisabledTemplateProperty, value);
		}

		public static readonly DependencyProperty OnDisabledTemplateProperty =
			DependencyProperty.Register(nameof(OnDisabledTemplate), typeof(DataTemplate), typeof(RTDToggleButton),
				new PropertyMetadata(default(DataTemplate)));

		public object OnDisabledContent
		{
			get => GetValue(OnDisabledContentProperty);
			set => SetValue(OnDisabledContentProperty, value);
		}

		public static readonly DependencyProperty OnDisabledContentProperty =
			DependencyProperty.Register(nameof(OnDisabledContent), typeof(object), typeof(RTDToggleButton),
				new PropertyMetadata(default(object)));

		public Brush OnDisabledBackground
		{
			get => (Brush)GetValue(OnDisabledBackgroundProperty);
			set => SetValue(OnDisabledBackgroundProperty, value);
		}

		public static readonly DependencyProperty OnDisabledBackgroundProperty =
			DependencyProperty.Register(nameof(OnDisabledBackground), typeof(Brush), typeof(RTDToggleButton),
				new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 237, 28, 36))));

		public Brush OnDisabledForeground
		{
			get => (Brush)GetValue(OnDisabledForegroundProperty);
			set => SetValue(OnDisabledForegroundProperty, value);
		}

		public static readonly DependencyProperty OnDisabledForegroundProperty =
			DependencyProperty.Register(nameof(OnDisabledForeground), typeof(Brush), typeof(RTDToggleButton),
				new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));

		public Brush OnDisabledBorderBrush
		{
			get => (Brush)GetValue(OnDisabledBorderBrushProperty);
			set => SetValue(OnDisabledBorderBrushProperty, value);
		}

		public static readonly DependencyProperty OnDisabledBorderBrushProperty =
			DependencyProperty.Register(nameof(OnDisabledBorderBrush), typeof(Brush), typeof(RTDToggleButton),
				new PropertyMetadata(default(Brush)));

		public Thickness OnDisabledBorderThickness
		{
			get => (Thickness)GetValue(OnDisabledBorderThicknessProperty);
			set => SetValue(OnDisabledBorderThicknessProperty, value);
		}

		public static readonly DependencyProperty OnDisabledBorderThicknessProperty =
			DependencyProperty.Register(nameof(OnDisabledBorderThickness), typeof(Thickness), typeof(RTDToggleButton),
				new PropertyMetadata(new Thickness(0)));

		public bool IsCornerRadiusVisible
		{
			get => (bool)GetValue(IsCornerRadiusVisibleProperty);
			set => SetValue(IsCornerRadiusVisibleProperty, value);
		}

		public static readonly DependencyProperty IsCornerRadiusVisibleProperty =
			DependencyProperty.Register(nameof(IsCornerRadiusVisible), typeof(bool), typeof(RTDToggleButton),
				new PropertyMetadata(false, (d, e) => ((RTDToggleButton)d).UpdateCornerRadius()));

		public CornerRadius CornerRadius
		{
			get => (CornerRadius)GetValue(CornerRadiusProperty);
			set => SetValue(CornerRadiusProperty, value);
		}

		public static readonly DependencyProperty CornerRadiusProperty =
			DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(RTDToggleButton),
				new PropertyMetadata(default(CornerRadius), (d, e) => ((RTDToggleButton)d).UpdateCornerRadius()));
	}
}
