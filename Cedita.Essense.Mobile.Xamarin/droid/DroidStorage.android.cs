using System;
using System.IO;
using Cedita.Essense.Mobile.Xamarin.Droid.Injected;
using Cedita.Essense.Mobile.Xamarin.Interfaces;
using Xamarin.Forms;
using Microsoft.CSharp;

[assembly: Dependency(typeof(DroidStorage))]
namespace Cedita.Essense.Mobile.Xamarin.Droid.Injected
{
    public class DroidStorage : IFileservice
    {
        public string GetStorageFolderPath() => Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public T LoadFile<T>(string filename, bool isTextFile = true)
        {
            if (!File.Exists(filename))
            {
                return default(T);
            }

            dynamic file;

            if (isTextFile)
            {
                file = File.ReadAllText(filename);
                return file;
            }
            else
            {
                file = File.ReadAllBytes(filename);
                return file;
            }
        }

        public bool SaveFile<T>(string filename, T file, bool isTextFile = true)
        {
            var exists = File.Exists(filename);

            if (exists || file == null)
            {
                return false;
            }

            if (isTextFile)
            {
                File.WriteAllText(filename, file as string);
            }
            else
            {
                File.WriteAllBytes(filename, file as byte[]);
            }

            return true;
        }
    }
}
