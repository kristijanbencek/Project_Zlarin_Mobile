using System;
using UnityEngine;
using Unity.Notifications.Android;
using System.Collections.Generic;

namespace MyAmazingGame.Components
{
    public class NotificationManager : MonoBehaviour
    {
        static List<string> Handled_Ids = new List<string>();


        string _Channel_Id = "notify_daily_reminder";
        string _Icon_Small = "icon1"; //this is setup under Project Settings -> Mobile Notifications
        string _Icon_Large = "icon2"; //this is setup under Project Settings -> Mobile Notifications
        string _Channel_Title = "Daily Reminders";
        string _Channel_Description = "Get daily updates to see anything you missed.";


        void Start()
        {
            Debug.Log("NotificationManager: Start");


            //always remove any currently displayed notifications
            Unity.Notifications.Android.AndroidNotificationCenter.CancelAllDisplayedNotifications();



            //check if this was openened from a notification click
            var notification_intent_data = AndroidNotificationCenter.GetLastNotificationIntent();

            //this is just for debugging purposes
            if (notification_intent_data != null)
            {
                Debug.Log("notification_intent_data.Id: " + notification_intent_data.Id);
                Debug.Log("notification_intent_data.Channel: " + notification_intent_data.Channel);
                Debug.Log("notification_intent_data.Notification: " + notification_intent_data.Notification);
            }


            //if the notification intent is not null and we have not already seen this notification id, do something
            //using a static List to store already handled notification ids
            if (notification_intent_data != null && NotificationManager.Handled_Ids.Contains(notification_intent_data.Id.ToString()) == false)
            {
                NotificationManager.Handled_Ids.Add(notification_intent_data.Id.ToString());

                //this logic assumes only one type of notification is shown
                //show high scores when the user clicks the notification                
                UnityEngine.SceneManagement.SceneManager.LoadScene("HighScores");
                return;
            }
            else
            {
                Debug.Log("notification_intent_data is null or already handled");
            }



            //dont do anything further if the user has disabled notifications
            //this assumes you have additional ui to enabled/disable this preference
            var allow_notifications = PlayerPrefs.GetString("notifications");
            if (allow_notifications?.ToLower() == "false")
            {
                Debug.Log("Notifications Disabled");
                return;
            }


            this.Setup_Notifications();
        }


        internal void Setup_Notifications()
        {
            Debug.Log("NotificationsManager: Setup_Notifications");


            //initialize the channel
            this.Initialize();


            //schedule the next notification
            this.Schedule_Daily_Reminder();
        }


        void Initialize()
        {
            Debug.Log("NotificationManager: Initialize");

            //you could create platform specific logic, for now, we will just do Android
            //#if UNITY_ANDROID || UNITY_EDITOR            
            //            this.Initialize_Android();
            //#elif UNITY_IPHONE
            //#endif            


            //add our channel
            //a channel can be used by more than one notification
            //you do not have to check if the channel is already created, Android OS will take care of that logic
            var androidChannel = new AndroidNotificationChannel(this._Channel_Id, this._Channel_Title, this._Channel_Description, Importance.Default);
            AndroidNotificationCenter.RegisterNotificationChannel(androidChannel);
        }



        void Schedule_Daily_Reminder()
        {
            Debug.Log("NotificationManager: Schedule_Daily_Reminder");


            //since this is the only notification I have, I will cancel any currently pending notifications
            //if I create more types of notifications, additional logic will be needed
            AndroidNotificationCenter.CancelAllScheduledNotifications();


            //create new schedule
            string title = "We Miss You!";
            string body = "Come Back! Come Back! Come Back!";

            //show at the specified time - 10:30 AM
            //you could also always set this a certain amount of hours ahead, since this code resets the schedule, this could be used to prompt the user to play again if they haven't played in a while
            DateTime delivery_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 50, 0);
            if (delivery_time < DateTime.Now)
            {
                //if in the past (ex: this code runs at 11:00 AM), push delivery date forward 1 day
                //delivery_time = delivery_time.AddDays(1);
            }
            else if ((delivery_time - DateTime.Now).TotalHours <= 0)
            {
                //optional
                //if too close to current time (<= 4 hours away), push delivery date forward 1 day
                //delivery_time = delivery_time.AddDays(1);
            }
            Debug.Log("Delivery Time: " + delivery_time.ToString());


            //you currently do not need the notification id
            //if you had multiple notifications, you could store this and use it to cancel a specific notification
            var scheduled_notification_id = Unity.Notifications.Android.AndroidNotificationCenter.SendNotification(
                new Unity.Notifications.Android.AndroidNotification()
                {
                    Title = title,
                    Text = body,
                    FireTime = delivery_time,
                    SmallIcon = this._Icon_Small,
                    LargeIcon = this._Icon_Large
                },
                this._Channel_Id);
        }
    }
}
