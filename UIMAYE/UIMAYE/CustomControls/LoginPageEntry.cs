using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UIMAYE.CustomControls
{
    public class LoginPageEntry : Entry
    {
        public static readonly BindableProperty CornerRadiusProperty =
                BindableProperty.Create(nameof(CornerRadiusProperty), typeof(float), typeof(LoginPageEntry), 0f);

        public float CornerRadius
        {
            get
            {
                return (float)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

    }
}
