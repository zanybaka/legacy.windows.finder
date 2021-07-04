using Samples.Finder.Components.Common.CommonLibrary.Enums;

namespace Samples.Finder.Application.Extensions
{
    internal static class InternalTypeExtensions
    {
        public static long GetByteCount(this FileUnit source)
        {
            switch (source)
            {
                case FileUnit.Byte:
                    return 1;
                case FileUnit.Kilobyte:
                    return 1024;
                case FileUnit.Megabyte:
                    return 1024*1024;// 1048576;
                case FileUnit.Gigabyte:
                    return 1024*1024*1024;// 1073741824;
                default:
                    //Debug.Assert?
                    return 0;
            }
        }
    }
}