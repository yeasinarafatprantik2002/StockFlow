using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace StockFlow.Utilities
{
    internal static class DesignModeHelper
    {
        public static void ClearGridSelection(DataGridView grid)
        {
            grid.ClearSelection();
            grid.CurrentCell = null;
        }

        public static bool IsActive
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                {
                    return true;
                }

                string processName = Process.GetCurrentProcess().ProcessName;
                return processName.Contains("devenv", StringComparison.OrdinalIgnoreCase)
                    || processName.Contains("DesignToolsServer", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
