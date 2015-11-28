using Technoland.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Technoland.Data
{
    public class DatabaseInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Laptops.Count() > 0)
            {
                return;
            }

            Random rand = new Random();
            Manufacturer acerManufacturer = new Manufacturer { Name = "Acer" };
            ApplicationUser laptopUser = new ApplicationUser() { UserName = "TestUser2", Email = "TestMail2@test.com" };

            for (int i = 0; i < 10; i++)
            {
               
                Laptop laptop = new Laptop();
                laptop.BatteryInformation = "Li-On";
                laptop.ImageURL = "http://laptop.bg/system/images/76546/normal/acer_aspire_e5572g_NX_MV2EX_011.jpg";
                laptop.Camera = true;
                laptop.Color = "Black";
                laptop.ConnectionsInformation = "LAN 10/100/1000 Мбит/сек, Wi-Fi 802.11ac, Bluetooth 4.0";
                laptop.CPUFrequency = 1.70;
                laptop.CPUManufacturer = "Intel";
                laptop.CPUModel = "Intel Core i3-4005U";
                laptop.Interfaces = "1x USB 2.0, 1x USB 3.0, HDMI, вградена уеб камера, вграден микрофон, вградени стерео високоговорители, RJ-45, комбиниран аудио жак (слушалки/микрофон), SD картов четец";
                laptop.IPS = true;
                laptop.Manufacturer = acerManufacturer;
                laptop.Model = "Aspire V3-371";
                laptop.OS = "Windows 10";
                laptop.HDDSize = rand.Next(300, 1001);
                laptop.RAM = rand.Next(4, 9);
                laptop.RAMMemoryType = "DDR3";
                laptop.SSD = true;
                laptop.VideoCardManufacturer = "NVIDIA";
                laptop.VideoCardModel = "GeForce GTX 960M";
                laptop.VideoMemory = rand.Next(2, 5);
                laptop.Price = rand.Next(700, 3000);

                var votesCount = rand.Next(0, 10);
                for (int j = 0; j < votesCount; j++)
                {
                    laptop.Votes.Add(new Vote { Laptop = laptop, VotedBy = laptopUser });
                }

                var commentsCount = rand.Next(0, 10);
                for (int j = 0; j < commentsCount; j++)
                {
                    laptop.Comments.Add(new Comment { Content = "Mnou qk Laptop brat.", Author = laptopUser });
                }

                context.Laptops.Add(laptop);
            }
            context.SaveChanges();

            base.Seed(context);

            if (context.Smartphones.Count() > 0)
            {
                return;
            }

            Manufacturer sampleManufacturer = new Manufacturer { Name = "Samsung" };
            ApplicationUser user = new ApplicationUser() { UserName = "TestUser", Email = "TestMail@test.com" };
            context.Roles.Add(new IdentityRole { Name = "Admin" });
            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                Smartphone smartphone = new Smartphone();
                smartphone.ImageURL = "http://www.telenor.bg/sites/default/files/styles/device-full/public/Samsung-Galaxy-S6-Edge-Plus-Black-combo-web.png";
                smartphone.additionalCameraFunctions = "Автофокус, dual-LED светкавица, фокус с допир, разпознаване на лице/усмивка, HDR, панорама";
                smartphone.BatteryCappacity = 2750;
                smartphone.HoursListenOfMusic = 80;
                smartphone.BattryType = "Li-Po";
                smartphone.BluetoothInfo = "v4.2 с A2DP";
                smartphone.CameraPixels = 13;
                smartphone.CameraResolution = "4608 x 2592";
                smartphone.Chipset = "Exynos 7420";
                smartphone.connection2G = "GSM, 850 / 900 / 1800 / 1900";
                smartphone.connection3G = "HSDPA, 850 / 900 / 1700 / 1900 / 2100";
                smartphone.connection4G = "LTE";
                smartphone.Cores = 4;
                smartphone.DeffoultBrowser = "Chrome";
                smartphone.EDGE = true;
                smartphone.externalMomory = 32;
                smartphone.Frequency = 2.30;
                smartphone.GPRS = true;
                smartphone.GPSInformation = "GPS, с A-GPS, GLONASS";
                smartphone.GPU = "Adrena 420";
                smartphone.HoursOfTalk = 110;
                smartphone.HSDPA = 42.2;
                smartphone.HSUPA = 5.76;
                smartphone.internalMemory = rand.Next(16, 32);
                smartphone.Manufacturer = sampleManufacturer;
                smartphone.MessagesInfo = "iMessage, SMS (threaded view), MMS, Email, Push Email";
                smartphone.Model = "Galaxy iSpace";
                smartphone.Multitouch = true;
                smartphone.USB = "USB 2.0";
                smartphone.OS = "Android 7+";
                smartphone.Price = rand.Next(600, 3000);
                smartphone.RAM = rand.Next(1, 8);
                smartphone.RAMMemoryType = "GB";
                smartphone.Resolution = "1080 x 1920";
                smartphone.ScreenColors = 16;
                smartphone.ScreenProtection = "Ion-strengthened glass, oleophobic coating";
                smartphone.ScreenSize = 6;
                smartphone.ScreenType = "IPS LCD, capacitive touchscreen";
                smartphone.SecondaryCameraPixels = 5;
                smartphone.Senzors = "Акселерометър, proximity, компас, барометър, Сензор за разпознаване по пръстов отпечатък, вграден в Home бутона";
                smartphone.SIMType = "UltraSIM";
                smartphone.StereoSound = true;
                smartphone.VideoFPS = 30;
                smartphone.VideoResolutionP = 2160;
                smartphone.Weight = 0.200;
                smartphone.WLANInfo = "Wi-Fi, 802.11 a/b/g/n/ac, Wi-Fi hotspot";

                var votesCount = rand.Next(0, 10);
                for (int j = 0; j < votesCount; j++)
                {
                    smartphone.Votes.Add(new Vote { Smartphone = smartphone, VotedBy = user });
                }

                var commentsCount = rand.Next(0, 10);
                for (int j = 0; j < commentsCount; j++)
                {
                    smartphone.Comments.Add(new Comment { Content = "Mnou qk telefon brat.", Author = user });
                }

                context.Smartphones.Add(smartphone);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
