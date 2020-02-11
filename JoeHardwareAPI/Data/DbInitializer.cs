using System;
using System.Diagnostics;
using System.Linq;
using JoeHardwareAPI.Models;

namespace JoeHardwareAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(DeviceContext context)
        {
            context.Database.EnsureCreated();
            
            // Look for any Devices that inherit from IDevice devices
            if (context.ComputerDevices.Any())
                return;

            var computers = new ComputerDevice[]
            {
                new ComputerDevice{Name="Dell PowerEdge T140", Description = "Easy to use, safe, and practical entry-level " +
                                                                             "server for growing businesses. Ideal for file " +
                                                                             "and print, and point of sale applications."},
                new ComputerDevice{Name="Dell PowerEdge T30 Mini", Description = "deal for small office/home office " +
                                                                                 "collaboration, file storage and sharing, " +
                                                                                 "and data protection."}
            };
            foreach (ComputerDevice c in computers)
            {
                context.ComputerDevices.Add(c);
            }

            context.SaveChanges();
        } //Initialize method
    }  // class 
} // namespace