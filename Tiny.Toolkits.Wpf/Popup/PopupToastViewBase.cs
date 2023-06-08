using System;
using System.Windows.Controls;

namespace Tiny.Toolkits
{    /// <summary>
     /// The base class for all toast popup views.
     /// </summary>
    public abstract class PopupToastViewBase : UserControl
    {
        internal Action CloseCallback { get; set; }

        /// <summary>
        /// set toast information
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        protected abstract void SetToastInfo(string title, string message, params object[] @objects);

        internal void SetToastContent(string title, string message, int displayTimeSpan_Ms, params object[] @objects)
        {
            SetToastInfo(title, message, @objects);
            SizeChanged += PopupToastViewBase_SizeChanged;
            Ealy();

            void Ealy()
            {
                if(displayTimeSpan_Ms < 0)
                {
                    return;
                }

                System.Timers.Timer timer = new();
                timer.Interval = displayTimeSpan_Ms;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

                void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
                {
                    timer.Elapsed -= Timer_Elapsed;
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                    this.Dispatcher.InvokeAsync(CloseToast);
                }
            }
        }


        private void PopupToastViewBase_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            ResetSize();
        }

        internal void ResetSize()
        {
            Width = 320;
            if (ActualHeight > 1)
            {
                Height = ActualHeight;
            }

            MaxHeight = 100;
        }

        /// <summary>
        /// request close this toast
        /// </summary>
        protected void CloseToast()
        {
            SizeChanged -= PopupToastViewBase_SizeChanged;

            TimeSpan ts = TimeSpan.FromMilliseconds(300);

            System.Windows.Thickness t = new(Width + Margin.Left + Margin.Right + 10, 5, 5, 0);
            IAnimationPlayer player1 = this.WithThicknessAnimation()
                .To(t)
                .Property(i => i.Margin)
                .Duration(ts)
                .BuildAnimation();

            IAnimationPlayer player2 = this.WithDoubleAnimation()
                .Property(i => i.Height)
                .To(0)
                .Duration(150)
                .BeginTime(ts.Add(TimeSpan.FromMilliseconds(100)))
                .BuildAnimation();

            new[] { player1, player2 }.PlayAnimations(() =>
            {
                Action action = CloseCallback;
                CloseCallback = null;
                action?.Invoke();
            });
        }
    }
}
