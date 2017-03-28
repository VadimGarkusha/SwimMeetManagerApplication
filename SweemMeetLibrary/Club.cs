﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Name: Eskender Memetov 
* Student Number: 300805013 */

namespace SwimMeetLibrary
{
    public class Club
    {
        private static int clubNumber;
        public int ClubID { set; get; }              
        public long ClubPhoneNumber { get; set; }
        public string ClubName { get; set; }
        public int NumberOfCoaches { get; set; }
        public Adress Address { get; set; }
        public Registrant[] Swimmers { get; set; }
        public Coach[] Coaches { get; set; }
        public int NumberOfSwimmers { get; set; }

        

        
     
        #region Constructor | Setting Default values
        public Club(string clubName, Adress PhysicalLocation, long clubPhoneNumber)
        {
            ClubName = clubName;
            ClubPhoneNumber = clubPhoneNumber;
            ClubID = clubNumber++;
            Swimmers = new Registrant[20];
            Address = PhysicalLocation;
            Coaches = new Coach[20];
        }
        public Club()
        {
            Swimmers = new Registrant[20];
            Coaches = new Coach[20];
            ClubID = clubNumber++;
        }
        static Club()
        {
            clubNumber = 1;
        }
        #endregion



        #region ToString Method
        public override string ToString()
        {
            string info;

          

            info = string.Format("\nName: {1} \nAdress: {2} \n#hone number: {3} \nReg number: {0}", ClubID, ClubName, Address.ToString(), PhoneNumber(ClubPhoneNumber));

            info += string.Format("\nSwimmers:");
     
            
            for (int i = 0; i < NumberOfSwimmers; i++)
            {
                info += string.Format("\n\t  {0}", Swimmers[i].RegistrantName);
            }
            info += string.Format("\nCoaches: ");
            for (int i = 0; i < NumberOfCoaches; i++)
            {
                info += string.Format("\n\t  {0}", Coaches[i].RegistrantName);
            }
          

            return info;
        }
        #endregion

        #region PhoneNumber Method | Convering String 
        public static string PhoneNumber(long rawValue)
        {
            string value = rawValue.ToString();
            if (value == "None")
            {
                value = "None";
            }
            else
            {
                value = new System.Text.RegularExpressions.Regex(@"\D")
                    .Replace(value, string.Empty);
                value = value.TrimStart('1');
                if (value.Length == 10)
                    return Convert.ToInt64(value).ToString("+1(###)-###-####");
                if (value.Length > 10)
                    return Convert.ToInt64(value)
                        .ToString("+1(###)-###-#### " + new String('#', (value.Length - 10)));
            }
            return value;
        }
        #endregion

        #region AddSwimmer Method 
        public void AddSwimmer(Registrant swimmer)
        {
            if (NumberOfSwimmers == 0 || Swimmers[NumberOfSwimmers - 1] != swimmer)
            {
                if (swimmer.NClub == null || swimmer.NClub == this)
                {
                    Swimmers[NumberOfSwimmers] = swimmer;
                    NumberOfSwimmers++;                  
                        swimmer.NClub = this;                   
                }
                else
                {
                    //Console.WriteLine("Swimmer already assigned to {0} club", swimmer.NClub.ClubName);
                   throw new Exception(string.Format("Swimmer already assigned to {0} club", swimmer.NClub.ClubName));
                }

            }
        }
        #endregion
        public void AddCoach(Coach coach)
        {
            Coaches[NumberOfCoaches++] = coach;
                  coach.NClub = this;                
        }
    }
}
