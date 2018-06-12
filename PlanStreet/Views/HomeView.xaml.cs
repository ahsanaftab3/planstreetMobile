using System;
using System.Collections.Generic;
using PlanStreet.Constants;
using PlanStreet.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace PlanStreet.Views
{
	public partial class HomeView : ContentView
	{
		HomeViewModel _homeViewModel;
		public HomeView()
		{
			_homeViewModel = App.Locator.HomeViewModel;
			InitializeComponent();
			BindingContext = _homeViewModel;
			SKCanvasView sKCanvasView = new SKCanvasView();
			sKCanvasView.BackgroundColor = Color.Transparent;
			sKCanvasView.PaintSurface += SKCanvasView_PaintSurface;
			TaskCountGrid.Children.Add(sKCanvasView, 0, 0);


			SKCanvasView dueByTodayCanvasView = new SKCanvasView();
			dueByTodayCanvasView.BackgroundColor = Color.Transparent;
			dueByTodayCanvasView.PaintSurface += DueByTodayCanvasView_PaintSurface;
			DueGrid.Children.Add(dueByTodayCanvasView, 0, 1);

			SKCanvasView dueByThisWeekCanvasView = new SKCanvasView();
			dueByThisWeekCanvasView.BackgroundColor = Color.Transparent;
			dueByThisWeekCanvasView.PaintSurface += DueByThisWeekCanvasView_PaintSurface;
			DueGrid.Children.Add(dueByThisWeekCanvasView, 1, 1);

			SKCanvasView overDueCanvasView = new SKCanvasView();
			overDueCanvasView.BackgroundColor = Color.Transparent;
			overDueCanvasView.PaintSurface += OverDueCanvasView_PaintSurface;
			DueGrid.Children.Add(overDueCanvasView, 2, 1);
		}

		private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
		{
			SKImageInfo info = e.Info;
			SKSurface surface = e.Surface;
			SKCanvas canvas = surface.Canvas;
			canvas.Clear();

			canvas.DrawRoundRect(0, 0, info.Width, info.Height - 5, 15, 15, new SKPaint()
			{
				Style = SKPaintStyle.Stroke,
				StrokeWidth = 3,
				StrokeCap = SKStrokeCap.Round,
				StrokeJoin = SKStrokeJoin.Round,
				Color = AppThemeConstants.LightPurpleColor.ToSKColor(),
				PathEffect = SKPathEffect.CreateDash(new float[] { 4, 4 }, 3f),
			});
		}

		private void DueByTodayCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			SKImageInfo info = e.Info;
			SKSurface surface = e.Surface;
			SKCanvas canvas = surface.Canvas;
			canvas.Clear();

			canvas.DrawRoundRect(0, 0, info.Width, info.Height, 20, 20, new SKPaint()
			{
				Style = SKPaintStyle.Stroke,
				StrokeWidth = 4,
				StrokeCap = SKStrokeCap.Round,
				StrokeJoin = SKStrokeJoin.Round,
				Color = AppThemeConstants.LightPurpleColor.ToSKColor(),
				PathEffect = SKPathEffect.CreateDash(new float[] { 8, 8 }, 5f),
			});
		}

		private void DueByThisWeekCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            canvas.DrawRoundRect(0, 0, info.Width, info.Height, 20, 20, new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 4,
                StrokeCap = SKStrokeCap.Round,
                StrokeJoin = SKStrokeJoin.Round,
                Color = AppThemeConstants.LightPurpleColor.ToSKColor(),
                PathEffect = SKPathEffect.CreateDash(new float[] { 8, 8 }, 5f),
            });
		}

		private void OverDueCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            canvas.DrawRoundRect(0, 0, info.Width, info.Height, 20, 20, new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 4,
                StrokeCap = SKStrokeCap.Round,
                StrokeJoin = SKStrokeJoin.Round,
                Color = AppThemeConstants.LightPurpleColor.ToSKColor(),
                PathEffect = SKPathEffect.CreateDash(new float[] { 8, 8 }, 5f),
            });
		}
	}
}
