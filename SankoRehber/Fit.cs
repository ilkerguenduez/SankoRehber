using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SankoRehber;

namespace SankoRehber
{
    internal class Fit
    {
        public static void FitColums(GridView view)
        {
            if (!view.OptionsCustomization.AllowColumnResizing)
            {
                view.OptionsCustomization.AllowColumnResizing = true;
                view.BestFitColumns();
                view.OptionsCustomization.AllowColumnResizing = false;
            }
            else
            {
                view.BestFitColumns();
            }
        }
    }
}
