namespace Autumn.Wasm.Interfaces
{
    public interface IScreenService
    {
        /// @media(min-width: 576px) { ... }
        /// Small devices (landscape phones, 576px and up)
        bool IsSmallUpMedia { get; }

        /// @media(min-width: 768px) { ... }
        /// Medium devices (tablets, 768px and up)
        bool IsMediumUpMedia { get; }

        // Large devices (desktops, 992px and up)
        /// @media(min-width: 992px) { ... }
        bool IsLargeUpMedia { get; }

        /// Extra large devices (large desktops, 1200px and up)
        /// @media(min-width: 1200px) { ... }
        bool IsXLargeUpMedia { get; }

        /// Extra small devices (portrait phones, less than 576px)
        /// @media(max-width: 575.98px) { ... }
        bool IsXSmallDown { get; }

        /// Small devices (landscape phones, less than 768px)
        /// @media(max-width: 767.98px) { ... }
        bool IsSmallDown { get; }

        /// Medium devices (tablets, less than 992px)
        /// @media(max-width: 991.98px) { ... }
        bool IsMediumDown { get; }

        /// Large devices (desktops, less than 1200px)
        /// @media(max-width: 1199.98px) { ... }
        bool IsLargeDown { get; }

        /// Small devices (landscape phones, 576px and up)
        /// @media(min-width: 576px) and(max-width: 767.98px) { ... }
        bool IsSmallOnly { get; }

        /// Medium devices (tablets, 768px and up)
        /// @media(min-width: 768px) and(max-width: 991.98px) { ... }
        bool IsMediumOnly { get; }

        /// Large devices (desktops, 992px and up)
        /// @media(min-width: 992px) and(max-width: 1199.98px) { ... }
        bool IsOnlyLarge { get; }

        void Subscribe(Action? action);

        void Unsubscribe();
    }
}
