namespace Samples.Finder.Application.Controls
{
    public interface IRegExValidatable
    {
        string RegularExpression { get; set; }
        bool Validate();
    }
}