using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.MDSService;

namespace MDSManager2012.Desktop
{
    public static class Extensions
    {
        static public Control[] FilterControls(this Control start, Func<Control, bool> isMatch)
        {
            var matches = new List<Control>();

            Action<Control> filter = null;
            (filter = new Action<Control>(c =>
            {
                if (isMatch(c))
                    matches.Add(c);
                foreach (Control c2 in c.Controls)
                    filter(c2);
            }))(start);

            return matches.ToArray();
        }

        static public Control FilterControlsOne(this Control start, Func<Control, bool> isMatch)
        {
            Control[] arrMatches = Extensions.FilterControls(start, isMatch);
            return arrMatches.Length == 0 ? null : arrMatches[0];
        }


      
    }
}
