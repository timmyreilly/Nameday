﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameday
{
    class MainPageData : INotifyPropertyChanged 
    {
        private string _greeting = "Hello World";

        public string Greeting
        {
            get { return _greeting; }
            set
            {
                if (value == _greeting)
                {
                    return; 
                }
                _greeting =  value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Greeting)));
            }
        }


        public List<NamedayModel> Namedays { get; set; }

        public MainPageData()
        {
            Namedays = new List<NamedayModel>();

            for (int month = 1; month <= 12; month++)
            {
                Namedays.Add(new NamedayModel(month, 1, new string[] { "Adam" }));
                Namedays.Add(new NamedayModel(month, 24, new string[] { "Eve", "Andrew" }));
            }
        }

        private NamedayModel _selectedNameday;

        public event PropertyChangedEventHandler PropertyChanged;

        public NamedayModel SelectedNameday
        {
            get { return _selectedNameday; }
            set
            {
                _selectedNameday = value;

                if (value == null)
                {
                    Greeting = "Hello World!";
                }
                else
                {
                    Greeting = "Hello " + value.NamesAsString; 
                }
            }
        }

    }
}
