﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;

namespace WpfApplication1
{
    public class PartitionListData
    {

        private ObservableCollection<PartitionInfo> _Partitions = new ObservableCollection<PartitionInfo>();
        public ObservableCollection<PartitionInfo> Partitions { get { return _Partitions; } }

        public PartitionListData()
        {
            String[] drives = Environment.GetLogicalDrives();
            foreach (String drive in drives)
            {
                DriveInfo dInfo = new DriveInfo(drive);
                if (dInfo.IsReady)
                {
                    PartitionInfo tmp = new PartitionInfo(drive, dInfo.TotalSize, dInfo.TotalSize - dInfo.AvailableFreeSpace, dInfo.AvailableFreeSpace);
                    _Partitions.Add(tmp);
                }
            }
        }

    }
}
