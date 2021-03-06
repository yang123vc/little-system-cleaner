﻿/*
    Little System Cleaner
    Copyright (C) 2008 Little Apps (http://www.little-apps.com/)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using Little_System_Cleaner.Misc;
using Little_System_Cleaner.Properties;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;

namespace Little_System_Cleaner.Tab_Controls
{
    /// <summary>
    ///     Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var memStatus = new PInvoke.MemoryStatusEx();
            RegistryKey regKey = null;

            LastDateTime.Text = Settings.Default.lastScanDate != 0
                ? DateTime.FromBinary(Settings.Default.lastScanDate).ToString(CultureInfo.InvariantCulture)
                : "Unknown";
            ErrorsFound.Text = $"{Settings.Default.lastScanErrors} errors found";
            ErrorsRepaired.Text = $"{Settings.Default.lastScanErrorsFixed} errors fixed";
            if (Settings.Default.lastScanElapsed != 0)
            {
                var ts = TimeSpan.FromTicks(Settings.Default.lastScanElapsed);
                ElapsedTime.Text = $"{Convert.ToInt32(ts.TotalSeconds)} seconds";
            }
            else
                ElapsedTime.Text = "Unknown";

            TotalScans.Text = $"{Settings.Default.totalScans} scans performed";
            TotalErrors.Text = $"{Settings.Default.totalErrorsFound} errors found";
            TotalErrorsFixed.Text = $"{Settings.Default.totalErrorsFixed} errors fixed";

            CpuType.Text = "Unknown";

            try
            {
                regKey = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");

                var procName = regKey?.GetValue("ProcessorNameString") as string;

                if (!string.IsNullOrEmpty(procName))
                    CpuType.Text = procName;
            }
            catch (Exception)
            {
                CpuType.Text = "Unknown";
            }
            finally
            {
                regKey?.Close();
            }

            try
            {
                if (!PInvoke.GlobalMemoryStatusEx(memStatus))
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

                TotalRam.Text = $"{Utils.ConvertSizeToString(Convert.ToInt64(memStatus.ullTotalPhys))} total memory";
            }
            catch
            {
                TotalRam.Text = "Unknown";
            }

            OsVersion.Text = Misc.OsVersion.GetOsVersion();
        }
    }
}