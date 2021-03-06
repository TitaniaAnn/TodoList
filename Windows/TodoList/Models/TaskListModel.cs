﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    class TaskListModel {}

    class TaskList : INotifyPropertyChanged
    {
        private string id;
        private string title;
        private string color;
        private string type;
        private int count;

        public string Id
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        public string Color
        {
            get { return this.color; }
            set
            {
                if (this.color != value)
                {
                    this.color = value;
                    RaisePropertyChanged("Color");
                }
            }
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (this.type != value)
                {
                    this.type = value;
                    RaisePropertyChanged("Type");
                }
            }
        }

        public int Count
        {
            get { return this.count; }
            set
            {
                if (this.count != value)
                {
                    this.count = value;
                    RaisePropertyChanged("Count");
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
