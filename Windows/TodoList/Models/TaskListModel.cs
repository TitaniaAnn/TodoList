﻿using System;
using System.Collections.Generic;
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
