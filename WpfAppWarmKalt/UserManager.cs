
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWarmKalt
{
    public static class UserManager
    {
        public static List<User> Users { get; private set; } = new List<User>();
        public static User User { get => user; set => user = value; }
        public static string SpielMode { get => spielMode; set => spielMode = value; }
        public static bool IsRadioButtonsSelected { get => isRadioButtonsSelected; set => isRadioButtonsSelected = value; }
        public static string UserType { get => userType; set => userType = value; }
        public static int RandomNumber { get => randomNumber; set => randomNumber = value; }
        public static int AttemptNumber { get => attemptNumber; set => attemptNumber = value; }
        public static int EingegebeneNumber { get => eingegebeneNumber; set => eingegebeneNumber = value; }

        private static User user;
        private static string spielMode;
        private static bool isRadioButtonsSelected;
        private static string userType;
        private static int randomNumber;
        private static int attemptNumber;
        private static int eingegebeneNumber=0;

        public static void newGame()
        {
            
            IsRadioButtonsSelected= false;
            UserType = null;
            RandomNumber = 0 ;
            AttemptNumber = 0;
            EingegebeneNumber=0;

        }
        public static void newUserGame()
        {
            User = null;
            SpielMode = null;
            IsRadioButtonsSelected = false;
            UserType = null;
            RandomNumber = 0;
            AttemptNumber = 0;
            EingegebeneNumber = 0;

        }

        static UserManager()
        {
            LoadUsers();
        }

        public static void LoadUsers()
        {
            string filePath = "users.json";
            if (File.Exists(filePath))
            {
                Users = JSONHelper.ReadFromJsonFile<List<User>>(filePath);
            }
            else
            {
                InitializeDefaultUsers();
                SaveUsers();
            }
        }

        public static void SaveUsers()
        {
            string filePath = "users.json";
            JSONHelper.WriteToJsonFile(filePath, Users);
        }

        private static void InitializeDefaultUsers()
        {
            Users.Add(new User("Michael"));
            Users.Add(new User("Karl"));
            Users.Add(new User("Maria"));
            Users.Add(new User("Tom"));
            Users.Add(new User("Pat"));
        }
    }
}
