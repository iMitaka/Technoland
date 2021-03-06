﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technoland.Models
{
    public class Smartphone
    {
        private ICollection<Vote> votes { get; set; }
        private ICollection<Comment> comments { get; set; }
        public Smartphone() 
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public string ImageURL { get; set; }
        public string connection2G { get; set; }
        public string connection3G { get; set; }
        public string connection4G { get; set; }
        public bool GPRS { get; set; }
        public bool EDGE { get; set; }
        public double HSDPA { get; set; }
        public double HSUPA { get; set; }
        public double Weight { get; set; }
        public string SIMType { get; set; }
        public string ScreenType { get; set; }
        public int ScreenColors { get; set; }
        public double ScreenSize { get; set; }
        public string Resolution { get; set; }
        public bool Multitouch { get; set; }
        public string ScreenProtection { get; set; }
        public int internalMemory { get; set; }
        public int externalMomory { get; set; }
        public int RAM { get; set; }
        public string RAMMemoryType { get; set; }
        public double CameraPixels { get; set; }
        public string CameraResolution { get; set; }
        public double SecondaryCameraPixels { get; set; }
        public int VideoFPS { get; set; }
        public int VideoResolutionP { get; set; }
        public string additionalCameraFunctions { get; set; }
        public string USB { get; set; }
        public bool StereoSound { get; set; }
        public string OS { get; set; }
        public string Chipset { get; set; }
        public double Frequency { get; set; }
        public int Cores { get; set; }
        public string GPU { get; set; }
        public string GPSInformation { get; set; }
        public string Senzors { get; set; }
        public string MessagesInfo { get; set; }
        public string DeffoultBrowser { get; set; }
        public string BattryType { get; set; }
        public int BatteryCappacity { get; set; }
        public int HoursOfTalk { get; set; }
        public int HoursListenOfMusic { get; set; }
        public string WLANInfo { get; set; }
        public string BluetoothInfo { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Vote> Votes 
        {
            get 
            {
                return this.votes;
            }
            set 
            {
                this.votes = value;
            }
        }
        public virtual ICollection<Comment> Comments 
        {
            get 
            {
                return this.comments;
            }
            set 
            {
                this.comments = value;
            }
        }
    }
}
