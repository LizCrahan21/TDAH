using System.Collections.Generic;
using Xamarin.Forms;

namespace TDAH.Handlers
{
    public interface IBorderlessEntry
    {
        IDispatcher Dispatcher { get; }

        bool Equals(object obj);
        IList<GestureElement> GetChildElements(Point point);
        int GetHashCode();
        SizeRequest GetSizeRequest(double widthConstraint, double heightConstraint);
        string ToString();
    }
}