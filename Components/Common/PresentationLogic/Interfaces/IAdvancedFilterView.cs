using System;
using System.IO;
using Samples.Finder.Components.Common.CommonLibrary.Enums;

namespace Samples.Finder.Components.Common.PresentationLogic.Interfaces
{
    public interface IAdvancedFilterView : IView
    {
        bool SearchInSubdirectories { get; set; }

        bool SearchWithAttributes { get; set; }

        bool SearchByDate { get; set; }

        bool SearchBySize { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

        void SetComparisonOperation(ComparisonOperation value);
        ComparisonOperation GetComparisonOperation();

        void SetFileAttributes(FileAttributes value);
        FileAttributes GetFileAttributes();

        void SetFileSizeInBytes(long value);
        long GetFileSizeInBytes();
    }
}