using System;
using BarcodeDriver.API;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BarcodeScanner.Core.BarcodeDriver
{
    public sealed class BarcodeDriverFactory
    {

#region Delegates

        public delegate void OnDriverLoadError(string libraryPath, Exception ex);

#endregion

#region Properties

        private string ApplicationPath
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }

        public List<IBarcodeDriver> Drivers { get; private set; }

#endregion

#region Class methods

        public void LoadDrivers(string[] librariesList, OnDriverLoadError onLoadError = null)
        {
            Drivers = new List<IBarcodeDriver>();

            foreach (string libraryPath in librariesList)
            {
                string fullLibraryPath = !Path.IsPathRooted(libraryPath)
                    ? Path.Combine(ApplicationPath, libraryPath)
                    : libraryPath;
                try
                {
                    Assembly assembly = Assembly.LoadFile(fullLibraryPath);
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.GetInterfaces().FirstOrDefault(i => i == typeof(IBarcodeDriver)) != null &&
                            !type.IsInterface && !type.IsAbstract)
                        {
                            IBarcodeDriver processor = (IBarcodeDriver) Activator.CreateInstance(type);
                            Drivers.Add(processor);
                        }
                    }
                }
                catch (Exception ex)
                {
                    onLoadError?.Invoke(libraryPath, ex);
                }
            }
        }

#endregion


    }
}
