﻿using Little_System_Cleaner.Duplicate_Finder.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Little_System_Cleaner.Duplicate_Finder.Controls
{
    /// <summary>
    /// Interaction logic for FileInfo.xaml
    /// </summary>
    public partial class Details : UserControl
    {
        private readonly Wizard _scanBase;
        private readonly FileEntry _fileEntry;

        #region File information
        public string FileName
        {
            get { return this._fileEntry.FileName; }
        }

        public string Size
        {
            get { return Utils.ConvertSizeToString(this._fileEntry.FileSize); }
        }
        public string FilePath
        {
            get { return this._fileEntry.FilePath; }
        }
        #endregion

        //#region Audio information
        //public string Artist
        //{
        //    get
        //    {
        //        if (this._fileEntry.HasAudioTags)
        //            return this._fileEntry.Artist;
        //        else
        //            return "N/A";
        //    }
        //}
        //public string Title
        //{
        //    get
        //    {
        //        if (this._fileEntry.HasAudioTags)
        //            return this._fileEntry.Title;
        //        else
        //            return "N/A";
        //    }
        //}
        //public string Year
        //{
        //    get
        //    {
        //        if (this._fileEntry.HasAudioTags)
        //            return this._fileEntry.Year;
        //        else
        //            return "N/A";
        //    }
        //}
        //public string Genre
        //{
        //    get
        //    {
        //        if (this._fileEntry.HasAudioTags)
        //            return this._fileEntry.Genre;
        //        else
        //            return "N/A";
        //    }
        //}
        //public string Album
        //{
        //    get
        //    {
        //        if (this._fileEntry.HasAudioTags)
        //            return this._fileEntry.Album;
        //        else
        //            return "N/A";
        //    }
        //}
        //public string Duration
        //{
        //    get
        //    {
        //        if (this._fileEntry.HasAudioTags)
        //            return this._fileEntry.Duration;
        //        else
        //            return "N/A";
        //    }
        //}
        //public string TrackNo
        //{
        //    get
        //    {
        //        if (this._fileEntry.HasAudioTags)
        //            return this._fileEntry.TrackNo;
        //        else
        //            return "N/A";
        //    }
        //}
        //public string Bitrate
        //{
        //    get
        //    {
        //        if (this._fileEntry.HasAudioTags)
        //            return this._fileEntry.Bitrate;
        //        else
        //            return "N/A";
        //    }
        //}
        //#endregion

        public Details(Wizard scanBase, FileEntry fileEntry)
        {
            InitializeComponent();

            this._scanBase = scanBase;
            this._fileEntry = fileEntry;
        }

        private void buttonGoBack_Click(object sender, RoutedEventArgs e)
        {
            this._scanBase.HideFileInfo();
        }
    }
}