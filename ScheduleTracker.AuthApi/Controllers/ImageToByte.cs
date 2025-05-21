using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTracker.WPF.Services
{
    public class ImageToByte
    {
        public static byte[] LoadDefaultProfileImage()
        {
            string path = Path.Combine("Assets", "defaultAvatar.jpg");


            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Default avatar image not found at: {path}");
            }

            return File.ReadAllBytes(path);
        }
    }

}
