using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.WindowsAPICodePack.Dialogs;
using OpenCvSharp;

namespace WatermarkManager.ViewModel
{
    public class WatermarkManagerViewModel : ViewModelBase
    {
        #region UI Variable
        private string _watermarkWhitePath = "";
        public string WatermarkWhitePath
        {
            get { return _watermarkWhitePath; }
            set { _watermarkWhitePath = value; RaisePropertyChanged("WatermarkWhitePath"); }
        }

        private string _watermarkBlackPath = "";
        public string WatermarkBlackPath
        {
            get { return _watermarkBlackPath; }
            set { _watermarkBlackPath = value; RaisePropertyChanged("WatermarkBlackPath"); }
        }

        private string _fileDirPath = "";
        public string FileDirePath
        {
            get { return _fileDirPath; }
            set { _fileDirPath = value; RaisePropertyChanged("FileDirePath"); }
        }
        #endregion

        #region Command
        public RelayCommand<object> ButtonClickCommand { get; private set; }

        private void InitRelayCommand()
        {
            ButtonClickCommand = new RelayCommand<object>(OnButtonClick);
        }

        private void OnButtonClick(object param)
        {
            switch (param.ToString())
            {
                case "LoadWatermarkWhite":
                    OpenDialog("LoadWatermarkWhite");
                    break;
                case "LoadWatermarkBlack":
                    OpenDialog("LoadWatermarkBlack");
                    break;
                case "Load":
                    OpenDialog("Load");
                    break;
                case "Run":
                    RunProcess();
                    break;
            }
        }

        private void OpenDialog(string param)
        {
            using(CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.InitialDirectory = _InitPath;
                dialog.IsFolderPicker = true;
                
                if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    _InitPath = Path.GetDirectoryName(dialog.FileName);

                    if (param == "LoadWatermarkWhite")
                        WatermarkWhitePath = dialog.FileName;

                    if (param == "LoadWatermarkBlack")
                        WatermarkBlackPath = dialog.FileName;

                    if (param == "Load")
                        FileDirePath = dialog.FileName;
                }
            }  
        }
        #endregion

        #region Field
        private string _InitPath = @"C:\Users\Desktop";
        private List<string> _SupportExtensionList = new List<string>() { ".jpg", ".jpeg", ".png", ".bmp" };
        #endregion

        public WatermarkManagerViewModel()
        {
            InitRelayCommand();
        }

        private void RunProcess()
        {
            var imageFilePaths = Directory.GetFiles(FileDirePath, "*.*", SearchOption.TopDirectoryOnly).Where(s => _SupportExtensionList.Any(e => s.ToLower().EndsWith(e)));


            Mat watermarkWhiteImg = Cv2.ImRead(WatermarkWhitePath, ImreadModes.Unchanged);
            Mat watermarkBlackImg = Cv2.ImRead(WatermarkBlackPath, ImreadModes.Unchanged);

            int watermarkRatio = 10;

            foreach(var imageFilePath in imageFilePaths)
            {
                // 이미지 처리
                // 이미지 정보
                // 히스토그램
            }
        }

        

    }
}
