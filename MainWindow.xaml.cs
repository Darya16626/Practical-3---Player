using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
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
using System.Windows.Threading;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;

namespace Practical_3___Player
{
    public partial class MainWindow : Window
    {
        CommonOpenFileDialog COFD = new CommonOpenFileDialog { IsFolderPicker = true };
        public List<string> musicFiles = new List<string>();
        int i = 0;
        bool isPlaying = false;
        int currentTrackIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            Media.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
        }

        private void Spisok_Click(object sender, RoutedEventArgs e)
        {
            CommonFileDialogResult vibor = COFD.ShowDialog();
            if (vibor == CommonFileDialogResult.Ok)
            {
                LoadMusicFiles(COFD.FileName);
                if (musicFiles.Count != 0)
                {
                    PlayMusic(currentTrackIndex);
                }
                else
                {
                    MessageBox.Show("Музыкальные файлы в папке отсутствуют. Попробуйте выбрать другую папку.");
                }
            }
        }

        private void LoadMusicFiles(string folderPath)
        {
            musicFiles.Clear();
            if (Directory.Exists(folderPath))
            {
                foreach (string file in Directory.GetFiles(folderPath))
                {
                    string fileExtension = System.IO.Path.GetExtension(file).ToLower();
                    if (fileExtension == ".mp3" || fileExtension == ".wav" || fileExtension == ".m4a")
                    {
                        musicFiles.Add(file);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выбранная папка не существует.");
            }
        }

        private void PlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                Media.Pause();
                isPlaying = false;
            }
            else
            {
                Media.Play();
                isPlaying = true;
            }
        }

        private void PreviousTrack_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrackIndex > 0)
            {
                currentTrackIndex--;
            }
            else
            {
                currentTrackIndex = musicFiles.Count - 1;
            }
            PlayMusic(currentTrackIndex);
        }

        private void NextTrack_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrackIndex < musicFiles.Count - 1)
            {
                currentTrackIndex++;
            }
            else
            {
                currentTrackIndex = 0;
            }
            PlayMusic(currentTrackIndex);
        }
        private void RepeatCurrentTrack(object sender, RoutedEventArgs e)
        {
            Media.Position = TimeSpan.Zero;
            Media.Play();
        }
        private void SuffleMusicFiles()
        {
            //реализовать логику случайного трека
        }

        private void PlayMusic(int index)
        {
            Media.Source = new Uri(musicFiles[index]);
            Media.Play();
            i = index + 1;
            if (i == musicFiles.Count)
            {
                i = 0;
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (musicFiles.Count != 0)
            {
                PlayMusic(currentTrackIndex);
            }
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Media.Pause();
        }
    }
}