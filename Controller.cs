﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public class Controller
    {
        private MainWindow mainWindow;
        private DiskSelectDialog diskSelectDialog;
        private Analizer analizer;
        private ResultChart chart;
        private DirectoryTreeViewItem actualNode;

        public Controller()
        {
            mainWindow = new MainWindow();
            diskSelectDialog = new DiskSelectDialog();
            analizer = new Analizer();
            chart = new PieChart(this);
        }
        public void startApp()
        {
            diskSelectDialog.ShowDialog();
            analizer.Analize(diskSelectDialog.SelectedDrive);
            mainWindow.addTreeViewRoot(analizer.Root);
            mainWindow.Show();
            actualNode = analizer.Root;
            chart.Root = actualNode;
            mainWindow.Chart = chart;
        }


        public void expandTreeNode(DirectoryTreeViewItem item)
        {
            item.IsExpanded = true;
            item.BringIntoView();
        }
    }
}
