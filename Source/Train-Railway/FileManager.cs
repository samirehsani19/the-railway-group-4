﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Train_Railway
{
    public interface IData
    {
        
    }

    class FilesPath
    {
        public string PassengersPath = "Data/passengers.txt";
        public string TimetablePath = "Data/timetable.txt";
        public string ControllerPath = "Data/controllerlog.txt";
        public string SationPath = "Data/stations.txt";
        public string TrainPath = "Data/trains.txt";
        public string TrainTrackPath = "Data/traintrack.txt";
    }

    public interface IFilesRead
    {
        IFilesSplit ReadingFile(string filePath);
    }

    public interface IFilesSplit
    {
        void SplitFile(string [] s);
    }

    class FileManager: IFilesRead, IFilesSplit
    {
        //private string[] data;

        public FileManager()
        {

        }

        public IFilesSplit ReadingFile(string filePath)
        {
            string[] data = File.ReadAllLines(filePath);
            SplitFile(data);

            return this;
        }

        public void SplitFile(string [] r)
        {
            char[] splitBy = { ',', ';' };

            for (int i = 0; i < r.Length; i++)
            {
                string[] splitedData = r[i].Split(splitBy);

                Timetable t = new Timetable();
                t.GetTrain(splitedData);

                //foreach (var item in splitedData)
                //{
                //    Console.WriteLine(item);
                //}

            }
        }
    }
}