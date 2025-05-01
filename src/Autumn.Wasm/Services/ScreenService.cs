using BlazorPro.BlazorSize;
using Autumn.Wasm.Interfaces;

namespace Autumn.Wasm.Services
{
    public class ScreenService : IScreenService
    {
        private readonly IResizeListener _resizeListener;
        private Action? _componentAction;

        public bool IsSmallUpMedia { get; private set; }

        public bool IsMediumUpMedia { get; private set; }

        public bool IsLargeUpMedia { get; private set; }

        public bool IsXLargeUpMedia { get; private set; }

        public bool IsXSmallDown { get; private set; }

        public bool IsSmallDown { get; private set; }

        public bool IsMediumDown { get; private set; }

        public bool IsLargeDown { get; private set; }

        public bool IsSmallOnly { get; private set; }

        public bool IsMediumOnly { get; private set; }

        public bool IsOnlyLarge { get; private set; }

        public ScreenService(IResizeListener resizeListener)
        {
            _resizeListener = resizeListener;
        }

        public void Subscribe(Action? action)
        {
            _componentAction = action;
            _resizeListener.OnResized += OnWindowResized;
        }

        public void Unsubscribe()
        {
            _componentAction = null;
            _resizeListener.OnResized -= OnWindowResized;
        }

        private async void OnWindowResized(object? _, BrowserWindowSize window)
        {
            /// @media(min-width: 576px) { ... }
            /// Small devices (landscape phones, 576px and up)
            IsSmallUpMedia = await _resizeListener.MatchMedia(Breakpoints.SmallUp);

            /// @media(min-width: 768px) { ... }
            /// Medium devices (tablets, 768px and up)
            IsMediumUpMedia = await _resizeListener.MatchMedia(Breakpoints.MediumUp);

            // Large devices (desktops, 992px and up)
            /// @media(min-width: 992px) { ... }
            IsLargeUpMedia = await _resizeListener.MatchMedia(Breakpoints.LargeUp);

            /// Extra large devices (large desktops, 1200px and up)
            /// @media(min-width: 1200px) { ... }
            IsXLargeUpMedia = await _resizeListener.MatchMedia(Breakpoints.XLargeUp);

            /// Extra small devices (portrait phones, less than 576px)
            /// @media(max-width: 575.98px) { ... }
            IsXSmallDown = await _resizeListener.MatchMedia(Breakpoints.XSmallDown);

            /// Small devices (landscape phones, less than 768px)
            /// @media(max-width: 767.98px) { ... }
            IsSmallDown = await _resizeListener.MatchMedia(Breakpoints.SmallDown);

            /// Medium devices (tablets, less than 992px)
            /// @media(max-width: 991.98px) { ... }
            IsMediumDown = await _resizeListener.MatchMedia(Breakpoints.MediumDown);

            /// Large devices (desktops, less than 1200px)
            /// @media(max-width: 1199.98px) { ... }
            IsLargeDown = await _resizeListener.MatchMedia(Breakpoints.LargeDown);

            /// Small devices (landscape phones, 576px and up)
            /// @media(min-width: 576px) and(max-width: 767.98px) { ... }
            IsSmallOnly = await _resizeListener.MatchMedia(Breakpoints.OnlySmall);

            /// Medium devices (tablets, 768px and up)
            /// @media(min-width: 768px) and(max-width: 991.98px) { ... }
            IsMediumOnly = await _resizeListener.MatchMedia(Breakpoints.OnlyMedium);

            /// Large devices (desktops, 992px and up)
            /// @media(min-width: 992px) and(max-width: 1199.98px) { ... }
            IsOnlyLarge = await _resizeListener.MatchMedia(Breakpoints.OnlyLarge);

            _componentAction?.Invoke();
        }
    }
}
