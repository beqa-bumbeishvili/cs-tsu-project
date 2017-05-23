using ComputerScienceTsu.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerScienceTsu.Services
{
    public class LecturersService
    {
        public static Photo SetPhoto(string filePath)
        {
            Photo photo = new Photo();
            photo.Created_at = DateTime.Now;
            photo.Image_path = filePath;
            return photo;
        }


        public static Lecturer SetLecturer(string name, string lastname, string phone, string email, string about, string additional_info, int photo_id, string full_address)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.Name = name;
            lecturer.Lastname = lastname;
            lecturer.Phone = phone;
            lecturer.Email = email;
            lecturer.About = about;
            lecturer.Additional_info = additional_info;
            lecturer.Photo_id = photo_id;
            lecturer.Full_address = full_address;
            return lecturer;
        }
    }
}